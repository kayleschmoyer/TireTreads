Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.Logging

Public Class Program
    Public Shared Async Function Main(args As String()) As Task
        Dim builder As HostApplicationBuilder = Host.CreateApplicationBuilder(args)

        builder.Configuration.AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True).
            AddEnvironmentVariables()

        builder.Services.AddHostedService(Of Worker)()

        builder.Logging.ClearProviders()
        builder.Logging.AddConsole()

        Dim host As Host = builder.Build()
        Await host.RunAsync()
    End Function
End Class
