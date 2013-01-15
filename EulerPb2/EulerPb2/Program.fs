
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

//Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
//By starting with 1 and 2, the first 10 terms will be:
//1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
//By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
//find the sum of the even-valued terms.
//

module EulerPb2.Main

open System
open Microsoft.FSharp.Core

let fib (n:bigint) = Seq.unfold  (fun x  ->
            if (snd x > n) then None
            else Some(snd x, (snd x, fst x + snd x))) (0I , 1I) 

let result = fib  4000000I 
             |> Seq.filter (fun p -> p % 2I  = 0I ) 
             |> Seq.sum

[<EntryPoint>]
let main args = 
    Console.WriteLine(result)
    0
