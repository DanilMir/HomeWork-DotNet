namespace HW6

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open HW6

module Program =
    let CreateHostBuilder (_: string array) =
        Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(fun webHostBuilder ->
                webHostBuilder
                   .UseStartup<Startup>()
                |> ignore)
    
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
