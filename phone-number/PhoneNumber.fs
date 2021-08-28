module PhoneNumber

open System

let indexOfSubscriberNumber = 3

let inline charToInt c = int c - int '0'

let getDiggits input =
    input
    |> Seq.filter Char.IsDigit
    |> Seq.map charToInt
    |> Seq.toList

let test =
    [ 0 .. 9 ]
    |> List.rev
    |> List.map (fun n -> Math.Pow((float) 10, (float) n))

let getNumberFromDigits diggits =
    List.zip test diggits
    |> List.map (fun (x, y) -> (uint64) x * (uint64) y)
    |> List.sum



let cleanTen diggits =
    if diggits
       |> List.item 0 = 0 then
        Error "area code cannot start with zero"
    else if diggits
            |> List.item 0 = 1 then
        Error "area code cannot start with one"
    else if diggits
            |> List.item 3 = 0 then
        Error "exchange code cannot start with zero"
    else if diggits
            |> List.item 3 = 1 then
        Error "exchange code cannot start with one"
    else
        Ok(diggits |> getNumberFromDigits)

let cleanEleven diggits =
    if diggits
       |> List.head
       <> 1 then
        Error "11 digits must start with 1"
    else
        diggits
        |> List.skip 1
        |> cleanTen

let cleanDigits diggits =
    if diggits
       |> List.length > 11 then
        Error "more than 11 digits"
    else if diggits
            |> List.length < 10 then
        Error "incorrect number of digits"
    else if diggits
            |> List.length = 11 then
        diggits |> cleanEleven
    else
        diggits |> cleanTen


let validateLetter character: string option =
    match character with
    | character when (character |> Char.IsLetter) -> Some "letters not permitted"
    | '@'
    | ':'
    | '!' -> Some "punctuations not permitted"
    | character -> None



let clean input =
    let error =
        input
        |> Seq.map validateLetter
        |> Seq.filter (fun x -> x.IsSome)
        |> Seq.tryHead

    if error.IsSome && error.Value.IsSome then
        Error(error.Value.Value)
    else
        input
        |> getDiggits
        |> cleanDigits
