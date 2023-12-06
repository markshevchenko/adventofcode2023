module Problem06Tests

open Xunit
open Problem06

let sample = [|
    "Time:      7  15   30"
    "Distance:  9  40  200"
|]


[<Fact>]
let ``solve_a_with_sample_returns_288`` () =
    let actual = solve_a sample
    
    Assert.Equal(288, actual)


[<Fact>]
let ``solve_b_with_sample_returns_71503`` () =
    let actual = solve_b sample
    
    Assert.Equal(71503, actual)