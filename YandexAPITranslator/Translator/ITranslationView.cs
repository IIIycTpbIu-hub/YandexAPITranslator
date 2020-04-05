using System.Collections.ObjectModel;
namespace YandexAPITranslator.Translator
{
    public interface ITranslationView
    {
        void SetInputHandler(ITranslationViewInputHandler inputHandler);
        void RemoveInputHandler(ITranslationViewInputHandler inputHandler);
        void SetAvailableLanguages(ObservableCollection<Language> languages);
        void ShowTranslation(string text);
    }
}