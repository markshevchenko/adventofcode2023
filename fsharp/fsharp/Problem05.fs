module Problem05

open System.Collections.Generic
open FParsec
open Utils

type Interval =
    { from_start: uint
      to_start: uint
      length: uint }
    
    member this.convert value =
        if value >= this.from_start && value <= (this.from_start + this.length - 1u)
        then Some (value - this.from_start + this.to_start)
        else None
        
    static member fromTuple to_start from_start length =
        { from_start = from_start
          to_start = to_start
          length = length }
        
let pseeds = skipString "seeds: " >>. many (puint32 .>> spaces)
let pinterval = pipe3 (puint32 .>> spaces) (puint32 .>> spaces) (puint32 .>> spaces) Interval.fromTuple

let unwrap = function
    | Success (result, _, _) -> result
    | Failure _ -> failwith "Incorrect format"

type Almanac =
    { seeds: uint32 seq
      intervals_seq: Interval seq seq }
    
    static member fromLines lines =
        use reader = new LinesReader(lines)
        let seeds = run pseeds (reader.ReadLine()) |> unwrap
        reader.ReadLine() |> ignore
        reader.ReadLine() |> ignore
        
        let intervals_seq = seq {
            let mutable line = reader.ReadLine()
            let mutable intervals = List<Interval>()
            while line <> null && line <> "" do
                intervals.Add(run pinterval line |> unwrap)
                line <- reader.ReadLine()
                
            yield intervals :> Interval seq
        }
        
        { seeds =  seeds; intervals_seq = intervals_seq }

let solve_a lines =
    let almanac = Almanac.fromLines lines
    0

let solve_b lines = 0