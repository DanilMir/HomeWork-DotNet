module HW6.Calculator

open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open HW6
open HW6.Expression
open Result

let Calculate (val1: decimal) operation (val2: decimal) =
        match operation with
        | "sum" -> Ok (val1 + val2)
        | "dif" -> Ok (val1 - val2)
        | "mult" -> Ok (val1 * val2)
        | "div" ->
        if val2 = 0m then
           Error "Divide by zero"
        else
           Ok (val1 / val2)
        | _ -> Error "Undefined operation"
        
    
let CalculateExpression (expression: Expression) =
    Calculate expression.V1 expression.Operation expression.V2
