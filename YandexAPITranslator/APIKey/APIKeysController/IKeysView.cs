using YandexAPITranslator.APIKey.APIKeysView;
using System.Collections.ObjectModel;


namespace YandexAPITranslator.APIKey.APIKeysController
{
    public interface IKeysView
    {
        void SetInputHandler(IKeysViewInputHandler inputHandler);
        void RemoveInputHandler(IKeysViewInputHandler inputHandler);
        void ShowAvailableKeys<T>(ObservableCollection<T> keysCollection);
        void ShowCurrentKey(APIKeyEntity key);
    }
}
