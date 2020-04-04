namespace YandexAPITranslator.YandexAPIInteraction.Entities
{
    public class GetLanguagesRequest : BaseYandexAPIRequest
    {
        public string UILanguage { get; private set; }

        public GetLanguagesRequest(string apiKey, string uiLanguage) :base(apiKey)
        {
            UILanguage = uiLanguage;
        }

        public override string CreateRequestString()
        {
            return base.APIAddress + "getLangs?key=" + base.APIKey + "&ui=" + UILanguage;
        }
    }
}
