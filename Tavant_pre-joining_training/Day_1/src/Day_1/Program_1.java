package Day_1;

import java.util.*;

class Temperature{
	public Double convertToFarenheit(Double celsius) {
		return (celsius*9/5)+32;	
	}
	public Double convertToCelsius (Double farenheit) {
		return (farenheit-32.0)*5/9;
	}
}

public class Program_1 {

	private static Scanner in;

	public static void main(String[] args) {
		Temperature t=new Temperature();
		in = new Scanner(System.in);
		System.out.print("Enter 1 for convert To Farenheit\nEnter 2 for convert To Celsius:\n");
		int choice = in.nextInt();
		System.out.println("Enter Temperature");
		Double temp=in.nextDouble(); 
		if(choice==1) {
			System.out.println(t.convertToFarenheit(temp));
		}
		else if(choice==2) {
			System.out.println(t.convertToCelsius(temp));
		}
		else
			System.out.println("Invalid choice");
	}

	public Double convertToFarenheit(double d) {
		return null;
	}

	public Double convertToCelsius(double d) {
		return null;
	}

}
