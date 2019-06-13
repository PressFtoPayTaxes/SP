using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CloudStorage
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

        static int userExistanceCode = 0;

        private async void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;

            if(await Task.Run(() => CheckDatabase(new PasswordLoginPair { Login = login, Password = password })))
            {
                DropBoxWindow window = new DropBoxWindow();
                window.Show();
                Hide();
            }

            
        }

        public bool CheckDatabase(object loginPassword)
        {
            var loginPasswordPair = loginPassword as PasswordLoginPair;

            using (var context = new DataContext())
            {
                foreach (var user in context.Users)
                {
                    if (loginPasswordPair.Login == user.Login && loginPasswordPair.Password == user.Password)
                    {
                        MessageBox.Show("Вы успешно вошли в систему", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);

                        return true;
                    }
                }
            }

            MessageBox.Show("Неверные логин или пароль", "Вход", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window = new RegistrationWindow();
            window.Show();
            Hide();
        }
    }
}
