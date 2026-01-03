using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
  public class aBST
  {
    public int? [] Tree; // массив ключей
	
    public aBST(int depth)
    {
      // правильно рассчитайте размер массива для дерева глубины depth:
      int tree_size = PowerOfTwo(depth + 1) - 1;
      Tree = new int?[ tree_size ];
      for(int i=0; i<tree_size; i++) Tree[i] = null;
    }
    private static int PowerOfTwo(int power) => 1 << power;
	
    // ищем в массиве индекс ключа
    public int? FindKeyIndex(int key) => InternalFindKey(key, 0);
    private int? InternalFindKey(int key, int index)
    {
        if (index >= Tree.Length) return null; // не найден
        if (Tree[index] is null) return -index;
        if (Tree[index] == key) return index;
        if (key < Tree[index]) return InternalFindKey(key, 2 * index + 1); // left child
        if (key > Tree[index]) return InternalFindKey(key, 2 * index + 2); // right child

        throw new InvalidOperationException();
    }
	
    public int AddKey(int key)
    {
      // добавляем ключ в массив
      int? nullable_index = FindKeyIndex(key);
      if (nullable_index == null) return -1;
      int index = (int)nullable_index;
      if (index == 0)
      {
        Tree[index] = key;
        return 0;
      }
      if (index < 0)
      {
        Tree[-index] = key;
        return -index;
      }
      return index;
      // индекс добавленного/существующего ключа или -1 если не удалось
    }
	
  }
}  