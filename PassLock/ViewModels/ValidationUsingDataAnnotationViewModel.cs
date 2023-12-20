using System.ComponentModel.DataAnnotations;
using ReactiveUI;


// https://github.com/AvaloniaUI/Avalonia.Samples/tree/main/src/Avalonia.Samples/MVVM/ValidationSample
namespace PassLock.ViewModels
{
    public class ValidationUsingDataAnnotationViewModel : ViewModelBase
    {
        private string? _EMail;

        [Required]
        [EmailAddress]
        public string? EMail
        {
            get => _EMail; 
            set => this.RaiseAndSetIfChanged(ref _EMail, value); 
        }
    }
}