module HW5.ResultComputation

type ResultBuilder() =
    member this.Bind(x, f) =
        match x with
        | None -> None
        | Some a -> f a

    member this.Return(x) =
        Some x
        
let resultBuilder = new ResultBuilder()