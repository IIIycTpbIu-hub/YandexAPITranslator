using System;
using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator.YandexAPIInteraction
{
    public class YandexAPIInteractor : IAPIResponceNotifier
    {
        readonly HttpClientController _httpClientController;
        readonly YandexAPIResponceDeserializer _responceDeserializer;

        event EventHandler<BaseYandexAPIResponce> ResponcePreformed;

        public YandexAPIInteractor()
        {
            _httpClientController = new HttpClientController();
            _responceDeserializer = new YandexAPIResponceDeserializer();
        }

        public void AddAPIResponceObserver(IAPIResponceObserver observer)
        {
            ResponcePreformed += observer.OnResponcePreformed;
        }

        public void RemoveAPIResponceObserver(IAPIResponceObserver observer)
        {
            ResponcePreformed -= observer.OnResponcePreformed;
        }

        public async void SendRequest(BaseYandexAPIRequest request)
        {
            try
            {
                string requestStr = request.CreateRequestString();
                String responceStr = await _httpClientController.GetContentAsync(requestStr);
                BaseYandexAPIResponce responceObject = _responceDeserializer.DeserializeByRequestType(request, responceStr);
                if(responceObject != null)
                {
                    Notify(responceObject);
                }                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private void Notify(BaseYandexAPIResponce responce)
        {
            ResponcePreformed?.Invoke(this, responce);
        }
    }
}
