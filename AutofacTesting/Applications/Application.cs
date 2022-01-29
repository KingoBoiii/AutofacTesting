using AutofacTesting.Extensions.OpenGL;
using AutofacTesting.Extensions.OpenGL.Enums;
using AutofacTesting.OpenGL;
using AutofacTesting.Windows;
using Serilog;

namespace AutofacTesting.Applications;

public class Application : ApplicationBase
{
    private VertexArray _vao;
    private VertexBuffer _vbo;
    private IndexBuffer _ibo;
    private Shader _shader;

    public Application(ILogger logger, IWindow window)
        : base(logger, window)
    {
        Logger.Information("Hello from Application");

        //float[] vertices = new float[3 * 3]
        //{
        //    -0.5f, -0.5f, 0.0f,
        //     0.5f, -0.5f, 0.0f,
        //     0.0f,  0.5f, 0.0f
        //};

        float[] vertices = new float[4 * 3] {
             0.5f,  0.5f, 0.0f,  // top right
             0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f   // top left 
        };
        uint[] indices = new uint[2 * 3] {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };

        _vao = new VertexArray(logger);
        _vbo = new VertexBuffer(logger, sizeof(float) * 12, vertices);
        _ibo = new IndexBuffer(logger, 6, indices);

        GL.VertexAttribPointer(0, 3, GLConstants.GL_FLOAT, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        _shader = new Shader(logger);
    }

    protected override void Update(float deltaTime)
    {
        GL.ClearColor(0.8f, 0.3f, 0.2f, 1.0f);
        GL.Clear(GLClearMask.ColorBufferBit);

        _shader.Bind();
        _vao.Bind();
        _vbo.Bind();
        _ibo.Bind();
        GL.DrawElements(GLConstants.GL_TRIANGLES, _ibo.Count, GLConstants.GL_UNSIGNED_INT);
    }
}
