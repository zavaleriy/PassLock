using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using PassLock.Models;
using PassLock.ViewModels;

namespace PassLock.Views
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, bool> _fieldsAccount = new()
        {
            {"TextTitle", false},
            {"TextLogin", false},
            {"TextPwd", false},
            {"TextUrl", false},
        };

        public MainWindow()
        {
            InitializeComponent();
        }
        
        public MainWindow(User user)
        {
            InitializeComponent();

            if (user is not null)
            {
                TextVersion.Text = $"Версия: {Assembly.GetExecutingAssembly().GetName().Version!.ToString()}";

                BlockLogin.Text = user.Login;
                BlockEmail.Text = user.Email;
                BlockCreatedDate.Text = user.Created.ToString();
            }
            
        }
        
        private void BtnNewAcc_OnClick(object? sender, RoutedEventArgs e) => RegAcc.IsVisible = true;
        
        private void BtnAdd_OnClick(object? sender, RoutedEventArgs e)
        {
            BtnAdd.IsEnabled = false;
            
            foreach (var key in _fieldsAccount.Keys.ToList())
                _fieldsAccount[key] = false;

        }
        
        private void BtnCancel_OnClick(object? sender, RoutedEventArgs e)
        {
            RegAcc.IsVisible = false;
        }
        

        private void AddField_TextChanged(object? sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            
            if (tb?.Text is null or "")
            {
                tb!.BorderBrush = Brushes.Red;
                _fieldsAccount[tb.Name] = false;
            }
            else
            {
                tb.BorderBrush = Brush.Parse("#FF776B5D");
                _fieldsAccount[tb.Name] = true;
            }

            BtnAdd.IsEnabled = _fieldsAccount.Values.All(b => b == true);
        }

        private void SwitchDarkTheme_OnIsCheckedChanged(object? sender, RoutedEventArgs e) =>
            RequestedThemeVariant = (bool)(sender as ToggleSwitch).IsChecked ? ThemeVariant.Dark : ThemeVariant.Light;

        public void CopyText(string text) => Clipboard?.SetTextAsync(text);
        
    }
}