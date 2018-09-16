using AutoRegistryTechingClass.AutoRegistry.WebCaller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRegistryTechingClass.Tests
{
    [TestClass]
    public class WebCallerTest
    {
        private IWebCaller _webCaller;

        [TestInitialize]
        public void Initialize()
        {
            _webCaller = new WebClientCaller();
        }

        [TestMethod]
        public void Get_WebHtmlContent_Success()
        {
            var htmlContent = _webCaller.GetStringContent("http://giasuminhtam.com/lop-moi/lop-day-kem-cap-3-thpt/");
            Assert.IsFalse(String.IsNullOrEmpty(htmlContent));
        }
    }
}
