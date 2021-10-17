module HW5.Tests.ProgramTests

open HW5
open Xunit
open Program

[<Theory>]
[<InlineData("1", "+", "3")>]
let ``Main valid`` arg1 arg2 arg3 =
    let actual = main [|arg1; arg2; arg3|]
    Assert.Equal(0, actual)
    
[<Theory>]
[<InlineData("1", ".", "3")>]
let ``Main invalid`` arg1 arg2 arg3 =
    let actual = main [|arg1; arg2; arg3|]
    Assert.Equal(1, actual)
