using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRegistryTechingClass.AutoRegistry.WebCaller
{
    public class EncodingUtf8HtmlContentHandler : IHtmlContentHandler
    {
        public string Process(string htmlContent)
        {
            byte[] bytes = Encoding.Default.GetBytes(htmlContent);
            htmlContent = Encoding.UTF8.GetString(bytes);
            return htmlContent;
        }
    }
}
