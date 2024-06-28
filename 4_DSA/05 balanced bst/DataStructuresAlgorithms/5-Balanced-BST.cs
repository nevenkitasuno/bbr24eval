using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public static class BalancedBST
	{
		public static int[] GenerateBBSTArray(int[] a) 
		{
            int[] tree = new int[a.Length];
            Array.Sort(a);
            tree[0] = a[a.Length/2];
			return tree;
		}
	}
}  