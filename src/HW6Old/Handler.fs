module HW6.Handler
open Giraffe
open HW6
open Expression
open Calculator
open ResultComputation

let someHttpHandler:HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Expression>()
        match values with
        | Ok v ->
            (setStatusCode 200 >=>
             json (CalculateExpression v)) next ctx
        | Error v ->
            (setStatusCode 400 >=> json v) next ctx