module HW5.Tests.Calculator

open HW5
open Xunit
open Calculator
open Result

[<Theory>]
[<InlineData(1, "+", 2, 3)>]
[<InlineData(1, "-", 2, -1)>]
[<InlineData(1, "*", 2, 2)>]
[<InlineData(1, "/", 1, 1)>]
let ``Calculate valid`` val1 operand val2 expected =
    let actual = Calculate val1 operand val2
    Assert.Equal(Success expected, actual)

[<Theory>]
[<InlineData(1, "0", 2)>]
let ``Calculate invalid operand`` val1 operand val2 =
    let actual = Calculate val1 operand val2
    Assert.Equal(Fail "Undefined operation", actual)
    
[<Theory>]
[<InlineData(1, "/", 0)>]
let ``Calculate divide by zero`` val1 operand val2 =
    let actual = Calculate val1 operand val2
    Assert.Equal(Fail "Divide by zero", actual)

