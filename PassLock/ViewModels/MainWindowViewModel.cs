using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using PassLock.Models;
using PassLock.Views;
using ReactiveUI;


namespace PassLock.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<TablePassword> _dataItems;

        public ObservableCollection<TablePassword> dataItems
        {
            get => _dataItems;
            set => this.RaiseAndSetIfChanged(ref _dataItems, value);
        }
        
        private readonly Dictionary<int, double> _gridSize = new()
        {
            {0, 33},
            {1, 67},
            {2, 100},
            {3, 133},
            {4, 166},
            {5, 199},
        };

        public double _gridHeight = 33;

        public double gridHeight
        {
            get => _gridHeight;
            set
            {
                _gridHeight = value;
                this.RaisePropertyChanged();
            }
        }
        
        private TablePassword _row;

        public TablePassword row
        {
            get { return _row; }
            set
            {
                _row = value;
                this.RaisePropertyChanged();
            }
        }

        public string Title { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Note { get; set; }
        
        public ICommand NewAccountCommand { get; }
        
        
        public ICommand CopyColumnCommand { get; }
        public ICommand VisitWebsiteCommand { get; }
        
        public ICommand ShareCommand { get; }
        public ICommand EditCommand { get; }
        
        public ICommand DeleteCommand { get; }

        public MainWindowViewModel()
        {
            dataItems = new ObservableCollection<TablePassword>();

            NewAccountCommand = ReactiveCommand.Create(NewAccount);
            
            CopyColumnCommand = ReactiveCommand.Create<string>(str => new MainWindow().CopyText(str));
            VisitWebsiteCommand = ReactiveCommand.Create<string>(VisitWebsite);
            ShareCommand = ReactiveCommand.Create<TablePassword>(pwd => new ShareWindow(pwd).Show());

            EditCommand = ReactiveCommand.Create<TablePassword>(pwd => new EditWindow(pwd, this).Show());
            DeleteCommand = ReactiveCommand.Create<TablePassword>(pwd =>
            {
                dataItems.Remove(pwd);
                gridHeight = _gridSize.TryGetValue(dataItems.Count, out double value) ? value : gridHeight;
            });

        }


        private void NewAccount()
        {
            dataItems.Add(new TablePassword(
                Title, Login, Password, Url, Note));
                
            gridHeight = _gridSize.TryGetValue(dataItems.Count, out double value) ? value : gridHeight;

        }
        
        private void VisitWebsite(string link)
        {
            if ( !link.StartsWith("https://") && !link.StartsWith("http://") )
                link = "https://" + link;
            
            Process.Start(new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true,
            } ); 
        }
        
    }
    
}