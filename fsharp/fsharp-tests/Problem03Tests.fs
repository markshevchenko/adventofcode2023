module Problem03Tests

open Xunit
open Problem03

let sample = [|
    "467..114.."
    "...*......"
    "..35..633."
    "......#..."
    "617*......"
    ".....+.58."
    "..592....."
    "......755."
    "...$.*...."
    ".664.598.."
|]


[<Fact>]
let ``solve_a_with_sample_returns_4261`` () =
    let actual = solve_a sample
    
    Assert.Equal(4361, actual)


[<Fact>]
let ``solve_b_with_sample_returns_467835`` () =
    let actual = solve_b sample
    
    Assert.Equal(467835, actual)