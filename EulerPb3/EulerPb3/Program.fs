
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.



//The prime factors of 13195 are 5, 7, 13 and 29.
//What is the largest prime factor of the number 600851475143 ?

module EulerPb3.Main

open System

let isPrime (x:bigint) = 
   seq {2I .. 1I .. x /2I} 
   |> Seq.map (fun i -> x % i = 0I)
   |> Seq.forall (fun p -> p = false)


//this should be faster...at least we bail out when we find a divisor and therefore we don't generate the
//whole seq
let isPrime2 (x:bigint) = 
    seq {2I .. 1I .. (bigint (Math.Sqrt (float x))) } 
   |> Seq.takeWhile (fun i -> x % i <> 0I)
   |> Seq.length
   |> (fun p -> (bigint p) = ((bigint (Math.Sqrt (float x))) - 1I))
   |> (fun p -> not p) 

let largestPrimeFactor (n:bigint) =
   seq {(bigint (Math.Sqrt (float n))) .. -(1I)..2I}
   |>Seq.tryFind (fun p -> n%p = 0I && isPrime p = true)
   
let result n =
   let x = largestPrimeFactor n 
   match x with
    | None -> n
    | Some x -> x 
   
   
[<EntryPoint>]
let main args = 
    Console.WriteLine("result : {0}", result 600851475143I)
    0

