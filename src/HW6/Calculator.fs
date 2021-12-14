module HW6.Calculator

open HW6.Expression

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
