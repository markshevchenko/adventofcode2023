module Problem02

open FParsec

type Cube =
    | Red
    | Green
    | Blue
    
type Game =
    { id: int
      subsets: (int * Cube) list list }
    
    static member fromTuple (id, subsets) =
        { id = id; subsets = subsets }

    
let pcube = choice [
    skipString "red" |>> fun () -> Red
    skipString "green" |>> fun () -> Green
    skipString "blue" |>> fun () -> Blue ]
let ppair = pint32 .>> spaces .>>. pcube
let psubset = sepBy ppair (pchar ',' >>. spaces)
let psubsets = sepBy psubset (pchar ';' >>. spaces)
let pgame = skipString "Game" >>. spaces >>. pint32
        .>> pchar ':' .>> spaces .>>. psubsets |>> Game.fromTuple
        
        
let toOption = function
    | Success (result, _, _) -> Some result
    | Failure (_, _, _) -> None
    
    
let is_valid_cube (count, cube) =
    match cube with
    | Red -> count <= 12
    | Green -> count <= 13
    | Blue -> count <= 14
    

let solve_a lines =
    lines
    |> Seq.map (run pgame)
    |> Seq.choose toOption
    |> Seq.filter (fun game -> game.subsets |> List.forall (List.forall is_valid_cube))
    |> Seq.map (fun game -> game.id)
    |> Seq.sum
    
let power (cubes: (int * Cube) list list) =
    cubes
    |> List.collect id
    |> List.groupBy snd
    |> List.map (snd >> List.map fst)
    |> List.map List.max
    |> List.fold (*) 1
    
    
let solve_b lines =
    lines
    |> Seq.map (run pgame)
    |> Seq.choose toOption
    |> Seq.map (fun game -> power game.subsets)
    |> Seq.sum
