using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YandexAPITranslator.APIKey.APIKeysView;
using YandexAPITranslator.APIKey.APIKeysController;
using YandexAPITranslator.Translator;
using YandexAPITranslator.YandexAPIInteraction;
using YandexAPITranslator.YandexAPIInteraction.Entities;
using System.Collections.ObjectModel;

namespace YandexAPITranslator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITranslationView
    {

        private APIKeysWindow _keysWindow;
        private int _test = 0;

        private event EventHandler<string> Translate;
        private event EventHandler<Language> SetCurrentLanguage;
        private event EventHandler<Language> SetTargetLanguage;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetAvailableLanguages(ObservableCollection<Language> languages)
        {
            currentLanguage.ItemsSource = languages;
            targetLanguage.ItemsSource = languages;
        }

        private void SetCurrentAPIKeyMenuItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _keysWindow.Visibility = Visibility.Visible;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            _keysWindow = new APIKeysWindow();
            ApiKeyController inputHandler = new ApiKeyController(_keysWindow);
            YandexAPIInteractor interactor = new YandexAPIInteractor();
            TranslationController translationController = new TranslationController(this, interactor, inputHandler);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _keysWindow.Close();
        }

        private void swapLanguages_Click(object sender, RoutedEventArgs e)
        {
            if (currentLanguage.SelectedItem != null && targetLanguage.SelectedItem != null)
            {
                var temp = currentLanguage.SelectedItem;
                currentLanguage.SelectedItem = targetLanguage.SelectedItem;
                targetLanguage.SelectedItem = temp;
                SetCurrentLanguage?.Invoke(this, currentLanguage.SelectedItem as Language);
                SetTargetLanguage?.Invoke(this, targetLanguage.SelectedItem as Language);
                currentLanguageTextBox.Text = targetLanguageTextBox.Text;
            }
        }

        public void ShowTranslation(string text)
        {
            targetLanguageTextBox.Text = text;
        }

        public void SetInputHandler(ITranslationViewInputHandler inputHandler)
        {
            Translate += inputHandler.OnTranslate;
            SetCurrentLanguage += inputHandler.OnSelectCurrentLanguage;
            SetTargetLanguage += inputHandler.OnSelectTargetLanguage;
        }

        public void RemoveInputHandler(ITranslationViewInputHandler inputHandler)
        {
            Translate -= inputHandler.OnTranslate;
            SetCurrentLanguage -= inputHandler.OnSelectCurrentLanguage;
            SetTargetLanguage -= inputHandler.OnSelectTargetLanguage;
        }

        private void currentLanguageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Translate?.Invoke(this, currentLanguageTextBox.Text);
        }

        private void currentLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetCurrentLanguage?.Invoke(this, currentLanguage.SelectedItem as Language);
        }

        private void targetLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetTargetLanguage?.Invoke(this, targetLanguage.SelectedItem as Language);
        }
    }
}
