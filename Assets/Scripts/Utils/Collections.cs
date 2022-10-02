using System;

namespace Utils {
	public static class Collections {
		public static int Normalize(int index, int length) {
			if( length <= 0 )
				throw new IndexOutOfRangeException();

			return index >= 0 ? index % length : length - (-index % length);
		}
	}
}