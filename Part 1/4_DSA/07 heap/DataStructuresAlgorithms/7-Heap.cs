using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
	public class Heap
	{

		public int[] HeapArray; // хранит неотрицательные числа-ключи
		private int _count;
		private int _heapSize;

		public Heap()
		{
			HeapArray = null;
			_count = 0;
		}

		public void MakeHeap(int[] a, int depth)
		{
			_heapSize = PowerOfTwo(depth + 1) - 1;
			HeapArray = new int[_heapSize];
			_count = 0;
			bool isFull = false;
			for (int i = 0; i < a.Length && !isFull; i++) isFull = !Add(a[i]);
		}
		private static int PowerOfTwo(int power) => 1 << power;

		public int GetMax()
		{
			// вернуть значение корня и перестроить кучу
			if (_count == 0) return -1; // если куча пуста
			int maxOfHeap = HeapArray[0];
			HeapArray[0] = HeapArray[--_count];
			HeapArray[_count] = 0;
			InternalDownHeap(0);
			return maxOfHeap;
		}

		private void InternalDownHeap(int i)
		{
			int max = InternalMaxFromParentAndChildren(i);
            if (max != i)
            {
                InternalSwap(ref HeapArray[i], ref HeapArray[max]);
                InternalDownHeap(max);
            }
		}

		private int InternalMaxFromParentAndChildren(int parent)
		{
			int max = parent, leftChild = InternalLeftChild(parent), rightChild = InternalRightChild(parent);
			if (leftChild < _count && HeapArray[max] < HeapArray[leftChild]) max = leftChild;
			if (rightChild < _count && HeapArray[max] < HeapArray[rightChild]) max = rightChild;
			return max;
		}
		private int InternalParent(int node) => (node - 1) / 2;
		private int InternalLeftChild(int node) => node * 2 + 1;
		private int InternalRightChild(int node) => node * 2 + 2;
		public bool Add(int key)
		{
			if (_count == _heapSize) return false;
			HeapArray[_count++] = key;
			for (int i = _count - 1; i != 0 && HeapArray[InternalParent(i)] < HeapArray[i]; i = InternalParent(i))
				InternalSwap(ref HeapArray[InternalParent(i)], ref HeapArray[i]);
			return true;
		}

		private static void InternalSwap<T>(ref T left, ref T right)
		{
			T temp;
			temp = left;
			left = right;
			right = temp;
		}
	}
}

