using System.Windows.Input;

namespace TitleViewBindingExampleMauiApp.ViewModels
{
    public class SecondPageViewModel
    {
        public ICommand GoToSettingsCommand { get; set; }

        public SecondPageViewModel()
        {

            GoToSettingsCommand = new Command(OnCounterClicked);
        }

        public async void OnCounterClicked()
        {
            await Shell.Current.GoToAsync("Settings");
        }
    }
}
