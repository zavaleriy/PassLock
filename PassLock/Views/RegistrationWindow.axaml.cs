using Avalonia.Controls;
using Avalonia.Interactivity;
using PassLock.Models;
using PassLock.ViewModels;
using System.Linq;
using System.Text.RegularExpressions;

namespace PassLock.Views
{
    public partial class RegistrationWindow : Window
    {
        
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BtnAccExist_OnClick(object? sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void BtnReg_OnClick(object? sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(BoxLogin.Text, @"\p{IsCyrillic}"))
            {
                BlockWarn.Text = "Кириллица недопустима в логине";
                return;
            }
            if (!Regex.IsMatch(BoxEmail.Text, @"/^[^\.\s][\w\-]+(\.[\w\-]+)*@([\w-]+\.)+[\w-]{2,}$/gm"))
            {
                BlockWarn.Text = "Неправильно введена почта";
            }
            if (Regex.IsMatch(BoxPassword.Text, @"\p{IsCyrillic}"))
            {
                BlockWarn.Text = "Кириллица недопустима в пароле";
                return;
            }
            
            bool existUser = LoginWindow._users.Any(u => u.Login == BoxLogin.Text || u.Email == BoxEmail.Text);

            if (existUser)
                BlockWarn.Text = "Пользователь уже существует";
            else
            {
                string? password = Hash.GetHashedString(BoxPassword.Text);

                User user = new(BoxLogin.Text,
                    password,
                    BoxEmail.Text);

                LoginWindow._users.Add(user);

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.DataContext = new LoginWindowViewModel();
                loginWindow.Show();
                Close();
            }

        }
    }
}
