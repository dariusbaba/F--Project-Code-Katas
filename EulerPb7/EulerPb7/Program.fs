
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

module EulerPb7.Main

open System

//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//What is the 10 001st prime number?

let  prime (n:int,list:list<int>)=
   let rez = list 
             |> Seq.takeWhile (fun y -> y <  n/2) 
             |> Seq.tryFind (fun x -> n % x = 0) 
   match rez with
   | Some(x) -> Some((n,list),((n+2), list))
   | None -> Some((n,list),((n+2) , ( list @ [n])))


let genPrime n = (3,[2]) 
                |> Seq.unfold (fun (x,y) -> prime (x,y)) 
                |> Seq.find (fun x -> (snd x).Length = n)
                |> snd 
                |> List.rev  // ugly..but works for now
                |> List.head
                        
//works but needs a lot of perf improvement -> don't test the even numbers / don't scan entire steeve...etc