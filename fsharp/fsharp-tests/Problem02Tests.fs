module Problem02Tests

open Xunit
open Problem02

let sample = [|
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red"
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
|]


[<Fact>]
let ``solve_a_with_sample_returns_8`` () =
    let actual = solve_a sample
    
    Assert.Equal(8, actual)


[<Fact>]
let ``solve_b_with_sample_returns_2286`` () =
    let actual = solve_b sample
    
    Assert.Equal(2286, actual)