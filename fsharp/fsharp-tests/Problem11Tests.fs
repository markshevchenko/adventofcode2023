module Problem11Tests

open Xunit
open Problem11

let sample = [|
    "...#......"
    ".......#.."
    "#........."
    ".........."
    "......#..."
    ".#........"
    ".........#"
    ".........."
    ".......#.."
    "#...#....."
|]


[<Fact(Skip = "Not solved")>]
let ``solve_a_with_sample_returns_374`` () =
    let actual = solve_a sample
    
    Assert.Equal(374, actual)


[<Fact>]
let ``solve_b_with_sample_returns_0`` () =
    let actual = solve_b sample
    
    Assert.Equal(0, actual)