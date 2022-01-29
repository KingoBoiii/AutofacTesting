using AutofacTesting.Extensions.OpenGL;
using AutofacTesting.Extensions.OpenGL.Enums;
using AutofacTesting.Windows;
using Serilog;

namespace AutofacTesting.Applications;

public class Application : ApplicationBase
{
    private uint _vbo;

    public Application(ILogger logger, IWindow window)
        : base(logger, window)
    {
        Logger.Information("Hello from Application");

        float[] vertices = new float[3 * 3]
        {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        };

        GL.GenBuffers(1, ref _vbo);
    }

    protected override void Update(float deltaTime)
    {
        GL.ClearColor(0.8f, 0.3f, 0.2f, 1.0f);
        GL.Clear(GLClearMask.ColorBufferBit);
    }
}
