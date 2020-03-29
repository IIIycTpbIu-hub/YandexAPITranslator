using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey;

namespace YandexAPITranslator.Tests.APIKey
{
    [TestClass]
    public class APIKeyControllerTests
    {
        [TestMethod]
        public void CheckAPIKeyFileExists()
        {
            APIKeyController controller = new APIKeyController();
            bool result = controller.APIKeyFileExists();
            Assert.AreEqual(true, result);
        }
    }
}
