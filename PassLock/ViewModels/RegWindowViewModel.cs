using System.Collections.Generic;
using System.Collections.ObjectModel;
using PassLock.Models;
using ReactiveUI;

namespace PassLock.ViewModels
{
    public class RegWindowViewModel : ViewModelBase
    {

        public ValidationUsingDataAnnotationViewModel ValidationUsingDataAnnotationViewModel { get; }
            = new();
        
        public RegWindowViewModel()
        {
            
        }

    }
}
