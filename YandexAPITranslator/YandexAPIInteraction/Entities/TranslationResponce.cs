using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexAPITranslator.YandexAPIInteraction.Entities
{
    public class TranslationResponce : BaseYandexAPIResponce
    {
        public int Code { get; set; }
        public string Lang { get; set; }
        public string[] Text { get; set; }
    }
}
