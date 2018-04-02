namespace Calculator
open System
open NUnit.Framework

[<TestFixture>]
type Test() = 

    let calculator = StringCalculator()

    [<TestCase("", 0)>]
    member this.``empty string`` input output =
        Assert.AreEqual(output, calculator.add input)

    [<TestCase("4", 4)>]
    member this.``one number`` input output =
        Assert.AreEqual(output, calculator.add input)

    [<TestCase("4,6", 10)>]
    member this.``two numbers`` input output =
        Assert.AreEqual(output, calculator.add input)
    
    [<TestCase("4,6,10", 20)>]
    member this.``multiple numbers`` input output =
        Assert.AreEqual(output, calculator.add input)

    [<TestCase("4\n6,10", 20)>]
    [<TestCase("4\n6\n10", 20)>]
    member this.``support new line as delimiter`` input output =
        Assert.AreEqual(output, calculator.add input)

    [<TestCase("//*\n4*6*10", 20)>]
    [<TestCase("//*\n50*40*10", 100)>]
    [<TestCase("//;\n50;40;10", 100)>]
    member this.``support dynamic delimiter`` input output =
        Assert.AreEqual(output, calculator.add input)

    [<TestCase("//;\n50;-40;-10", "Negatives not allowed: [-40,-10]")>]
    [<TestCase("//;\n-50;-40;-10", "Negatives not allowed: [-50,-40,-10]")>]
    [<TestCase("//;\n-50", "Negatives not allowed: [-50]")>]

    member this.``throw expection when negative number found`` input output =
        let result = Assert.Throws(typeof<System.Exception>, (fun () -> calculator.add input |> ignore))
        Assert.AreEqual(result.Message, output)
    
    [<TestCase("//*\n4*1000*10001", 1004)>]
    [<TestCase("//*\n1000*1000*1000", 3000)>]
    [<TestCase("//;\n1001;10001;10111", 0)>]
    [<TestCase("//;\n999;1;0", 1000)>]
    member this.``ignore numbers that more than 1000`` input output =
        Assert.AreEqual(output, calculator.add input)

    [<TestCase("//[%$#]\n560%$#440", 1000)>]
    [<TestCase("//[$$$]\n560$$$1440", 560)>]
    member this.``support one delimiter with more than one character`` input output =
        Assert.AreEqual(output, calculator.add input)


