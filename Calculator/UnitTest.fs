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






