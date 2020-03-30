using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPITranslator.APIKey
{
    public class APIKey
    {
        public string KeyValue { get; private set; }
        public bool IsCurrent { get; set; }

        public APIKey(string keyValue)
        {
            KeyValue = keyValue;
            IsCurrent = false;
        }

        public APIKey(string keyValue, bool isCurrent)
        {
            KeyValue = keyValue;
            IsCurrent = isCurrent;
        }
    }
}
