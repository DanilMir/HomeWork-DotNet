module HW5.Program

open System
open HW5
open Result
open ResultComputation
open Parser
open Calculator

let argsInLine (args: string[]) = String.Join(" ",args)

[<EntryPoint>]
let main args =
    let result = resultBuilder{
        let checkArgsCount = checkArgsCount args
        let! val1 = parseValue args.[0]
        let! operand = parseOperand args.[1]
        let! val2 = parseValue args.[2]
        let! result = Calculate val1 operand val2
        return result
    }
    
    
    match result with
    | Success x -> printf $"Result: {argsInLine args} = {x}"
    | Fail msg -> printf $"Error: {msg}"
    0