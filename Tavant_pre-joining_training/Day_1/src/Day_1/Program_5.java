package Day_1;
import java.util.*;
class Factorial{
	public int calculateFactorial(int n){
		
		if(n==0)
			return 1;
		return n*calculateFactorial(n-1);
	}
}

public class Program_5 {

	public static void main(String[] args) {
		Factorial f = new Factorial();
		Scanner in=new Scanner(System.in);
		System.out.println("Enter the number:");
		int n=in.nextInt();
		System.out.println(f.calculateFactorial(n));

	}

}
