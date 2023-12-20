using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PassLock.Models;
using PassLock.ViewModels;
using System.Linq;

namespace PassLock.Views
{
    public partial class LoginWindow : Window
    {
        private string? HashedPassword;
        
        public static List<User> _users = new()
        {
            new User("zavaleriy",
                "ee1067d2c54d8b095bb7b3937aa40968cc3475e4360433a8bf816217e823271fcc9e7222dd9e57afb5675d999b88f49574ed8e6a3833b1437910e9aba7b6575f",
                "emailemail@domain.com"),
        };
        
        public LoginWindow()
        {
            DataContext = new LoginWindowViewModel();
            InitializeComponent();
        }

        private void BtnLogin_OnClick(object? sender, RoutedEventArgs e)
        {
            if (BoxPassword.Text != null)
                HashedPassword = Hash.GetHashedString(BoxPassword.Text);

            User existUser = _users.FirstOrDefault(user => user.Login == BoxLogin.Text && user.Password == HashedPassword);
            
            if (existUser != null)
            {
                MainWindow wnd = new(existUser);
                wnd.DataContext = new MainWindowViewModel();
                wnd.Show();
                Close();
            }
            else
                BlockWarn.Text = "Неверный логин и/или пароль";
        }

        private void BtnReg_OnClick(object? sender, RoutedEventArgs e)
        {
            RegistrationWindow wnd = new();
            wnd.DataContext = new RegWindowViewModel();
            wnd.Show();
            Close();
        }

    }
}