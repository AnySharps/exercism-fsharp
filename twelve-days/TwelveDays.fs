module TwelveDays

let days =
    [ "first"; "second"; "third"; "fourth"; "fifth"; "sixth"; "seventh"; "eighth"; "ninth"; "tenth"; "eleventh"; "twelfth" ]

let giftsArray =
    [ "a Partridge in a Pear Tree."
      "two Turtle Doves, and "
      "three French Hens, "
      "four Calling Birds, "
      "five Gold Rings, "
      "six Geese-a-Laying, "
      "seven Swans-a-Swimming, "
      "eight Maids-a-Milking, "
      "nine Ladies Dancing, "
      "ten Lords-a-Leaping, "
      "eleven Pipers Piping, "
      "twelve Drummers Drumming, " ]

let formatRow gifts day = sprintf "On the %s day of Christmas my true love gave to me: %s" gifts day 


let crismtmasLine day = 
    giftsArray.[0..day]
    |> List.reduce(fun x y -> y + x)
    |> formatRow days.[day]


let recite start stop =
    seq { for day in start - 1..stop - 1 do yield crismtmasLine day}
    |> Seq.toList

