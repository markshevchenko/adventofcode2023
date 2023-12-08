module Problem07Tests

open Xunit
open Problem07

let sample = [|
    "32T3K 765"
    "T55J5 684"
    "KK677 28"
    "KTJJT 220"
    "QQQJA 483"
|]


[<Fact>]
let ``string_to_hand_type_a should return valid types for samples`` () =
    Assert.Equal(HandType.FiveOfKind, string_to_hand_type_a "AAAAA")
    Assert.Equal(HandType.FourOfKind, string_to_hand_type_a "AA8AA")
    Assert.Equal(HandType.FullHouse, string_to_hand_type_a "23332")
    Assert.Equal(HandType.ThreeOfKind, string_to_hand_type_a "TTT98")
    Assert.Equal(HandType.TwoPair, string_to_hand_type_a "23432")
    Assert.Equal(HandType.OnePair, string_to_hand_type_a "A23A4")
    Assert.Equal(HandType.HighCard, string_to_hand_type_a "23456")


[<Fact>]
let ``solve_a_with_sample_returns_6440`` () =
    let actual = solve_a sample
    
    Assert.Equal(6440uL, actual)


[<Fact>]
let ``string_to_hand_type_b should return valid types for samples`` () =
    Assert.Equal(HandType.OnePair, string_to_hand_type_b "32T3K")
    Assert.Equal(HandType.TwoPair, string_to_hand_type_b "KK677")
    Assert.Equal(HandType.FourOfKind, string_to_hand_type_b "T55J5")
    Assert.Equal(HandType.FourOfKind, string_to_hand_type_b "KTJJT")
    Assert.Equal(HandType.FourOfKind, string_to_hand_type_b "QQQJA")


[<Fact>]
let ``solve_b_with_sample_returns_5905`` () =
    let actual = solve_b sample
    
    Assert.Equal(5905uL, actual)