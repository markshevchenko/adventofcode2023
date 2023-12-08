module Problem07

type HandType =
    | FiveOfKind = 7
    | FourOfKind = 6
    | FullHouse = 5
    | ThreeOfKind = 4
    | TwoPair = 3
    | OnePair = 2
    | HighCard = 1


let string_to_hand_type_a (s: string) =
    let counters =
        s
        |> Seq.groupBy id
        |> Seq.map (fun (key, group) -> Seq.length group)
        |> Seq.sort
        |> Seq.toArray
        
    match counters with
    | [| 5 |] -> HandType.FiveOfKind
    | [| 1; 4 |] -> HandType.FourOfKind
    | [| 2; 3 |] -> HandType.FullHouse
    | [| 1; 1; 3 |] -> HandType.ThreeOfKind
    | [| 1; 2; 2 |] -> HandType.TwoPair
    | [| 1; 1; 1; 2 |] -> HandType.OnePair
    | _ -> HandType.HighCard
    
let parse (s: string) =
    match s.Split(' ') with
    | [| hand; amount |] -> (hand, uint64 amount)
    | _ -> failwith "Invalid format"


let card_code_a = function
    | '2' -> 2
    | '3' -> 3
    | '4' -> 4
    | '5' -> 5
    | '6' -> 6
    | '7' -> 7
    | '8' -> 8
    | '9' -> 9
    | 'T' -> 10
    | 'J' -> 11
    | 'Q' -> 12
    | 'K' -> 13
    | 'A' -> 14
    | _ -> failwith "Invalid card"
    
    
let compare_cards_a card1 card2 =
    card_code_a card1 - card_code_a card2
    

let card_code_b card =
    if card = 'J' then 1 else card_code_a card
    

let compare_cards_b card1 card2 =
    card_code_b card1 - card_code_b card2


let comparer_a (hand1, _) (hand2, _) =
    let handType1 = string_to_hand_type_a hand1
    let handType2 = string_to_hand_type_a hand2
    if handType1 > handType2 then 1
    elif handType1 < handType2 then -1
    else
        Seq.compareWith compare_cards_a hand1 hand2


let string_to_hand_type_b (s: string) =
    let counters =
        s
        |> Seq.groupBy id
        |> Seq.map (fun (key, group) -> (key, Seq.length group))
        |> Seq.sortBy snd
        |> Seq.toArray
        
    match counters with
    | [| (_, 5) |] -> HandType.FiveOfKind
    | [| ('J', 1); (_, 4) |] -> HandType.FiveOfKind
    | [| (_, 1); ('J', 4) |] -> HandType.FiveOfKind
    | [| (_, 1); (_, 4) |] -> HandType.FourOfKind
    | [| ('J', 2); (_, 3) |] -> HandType.FiveOfKind
    | [| (_, 2); ('J', 3) |] -> HandType.FiveOfKind
    | [| (_, 2); (_, 3) |] -> HandType.FullHouse
    | [| ('J', 1); (_, 1); (_, 3) |] -> HandType.FourOfKind
    | [| (_, 1); ('J', 1); (_, 3) |] -> HandType.FourOfKind
    | [| (_, 1); (_, 1); ('J', 3) |] -> HandType.FourOfKind
    | [| (_, 1); (_, 1); (_, 3) |] -> HandType.ThreeOfKind
    | [| ('J', 1); (_, 2); (_, 2) |] -> HandType.ThreeOfKind
    | [| (_, 1); ('J', 2); (_, 2) |] -> HandType.FourOfKind
    | [| (_, 1); (_, 2); ('J', 2) |] -> HandType.FourOfKind
    | [| (_, 1); (_, 2); (_, 2) |] -> HandType.TwoPair
    | [| ('J', 1); (_, 1); (_, 1); (_, 2) |] -> HandType.ThreeOfKind
    | [| (_, 1); ('J', 1); (_, 1); (_, 2) |] -> HandType.ThreeOfKind
    | [| (_, 1); (_, 1); ('J', 1); (_, 2) |] -> HandType.ThreeOfKind
    | [| (_, 1); (_, 1); (_, 1); ('J', 2) |] -> HandType.ThreeOfKind
    | [| (_, 1); (_, 1); (_, 1); (_, 2) |] -> HandType.OnePair
    | [| ('J', 1); (_, 1); (_, 1); (_, 1); (_, 1) |] -> HandType.OnePair
    | [| (_, 1); ('J', 1); (_, 1); (_, 1); (_, 1) |] -> HandType.OnePair
    | [| (_, 1); (_, 1); ('J', 1); (_, 1); (_, 1) |] -> HandType.OnePair
    | [| (_, 1); (_, 1); (_, 1); ('J', 1); (_, 1) |] -> HandType.OnePair
    | [| (_, 1); (_, 1); (_, 1); (_, 1); ('J', 1) |] -> HandType.OnePair
    | _ -> HandType.HighCard
        

let comparer_b (hand1, _) (hand2, _) =
    let handType1 = string_to_hand_type_b hand1
    let handType2 = string_to_hand_type_b hand2
    if handType1 > handType2 then 1
    elif handType1 < handType2 then -1
    else
        Seq.compareWith compare_cards_b hand1 hand2


let solve_a lines =
    lines
    |> Seq.map parse
    |> Seq.sortWith comparer_a
    |> Seq.mapi (fun i (_, amount) -> uint64 (i + 1) * amount)
    |> Seq.sum

let solve_b lines =
    lines
    |> Seq.map parse
    |> Seq.sortWith comparer_b
    |> Seq.mapi (fun i (_, amount) -> uint64 (i + 1) * amount)
    |> Seq.sum

