module HW5.Tests.Parser

open Xunit
open HW5.Parser
open HW5.Result


[<Theory>]
[<InlineData("1", "+", "3", 3)>]
let ``checkArgsCount valid`` arg1 arg2 arg3 expected =
    let actual = checkArgsCount [|arg1; arg2; arg3|]
    Assert.Equal(Success expected, actual)
    
[<Theory>]
[<InlineData("1", "+")>]
let ``checkArgsCount invalid with 2 args count`` arg1 arg2=
    let actual = checkArgsCount [|arg1; arg2|]
    Assert.Equal(Fail "Wrong args count", actual)
    
[<Theory>]
[<InlineData("1", 1)>]
[<InlineData("3", 3)>]
[<InlineData("4", 4)>]
let ``parseValue valid`` arg excepted=
    let actual = parseValue arg
    Assert.Equal(Success excepted, actual)
    
    
[<Theory>]
[<InlineData(".")>]
[<InlineData("*")>]
[<InlineData("/")>]
let ``parseValue invalid`` arg=
    let actual = parseValue arg
    Assert.Equal(Fail "Invalid value", actual)
    
[<Theory>]
[<InlineData("+")>]
[<InlineData("-")>]
[<InlineData("*")>]
[<InlineData("/")>]
let ``parseOperand valid`` arg=
    let actual = parseOperand arg
    Assert.Equal(Success arg, actual)
    
[<Theory>]
[<InlineData(".")>]
let ``parseOperand invalid`` arg=
    let actual = parseOperand arg
    Assert.Equal(Fail "Invalid operand", actual)
    