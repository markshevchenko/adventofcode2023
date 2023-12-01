module Problem01

open System

let get_number line =
    let first_digit = line |> Seq.find Char.IsDigit
    let last_digit = line |> Seq.findBack Char.IsDigit
    
    (string first_digit) + (string last_digit) |> int


let solve_a lines =
    lines
    |> Seq.map get_number
    |> Seq.sum


let solve_b lines =
    lines
    |> Seq.map get_number
    |> Seq.sum
