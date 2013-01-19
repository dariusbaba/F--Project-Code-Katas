
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
module EulerProblems
open System.Numerics
open System

let rec tryFactors lowerBound upperBound result =
    if lowerBound <= upperBound then
       let t = seq {lowerBound .. upperBound}
       let factor = t |> Seq.tryFind (fun p-> upperBound % lowerBound = 0 )
       match factor with
        | Some(x) -> let newResult = x :: result 
                     tryFactors  lowerBound (upperBound / lowerBound) newResult
        | None -> tryFactors  (lowerBound + 1) upperBound  result
    else
       result
       
let getPrimes n = tryFactors 2 n []

let mapPrimesToTuples x = 
    x |> Seq.countBy (fun p -> p)
    
let generateFactors n =
   seq {n .. -1 .. 2} 
   |> Seq.map (fun x -> getPrimes x) 
   |> Seq.map mapPrimesToTuples
   |> Seq.concat   
   |> Seq.groupBy (fun x -> fst x)
   |> Seq.map (fun x ->  Seq.max (snd x))
   |> Seq.fold (fun acc x -> acc * ( Convert.ToDouble(fst x) **  Convert.ToDouble(fst x))) 1.0
     




