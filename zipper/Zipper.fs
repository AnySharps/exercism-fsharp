module Zipper

type Node<'T> =
    { left: Node<'T> option
      value: 'T
      right: Node<'T> option 
      }

type Direction =
    | Right
    | Left
    | No

type Zipper<'T> =
    { prev: Zipper<'T> option
      focus: Node<'T>
      direction: Direction}

let tree value left right =
    { left = left
      value = value
      right = right}


let fromTree tree = { prev = None; focus = tree; direction = Direction.No}


let move direction newNode zipper = newNode |> Option.bind (fun x -> Some {prev = Some zipper; focus = x; direction = direction})

let left zipper = zipper |> move Direction.Left zipper.focus.left 

let right zipper = zipper |> move Direction.Right zipper.focus.right 
    
let value zipper = zipper.focus.value

let fromLeft left prev = {prev = prev.prev; focus = { prev.focus with left = Some left}; direction = prev.direction}

let fromRight right prev = {prev = prev.prev; focus = { prev.focus with right = Some right}; direction = prev.direction}

let up zipper = 
    match zipper.direction with
    | Direction.No -> None
    | Direction.Left -> zipper.prev |> Option.bind (fun x -> Some (x |> fromLeft zipper.focus))
    | Direction.Right -> zipper.prev |> Option.bind (fun x -> Some (x |> fromRight zipper.focus))

let rec toTree zipper = 
    let prevZipperOption = zipper |> up
    match prevZipperOption with
    | None -> zipper.focus
    | Some prevZipper -> prevZipper |> toTree

let setLeft left zipper = {zipper with focus = {zipper.focus with left = left}}

let setRight right zipper = {zipper with focus = {zipper.focus with right = right}}

let setValue value zipper = 
    {zipper with focus = {zipper.focus with value = value}}