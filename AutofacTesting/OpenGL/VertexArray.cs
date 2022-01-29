using AutofacTesting.Extensions.OpenGL;
using Serilog;

namespace AutofacTesting.OpenGL;

public class VertexArray : GLBase
{
    private readonly uint _id;

    public VertexArray(ILogger logger) 
        : base(logger)
    {
        var vao = new uint[1];
        GL.GenVertexArrays(1, ref vao);
        _id = vao[0];
        GL.BindVertexArray(_id);
    }

    public override void Bind()
    {
        GL.BindVertexArray(_id);
    }

    public override void Unbind()
    {
        GL.BindVertexArray(0);
    }
}
