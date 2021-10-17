module HW5.Calculator

open HW5
open Result

let Calculate (val1: decimal) operation (val2: decimal) =
        match operation with
        | "+" -> Success (val1 + val2)
        | "-" -> Success (val1 - val2)
        | "*" -> Success (val1 * val2)
        | "/" ->
        if val2 = 0m then
           Fail "Divide by zero"
        else
           Success (val1 +  val2)
        | _ -> Fail "Undefined operation"