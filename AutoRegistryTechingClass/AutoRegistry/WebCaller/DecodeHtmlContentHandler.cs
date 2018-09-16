using AutoRegistryTechingClass.Core.Extension;
using System;

namespace AutoRegistryTechingClass.AutoRegistry.WebCaller
{
    public class DecodeHtmlContentHandler : IHtmlContentHandler
    {
        public string Process(string htmlContent)
        {
            return htmlContent.ToHtmlDecode();
        }
    }
}