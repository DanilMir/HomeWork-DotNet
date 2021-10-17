module HW5.Parser

open System
open HW5
open Result

let parseValue (arg: string) =
    match Decimal.TryParse arg with
    | true, x -> Success x
    | _ -> Fail "Invalid value"
    
let parseOperand (arg: string) =
    match arg with
    | "+" -> Success "+"
    | "-" -> Success "-"
    | "*" -> Success "*"
    | "/" -> Success "/"
    | _ -> Fail "Invalid operand"
