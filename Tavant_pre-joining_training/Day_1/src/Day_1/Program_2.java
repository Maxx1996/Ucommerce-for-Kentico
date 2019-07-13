package Day_1;

import java.util.*;

class MarkValidator{
	public boolean isPass(float marks) {
		if(marks>=40.0)
			return true;
		else
			return false;
		
	}
	public String markGrade(float marks) {
		if(marks>90.0)
			return "Grade A";
		else if(marks>75.0)
			return "Grade B";
		else if(marks>60.0)
			return "Grade C";
		else
			return "Grade D";
	}
}


public class Program_2 {

	private static Scanner in;

	public static void main(String[] args) {
		in = new Scanner(System.in);
		MarkValidator m=new MarkValidator();
		System.out.println("Enter your marks:");
		float marks=in.nextFloat();
		if(marks>=0.0 && marks<=100.0) {
		Boolean t = m.isPass(marks);
			if(t) {
				System.out.println("Pass");
				System.out.println(m.markGrade(marks));
			}
			else
				System.out.println("Fail");
		}
		else
			System.out.println("Invalid input");
	}

}
