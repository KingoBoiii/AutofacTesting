using AutofacTesting.Windows;
using Serilog;

namespace AutofacTesting.Applications;

public abstract class ApplicationBase
{
    private readonly IWindow _window;

    public ApplicationBase(ILogger logger, IWindow window)
    {
        Logger = logger;
        _window = window;
    }

    protected ILogger Logger { get; }

    public void Run()
    {
        while(!_window.IsRunning())
        {
            Update(0.0f);

            _window.Update();
        }
    }

    protected abstract void Update(float deltaTime);
}