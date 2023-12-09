module Problem08Tests

open Xunit
open Problem08

let sample1 = [|
    "RL"
    ""
    "AAA = (BBB, CCC)"
    "BBB = (DDD, EEE)"
    "CCC = (ZZZ, GGG)"
    "DDD = (DDD, DDD)"
    "EEE = (EEE, EEE)"
    "GGG = (GGG, GGG)"
    "ZZZ = (ZZZ, ZZZ)"
|]


let sample2 = [|
    "LLR"
    ""
    "AAA = (BBB, BBB)"
    "BBB = (AAA, ZZZ)"
    "ZZZ = (ZZZ, ZZZ)"    
|]


let sample3 = [|
    "LR"
    ""
    "11A = (11B, XXX)"
    "11B = (XXX, 11Z)"
    "11Z = (11B, XXX)"
    "22A = (22B, XXX)"
    "22B = (22C, 22C)"
    "22C = (22Z, 22Z)"
    "22Z = (22B, 22B)"
    "XXX = (XXX, XXX)"
|]


[<Fact>]
let ``solve_a_with_sample1_returns_2`` () =
    let actual = solve_a sample1
    
    Assert.Equal(2, actual)


[<Fact>]
let ``solve_a_with_sample2_returns_6`` () =
    let actual = solve_a sample2
    
    Assert.Equal(6, actual)


[<Fact>]
let ``solve_b_with_sample3_returns_6`` () =
    let actual = solve_b sample3
    
    Assert.Equal(6uL, actual)