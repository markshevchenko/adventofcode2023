module Problem06

open System
open FParsec
open Utils

let pvalues_a = many1 letter >>. skipChar ':' >>. spaces >>. many (puint64 .>> spaces)
let pvalues_b = many1 letter >>. skipChar ':' >>. spaces >>. manyStrings (many1Chars digit .>> spaces) |>> uint64

let get_count (time, distance) =
    let a = -1.0
    let b = float time
    let c = -(float distance)
    let d = b * b - 4.0 * a * c
    let x1 = (-b - sqrt d)/(2.0 * a)
    let x2 = (-b + sqrt d)/(2.0 * a)
    
    let left = min x1 x2
    let right = max x1 x2
    let left = if ceil left = left then left + 1.0 else left
    let right = if floor right = right then right - 1.0 else right
    
    (right |> floor |> int) - (left |> ceil |> int) + 1

let solve_a lines =
    let lines = Seq.toArray lines
    let times = run pvalues_a lines.[0] |> unwrap
    let distances = run pvalues_a lines.[1] |> unwrap
    distances
        |> List.zip times
        |> List.map get_count
        |> List.fold (*) 1

let solve_b lines =
    let lines = Seq.toArray lines
    let time = run pvalues_b lines.[0] |> unwrap
    let distance = run pvalues_b lines.[1] |> unwrap
    
    get_count (time, distance)
