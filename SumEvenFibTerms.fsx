//Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
//1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
//By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.


//first we generate an infinite fibo seq
let fibSeq = Seq.unfold (fun (a,b) ->  Some(a,(b, a+b))) (0,1)

fibSeq 
|> Seq.takeWhile (fun n -> n < 4000000) 
|> Seq.sumBy (fun x-> if x%2=0 then x else 0)
|> printf "%d"

