module Hamming



let distance strand1 strand2 =
    strand1
    |> Seq.zip strand2
    |> Seq.filter (fun (x, y) -> x <> y)
    |> Seq.length
