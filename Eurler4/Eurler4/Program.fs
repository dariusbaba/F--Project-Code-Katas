// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.
//Find the largest palindrome made from the product of two 3-digit numbers.


let IsPalindrome n = 
       let inv =  n.ToString().ToCharArray() |> Array.rev
       n.ToString().Equals(new string(inv))

let MapToFactors n = 
       let div = seq {999 .. -1 .. 100} |> Seq.tryFind (fun x -> (n % x = 0) && ( n / x).ToString().Length = 3) 
       match div with
       | Some(i) -> (n/Some(i).Value, Some(i).Value)
       | None -> (0,0)

let palindromes = seq {999999 .. -1 .. 10000} 
                  |> Seq.filter IsPalindrome 
                  |> Seq.map MapToFactors 
                  |> Seq.find (fun x -> fst(x) <> 0) 
                  |> (fun x -> (fst(x)*snd(x), x))



