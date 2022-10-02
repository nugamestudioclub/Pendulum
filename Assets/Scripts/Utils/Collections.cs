using System;
using System.Collections.Generic;

namespace Utils {
	public static class Collections {
		public static int Normalize(int index, int length) {
			if( length <= 0 )
				throw new IndexOutOfRangeException();

			return index >= 0 ? index % length : length - (-index % length);
		}

        public static void Shuffle<T>(this Random random, IList<T> list) {
            int i = list.Count;
            while( i > 1 ) {
                int n = random.Next(i--);
				(list[n], list[i]) = (list[i], list[n]);
			}
		}
    }
}