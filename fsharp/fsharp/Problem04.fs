module Problem04

open FParsec
open Utils

type Card =
    { number: int
      win_numbers: Set<int>
      your_numbers: Set<int>
      mutable count: int }

    member this.win_count =
        Set.intersect this.win_numbers this.your_numbers |> Set.count



let pprefix = skipString "Card" >>. spaces >>. pint32 .>> skipChar ':' .>> spaces
let pnumbers = many (pint32 .>> spaces) |>> Set
let pcard = pipe3 pprefix pnumbers (skipChar '|' >>. spaces >>. pnumbers) (fun number win_numbers your_numbers ->
    { number = number
      win_numbers = win_numbers
      your_numbers = your_numbers
      count = 1 })


let solve_a lines =
    lines
    |> Seq.map (run pcard)
    |> Seq.choose Option.fromParseResult
    |> Seq.map (fun card -> card.win_count)
    |> Seq.filter ((<>) 0)
    |> Seq.map (fun n -> 1 <<< (n - 1))
    |> Seq.sum


let solve_b lines =
    let mutable cards =
        lines
        |> Seq.map (run pcard)
        |> Seq.choose Option.fromParseResult
        |> Seq.toArray
    
    for i = 0 to cards.Length - 1 do
        let win_count = cards.[i].win_count
        for j = 1 to win_count do
            cards.[i + j].count <- cards.[i + j].count + cards.[i].count
            
    Seq.sumBy (fun card -> card.count) cards