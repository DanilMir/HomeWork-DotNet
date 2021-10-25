module HW6.Calculator

open HW6
open HW6.Expression
open Result

let Calculate (val1: decimal) operation (val2: decimal) =
        match operation with
        | "sum" -> Success (val1 + val2)
        | "dif" -> Success (val1 - val2)
        | "mult" -> Success (val1 * val2)
        | "div" ->
        if val2 = 0m then
           Fail "Divide by zero"
        else
           Success (val1 / val2)
        | _ -> Fail "Undefined operation"
        
let CalculateExpression (expression: Expression) =
    match Calculate expression.V1 expression.Operation expression.V2 with
    | Success x -> x
    | Fail msg -> failwith msg