using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
  public class NativeDictionary<T>
  {
    public int size;
    public string[] slots;
    public T[] values;

    public NativeDictionary(int sz)
    {
      size = sz;
      slots = new string[size];
      values = new T[size];
    }

    public int HashFun(string key)
    {
      // random a [1, p-1], b [0, p-1], simple p - from universal family
      int x = 0, a = 2, b = 3, p = 17;
      foreach (char ch in key) x += (int)ch;
      return (a * x + b) % p % size;
    }

    public bool IsKey(string key)
    {
      if (InternalFind(key) == -1) return false;
      return true;
    }

    public void Put(string key, T value)
    {
      // guaranteed write
      int idx = InternalSeekSlotToWrite(key);
      if (idx == -1) idx = HashFun(key);
      slots[idx] = key;
      values[idx] = value;
    }

    public T Get(string key)
    {
      int idx = InternalFind(key);
      if (idx == -1) return default;
      return values[idx];
    }

    private int InternalFind(string lookup_key) => InternalSeekSlot(lookup_key,
      (slot, key) => string.Compare(slot, key) == 0);

    private int InternalSeekSlotToWrite(string provided_key) => InternalSeekSlot(provided_key,
      (slot, key) => slot == null || string.Compare(slot, key) == 0);

    private int InternalSeekSlot(string key, Func<string, string, bool> condition)
    {
      int h = HashFun(key), step = 3, offset, possible_slot_in_bounds;

      for (offset = 0; offset < step; offset++)
      {
        h += offset; // ensure iterating through all slots
        for (int iteration = h; iteration - h < size; iteration += step)
        {
          possible_slot_in_bounds = iteration % size;
          if (condition(slots[possible_slot_in_bounds], key)) return possible_slot_in_bounds;
        }
      }
      return -1; // when slot not found
    }
  }
}

