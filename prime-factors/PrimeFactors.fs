module PrimeFactors

let rec factors number =
    match number with
    | 1L -> List.empty
    | n ->
        seq { 2L .. n }
        |> Seq.filter (fun x -> n % x = 0L)
        |> Seq.head
        |> fun x -> [ int x ] @ (factors (n / x))
