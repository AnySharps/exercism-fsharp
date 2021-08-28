module Raindrops

open System

let pling number =
    if number % 3 = 0 then "Pling" else ""

let plang number =
    if number % 5 = 0 then "Plang" else ""

let plong number =
    if number % 7 = 0 then "Plong" else ""

let plingPlangPlong number = pling (number) + plang (number) + plong (number)

let convertNumer original converted =
    if converted |> String.IsNullOrEmpty then original else converted

let convert (number: int): string =
    number
    |> plingPlangPlong
    |> convertNumer (number.ToString())
