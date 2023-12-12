module Problem10Tests

open Xunit
open Problem10

let sample1 = [|
    "....."
    ".S-7."
    ".|.|."
    ".L-J."
    "....."    
|]

let sample2 = [|
    "7-F7-"
    ".FJ|7"
    "SJLL7"
    "|F--J"
    "LJ.LJ"
|]


[<Fact(Skip = "Not solved")>]
let ``solve_a_with_sample1_returns_4`` () =
    let actual = solve_a sample1
    
    Assert.Equal(4, actual)


[<Fact(Skip = "Not solved")>]
let ``solve_a_with_sample2_returns_8`` () =
    let actual = solve_a sample1
    
    Assert.Equal(8, actual)


[<Fact>]
let ``solve_b_with_sample1_returns_0`` () =
    let actual = solve_b sample1
    
    Assert.Equal(0, actual)