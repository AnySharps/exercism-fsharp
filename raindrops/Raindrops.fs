module Raindrops

open System


let convert (number: int): string = 
    let createReplacement  number (devisor, replacement) = if number % devisor = 0 then Some replacement else None  
    [ 3, "Pling"
      5, "Plang"
      7, "Plong" ]
    |> List.choose (createReplacement number)
    |> String.concat ""
    |> function
    | "" -> string number
    | s -> s
