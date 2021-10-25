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


let someHttpHandler:HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Expression>()
        match values with
        | Ok v ->
            (setStatusCode 200 >=>
             json (CalculateExpression v)) next ctx
        | Error v ->
            (setStatusCode 400 >=> json v) next ctx

let errorHandler (ex : Exception) (logger : ILogger) =
        logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
        clearResponse >=> setStatusCode 500 >=> text ex.Message