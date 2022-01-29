using Serilog;

namespace AutofacTesting.Windows;

public interface IWindowFactory
{
    TWindow CreateWindow<TWindow>(WindowOptions windowOptions) where TWindow : class, IWindow;
}

public interface IWindowFactory<TWindow>
    where TWindow : class, IWindow
{
    TWindow CreateWindow(WindowOptions windowOptions);
}

public class WindowFactory<TWindow> : IWindowFactory<TWindow>
    where TWindow : class, IWindow
{
    private readonly ILogger _logger;

    public WindowFactory(ILogger logger)
    {
        _logger = logger;
    }

    public TWindow CreateWindow(WindowOptions windowOptions)
    {
        var type = typeof(TWindow);

        var instance = Activator.CreateInstance(type, _logger, windowOptions);
        if (instance == null)
        {
            throw new Exception($"Failed to create instance of {type.Name}");
        }

        return (TWindow)instance;
    }
}
