// Learn more about F# at http://fsharp.org
namespace Calculator

open System

type StringCalculator() =


    member this.sum (number : string, delimiter : char[]) =
        let numberList = number.Split delimiter
        Array.map int numberList |> Array.sum 
            
    member this.add (input : string) = 
        match input with
        | "" -> 0
        | _ when input.StartsWith "//" -> this.sum(input.[4..], [|input.[2]|])
        | _ -> this.sum(input, [|','; '\n'|])
     
