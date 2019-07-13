package Day_1;
import java.util.*;
class SumOfNumbers{
	
	public int sumOfEvenNumbers(int start, int end){
		int sum=0;
		for(int i=start;i<=end;i=i+2) {
			sum=sum+i;
		}
		return sum;
	}
	
	
	public int sumOfOddNumbers( int start, int end) {
		int sum=0;
		for(int i=start;i<=end;i=i+2) {
			sum=sum+i;
		}
		return sum;
	}
}


public class Program_4 {

	public static void main(String[] args) {
		Scanner in=new Scanner(System.in);
		SumOfNumbers s=new SumOfNumbers();
		System.out.println("Enter the limit");
		int start = in.nextInt();
		int end = in.nextInt();
		if(start%2==0) {
			System.out.println("Even:"+s.sumOfEvenNumbers(start,end));
			System.out.println("Odd:"+s.sumOfOddNumbers(start+1,end));
		}
		else {
			System.out.println("Odd:"+s.sumOfOddNumbers(start,end));
			System.out.println("Even:"+s.sumOfEvenNumbers(start+1,end));
		}
			
		
		

	}

}
