module Problem09

let diffs sequence =
    sequence
    |> Seq.pairwise
    |> Seq.map (fun (a, b) -> b - a)

let rec many_diffs sequence =
    seq {
        yield sequence
        if Seq.exists ((<>) 0) sequence
        then yield! many_diffs (diffs sequence)
    }
    
let parse (line: string) =
    line.Split(' ') |> Seq.map int

let solve_a lines =
    lines
    |> Seq.map parse
    |> Seq.map many_diffs
    |> Seq.map (fun diffs -> diffs |> Seq.map Seq.last |> Seq.sum)
    |> Seq.sum

let solve_b lines =
    lines
    |> Seq.map parse
    |> Seq.map many_diffs
    |> Seq.map (fun diffs -> diffs |> Seq.map Seq.head |> Seq.rev |> Seq.fold (fun state next -> next - state) 0)
    |> Seq.sum
