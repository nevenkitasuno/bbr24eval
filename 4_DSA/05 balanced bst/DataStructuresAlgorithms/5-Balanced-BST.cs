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
        private static void InternalInsertInTree(int[] tree, int treeSlot, int[] source)
        {
            if(treeSlot >= tree.Length) return;
            int mid = source.Length/2;
            tree[treeSlot] = source[mid];
            InternalInsertInTree(tree, treeSlot + 1, source[0..(mid - 1)]);
            InternalInsertInTree(tree, treeSlot + 2, source[(mid + 1)..]);
        }
	}
}  