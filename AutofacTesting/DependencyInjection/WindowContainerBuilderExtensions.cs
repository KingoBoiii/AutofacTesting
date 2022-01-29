using Autofac;
using AutofacTesting.Windows;

namespace AutofacTesting.DependencyInjection;
public static class WindowContainerBuilderExtensions
{
    public static ContainerBuilder RegisterWindow<TWindow>(this ContainerBuilder builder)
    where TWindow : class, IWindow
    {
        var windowOptions = new WindowOptions
        {
            Title = "Test Window",
            Width = 1024,
            Height = 768
        };

        builder.RegisterWindow<TWindow>(windowOptions);

        builder.Register((cc) =>
        {
            var windowFactory = cc.Resolve<IWindowFactory<TWindow>>();
            return windowFactory.CreateWindow(windowOptions);
        }).As<IWindow>();

        return builder;
    }

    public static ContainerBuilder RegisterWindow<TWindow>(this ContainerBuilder builder, WindowOptions windowOptions)
        where TWindow : class, IWindow
    {
        builder.RegisterType<WindowFactory<TWindow>>()
            .As<IWindowFactory<TWindow>>();

        return builder;
    }
}
