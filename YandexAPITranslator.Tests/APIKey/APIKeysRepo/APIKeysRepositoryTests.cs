using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey;
using YandexAPITranslator.APIKey.APIKeysRepo;

namespace YandexAPITranslator.Tests.APIKey.APIKeysRepo
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
        public void Add_Find_Remove_APIKeyTest()
        {
            APIKeyEntity key = new APIKeyEntity("1234");
            _apiKeyModel.AddAPIKey(key);

            var writtenKey = _apiKeyModel.FindAPIKey(key.KeyValue);
            Assert.IsNotNull(writtenKey);

            _apiKeyModel.RemoveAPIKey(key);

            var keysCount = _apiKeyModel.ReadAPIKeys().Count;
            Assert.AreEqual(0, keysCount);
        }

        [TestMethod]
        public void FindCurrentKeyTest()
        {
            APIKeyEntity key = new APIKeyEntity("1234", true);
            _apiKeyModel.AddAPIKey(key, true);

            var writtenKey = _apiKeyModel.FindCurrentAPIKey();

            Assert.AreEqual(key.IsCurrent, writtenKey.IsCurrent);
            Assert.AreEqual(key.KeyValue, writtenKey.KeyValue);
        }
    }
}
