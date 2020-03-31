using YandexAPITranslator.APIKey.APIKeysController;
using System.Collections.ObjectModel;


namespace YandexAPITranslator.APIKey.APIKeysView
{
    public interface IKeysView
    {
        void SetInputHandler(IKeysViewInputHandler inputHandler);
        void RemoveInputHandler(IKeysViewInputHandler inputHandler);
        void ShowAvaibleKeys<T>(ObservableCollection<T> keysCollection);
        void ShowCurrentKey(APIKeyEntity key);
    }
}
