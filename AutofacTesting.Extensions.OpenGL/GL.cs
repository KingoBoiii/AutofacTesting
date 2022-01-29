using AutofacTesting.Extensions.OpenGL.Enums;

namespace AutofacTesting.Extensions.OpenGL;

public static class GL
{
    public static void BufferData(uint type, int size, float[] data, GLBufferUsage usage)
    {
        OpenGLDllImport.glBufferData(type, size, data, (uint)usage);
    }

    public static void BindBuffer(uint type, uint buffer)
    {
        OpenGLDllImport.glBindBuffer(type, buffer);
    }

    public static void GenBuffers(int count, ref uint[] buffers)
    {
        OpenGLDllImport.glGenBuffers(count, buffers);
    }

    public static void ClearColor(float red, float green, float blue, float alpha)
    {
        OpenGLDllImport.glClearColor(red, green, blue, alpha);
    }

    public static void Clear(GLClearMask mask)
    {
        OpenGLDllImport.glClear((uint)mask);
    }

    public static void Clear(uint mask)
    {
        OpenGLDllImport.glClear(mask);
    }

    public static void Viewport(int x, int y, int width, int height)
    {
        OpenGLDllImport.glViewport(x, y, width, height);
    }
}
