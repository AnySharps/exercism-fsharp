module BinarySearchTree

type Node<'T> =
    { left: Node<'T> option
      value: 'T
      right: Node<'T> option }

let data node = node.value

let left node = node.left

let right node = node.right


let create items =
    let rec insert x =
        function
        | None ->
            { left = None
              value = x
              right = None }
        | Some(t) when x <= t.value -> { t with left = Some(t.left |> insert x) }
        | Some(t) -> { t with right = Some(t.right |> insert x) }
    items
    |> Seq.fold (fun tree x -> Some(tree |> insert x)) None
    |> Option.get


let sortedData node =
    let rec traverse node =
        seq {
            if node.left.IsSome then yield! traverse (node.left.Value)
            yield node.value
            if node.right.IsSome then yield! traverse (node.right.Value)
        }
    traverse (node) |> Seq.toList
