using System;
using YandexAPITranslator.APIKey.APIKeysView;
using YandexAPITranslator.APIKey.APIKeysRepo;

namespace YandexAPITranslator.APIKey.APIKeysController
{
    public class ApiKeyController : IKeysViewInputHandler
    {
        private readonly IKeysView _view;
        private readonly IKeysRepository _keysRepository;

        public APIKeyEntity CurrentKey { get; private set; }

        public ApiKeyController(IKeysView view)
        {
            APIKeysFileExistingChecker checker = new APIKeysFileExistingChecker(Environment.CurrentDirectory);
            if(!checker.IsAPIKeysFileExists)
            {
                checker.CreateKeysConfingFile();
            }
            _view = view;
            _view.SetInputHandler(this);

            _keysRepository = new APIKeysRepository(checker.ConfigFilePath);
            CurrentKey = _keysRepository.FindCurrentAPIKey();

            _view.ShowCurrentKey(CurrentKey);
            _view.ShowAvailableKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
        }

        public void OnAddKey(object sender, string key)
        {
            bool done;
            APIKeyEntity newKey;
            if (CurrentKey == null)
            {
                newKey = new APIKeyEntity(key, true);
                CurrentKey = newKey;
                done = _keysRepository.AddAPIKey(CurrentKey, true);
                _view.ShowCurrentKey(newKey);
            }
            else
            {
                newKey = new APIKeyEntity(key, false);
                done = _keysRepository.AddAPIKey(newKey, false);
            }
            
            if(done)
            {
                _view.ShowAvailableKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
            }
        }

        public void OnRemoveKey(Object sender, String key)
        {
            var removingKey = _keysRepository.FindAPIKey(key);
            if(removingKey != null)
            {
                if(CurrentKey != null)
                {
                    if (removingKey.KeyValue == CurrentKey.KeyValue && removingKey.IsCurrent == CurrentKey.IsCurrent)
                    {
                        CurrentKey = null;
                        _view.ShowCurrentKey(new APIKeyEntity("-"));
                    }
                }                
                _keysRepository.RemoveAPIKey(removingKey);
                _view.ShowAvailableKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
            }
        }

        public void OnSelectKey(Object sender, String key)
        {
            if(CurrentKey != null)
            {
                APIKeyEntity temp = CurrentKey;
                _keysRepository.RemoveAPIKey(CurrentKey);
                _keysRepository.AddAPIKey(new APIKeyEntity(temp.KeyValue, false));
                temp = _keysRepository.FindAPIKey(key);
                if(temp != null)
                {
                    _keysRepository.RemoveAPIKey(temp);
                    CurrentKey = new APIKeyEntity(temp.KeyValue, true);
                    _keysRepository.AddAPIKey(CurrentKey, true);
                }
            }
            else
            {
                APIKeyEntity newKey = _keysRepository.FindAPIKey(key);
                if(newKey != null)
                {
                    _keysRepository.RemoveAPIKey(newKey);
                    CurrentKey = new APIKeyEntity(newKey.KeyValue, true);
                    _keysRepository.AddAPIKey(CurrentKey, true);
                }
            }
            _view.ShowCurrentKey(CurrentKey);
            _view.ShowAvailableKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
        }

        public void OnViewClosing(Object sender, EventArgs e)
        {
            _view.RemoveInputHandler(this);
        }
    }
}
