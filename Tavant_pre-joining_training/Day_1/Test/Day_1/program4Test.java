package Day_1;

import static org.junit.Assert.assertEquals;
import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class program4Test {

	@Test
	public void test()
	{
		SumOfNumbers t = new SumOfNumbers();
		int a = t.sumOfEvenNumbers(2,10);
		int e = 30;
		assertEquals(a,e);
	}
	
	@Test
	public void test1() {
		SumOfNumbers t = new SumOfNumbers();
		int a = t.sumOfOddNumbers(1,10);
		int e = 25;
		assertEquals(a,e);
	}

}
