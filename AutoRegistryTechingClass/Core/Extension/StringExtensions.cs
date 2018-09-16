namespace AutoRegistryTechingClass.Core.Extension
{
    public static class StringExtensions
    {
        public static string ToHtmlEncode(this string htmlContent)
        {
            return System.Net.WebUtility.HtmlEncode(htmlContent);
        }

        public static string ToHtmlDecode(this string htmlContent)
        {
            return System.Net.WebUtility.HtmlDecode(htmlContent);
        }
    }
}
