namespace YandexAPITranslator.YandexAPIInteraction.Entities
{
    public class TranslationRequest : BaseYandexAPIRequest
    {
        public string LanguagePair { get; private set; }
        public string Text { get; private set; }

        public TranslationRequest(string apiKey, string lanuagePair, string text) :base(apiKey)
        {
            LanguagePair = lanuagePair;
            Text = text;
        }

        public override string CreateRequestString()
        {
            return base.APIAddress + "translate?key=" + base.APIKey + "&text=" + Text +"&lang=" + LanguagePair;
        }
    }
}
