namespace Homework4

open System
open Calculator
module Parser =
    let parseValue (arg: string) =
        match Int32.TryParse(arg) with
        | true, x -> (result.Ok, x)
        | _ -> (result.BadValue, 0)