using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
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
      return ((a * x + b) % p) % size;
    }

    public int SeekSlot(string value)
    {
      int h = HashFun(value);

      int possible_slot = h;

      while (possible_slot - h < size)
      {
        if (slots[possible_slot % size] == null
          || slots[possible_slot % size] == value)
          return possible_slot;

        possible_slot += step;
      }

      return -1; // when slot not found
    }

    public int Put(string value)
    {
      int idx = SeekSlot(value);
      if (idx == -1) return -1;
      slots[idx] = value;
      return idx;
    }

    public int Find(string value)
    {
      int h = HashFun(value);
      int possible_slot = h;
      while (possible_slot - h < size)
      {
        if (slots[possible_slot % size] == value) return possible_slot;
        possible_slot += step;
      }
      return -1;
    }
  }

}

