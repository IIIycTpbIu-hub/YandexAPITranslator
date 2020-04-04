using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPITranslator.YandexAPIInteraction.Entities
{
    public abstract class BaseYandexAPIRequest
    {
        public String APIKey { get; private set; }
        public String APIAddress { get; private set; }

        public BaseYandexAPIRequest(string apiKey)
        {
            APIAddress = "https://translate.yandex.net/api/v1.5/tr.json/";
            APIKey = apiKey;
        }

        public abstract string CreateRequestString();
    }
}
