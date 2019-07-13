package Day_1;

import static org.junit.Assert.assertEquals;

import org.junit.jupiter.api.Test;

class program1Test {

	public void test()
	{
		Temperature t = new Temperature();
		double a = t.convertToFarenheit(36.0);
		double e = 96.8;
		double d = 0.00;
		assertEquals( e, a,d);
	}
	
	@Test
	public void test1() {
		Temperature t = new Temperature();
		double a = t.convertToCelsius(96.8);
		double e = 36;
		double d = 0.00;
		assertEquals( e, a,d);
	}
	

}
