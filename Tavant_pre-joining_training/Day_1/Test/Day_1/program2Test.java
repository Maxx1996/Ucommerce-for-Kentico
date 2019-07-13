package Day_1;

import static org.junit.Assert.assertEquals;
import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class program2Test {

	public void test()
	{
		MarkValidator t = new MarkValidator();
		boolean a = t.isPass(36);
		boolean e = false;
		assertEquals(a,e);
	}
	
	@Test
	public void test1() {
		MarkValidator t = new MarkValidator();
		String a = t.markGrade(96);
		String e = "Grade A";
		assertEquals( e, a);
	}

}
