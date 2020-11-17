// referenced from: https://htmlcolorcodes.com/color-names/
using UnityEngine;

public static class HTMLColor
{
    private static Color32 c = new Color32();
    // reds
    public static Color indianRed => c.Set(205, 92, 92);
    public static Color lightCoral => c.Set(240, 128, 128);
    public static Color salmon => c.Set(250, 128, 114);
    public static Color darkSalmon => c.Set(233, 150, 122);
    public static Color lightSalmon => c.Set(255, 160, 122);
    public static Color crimson => c.Set(220, 20, 60);
    public static Color red => c.Set(255, 0, 0);
    public static Color fireBrick => c.Set(178, 34, 34);
    public static Color darkRed => c.Set(139, 0, 0);
    // pinks
    public static Color pink => c.Set(255, 192, 203);
    public static Color lightPink => c.Set(255, 182, 193);
    public static Color hotPink => c.Set(255, 105, 180);
    public static Color mediumVioletRed => c.Set(199, 21, 133);
    public static Color paleVioletRed => c.Set(219, 112, 147);
    // oranges
    public static Color coral => c.Set(255, 160, 122);
    public static Color tomato => c.Set(255, 99, 71);
    public static Color orangeRed => c.Set(255, 69, 0);
    public static Color darkOrange => c.Set(255, 140, 0);
    public static Color orange => c.Set(255, 165, 0);
    // yellows
    public static Color gold => c.Set(255, 215, 0);
    public static Color yellow => c.Set(255, 255, 0);
    public static Color lightYellow => c.Set(255, 255, 224);
    public static Color lemonChiffon => c.Set(255, 250, 205);
    public static Color lightGoldenrodYellow => c.Set(250, 250, 210);
    public static Color papayaWhip => c.Set(255, 239, 213);
    public static Color mocassin => c.Set(255, 228, 181);
    public static Color peachPuff => c.Set(255, 218, 185);
    public static Color paleGoldenrod => c.Set(238, 232, 170);
    public static Color khaki => c.Set(240, 230, 140);
    public static Color darkKhaki => c.Set(189, 183, 107);
    // purples
    public static Color lavender => c.Set(230, 230, 250);
    public static Color thistle => c.Set(216, 191, 216);
    public static Color plum => c.Set(221, 160, 221);
    public static Color violet => c.Set(238, 130, 238);
    public static Color orchid => c.Set(218, 112, 214);
    public static Color fuchsia => c.Set(255, 0, 255);
    public static Color magenta => c.Set(255, 0, 255);
    public static Color mediumOrchid => c.Set(186, 85, 211);
    public static Color mediumPurple => c.Set(147, 112, 219);
    public static Color rebeccaPurple => c.Set(102, 51, 153);
    public static Color blueViolet => c.Set(138, 43, 226);
    public static Color darkViolet => c.Set(148, 0, 211);
    public static Color darkOrchid => c.Set(153, 50, 204);
    public static Color darkMagenta => c.Set(139, 0, 139);
    public static Color purple => c.Set(128, 0, 128);
    public static Color indigo => c.Set(75, 0, 130);
    public static Color slateBlue => c.Set(106, 90, 205);
    public static Color darkSlateBlue => c.Set(72, 61, 139);
    public static Color mediumSlateBlue => c.Set(123, 104, 238);
    // greens
    public static Color greenYellow => c.Set(173, 25, 47);
    public static Color chartreuse => c.Set(127, 255, 0);
    public static Color lawnGreen => c.Set(124, 252, 0);
    public static Color lime => c.Set(0, 255, 0);
    public static Color limeGreen => c.Set(50, 205, 50);
    public static Color paleGreen => c.Set(152, 251, 152);
    public static Color lightGreen => c.Set(144, 238, 144);
    public static Color mediumSpringGreen => c.Set(0, 250, 154);
    public static Color springGreen => c.Set(0, 255, 127);
    public static Color mediumSeaGreen => c.Set(60, 179, 113);
    public static Color seaGreen => c.Set(46, 139, 34);
    public static Color forestGreen => c.Set(34, 139, 34);
    public static Color green => c.Set(0, 128, 0);
    public static Color darkGreen => c.Set(0, 100, 0);
    public static Color yellowGreen => c.Set(154, 205, 50);
    public static Color oliveDrab => c.Set(107, 142, 35);
    public static Color olive => c.Set(128, 128, 0);
    public static Color darkOliveGreen => c.Set(85, 107, 47);
    public static Color mediumAquamarine => c.Set(102, 205, 170);
    public static Color darkSeaGreen => c.Set(143, 188, 139);
    public static Color lightSeaGreen => c.Set(32, 178, 170);
    public static Color darkCyan => c.Set(0, 139, 139);
    public static Color teal => c.Set(0, 128, 128);
    // blues
    public static Color aqua => c.Set(0, 255, 255);
    public static Color cyan => c.Set(0, 255, 255);
    public static Color lightCyan => c.Set(224, 255, 255);
    public static Color paleTurquoise => c.Set(175, 238, 238);
    public static Color aquamarine => c.Set(127, 255, 212);
    public static Color turquoise => c.Set(64, 224, 208);
    public static Color mediumTurquoise => c.Set(72, 209, 204);
    public static Color darkTurquoise => c.Set(0, 206, 209);
    public static Color cadetBlue => c.Set(95, 158, 160);
    public static Color steelBlue => c.Set(70, 130, 180);
    public static Color lightSteelBlue => c.Set(176, 196, 222);
    public static Color powderBlue => c.Set(176, 224, 230);
    public static Color lightBlue => c.Set(173, 216, 230);
    public static Color skyBlue => c.Set(135, 206, 235);
    public static Color lightSkyBlue => c.Set(135, 206, 250);
    public static Color deepSkyBlue => c.Set(0, 191, 255);
    public static Color dodgerBlue => c.Set(30, 144, 255);
    public static Color cornFlowerBlue => c.Set(100, 149, 237);
    public static Color royalBlue => c.Set(65, 105, 225);
    public static Color blue => c.Set(0, 0, 255);
    public static Color mediumBlue => c.Set(0, 0, 205);
    public static Color darkBlue => c.Set(0, 0, 139);
    public static Color navy => c.Set(0, 0, 128);
    public static Color midnightBlue => c.Set(25, 25, 112);
    // browns
    public static Color cornSilk => c.Set(255, 248, 220);
    public static Color blanchedAlmond => c.Set(255, 235, 205);
    public static Color bisque => c.Set(255, 228, 198);
    public static Color navajoWhite => c.Set(255, 222, 173);
    public static Color wheat => c.Set(245, 222, 179);
    public static Color burlyWood => c.Set(222, 184, 135);
    public static Color tan => c.Set(210, 180, 140);
    public static Color rosyBrown => c.Set(188, 143, 143);
    public static Color sandyBrown => c.Set(244, 164, 96);
    public static Color goldenrod => c.Set(218, 165, 32);
    public static Color darkGoldenrod => c.Set(184, 134, 11);
    public static Color peru => c.Set(205, 133, 63);
    public static Color chocolate => c.Set(210, 105, 30);
    public static Color saddleBrown => c.Set(139, 69, 19);
    public static Color sienna => c.Set(160, 82, 45);
    public static Color brown => c.Set(165, 42, 42);
    public static Color maroon => c.Set(128, 0, 0);
    // whites
    public static Color white => c.Set(255, 255, 255);
    public static Color snow => c.Set(255, 250, 250);
    public static Color honeydew => c.Set(240, 255, 240);
    public static Color mintCream => c.Set(245, 255, 250);
    public static Color azure => c.Set(240, 255, 255);
    public static Color aliceBlue => c.Set(240, 248, 255);
    public static Color ghostWhite => c.Set(248, 248, 255);
    public static Color whiteSmoke => c.Set(245, 245, 245);
    public static Color seaShell => c.Set(255, 245, 238);
    public static Color beige => c.Set(245, 245, 220);
    public static Color oldLace => c.Set(253, 245, 230);
    public static Color floralWhite => c.Set(255, 250, 240);
    public static Color ivory => c.Set(255, 255, 240);
    public static Color antiqueWhite => c.Set(250, 235, 215);
    public static Color linen => c.Set(250, 240, 230);
    public static Color lavenderBlush => c.Set(255, 240, 245);
    public static Color mistyRose => c.Set(255, 228, 225);
    // grays
    public static Color gainsboro => c.Set(220, 220, 220);
    public static Color lightGray => c.Set(211, 211, 211);
    public static Color silver => c.Set(192, 192, 192);
    public static Color darkGray => c.Set(169, 169, 169);
    public static Color gray => c.Set(128, 128, 128);
    public static Color dimGray => c.Set(105, 105, 105);
    public static Color lightSlateGray => c.Set(119, 136, 153);
    public static Color slateGray => c.Set(112, 128, 144);
    public static Color darkSlateGray => c.Set(47, 79, 79);
    public static Color black => c.Set(0, 0, 0);

    public static Color32 Set(this Color32 c, byte r, byte g, byte b, byte a = 255)
    {
        c.r = r;
        c.g = g;
        c.b = b;
        c.a = a;
        return c;
    }

    public static string ToHTML(this Color c, bool useRGBA = true)
    {
        if (useRGBA) 
            return ColorUtility.ToHtmlStringRGBA(c);
        return ColorUtility.ToHtmlStringRGB(c);
    }

    public static string ToHTML(this Color32 c, bool useRGBA = true) {
        return ((Color)c).ToHTML();
    }
}
