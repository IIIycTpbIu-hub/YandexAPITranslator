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
using YandexAPITranslator.YandexAPIInteraction;
using YandexAPITranslator.YandexAPIInteraction.Entities;

namespace YandexAPITranslator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetCurrentAPIKeyMenuItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            APIKeysWindow view = new APIKeysWindow();
            view.Visibility = Visibility.Visible;
            APIKeyController inputHandler = new APIKeyController(view);
            YandexAPIInteractor interactor = new YandexAPIInteractor();
            interactor.SendRequest(new TranslationRequest(inputHandler.CurrentKey.KeyValue, "ru-en", "Привет"));
            interactor.SendRequest(new GetLanguagesRequest(inputHandler.CurrentKey.KeyValue, "ru"));
        }
    }
}
