module Problem10

type Matrix(lines: string seq) =
    let matrix = Seq.toArray lines
    
    member _.height = matrix.Length
    member _.width = matrix.[0].Length
    member _.Index(row, column) = matrix.[row].[column]
    member _.findStart () =
        seq {
            for row in 0..matrix.Length - 1 do
                for column in 0..matrix.[row].Length - 1 do
                    if matrix.[row].[column] = 'S'
                    then yield (row, column)
        } |> Seq.head
    member _.get_S_value (row, column) =
        let up =
            match matrix.[row - 1].[column] with
            | '|' | 'F' | '7' -> 'V'
            | _ -> '.'
        let right =
            match matrix.[row].[column + 1] with
            | '-' | 'J' | '7' -> 'H'
            | _ -> '.'
        let down =
            match matrix.[row + 1].[column] with
            | '|' | 'J' | 'L' -> 'V'
            | _ -> '.'
        let left =
            match matrix.[row].[column - 1] with
            | '-' | 'L' | 'F' -> 'H'
            | _ -> '.'
        match up, right, down, left with
        | 'V', _, 'V', _ -> '|'
        | 'V', 'H', _, _ -> 'L'
        | 'V', _, _, 'H' -> 'J'
        | _, 'H', _, 'H' -> '-'
        | _, 'H', 'V', _ -> 'F'
        | _, _, 'V', 'H' -> '7'
        | _ -> failwith "Invalid S"

let solve_a lines = 0

let solve_b lines = 0