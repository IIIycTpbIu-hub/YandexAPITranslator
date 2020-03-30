using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPITranslator.Translator
{
    public class Language
    {
        public string ShortName { get; private set; }
        public string FullName { get; private set; }

        public Language(string shortName, string fullName)
        {
            ShortName = shortName;
            FullName = fullName;
        }
    }
}
