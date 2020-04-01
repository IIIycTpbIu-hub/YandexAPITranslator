using System;

namespace YandexAPITranslator.APIKey.APIKeysController
{
    public interface IKeysViewInputHandler
    {
        void OnAddKey(Object sender, String key);
        void OnRemoveKey(Object sender, String key);
        void OnSelectKey(Object sender, String key);
        void OnViewClosing(Object sender, EventArgs e);
    }
}
