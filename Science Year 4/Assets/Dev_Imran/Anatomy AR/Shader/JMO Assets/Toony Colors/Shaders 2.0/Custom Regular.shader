// Toony Colors Free
// (c) 2012,2016 Jean Moreno


// Want more features ? Check out Toony Colors Pro+Mobile 2 !
// http://www.jeanmoreno.com/toonycolorspro/


Shader "Toony Colors Free/Custom Regular"
{
	Properties
	{
		//TOONY COLORS
		_Color ("Color", Color) = (0.5,0.5,0.5,1.0)
		_HColor ("Highlight Color", Color) = (0.6,0.6,0.6,1.0)
		_SColor ("Shadow Color", Color) = (0.3,0.3,0.3,1.0)
		_CutTex("Cutout (A)", 2D) = "white" {}

		_Cutoff("Cut off", Range(0, 1)) = 0.25

		_EdgeWidth("Edge Width", Range(0, 1)) = 0.05

		_NoiseTex("Noise", 2D) = "white" {}

		[HDR] _EdgeColor("Edge Color", Color) = (1,1,1,1)
		
		//DIFFUSE
		_MainTex ("Main Texture (RGB)", 2D) = "white" {}
		
		//TOONY COLORS RAMP
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		
	}
	
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		/*Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha*/
		
		CGPROGRAM
		
		#pragma surface surf ToonyColorsCustom fullforwardshadow
		//#pragma fragment frag
		//#pragma target 2.0
		//#pragma glsl
		
		
		//================================================================
		// VARIABLES
		
		fixed4 _Color;
		sampler2D _MainTex;
		sampler2D _CutTex;

		half _EdgeWidth;
		half _Cutoff;
		sampler2D _NoiseTex;
		fixed4 _EdgeColor;

		fixed4 noisePixel, pixel;
		
		struct Input
		{
			float2 uv_NoiseTex;
			float2 uv_MainTex;
		};
		
		//================================================================
		// CUSTOM LIGHTING
		
		//Lighting-related variables
		fixed4 _HColor;
		fixed4 _SColor;
		sampler2D _Ramp;
		
		//Custom SurfaceOutput
		struct SurfaceOutputCustom
		{
			fixed3 Albedo;
			fixed3 Normal;
			fixed3 Emission;
			half Specular;
			fixed Alpha;
		};

		inline half4 LightingToonyColorsCustom (SurfaceOutputCustom s, half3 lightDir, half3 viewDir, half atten)
		{
			s.Normal = normalize(s.Normal);
			fixed ndl = max(0, dot(s.Normal, lightDir)*0.5 + 0.5);
			
			fixed3 ramp = tex2D(_Ramp, fixed2(ndl,ndl));
		//#if !(POINT) && !(SPOT)
			ramp *= atten;
		//#endif
			_SColor = lerp(_HColor, _SColor, _SColor.a);	//Shadows intensity through alpha
			ramp = lerp(_SColor.rgb,_HColor.rgb,ramp);
			fixed4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * ramp;
			c.a = s.Alpha;
		//#if (POINT || SPOT)
			//c.rgb *= atten;
		//#endif

			return c;
		}
		
		
		//================================================================
		// SURFACE FUNCTION
		

		void surf (Input IN, inout SurfaceOutputCustom o)
		{
			fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
			
			o.Albedo = mainTex.rgb * _Color.rgb;
			o.Alpha = mainTex.a * _Color.a;

			noisePixel = tex2D(_NoiseTex, IN.uv_NoiseTex);

			clip(noisePixel.r >= _Cutoff ? 1 : -1);
			o.Emission = noisePixel.r >= (_Cutoff * (_EdgeWidth + 1.0)) ? 0 : _EdgeColor;
		}
		
		ENDCG
	}
	
	Fallback "Diffuse"
	CustomEditor "TCF_MaterialInspector"
}
