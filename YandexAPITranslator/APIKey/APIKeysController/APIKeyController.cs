using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexAPITranslator.APIKey.APIKeysView;
using YandexAPITranslator.APIKey.APIKeysRepo;

namespace YandexAPITranslator.APIKey.APIKeysController
{
    public class APIKeyController : IKeysViewInputHandler
    {
        IKeysView _view;
        IKeysRepository _keysRepository;

        public APIKeyEntity CurrentKey { get; private set; }

        public APIKeyController(IKeysView view)
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
            _view.ShowAvaibleKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
        }

        public void OnAddKey(object sender, string key)
        {
            bool done = false;
            APIKeyEntity newKey = null;
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
                _view.ShowAvaibleKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
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
            _view.ShowAvaibleKeys<APIKeyEntity>(_keysRepository.ReadAPIKeys());
        }

        public void OnViewClosing(Object sender, EventArgs e)
        {
            _view.RemoveInputHandler(this);
        }
    }
}
