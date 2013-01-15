
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

//http://projecteuler.net/problem=1
//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
//The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

module EulerPb1.Main

open System

let isMultipleof3or5 x = ((x % 3) = 0) || ((x % 5) = 0)

let sum x = seq { 1 .. x-1} 
            |> Seq.filter isMultipleof3or5
            |> Seq.sum 

let result = sum 10

[<EntryPoint>]
let main args = 
    Console.WriteLine(result)
    0
