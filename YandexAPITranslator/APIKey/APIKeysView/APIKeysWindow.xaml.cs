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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using YandexAPITranslator.APIKey.APIKeysController;

namespace YandexAPITranslator.APIKey.APIKeysView
{
    /// <summary>
    /// Логика взаимодействия для APIKeysWindow.xaml
    /// </summary>
    public partial class APIKeysWindow : Window, IKeysView
    {
        public APIKeysWindow()
        {
            InitializeComponent();
        }

        public event EventHandler<String> AddKey;
        public event EventHandler<String> SelectKey;
        public event EventHandler CloseView;

        public void SetInputHandler(IKeysViewInputHandler inputHandler)
        {
            AddKey += inputHandler.OnAddKey;
            SelectKey += inputHandler.OnSelectKey;
            CloseView += inputHandler.OnViewClosing;
        }

        public void RemoveInputHandler(IKeysViewInputHandler inputHandler)
        {
            AddKey -= inputHandler.OnAddKey;
            SelectKey -= inputHandler.OnSelectKey;
            CloseView -= inputHandler.OnViewClosing;
        }

        public void ShowAvaibleKeys<T>(ObservableCollection<T> keysCollection)
        {
            keysList.ItemsSource = keysCollection;
        }

        public void ShowCurrentKey(APIKeyEntity key)
        {
            if(key != null)
            {
                currentKeyLabel.Content = key.KeyValue;
            }
            
        }

        private void addKeyButton_Click(object sender, RoutedEventArgs e)
        {
            AddKey?.Invoke(sender, newKeyTextBox.Text);
            newKeyTextBox.Text = "";
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var sp = sender as StackPanel;
            var child = sp.Children[0] as Label;
            SelectKey?.Invoke(sender, child.Content.ToString());
        }

        private void APIKeysView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseView?.Invoke(this, e);
        }
    }
}
