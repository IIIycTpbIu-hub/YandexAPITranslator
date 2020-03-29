using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey;

namespace YandexAPITranslator.APIKey.Tests
{
    [TestClass]
    public class APIKeyModelTests
    {
        private APIKeyModel _apiKeyModel;

        [TestMethod]
        public void APIKeyModelInitialized()
        {
            _apiKeyModel = new APIKeyModel();
        }
    }
}
