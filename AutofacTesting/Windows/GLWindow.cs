using AutofacTesting.Extensions.Glfw;
using AutofacTesting.Extensions.Glfw.Data;
using Serilog;

namespace AutofacTesting.Windows;

public class GLWindow : WindowBase
{
    private GlfwWindow _glfwWindow;

    public GLWindow(ILogger logger, WindowOptions windowOptions)
        : base(logger, windowOptions)
    {
    }

    public void ErrorFunction(int errorCode, string description)
    {
        Logger.Error($"{errorCode} {description}");
    }

    public override void Initialize()
    {
        if (string.IsNullOrWhiteSpace(WindowOptions.Title))
        {
            Logger.Warning("Title for Windows has not been set!");
            WindowOptions.Title = "Glfw Window";
        }

        if (!Glfw.Init())
        {
            Logger.Fatal("Failed to initialize Glfw");
            return;
        }

        _glfwWindow = Glfw.CreateWindow(WindowOptions.Width, WindowOptions.Height, WindowOptions.Title);
        if (_glfwWindow.Equals(null))
        {
            Glfw.Terminate();
            Logger.Fatal("Failed to create Glfw window");
            return;
        }

        Glfw.MakeContextCurrent(_glfwWindow);

        Glfw.SetErrorCallback(ErrorFunction);
    }

    public override void Shutdown()
    {
        Glfw.DestroyWindow(_glfwWindow);
        Glfw.Terminate();
    }

    public override bool IsRunning()
    {
        return Glfw.WindowShouldClose(_glfwWindow);
    }

    public override void Update()
    {
        if(Glfw.IsKeyPressed(_glfwWindow, GlfwConstants.GLFW_KEY_ESCAPE))
        {
            Glfw.SetWindowShouldClose(_glfwWindow, GlfwConstants.GLFW_TRUE);
        }

        Glfw.SwapBuffers(_glfwWindow);
        Glfw.PollEvents();
    }
}
