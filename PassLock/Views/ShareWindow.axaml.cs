using System.Diagnostics;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PassLock.Models;

namespace PassLock.Views
{
    public partial class ShareWindow : Window
    {
        private TablePassword _sharedPassword;
        
        public ShareWindow(TablePassword pwd)
        {
            InitializeComponent();
            _sharedPassword = pwd;
            TextBlockTitle.Text = $"Вы делитесь аккаунтом {_sharedPassword.Title}";
        }

        private void ButtonShare_OnClick(object sender, RoutedEventArgs e)
        {
            bool existUser = LoginWindow._users.Any(u => u.Login == TextBoxShare.Text);

            if (!existUser)
                BlockErr.Text = "Такого пользователя не существует";
            else
            {
                BlockErr.Text = null;
                SharePwd();
            }

        }

        private void SharePwd() => Debug.WriteLine("Share password");

    }
}
