module ParserTests

open System
open Homework4.Calculator
open Homework4.Parser
open Xunit

[<Theory>]
[<InlineData("1", result.Ok, 1)>]
[<InlineData("2", result.Ok, 2)>]
[<InlineData("3", result.Ok, 3)>]
[<InlineData("4", result.Ok, 4)>]
[<InlineData("5", result.Ok, 5)>]
[<InlineData("6", result.Ok, 6)>]
[<InlineData("7", result.Ok, 7)>]
let ``Parse value valid arguments`` (arg: string, exceptedResult :result, expectedValue: int) =
    let excepted = (exceptedResult, expectedValue)
    let actual = parseValue arg
    Assert.Equal(excepted, actual)
    

[<Theory>]
[<InlineData(".", result.BadValue, 0)>]
[<InlineData("a", result.BadValue, 0)>]
[<InlineData("1z", result.BadValue, 0)>]

let ``Parse value invalid arguments`` (arg: string, exceptedResult :result, expectedValue: int) =
    let excepted = (exceptedResult, expectedValue)
    let actual = parseValue arg
    Assert.Equal(excepted, actual)