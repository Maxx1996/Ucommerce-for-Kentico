package Day_1;

import java.util.*;

class MarkValidator12{
	public boolean isPass(int marks) {
		if(marks>=40.0)
			return true;
		else
			return false;
		
	}
	public String markGrade(int marks) {
		int c=convert(marks);
		String p = null;
		switch(c) {
		
		case 1:  p="Grade A";
				 break;
		case 2:  p="Grade B";
				 break;
		case 3:  p="Grade C";
				 break;
		case 4:  p="Grade D";
		}
		return p;
	}
	public int convert(int marks) {
		
		if(marks>90)
			return 1;
		else if(marks>75)
			return 2;
		else if(marks>60)
			return 3;
		else
			return 4;
		
	}
}


public class Program_3 {

	private static Scanner in;

	public static void main(String[] args) {
		in = new Scanner(System.in);
		MarkValidator12 m=new MarkValidator12();
		System.out.println("Enter your marks:");
		int marks=in.nextInt();
		if(marks>=0 && marks<=100) {
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
