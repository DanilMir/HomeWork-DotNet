module HW6.Handler
open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open HW6
open Expression
open Calculator



let processError msg: HttpHandler =
    setStatusCode 400 >=> json msg

let someHttpHandler:HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Expression>()
        (match values with
        | Ok v ->
            let result = CalculateExpression v
            match result with
            | Ok result -> (setStatusCode 200 >=> json result)
            | Error msg -> processError msg
        | Error msg ->
            processError msg) next ctx

let errorHandler (ex : Exception) (logger : ILogger) =
        logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
        clearResponse >=> setStatusCode 500 >=> text ex.Message