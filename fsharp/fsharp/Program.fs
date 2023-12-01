open System
open Utils

let arg = Environment.GetCommandLineArgs ()
       |> Seq.skip 1
       |> Seq.tryHead
let input_lines = Console.In |> Seq.from_reader 
match arg with
| Some "1a" -> input_lines |> Problem01.solve_a |> printfn "%d"
| _ -> printfn "Advent of Code 2023 (https://adventofcode.com)"
       printfn "Run: adventofcode2023 problem"
       printfn "     problem is one of 1a"
       printfn "                       1b"
       printfn "The utility reads input from stdin and prints result to stdout."