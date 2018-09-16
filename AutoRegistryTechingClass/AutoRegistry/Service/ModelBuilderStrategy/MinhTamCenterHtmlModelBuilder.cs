using AutoRegistryTechingClass.AutoRegistry.Model;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace AutoRegistryTechingClass.AutoRegistry.Service
{
    public class MinhTamCenterHtmlModelBuilder : IWebContentModelBuilderStrategy
    {
        public List<ClassInformationModel> BuildModel(string htmlContent)
        {
            var classInformations = new List<ClassInformationModel>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);

            var tableNewClass = htmlDocument.DocumentNode.SelectNodes("//table[@class='tbl_lopmoi']//tr[@class = 'le' or @class = 'chan']");
            foreach (HtmlNode trElement in tableNewClass)
            {
                var classId = trElement.SelectSingleNode(".//b[text()='Mã lớp:']/../span").InnerText;
                var currentClass = new ClassInformationModel() { ClassId = classId, ContentHtml = trElement.InnerText };
                classInformations.Add(currentClass);
            }

            return classInformations;
        }
    }
}
