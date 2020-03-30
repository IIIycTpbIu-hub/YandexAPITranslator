using System.IO;
using System.Xml.Linq;

namespace YandexAPITranslator.APIKey
{
    public class APIKeysFileExistingChecker
    {
        private string _fileName;

        public bool IsAPIKeysFileExists { get; private set; }
        public string ConfigFilePath {
            get
            {
                return _fileName;
            }
            private set 
            {
                _fileName = value;
            }
        }

        public APIKeysFileExistingChecker(string environmentFolderPath)
        {
            ConfigFilePath = environmentFolderPath + "\\APIKeys.xml";
            CheckKeysConfigFileExisting();
        }

        private bool CheckKeysConfigFileExisting()
        {
            IsAPIKeysFileExists = File.Exists(ConfigFilePath);
            return IsAPIKeysFileExists;
        }

        public bool CreateKeysConfingFile()
        {
            try
            {
                XDocument xmlFile = new XDocument();
                XElement keys = new XElement("APIKeys");
                xmlFile.Add(keys);
                xmlFile.Save(ConfigFilePath);
                IsAPIKeysFileExists = true;
                return IsAPIKeysFileExists;
            }
            catch (System.Exception e)
            {
                return false;
                throw new System.Exception(e.Message);
            } 
        }

    }
}
