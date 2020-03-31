using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPITranslator.APIKey
{
    public class APIKeyEntity
    {
        public string KeyValue { get; private set; }
        public bool IsCurrent { get; set; }

        public APIKeyEntity(string keyValue)
        {
            KeyValue = keyValue;
            IsCurrent = false;
        }

        public APIKeyEntity(string keyValue, bool isCurrent)
        {
            KeyValue = keyValue;
            IsCurrent = isCurrent;
        }
    }
}
