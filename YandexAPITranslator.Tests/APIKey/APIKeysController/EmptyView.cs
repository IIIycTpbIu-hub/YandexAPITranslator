using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexAPITranslator.APIKey.APIKeysController;
using YandexAPITranslator.APIKey.APIKeysView;

namespace YandexAPITranslator.Tests.APIKey.APIKeysController
{
    public class EmptyView : IKeysView
    {
        public bool Remove {get; set;}
        public bool Set {get; set;}
        public bool ShowAvaible {get; set;}
        public bool ShowCurrent {get; set;}

        public void RemoveInputHandler(IKeysViewInputHandler inputHandler)
        {
            Remove = true;
        }

        public void SetInputHandler(IKeysViewInputHandler inputHandler)
        {
            Set = true;
        }

        public void ShowAvaibleKeys<T>(ObservableCollection<T> keysCollection)
        {
            ShowAvaible = true;
        }

        public void ShowCurrentKey(YandexAPITranslator.APIKey.APIKeyEntity key)
        {
            ShowCurrent = true;
        }
    }
}
