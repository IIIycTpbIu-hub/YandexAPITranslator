using System;
using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator.YandexAPIInteraction
{
    public interface IAPIResponceObserver
    {
        void OnResponcePreformed(Object sender, BaseYandexAPIResponce responce);
    }
}
 