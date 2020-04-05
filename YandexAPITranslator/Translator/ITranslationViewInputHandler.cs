namespace YandexAPITranslator.Translator
{
    public interface ITranslationViewInputHandler
    {
        void OnTranslate(object sender, string text);
        void OnSelectCurrentLanguage(object sender, Language currentLanguage);
        void OnSelectTargetLanguage(object sender, Language targetLanguage);
    }
}