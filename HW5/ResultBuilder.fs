module HW5.ResultComputation

open Result

type ResultBuilder() =
    member this.Bind(x, f) =
        match x with
        | Success x -> f x
        | Fail msg -> Fail msg

    member this.Return(x) =
        Some x
        
let resultBuilder = new ResultBuilder()