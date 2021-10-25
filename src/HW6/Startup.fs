namespace HW6

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open HW6.Handler

module Initialize =
    let webApp =
    choose [ route "/ping" >=> text "pong"
             route "/calculate" >=> someHttpHandler ]

type Startup() =
    member __.ConfigureServices(services: IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member __.Configure (app: IApplicationBuilder) (env: IHostEnvironment) (loggerFactory: ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app
            .UseGiraffeErrorHandler(errorHandler)
            .UseGiraffe Initialize.webApp
