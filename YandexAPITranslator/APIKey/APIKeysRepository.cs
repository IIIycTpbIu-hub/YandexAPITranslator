using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;

namespace YandexAPITranslator.APIKey
{
    public class APIKeysRepository
    {
        private readonly string _repositoryPath;
        private XDocument _repository;

        public APIKeysRepository(string existingRepositoryPath)
        {
            _repositoryPath = existingRepositoryPath;
        }

        public ObservableCollection<APIKey> ReadAPIKeys()
        {
            ObservableCollection<APIKey> keys = new ObservableCollection<APIKey>();
            try
            {
                _repository = XDocument.Load(_repositoryPath);
                XElement rootElement = _repository.Element("APIKeys");
                if (rootElement.HasElements)
                {
                    foreach (XElement node in rootElement.Elements("APIKey"))
                    {
                        keys.Add(new APIKey(node.Value.ToString(), Convert.ToBoolean(node.Attribute("isCurrent").Value)));
                    }
                }    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return keys;
        }

        public void AddAPIKey(APIKey key, bool useIsCurrentValue = false)
        {
            try
            {
                _repository = XDocument.Load(_repositoryPath);
                XElement rootElement = _repository.Element("APIKeys");
                XElement keyElement = new XElement("APIKey");
                keyElement.SetValue(key.KeyValue);

                if (useIsCurrentValue)
                {
                    keyElement.SetAttributeValue("isCurrent", key.IsCurrent);
                }
                else
                {
                    keyElement.SetAttributeValue("isCurrent", false);
                }

                rootElement.Add(keyElement);
                _repository.Save(_repositoryPath);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
