module Problem08

let rec repeat sequence =
    seq {
        yield! sequence
        yield! repeat sequence
    }

let parse (line: string) =
    let key = line.Substring(0, 3)
    let left = line.Substring(7, 3)
    let right = line.Substring(12, 3)
    
    (key, (left, right))
    

let solve_a lines =
    let lines = lines |> Seq.toArray
    let commands = lines.[0] |> repeat
    let map = Map <| seq {
        for i in 2..lines.Length - 1 do
            yield parse lines.[i]
    }
    
    let scanner name command =
        let next = map.[name]
        match command with
        | 'L' -> fst next
        | 'R' -> snd next
        | _ -> failwith "Unrecognized command"
    
    commands
    |> Seq.scan scanner "AAA"
    |> Seq.takeWhile ((<>) "ZZZ")
    |> Seq.length
    
    
let rec gcd a b =
    match (a,b) with
    | x, 0uL -> x
    | 0uL, y -> y
    | a, b -> gcd b (a % b)

let lcm a b = a * b / (gcd a b)
    

let solve_b lines =
    let lines = lines |> Seq.toArray
    let commands = lines.[0] |> repeat
    let map = Map <| seq {
        for i in 2..lines.Length - 1 do
            yield parse lines.[i]
    }
    
    let scanner name command =
        let next = map.[name]
        match command with
        | 'L' -> fst next
        | 'R' -> snd next
        | _ -> failwith "Unrecognized command"
        
    let get_cycle_length name =
        commands
            |> Seq.scan scanner name
            |> Seq.takeWhile (fun name -> name.[2] <> 'Z')
            |> Seq.length
            
            
    map.Keys
        |> Seq.filter (fun name -> name.[2] = 'A')
        |> Seq.map get_cycle_length
        |> Seq.map uint64
        |> Seq.reduce lcm