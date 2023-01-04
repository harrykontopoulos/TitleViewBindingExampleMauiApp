using TitleViewBindingExampleMauiApp.ViewModels;

namespace TitleViewBindingExampleMauiApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Settings", typeof(SettingsPage));
        Application.Current.PageAppearing += OnPageAppearing;
	}

    private void ShellAppearing(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void OnPageAppearing(object sender, Page page)
    {
        if (page is not AppShell && page.Title is not null)
        {
            ((AppShellViewModel)BindingContext).Title = page.Title;
        }
    }
}
