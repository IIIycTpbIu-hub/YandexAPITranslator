using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey.APIKeysRepo;
using System;

namespace YandexAPITranslator.Tests.APIKey.APIKeysRepo
{
    [TestClass]
    public class APIKeysFileExistingCheckerTests
    {
        [TestMethod]
        public void CheckCreatingKeyConfigFileIfNotExists()
        {
            string path = Environment.CurrentDirectory;
            APIKeysFileExistingChecker existingModel = new APIKeysFileExistingChecker(path);
            
            if(!existingModel.IsAPIKeysFileExists)
            {
                bool result = existingModel.CreateKeysConfingFile();
                Assert.AreEqual(path + "\\APIKeys.xml", existingModel.ConfigFilePath);
                File.Delete(path + "\\APIKeys.xml");
            }
        }

        [TestMethod]
        public void CheckCreatingKeyConfigFileIfExists()
        {
            string path = Environment.CurrentDirectory;
            APIKeysFileExistingChecker existingModel = new APIKeysFileExistingChecker(path);
            if(existingModel.IsAPIKeysFileExists)
            {
                Assert.AreEqual(path + "\\APIKeys.xml", existingModel.ConfigFilePath);
            }
        }
    }
}
