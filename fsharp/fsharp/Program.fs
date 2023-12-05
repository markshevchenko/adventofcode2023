open System
open Utils

let arg = Environment.GetCommandLineArgs ()
       |> Seq.skip 1
       |> Seq.tryHead
let input_lines = Console.In |> Seq.from_reader 
match arg with
| Some "1a" -> input_lines |> Problem01.solve_a |> printfn "%d"
| Some "1b" -> input_lines |> Problem01.solve_b |> printfn "%d"
| Some "2a" -> input_lines |> Problem02.solve_a |> printfn "%d"
| Some "2b" -> input_lines |> Problem02.solve_b |> printfn "%d"
| Some "3a" -> input_lines |> Problem03.solve_a |> printfn "%d"
| Some "3b" -> input_lines |> Problem03.solve_b |> printfn "%d"
| Some "4a" -> input_lines |> Problem04.solve_a |> printfn "%d"
| Some "4b" -> input_lines |> Problem04.solve_b |> printfn "%d"
| _ -> printfn "Advent of Code 2023 (https://adventofcode.com)"
       printfn "Run: adventofcode2023 problem"
       printfn "     problem is one of 1a-4a"
       printfn "                       1b-4b"
       printfn "The utility reads input from stdin and prints result to stdout."