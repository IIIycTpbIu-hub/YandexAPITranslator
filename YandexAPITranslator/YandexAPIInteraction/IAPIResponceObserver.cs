using System;
using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator.YandexAPIInteraction
{
    public interface IAPIResponceObserver
    {
        void OnResponsePreformed(Object sender, BaseYandexAPIResponce response);
    }
}
 