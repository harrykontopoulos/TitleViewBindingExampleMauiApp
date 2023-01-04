using System.Runtime.Versioning;

namespace TitleViewBindingExampleMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).ConfigureMauiHandlers((handlers) =>
            {
				#if IOS15_0_OR_GREATER
					handlers.AddHandler(typeof(AppShell), typeof(CustomShellRenderer));
				#endif
            });

        return builder.Build();
	}
}
