using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexAPITranslator.APIKey;
using System;

namespace YandexAPITranslator.Tests.APIKey
{
    [TestClass]
    public class KeysFileModelTests
    {
        [TestMethod]
        public void CheckCreatingKeyConfigFileIfNotExists()
        {
            string path = Environment.CurrentDirectory;
            APIKeysFileExistingModel existingModel = new APIKeysFileExistingModel(path);
            
            if(!existingModel.IsConfilgExists)
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
            APIKeysFileExistingModel existingModel = new APIKeysFileExistingModel(path);
            if(existingModel.IsConfilgExists)
            {
                Assert.AreEqual(path + "\\APIKeys.xml", existingModel.ConfigFilePath);
            }
        }
    }
}
