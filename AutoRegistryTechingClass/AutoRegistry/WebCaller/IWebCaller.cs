namespace AutoRegistryTechingClass.AutoRegistry.WebCaller
{
    public interface IWebCaller
    {
        void AddHtmlHandler(IHtmlContentHandler htmlHandler);

        string GetStringContent(string url);
    }
}
