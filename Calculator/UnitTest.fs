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






