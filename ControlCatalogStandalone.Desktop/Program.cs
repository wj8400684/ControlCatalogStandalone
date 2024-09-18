using System;
using Avalonia;

namespace ControlCatalogStandalone.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        var app = AppBuilder.Configure<App>()
            .UseSkia() // skia
            //.UseFontSourceSansPro()//In some platforms, it may not be opened after publishing with aot, please remove it!
            .LogToTrace();

        return app.UsePlatformDetect();

#if Linux
            app.UseX11();
#elif OSX
            app.UseAvaloniaNative();
#elif Windows
            app.UseWin32();
#endif

        return app;
    }
}
