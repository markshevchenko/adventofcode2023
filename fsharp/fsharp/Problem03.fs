module Problem03

open System.Text.RegularExpressions

type Matrix(lines: string seq) =
    let matrix = lines |> Seq.map Seq.toArray |> Seq.toArray
    
    member _.height = matrix.Length
    member _.width = matrix.[0].Length
    member this.rows
        with get row = matrix.[row] |> System.String
    member this.Item
        with get (row, column) = if row < 0 then '.'
                                 elif row >= this.height then '.'
                                 elif column < 0 then '.'
                                 elif column >= this.width then  '.'
                                 else matrix.[row].[column]
    member _.around row start finish = seq {
        for column = start - 1 to finish + 1 do
            yield (row - 1, column)
        yield (row, finish + 1)
        for column = finish + 1 downto start - 1 do
            yield (row + 1, column)
        yield (row, start - 1)            
    }
    
let digits = Regex(@"\d+")

let solve_a lines =
    let matrix = Matrix(lines)
    let parts = seq {
        for row in 0..matrix.height - 1 do
            let matches = digits.Matches(matrix.rows row)
            for m in matches do
                let around = matrix.around row m.Index (m.Index + m.Length - 1) |> Seq.map (fun (r, c) -> matrix.[r, c])
                if Seq.exists ((<>) '.') around then
                    yield int m.Value
    }
    
    Seq.sum parts
            

let solve_b lines =
    let matrix = Matrix(lines)
    let parts = seq {
        for row in 0..matrix.height - 1 do
            let matches = digits.Matches(matrix.rows row)
            for m in matches do
                yield! matrix.around row m.Index (m.Index + m.Length - 1)
                    |> Seq.filter (fun (r, c) -> matrix.[r, c] = '*')
                    |> Seq.map (fun (r, c) -> (int m.Value, (r, c)))
    }

    parts
    |> Seq.groupBy snd
    |> Seq.filter (fun (_, numbers) -> Seq.length numbers > 1)
    |> Seq.map (fun (_, numbers) -> numbers |> Seq.map fst |> Seq.fold (*) 1)
    |> Seq.sum