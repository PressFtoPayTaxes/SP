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

namespace CloudStorage
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "" || newLoginTextBox.Text == "" || newPasswordBox.Password == "" || repeatedPasswordBox.Password == "" || emailTextBox.Text == "" || notARobotCheckBox.IsChecked == false)
            {
                MessageBox.Show("Не все поля заполнены", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPasswordBox.Password != repeatedPasswordBox.Password)
            {
                MessageBox.Show("Пароли не совпадают", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new User
            {
                Login = newLoginTextBox.Text,
                Password = newPasswordBox.Password,
                Name = nameTextBox.Text,
                Email = emailTextBox.Text
            };

            await ContextSaveChanges(user);

            MessageBox.Show("Вы успешно зарегистрировались", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

            DropBoxWindow window = new DropBoxWindow();
            window.Show();
            Hide();
        }

        public Task<int> ContextSaveChanges(User user)
        {
            using (var context = new DataContext())
            {

                context.Users.Add(user);
                return Task.FromResult(context.SaveChanges());
            }
        }
    }
}
