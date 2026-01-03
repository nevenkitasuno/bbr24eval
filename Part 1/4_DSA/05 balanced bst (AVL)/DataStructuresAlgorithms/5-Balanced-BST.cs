using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);
            int[] tree = new int[a.Length];
            InternalInsertInTree(tree, 0, a);
            return tree;
        }
        private static void InternalInsertInTree(int[] tree, int treeSlot, int[] source)
        {
            if (treeSlot >= tree.Length || source.Length == 0) return;
            int mid = source.Length / 2;
            tree[treeSlot] = source[mid];

            int[] left = new int[mid];
            Array.Copy(source, left, mid);

            int[] right = new int[mid];
            Array.Copy(source, mid + 1, right, 0, mid);

            InternalInsertInTree(tree, treeSlot * 2 + 1,left);
            InternalInsertInTree(tree, treeSlot * 2 + 2, right);
        }
    }
}

