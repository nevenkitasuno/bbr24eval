using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class BSTNode
	{
		public int NodeKey; // ключ узла
		public BSTNode Parent; // родитель или null для корня
		public BSTNode LeftChild; // левый потомок
		public BSTNode RightChild; // правый потомок	
		public int Level; // глубина узла

		public BSTNode(int key, BSTNode parent)
		{
			NodeKey = key;
			Parent = parent;
			LeftChild = null;
			RightChild = null;
			Level = parent == null ? 0 : parent.Level + 1;
		}

		public int CountChildren()
		{
			int count = 0;
			if (LeftChild != null) count++;
			if (RightChild != null) count++;
			return count;
		}
	}

	public class BalancedBST
	{
		public BSTNode Root; // корень дерева

		public BalancedBST()
		{
			Root = null;
		}

		public void GenerateTree(int[] a)
		{
			Array.Sort(a);
			Root = InternalInsertInTree(null, a);
		}
		private static BSTNode InternalInsertInTree(BSTNode parent, int[] source)
		{
			int mid = source.Length / 2;
			BSTNode current = new BSTNode(source[mid], parent);
			if (source.Length == 1) return current;

			int[] left = new int[mid];
			Array.Copy(source, left, mid);
			current.LeftChild = InternalInsertInTree(current, left);

			bool midIsIdxOfLastElement = source.Length == 2;

			if (!midIsIdxOfLastElement) // to avoid IndexOutOfRange that occurs when idx of last element is incremented inside
			{
				int[] right = new int[source.Length - mid - 1];
				Array.Copy(source, mid + 1, right, 0, right.Length);
				current.RightChild = InternalInsertInTree(current, right);
			}

			return current;
		}

		public bool IsBalanced(BSTNode root_node)
		{
			if (root_node == null) return true;

			return	IsBalanced(root_node.RightChild) &&
					IsBalanced(root_node.LeftChild) &&
					InternalAbs(InternalHeight(root_node.LeftChild) - InternalHeight(root_node.RightChild)) <= 1;
		}

		private int InternalHeight(BSTNode node) =>
			node == null ? 0 : 1 + InternalMax(InternalHeight(node.LeftChild), InternalHeight(node.RightChild));
		private int InternalAbs(int n) => n < 0 ? -n : n;
		private int InternalMax(int a, int b) => a > b ? a : b;
	}
}

