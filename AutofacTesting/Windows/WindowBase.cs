using Serilog;

namespace AutofacTesting.Windows;

public abstract class WindowBase : IWindow, IDisposable
{
    private bool _disposed;

    public WindowBase(ILogger logger, WindowOptions windowOptions)
    {
        WindowOptions = windowOptions;
        Logger = logger;

        Initialize();
    }

    protected ILogger Logger { get; }
    protected WindowOptions WindowOptions { get; }

    public abstract void Initialize();
    public abstract void Shutdown();

    public abstract bool IsRunning();

    public abstract void Update();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            Shutdown();
        }

        _disposed = true;
    }
}
