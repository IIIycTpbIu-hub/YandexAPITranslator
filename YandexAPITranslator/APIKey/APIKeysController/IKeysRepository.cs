﻿using System.Collections.ObjectModel;

namespace YandexAPITranslator.APIKey.APIKeysController
{
    public interface IKeysRepository
    {
        ObservableCollection<APIKeyEntity> ReadAPIKeys();
        bool AddAPIKey(APIKeyEntity key, bool useIsCurrentValue = false);
        void RemoveAPIKey(APIKeyEntity key);
        APIKeyEntity FindAPIKey(string key);
        APIKeyEntity FindCurrentAPIKey();
    }
}
