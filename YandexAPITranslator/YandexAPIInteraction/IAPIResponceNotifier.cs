using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator.YandexAPIInteraction
{
    public interface IAPIResponceNotifier
    {
        void AddAPIResponceObserver(IAPIResponceObserver observer);
        void RemoveAPIResponceObserver(IAPIResponceObserver observer);
        void SendRequest(BaseYandexAPIRequest request);
    }
}
