using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPITranslator.APIKey.APIKeysController
{
    public interface IKeysViewInputHandler
    {
        void OnAddKey(Object sender, String key);
        void OnSelectKey(Object sender, String key);
        void OnViewClosing(Object sender, EventArgs e);
    }
}
