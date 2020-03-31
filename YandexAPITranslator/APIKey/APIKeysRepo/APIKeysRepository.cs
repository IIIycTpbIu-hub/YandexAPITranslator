using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace YandexAPITranslator.APIKey.APIKeysRepo
{
    public class APIKeysRepository : IKeysRepository
    {
        private readonly string _repositoryPath;
        private XDocument _repository;

        public APIKeysRepository(string existingRepositoryPath)
        {
            _repositoryPath = existingRepositoryPath;
        }

        public ObservableCollection<APIKeyEntity> ReadAPIKeys()
        {
            ObservableCollection<APIKeyEntity> keys = new ObservableCollection<APIKeyEntity>();
            try
            {
                _repository = XDocument.Load(_repositoryPath);
                XElement rootElement = _repository.Element("APIKeys");
                if (rootElement.HasElements)
                {
                    foreach (XElement node in rootElement.Elements("APIKey"))
                    {
                        keys.Add(new APIKeyEntity(node.Value.ToString(), Convert.ToBoolean(node.Attribute("isCurrent").Value)));
                    }
                }    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return keys;
        }

        public bool AddAPIKey(APIKeyEntity key, bool useIsCurrentValue = false)
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
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
            
        }

        public void RemoveAPIKey(APIKeyEntity key)
        {
            _repository = XDocument.Load(_repositoryPath);
            XElement rootElement = _repository.Element("APIKeys");
            foreach (var item in rootElement.Elements("APIKey"))
            {
                if (item.Value == key.KeyValue && Convert.ToBoolean(item.Attribute("isCurrent").Value) == key.IsCurrent)
                {
                    item.Remove();
                }
            }
            _repository.Save(_repositoryPath);
        }

        public APIKeyEntity FindAPIKey(string key)
        {
            APIKeyEntity result = null;
            _repository = XDocument.Load(_repositoryPath);
            XElement rootElement = _repository.Element("APIKeys");
            foreach (var item in rootElement.Elements("APIKey"))
            {
                if(item.Value == key)
                {
                    result = new APIKeyEntity(item.Value, Convert.ToBoolean(item.Attribute("isCurrent").Value));
                }
            }
            _repository.Save(_repositoryPath);
            return result;
        }

        public APIKeyEntity FindCurrentAPIKey()
        {
            APIKeyEntity result = null;
            _repository = XDocument.Load(_repositoryPath);
            XElement rootElement = _repository.Element("APIKeys");
            foreach (var item in rootElement.Elements("APIKey"))
            {
                if (item.Attribute("isCurrent").Value == "true")
                {
                    result = new APIKeyEntity(item.Value, Convert.ToBoolean(item.Attribute("isCurrent").Value));
                }
            }
            _repository.Save(_repositoryPath);
            return result;
        }
    }
}
