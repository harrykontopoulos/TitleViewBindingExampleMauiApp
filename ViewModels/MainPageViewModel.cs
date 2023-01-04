using System.Windows.Input;

namespace TitleViewBindingExampleMauiApp.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand GoToSettingsCommand { get; set; }

        public MainPageViewModel()
        {
            
            GoToSettingsCommand = new Command(OnCounterClicked);
        }

        public async void OnCounterClicked()
        {
            await Shell.Current.GoToAsync("Settings");
        }
    }
}
