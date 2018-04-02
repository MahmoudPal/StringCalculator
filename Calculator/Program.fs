// Learn more about F# at http://fsharp.org
namespace Calculator

open System

type StringCalculator() =


    member this.sum (number : string, delimiter : char[]) =
        let threshold = 1000
        let numberList = number.Split delimiter
        let negative, positive = Array.map int numberList |> Array.partition (fun n -> n < 0 )
        if negative.Length > 0 then
            failwith (sprintf "Negatives not allowed: [%s]" <| String.Join(",",negative)) 
        else 
            positive |> Array.filter(fun n -> n <= threshold) |> Array.sum
            
    member this.add (input : string) = 
        match input with
        | "" -> 0
        | _ when input.StartsWith "//" -> this.sum(input.[4..], [|input.[2]|])
        | _ -> this.sum(input, [|','; '\n'|])
     
