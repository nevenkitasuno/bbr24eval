using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{

  public class HashTable
  {
    public int size;
    public int step;
    public string[] slots;

    public HashTable(int sz, int stp)
    {
      size = sz;
      step = stp;
      slots = new string[size];
      for (int i = 0; i < size; i++) slots[i] = null;
    }

    public int HashFun(string value)
    {
      // random a [1, p-1], b [0, p-1], simple p - from universal family
      int x = 0, a = 2, b = 3, p = 17;
      foreach (char ch in value) x += (int)ch;
      return (a * x + b) % p % size;
    }

    public int SeekSlot(string value) => InternalSeekSlot(value,
      (slot, val) => slot == null || string.Compare(slot, val) == 0);

    public int Put(string value)
    {
      int idx = SeekSlot(value);
      if (idx == -1) return -1;
      slots[idx] = value;
      return idx;
    }

    public int Find(string value) => InternalSeekSlot(value,
      (slot, val) => string.Compare(slot, val) == 0);

    private int InternalSeekSlot(string value, Func<string, string, bool> condition)
    {
      int h = HashFun(value), offset, possible_slot_in_bounds;

      for (offset = 0; offset < step; offset++)
      {
        h += offset; // ensure iterating through all slots
        for (int iteration = h; iteration - h < size; iteration += step)
        {
          possible_slot_in_bounds = iteration % size;
          if (condition(slots[possible_slot_in_bounds], value)) return possible_slot_in_bounds;
        }
      }
      return -1; // when slot not found
    }
  }

}

