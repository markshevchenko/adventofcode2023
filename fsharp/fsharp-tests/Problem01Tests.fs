module Problem01Tests

open Xunit
open Problem01

let sample1 = [|
    "1abc2"
    "pqr3stu8vwx"
    "a1b2c3d4e5f"
    "treb7uchet"  
|]

let sampel2 = [|
    "two1nine"
    "eightwothree"
    "abcone2threexyz"
    "xtwone3four"
    "4nineeightseven2"
    "zoneight234"
    "7pqrstsixteen"
|]

[<Fact>]
let ``solve_a_with_sample1_returns_142`` () =
    let actual = solve_a sample1
    
    Assert.Equal(142, actual)


[<Fact>]
let ``solve_b_with_sample2_return_281`` () =
    let actual = solve_b sampel2
    
    Assert.Equal(281, actual)