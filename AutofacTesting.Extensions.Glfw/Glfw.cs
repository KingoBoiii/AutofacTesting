using AutofacTesting.Extensions.Glfw.Data;
using System.Text;

namespace AutofacTesting.Extensions.Glfw;

public static class Glfw
{
    public static void SetErrorCallback(GlfwCallbacks.GLFWerrorfun callback)
    {
        GlfwDllImport.glfwSetErrorCallback(callback);
    }

    public static void WindowHint(int target, int hint)
    {
        GlfwDllImport.glfwWindowHint(target, hint);
    }

    public static void SwapBuffers(GlfwWindow glfwWindow)
    {
        GlfwDllImport.glfwSwapBuffers(glfwWindow.WindowHandle);
    }

    public static void PollEvents()
    {
        GlfwDllImport.glfwPollEvents();
    }

    public static bool WindowShouldClose(GlfwWindow glfwWindow)
    {
        return GlfwDllImport.glfwWindowShouldClose(glfwWindow.WindowHandle) == GlfwConstants.GLFW_TRUE;
    }

    public static void MakeContextCurrent(GlfwWindow glfwWindow)
    {
        GlfwDllImport.glfwMakeContextCurrent(glfwWindow.WindowHandle);
    }

    public static GlfwWindow CreateWindow(int width, int height, string title)
    {
        var titleBytes = Encoding.UTF8.GetBytes(title);
        var windowHandle = GlfwDllImport.glfwCreateWindow(width, height, titleBytes, IntPtr.Zero, IntPtr.Zero);

        return new GlfwWindow
        {
            WindowHandle = windowHandle
        };
    }

    public static void DestroyWindow(GlfwWindow glfwWindow)
    {
        GlfwDllImport.glfwDestroyWindow(glfwWindow.WindowHandle);
    }

    public static void Terminate()
    {
        GlfwDllImport.glfwTerminate();
    }

    public static bool Init()
    {
        return GlfwDllImport.glfwInit() != GlfwConstants.GLFW_FALSE;
    }
}
