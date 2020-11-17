﻿Shader "Unlit/Dissolve/Transparent"
{
    Properties
    {
        _MainTex ("Albedo Texture", 2D) = "white" {}
        _TintColor("Tint Color", Color) = (1, 1, 1, 1)
        _Transparency("Transparency", Range(0.0, 0.5)) = 0.25
        _CutoutThresh("Cutout Threshold", Range(0.0, 1.0)) = 0.2

        _DissolveTexture("Dissolve Texture", 2D) = "white" {}
        _DissolveY("Current Y of the Dissolve Effect", Float) = 0
        _DissolveSize("Size of the Effect", Float) = 2
        _StartingY("Starting point of the Effect", Float) = -10

    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _Transparency;
            float _CutoutThresh;

            sampler2D _DissolveTexture;
            float _DissolveY;
            float _DissolveSize;
            float _StartingY;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float transition = _DissolveY - i.worldPos.y;
                clip(_StartingY + (transition + (tex2D(_DissolveTexture, i.uv)) * _DissolveSize));

                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;
                col.a = _Transparency;
                clip(col.r - _CutoutThresh);
                return col;
            }
            ENDCG
        }
    }
}
