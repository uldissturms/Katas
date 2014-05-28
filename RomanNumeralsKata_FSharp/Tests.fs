namespace RomanNumeralsKata.Tests
open NUnit.Framework

module Impl =
    let arabicToRoman arabic = 
       (String.replicate arabic "I")
        .Replace("IIIII","V")
        .Replace("VV","X")
        .Replace("XXXXX","L")
        .Replace("LL","C")
        .Replace("CCCCC","D")
        .Replace("DD","M")
        .Replace("IIII","IV")
        .Replace("VIV","IX")
        .Replace("XXXX","XL")
        .Replace("LXL","XC")
        .Replace("CCCC","CD")
        .Replace("DCD","CM")

[<TestFixture>]
type Scenarious() =
    [<TestCase(1, Result = "I")>]
    [<TestCase(2, Result = "II")>]
    [<TestCase(4, Result = "IV")>]
    [<TestCase(5, Result = "V")>]
    [<TestCase(9, Result = "IX")>]
    [<TestCase(10, Result = "X")>]
    [<TestCase(900, Result = "CM")>]
    [<TestCase(1000, Result = "M")>]
    [<TestCase(3497, Result = "MMMCDXCVII")>]
    member x.All arabic =
        Impl.arabicToRoman arabic