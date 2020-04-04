using System;

namespace YandexAPITranslator.APIKey.APIKeysView
{
    public interface IKeysViewInputHandler
    {
        void OnAddKey(Object sender, String key);
        void OnRemoveKey(Object sender, String key);
        void OnSelectKey(Object sender, String key);
        void OnViewClosing(Object sender, EventArgs e);
    }
}
