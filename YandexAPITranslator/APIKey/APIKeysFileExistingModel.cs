using System.IO;

namespace YandexAPITranslator.APIKey
{
    public class APIKeysFileExistingModel
    {
        private string _fileName;

        public bool IsConfilgExists { get; private set; }
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

        public APIKeysFileExistingModel(string environmentFolderPath)
        {
            ConfigFilePath = environmentFolderPath + "\\APIKeys.xml";
            CheckKeysConfigFileExisting();
        }

        private bool CheckKeysConfigFileExisting()
        {
            IsConfilgExists = File.Exists(ConfigFilePath);
            return IsConfilgExists;
        }

        public bool CreateKeysConfingFile()
        {
            try
            {
                using (FileStream fileStream = new FileStream(ConfigFilePath ,FileMode.Create))
                {
                    IsConfilgExists = true;
                }
                return IsConfilgExists;
            }
            catch (System.Exception e)
            {
                return false;
                throw new System.Exception(e.Message);
            } 
        }

    }
}
