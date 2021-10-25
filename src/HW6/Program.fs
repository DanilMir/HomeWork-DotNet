module HW6.Program

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open HW6
open Startup

module Program =
    let createHostBuilder args =
        Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(fun webBuilder -> webBuilder.UseStartup<Startup>() |> ignore)

    [<EntryPoint>]
    let main _ =
        Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(fun webHostBuilder -> webHostBuilder.UseStartup<Startup>() |> ignore)
            .Build()
            .Run()

        0
