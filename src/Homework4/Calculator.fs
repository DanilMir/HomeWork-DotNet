namespace Homework4

open System
module Calculator =
    
    type result =
        | Ok = 0
        | BadValue = 1
        | UndefinedOperation = 2
        | WrongCountOfArgs = 3
        | DivideByZero = 4
        
    let Calculate val1 operation val2 =
        match operation with
        | "+" -> (result.Ok, val1 + val2)
        | "-" -> (result.Ok, val1 - val2)
        | "*" -> (result.Ok, val1 * val2)
        | "/" ->
        if val2 = 0 then
           (result.DivideByZero, 0)
        else
           (result.Ok, val1 / val2)
        | _ -> (result.UndefinedOperation, 0)