using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PassLock.Models;
using PassLock.ViewModels;

namespace PassLock.Views
{
    public partial class EditWindow : Window
    {
        private TablePassword _editPassword;

        public EditWindow(TablePassword pwd, MainWindowViewModel wnvm)
        {
            InitializeComponent();
            _editPassword = pwd;
            DataContext = wnvm;

            BoxTitle.Text = _editPassword.Title;
            BoxLogin.Text = _editPassword.Login;
            BoxWebsite.Text = _editPassword.Url;
            BoxPwd.Text = _editPassword.Password;
            BoxNote.Text = _editPassword.Note;

        }

        private void ButtonConfirm_OnClick(object? sender, RoutedEventArgs e)
        {
            _editPassword.Title = BoxTitle.Text;
            _editPassword.Login = BoxLogin.Text;
            _editPassword.Url = BoxWebsite.Text;
            _editPassword.Password = BoxPwd.Text;
            _editPassword.Note = BoxNote.Text;
            _editPassword.LastMod = DateTime.Now;
            
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                mainWindowViewModel.row = _editPassword;
            }
            
            Close();
            
        }
        
    }
}
