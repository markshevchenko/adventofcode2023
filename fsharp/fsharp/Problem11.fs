module Problem11


type Galaxy =
    { x: int
      y: int }
    
let to_galaxies (lines: string array) =
    seq {
        for y = 0 to lines.Length - 1 do
            for x = 0 to lines.[y].Length - 1 do
                if lines.[y].[x] = '#' then { x = x; y = y }
    }
    
let solve_a lines =
    let galaxies = lines |> Seq.toArray |> to_galaxies |> Seq.toArray
    let pairs =
        seq {
            for i = 0 to galaxies.Length - 2 do
                for j = i + 1 to galaxies.Length - 1 do
                    yield (galaxies.[i], galaxies.[j])
        }
    pairs
    |> Seq.map (fun ({x = x1; y = y1}, {x = x2; y = y2}) -> abs (y2 - y1) + abs (x2 - x1))
    |> Seq.sum
    

let solve_b lines = 0