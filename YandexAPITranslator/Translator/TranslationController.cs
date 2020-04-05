using System.Collections.ObjectModel;
using YandexAPITranslator.APIKey.APIKeysController;
using YandexAPITranslator.YandexAPIInteraction;
using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator.Translator
{
    public class TranslationController : IAPIResponceObserver, ITranslationViewInputHandler
    {
        private readonly ITranslationView _translationView;
        private readonly IAPIResponceNotifier _apiResponceNotifier;
        private readonly ApiKeyController _keyController;

        private Language _currentLanguage;
        private Language _targetLanguage;

        public TranslationController(ITranslationView translationView, IAPIResponceNotifier responceNotifier, 
            ApiKeyController keyController)
        {
            _translationView = translationView;
            _translationView.SetInputHandler(this);
            _apiResponceNotifier = responceNotifier;
            _keyController = keyController;
            _apiResponceNotifier.AddAPIResponceObserver(this);
            GetAvailableLanguages();
        }

        public void OnResponsePreformed(object sender, BaseYandexAPIResponce response)
        {
            switch (response)
            {
                case LanguagesResponce resp:
                    var dataToShow = ConvertApiResponseToObservableCollection(resp);
                    _translationView.SetAvailableLanguages(dataToShow);
                    break;
                case TranslationResponce resp:
                    if (resp.Code == 200)
                    {
                        _translationView.ShowTranslation(resp.Text[0]);
                    }
                    break;
            }
        }

        public void OnTranslate(object sender, string text)
        {
            if (_currentLanguage != null && _targetLanguage != null && text != "")
            {
                Translate(text);
            }
        }

        public void OnSelectCurrentLanguage(object sender, Language currentLanguage)
        {
            _currentLanguage = currentLanguage;
        }

        public void OnSelectTargetLanguage(object sender, Language targetLanguage)
        {
            _targetLanguage = targetLanguage;
        }

        private void GetAvailableLanguages()
        {
            _apiResponceNotifier.SendRequest(new GetLanguagesRequest(_keyController.CurrentKey.KeyValue, "ru"));
        }

        private ObservableCollection<Language> ConvertApiResponseToObservableCollection(LanguagesResponce response)
        {
            ObservableCollection<Language> result = new ObservableCollection<Language>();
            foreach (var lang in response.Langs)
            {
                result.Add(new Language(lang.Key, lang.Value));
            }
            return result;
        }

        private void Translate(string text)
        {
            _apiResponceNotifier.SendRequest(new TranslationRequest(
                _keyController.CurrentKey.KeyValue, _currentLanguage.ShortName +"-"+
                                                    _targetLanguage.ShortName, text));
        }
    }
}
