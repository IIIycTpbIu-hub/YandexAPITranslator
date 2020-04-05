using System;
using System.Text.Json;
using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator.YandexAPIInteraction
{
    public class YandexAPIResponceDeserializer
    {
        public BaseYandexAPIResponce DeserializeByRequestType(BaseYandexAPIRequest request, string responceString)
        {
            BaseYandexAPIResponce responseObject = null;
            switch (request)
            {
                case TranslationRequest _:
                    responseObject = JsonSerializer.Deserialize<TranslationResponce>(responceString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                    break;
                case GetLanguagesRequest _:
                    responseObject = JsonSerializer.Deserialize<LanguagesResponce>(responceString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                    break;
            }
            return responseObject;
        }
    }
}
