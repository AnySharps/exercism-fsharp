

module TwoFer

open System


let you = "you"
let twoFer (input: string option): string = $"One for {(you, input) ||> Option.defaultValue}, one for me." //"One for you, one for me."

