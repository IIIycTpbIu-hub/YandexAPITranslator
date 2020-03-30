using System.IO;

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
                using (FileStream fileStream = new FileStream(ConfigFilePath ,FileMode.Create))
                {
                    IsAPIKeysFileExists = true;
                }
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
