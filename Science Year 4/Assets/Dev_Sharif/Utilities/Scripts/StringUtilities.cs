using System.Text;

public static class StringUtilites
{
    public static string ToSentence(this string[] stringArray, string separator = " ")
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < stringArray.Length; i++) {
            builder.Append(stringArray[i]);
            if (i < stringArray.Length - 1) {
                builder.Append(separator);
            }
        }
        return builder.ToString();
    }
}
