module Problem05

open System
open System.Collections.Generic
open System.IO
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

type Almanac =
    { seeds: uint32 seq
      intervals_seq: Interval seq seq }
    
    static member fromLines (lines: string seq) =
        use reader = new StringReader(lines |> String.concat Environment.NewLine)
        let seeds = run pseeds (reader.ReadLine()) |> unwrap
        reader.ReadLine() |> ignore
        
        let mutable intervals_seq = List<Interval seq>();
        let mutable line = reader.ReadLine()
        line <- reader.ReadLine()
        
        while line <> null do
            let mutable intervals = List<Interval>()
            while line <> null && line <> "" do
                let interval = run pinterval line |> unwrap
                intervals.Add(interval)
                line <- reader.ReadLine()
                
            if line = "" then
                line <- reader.ReadLine()
                line <- reader.ReadLine()
                
            intervals_seq.Add(intervals)
        
        { seeds =  seeds; intervals_seq = intervals_seq }

let convert value (intervals: Interval seq) =
   intervals
   |> Seq.choose (fun interval -> interval.convert value)
   |> Seq.tryHead
   |> Option.defaultValue value
   
let convert_all value intervals_seq =
   intervals_seq |> Seq.fold convert value 

let solve_a lines =
    let almanac = Almanac.fromLines lines
    almanac.seeds
    |> Seq.map (fun seed -> convert_all seed almanac.intervals_seq)
    |> Seq.min

let solve_b lines = 0