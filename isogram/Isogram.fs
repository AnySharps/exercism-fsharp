module Isogram

open System

let getLetters str =
    str
    |> Seq.filter Char.IsLetter
    |> Seq.map Char.ToLower
    |> Seq.toList

let isIsogram1 charList =
    charList
    |> Seq.distinct
    |> Seq.length
    |> (=) (charList |> List.length)

let isIsogram str =
    str
    |> getLetters
    |> isIsogram1
