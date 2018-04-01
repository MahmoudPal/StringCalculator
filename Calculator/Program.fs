// Learn more about F# at http://fsharp.org
namespace Calculator

open System

type StringCalculator() =

    member this.add (number : string) =

        let delimiter = [|','; '\n'|]
        let numberList = number.Split delimiter
        if number.Length > 0 then  
            Array.map int numberList |> Array.sum
        else
            0

     
