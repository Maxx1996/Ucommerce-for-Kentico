package Day_1;

import static org.junit.Assert.assertEquals;
import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class program3Test {

	@Test

		public void test()
		{
			MarkValidator12 t = new MarkValidator12();
			boolean a = t.isPass(36);
			boolean e = false;
			assertEquals(a,e);
		}
		
		@Test
		public void test1() {
			MarkValidator12 t = new MarkValidator12();
			String a = t.markGrade(96);
			String e = "Grade A";
			assertEquals( e, a);
		}

}
