using System.Collections.Generic;
using YandexAPITranslator.Translator;

namespace YandexAPITranslator.YandexAPIInteraction.Entities
{
    public class LanguagesResponce : BaseYandexAPIResponce
    {
        public Dictionary<string, string> Langs { get; set; }
    }
}
