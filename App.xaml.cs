using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace IconForge;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? _window;
    
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        EnsureResourcesPriExtracted();
        InitializeComponent();
    }

    private static void EnsureResourcesPriExtracted()
    {
        try
        {
            string baseDir = System.AppContext.BaseDirectory;
            string targetPriPath = System.IO.Path.Combine(baseDir, "resources.pri");
            
            if (System.IO.File.Exists(targetPriPath))
            {
                return;
            }

            // 1. Try embedded manifest resource
            using (var stream = typeof(App).Assembly.GetManifestResourceStream("IconForge.resources.pri"))
            {
                if (stream != null)
                {
                    using (var fileStream = System.IO.File.Create(targetPriPath))
                    {
                        stream.CopyTo(fileStream);
                        return;
                    }
                }
            }

            // 2. Try .NET SingleFile self-extracted directory
            string asmLocation = typeof(App).Assembly.Location;
            if (!string.IsNullOrEmpty(asmLocation))
            {
                string asmDir = System.IO.Path.GetDirectoryName(asmLocation)!;
                string sourcePriPath = System.IO.Path.Combine(asmDir, "resources.pri");
                if (System.IO.File.Exists(sourcePriPath) && sourcePriPath != targetPriPath)
                {
                    System.IO.File.Copy(sourcePriPath, targetPriPath, true);
                    return;
                }
            }

            // 3. Fallback: search temp directory for bundled resources.pri
            string tempDir = System.IO.Path.GetTempPath();
            string[] foundFiles = System.IO.Directory.GetFiles(tempDir, "resources.pri", System.IO.SearchOption.AllDirectories);
            if (foundFiles.Length > 0 && System.IO.File.Exists(foundFiles[0]))
            {
                System.IO.File.Copy(foundFiles[0], targetPriPath, true);
            }
        }
        catch
        {
            // Ignore if directory is read-only
        }
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        _window = new MainWindow();
        _window.Activate();
    }
}
