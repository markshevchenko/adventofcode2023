module Problem09Tests

open Xunit
open Problem09

let sample = [|
    "0 3 6 9 12 15"
    "1 3 6 10 15 21"
    "10 13 16 21 30 45"
|]


[<Fact>]
let ``solve_a_with_sample_returns_114`` () =
    let actual = solve_a sample
    
    Assert.Equal(114, actual)


[<Fact>]
let ``solve_b_with_sample_returns_2`` () =
    let actual = solve_b sample
    
    Assert.Equal(2, actual)