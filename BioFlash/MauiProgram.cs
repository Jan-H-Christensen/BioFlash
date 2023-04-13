using Microsoft.Extensions.Logging;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using Microsoft.Maui.Controls.Handlers.Compatibility;

namespace BioFlash;

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
				
			//}).ConfigureMauiHandlers(handlers => {
			//	#if ANDROID
   //             handlers.AddHandler(typeof(Shell), typeof(ShellCustomRenderer));
			//	#endif
            });


		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);


		return builder.Build();
	}
}
