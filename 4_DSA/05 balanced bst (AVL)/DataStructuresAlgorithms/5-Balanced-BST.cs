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
            InternalInsertInTree(tree, treeSlot * 2 + 1, source[0..mid]);
            InternalInsertInTree(tree, treeSlot * 2 + 2, source[(mid + 1)..]);
        }
    }
}