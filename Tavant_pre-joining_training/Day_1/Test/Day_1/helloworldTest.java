package Day_1;

import static org.junit.Assert.assertEquals;
import org.junit.jupiter.api.Test;

class helloworldTest {

	@Test
	void testString() {
		String s=Hello_world.getMessage();
		String act="Hello world!";
		assertEquals(s,act);
	}
}
