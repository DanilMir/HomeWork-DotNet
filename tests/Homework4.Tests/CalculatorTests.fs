module CalculatorTests

open System
open Homework4
open Homework4.Calculator
open Xunit

[<Theory>]
[<InlineData(1, "+", 2, Calculator.result.Ok, 3)>]
[<InlineData(1, "-", 2, Calculator.result.Ok, -1)>]
[<InlineData(1, "*", 2, Calculator.result.Ok, 2)>]
[<InlineData(2, "/", 2, Calculator.result.Ok, 1)>]
let ``Calculate valid arguments`` (val1: int, operation: string, val2: int, exceptedResult :result, expectedValue: int) =
    let excepted = (exceptedResult, expectedValue)
    let actual = Calculate val1 operation val2
    Assert.Equal(excepted, actual)
    
    
[<Theory>]
[<InlineData(1, ".", 2, Calculator.result.UndefinedOperation, 0)>]
[<InlineData(1, "/", 0, Calculator.result.DivideByZero, 0)>]
let ``Calculate invalid arguments`` (val1: int, operation: string, val2: int, exceptedResult :result, expectedValue: int) =
    let excepted = (exceptedResult, expectedValue)
    let actual = Calculate val1 operation val2
    Assert.Equal(excepted, actual)