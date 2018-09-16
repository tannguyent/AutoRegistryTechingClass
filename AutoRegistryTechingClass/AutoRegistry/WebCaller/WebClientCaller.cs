using System.Collections.Generic;
using System.Net;

namespace AutoRegistryTechingClass.AutoRegistry.WebCaller
{
    public class WebClientCaller : IWebCaller
    {
        public List<IHtmlContentHandler> htmlContentHandlers { get; set; }

        public WebClientCaller()
        {
            htmlContentHandlers = new List<IHtmlContentHandler>();
        }

        public void AddHtmlHandler(IHtmlContentHandler htmlHandler)
        {
            if (htmlHandler != null)
            {
                htmlContentHandlers.Add(htmlHandler);
            }
        }

        public string GetStringContent(string url)
        {
            using (WebClient client = new WebClient())
            { 
                string htmlContent = client.DownloadString(url);
                foreach (var htmlContentHandler in htmlContentHandlers)
                {
                    htmlContent = htmlContentHandler.Process(htmlContent);
                }
                return htmlContent;
            }
        }
    }
}
