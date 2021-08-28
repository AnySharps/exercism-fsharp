module BankAccount



let mutable bankAccount: decimal option ref = ref None

let mkBankAccount() = bankAccount

let openAccount account =
    lock account (fun _ -> account := Some 0.0m)
    account

let closeAccount account =
    lock account (fun _ -> account := None)
    account

let getBalance (account: decimal option ref) = account.Value


let updateBalance change (account: decimal option ref) =
    if account.Value.IsSome then lock account (fun _ -> account := Some(change + account.Value.Value))
    account
