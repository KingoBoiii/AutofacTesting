using Serilog;
using Autofac;
using AutofacTesting.DependencyInjection;
using AutofacTesting.Applications;
using AutofacTesting.Windows;

var builder = new ContainerBuilder();

builder.RegisterType<Application>();

builder.Register((cc) =>
{
    return new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
}).AsImplementedInterfaces();

builder.RegisterWindow<GLWindow>();

var container = builder.Build();

using (var scope = container.BeginLifetimeScope())
{
    var application = scope.Resolve<Application>();
    application.Run();
}

