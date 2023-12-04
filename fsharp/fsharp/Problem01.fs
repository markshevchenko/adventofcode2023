module Problem01

open System
open System.Text.RegularExpressions

let get_number line =
    let first_digit = line |> Seq.find Char.IsDigit |> int
    let last_digit = line |> Seq.findBack Char.IsDigit |> int
    
    10 * first_digit + last_digit


let solve_a lines =
    lines
    |> Seq.map get_number
    |> Seq.sum
    
let values = Map [
    "one", 1
    "two", 2
    "three", 3
    "four", 4
    "five", 5
    "six", 6
    "seven", 7
    "eight", 8
    "nine", 9
    "1", 1
    "2", 2
    "3", 3
    "4", 4
    "5", 5
    "6", 6
    "7", 7
    "8", 8
    "9", 9
]
    
let digits = seq {
    "one"
    "two"
    "three"
    "four"
    "five"
    "six"
    "seven"
    "eight"
    "nine"
    "1"
    "2"
    "3"
    "4"
    "5"
    "6"
    "7"
    "8"
    "9"
}


let find_first (line: string) =
    digits
    |> Seq.map (fun digit -> (line.IndexOf(digit), values.[digit]))
    |> Seq.filter (fun (index, _) -> index <> -1)
    |> Seq.sortBy fst
    |> Seq.head
    |> snd


let find_last (line: string) =
    digits
    |> Seq.map (fun digit -> (-line.LastIndexOf(digit), values.[digit]))
    |> Seq.filter (fun (index, _) -> index <> 1)
    |> Seq.sortBy fst
    |> Seq.head
    |> snd

    
let get_complicated_number line =
    let first_digit = find_first line
    let last_digit = find_last line
    
    10 * first_digit + last_digit


let solve_b lines =
    lines
    |> Seq.map get_complicated_number
    |> Seq.sum
