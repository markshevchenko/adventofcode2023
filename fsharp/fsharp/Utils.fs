module Utils

open System.IO

module Seq =
    let from_reader (text_reader: TextReader) = seq {
        let mutable line = text_reader.ReadLine ()
        while line <> null do
            yield line
            line <- text_reader.ReadLine ()
    }