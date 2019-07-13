package Day_1;

import static org.junit.Assert.assertEquals;
import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class program5Test {

	@Test
	public void test()
	{
		Factorial t = new Factorial();
		int a = t.calculateFactorial(5);
		int e = 120;
		assertEquals(a,e);
	}

}
