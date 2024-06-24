using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T> : HashTable<T>
    {
        private int _count;

        public PowerSet() : base(20000)
        {
            _count = 0;
        }

        public int Size() => _count;

        public override void Put(T value)
        {
            int hf = HashFun(value);
            if (slots[hf] != null && slots[hf].Contains(value)) return;
            if (slots[hf] == null) slots[hf] = new LinkedList<T>();
            slots[hf].AddLast(value);
            _count++; // only different line from base
        }

        public bool Get(T value)
        {
            // if set contains value return true, otherwise false
            return FindContainingBucket(value) != -1;
        }

        public bool Remove(T value)
        {
            int bucket = FindContainingBucket(value);
            if (bucket == -1) return false;
            slots[bucket].Remove(value);
            _count--;
            return true; // if removed
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            PowerSet<T> result = new PowerSet<T>();
            foreach (T value in set2) if (Get(value)) result.Put(value);
            return result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            PowerSet<T> result = new PowerSet<T>();
            foreach (T value in this) result.Put(value);
            foreach (T value in set2) result.Put(value);
            return result;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            PowerSet<T> result = new PowerSet<T>();
            foreach (T value in this) result.Put(value);
            foreach (T value in set2) result.Remove(value);
            return result;
        }
        // public PowerSet<T> Difference(PowerSet<T> set2)
        // {
        //     PowerSet<T> result = new PowerSet<T>();
        //     foreach (T value in this) if (!set2.Get(value)) result.Put(value);
        //     foreach (T value in set2) if (!Get(value)) result.Put(value);
        //     return result;
        // }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (T value in set2) if (!Get(value)) return false;
            return true;
        }
    }

    public class HashTable<T>
    {
        public int size;
        public LinkedList<T>[] slots; // chaining collision resolution

        public HashTable(int sz)
        {
            size = sz;
            slots = new LinkedList<T>[size];
        }

        public int HashFun(T value)
        {
            int hc = value.GetHashCode();
            if (hc < 0) hc *= -1;
            return hc % size;
        }

        public virtual void Put(T value)
        {
            int hf = HashFun(value);
            if (slots[hf] != null && slots[hf].Contains(value)) return;
            if (slots[hf] == null) slots[hf] = new LinkedList<T>();
            slots[hf].AddLast(value);
        }

        public int FindContainingBucket(T value)
        {
            int hf = HashFun(value);
            if (slots[hf] != null && slots[hf].Contains(value)) return hf;
            return -1; // if not found
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var LinkedList in slots)
                if (LinkedList != null)
                    foreach (T val in LinkedList)
                        yield return val;
        }
    }
}

