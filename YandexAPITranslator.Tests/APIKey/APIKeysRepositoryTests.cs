using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey;

namespace YandexAPITranslator.APIKey.Tests
{
    [TestClass]
    public class APIKeysRepositoryTests
    {
        private APIKeysRepository _apiKeyModel;
        APIKeysFileExistingChecker _checker;

        [TestInitialize]
        public void APIKeyModelInitialized()
        {
            _checker = new APIKeysFileExistingChecker(Environment.CurrentDirectory);
            if(!_checker.IsAPIKeysFileExists)
            {
                _checker.CreateKeysConfingFile();
            }
            _apiKeyModel = new APIKeysRepository(_checker.ConfigFilePath);
        }
        [TestCleanup]
        public void RemoveRepo()
        {
            File.Delete(_checker.ConfigFilePath);
        }

        [TestMethod]
        public void ReadAPIKeysTest()
        {
            var keysCollection = _apiKeyModel.ReadAPIKeys();
            Assert.IsNotNull(keysCollection);
        }

        [TestMethod]
        public void WriteAPIKeyTest()
        {
            var keysCollection = _apiKeyModel.ReadAPIKeys();
            if(keysCollection.Count == 0)
            {
                APIKey key = new APIKey("1234");
                _apiKeyModel.AddAPIKey(key);
                keysCollection = _apiKeyModel.ReadAPIKeys();
                Assert.AreEqual(key.KeyValue, keysCollection[0].KeyValue);
            }
        }
    }
}
