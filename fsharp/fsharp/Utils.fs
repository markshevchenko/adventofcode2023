module Utils

open System.IO
open FParsec

module Option =
    let fromParseResult = function
        | Success (result, _, _) -> Some result
        | Failure _ -> None


module Seq =
    let from_reader (text_reader: TextReader) = seq {
        let mutable line = text_reader.ReadLine ()
        while line <> null do
            yield line
            line <- text_reader.ReadLine ()
    }


let unwrap = function
    | Success (result, _, _) -> result
    | Failure _ -> failwith "Incorrect format"

