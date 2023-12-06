module Problem05Tests

open Xunit
open Problem05

let sample = [|
    "seeds: 79 14 55 13"
    ""
    "seed-to-soil map:"
    "50 98 2"
    "52 50 48"
    ""
    "soil-to-fertilizer map:"
    "0 15 37"
    "37 52 2"
    "39 0 15"
    ""
    "fertilizer-to-water map:"
    "49 53 8"
    "0 11 42"
    "42 0 7"
    "57 7 4"
    ""
    "water-to-light map:"
    "88 18 7"
    "18 25 70"
    ""
    "light-to-temperature map:"
    "45 77 23"
    "81 45 19"
    "68 64 13"
    ""
    "temperature-to-humidity map:"
    "0 69 1"
    "1 0 69"
    ""
    "humidity-to-location map:"
    "60 56 37"
    "56 93 4"
|]

[<Fact>]
let ``interval (50, 98, 2) converts 98 to Some 50, 99 to Some 51, 97 to None and 100 to None`` () =
    let interval = Interval.fromTuple 50u 98u 2u
    
    Assert.Equal(None, interval.convert 97u)
    Assert.Equal(Some 50u, interval.convert 98u)
    Assert.Equal(Some 51u, interval.convert 99u)
    Assert.Equal(None, interval.convert 100u)

[<Fact>]
let ``solve_a_with_sample_returns_35`` () =
    let actual = solve_a sample
    
    Assert.Equal(35u, actual)


[<Fact>]
let ``solve_b_with_sample_returns_0`` () =
    let actual = solve_b sample
    
    Assert.Equal(0, actual)