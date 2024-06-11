using System;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;
        private bool _isFull;
        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            _isFull = false;
        }

        public int HashFun(string key)
        {
            // random a [1, p-1], b [0, p-1], simple p - from universal family
            int x = 0, a = 2, b = 3, p = 20011;
            foreach (char ch in key) x += (int)ch;
            return (a * x + b) % p % size;
        }

        public bool IsKey(string key) => InternalFind(key) != -1;

        public void Put(string key, T value)
        {
            // guaranteed write
            int idx = 0;

            if (!_isFull) idx = InternalSeekSlotToWrite(key);
            if (idx == -1) _isFull = true;
            
            if (_isFull) idx = InternalIdxOfLeastUsed();

            slots[idx] = key;
            values[idx] = value;
            hits[idx] = 0;
        }

        public T Get(string key)
        {
            int idx = InternalFind(key);
            if (idx == -1) return default;
            hits[idx]++;
            return values[idx];
        }

        private int InternalFind(string lookup_key) => InternalSeekSlot(lookup_key,
          (slot, key) => string.Compare(slot, key) == 0);

        private int InternalSeekSlotToWrite(string provided_key) => InternalSeekSlot(provided_key,
          (slot, key) => string.Compare(slot, key) == 0 || slot == null);

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

        private int InternalIdxOfLeastUsed()
        {
            int min = int.MaxValue, idx = 0;
            for (int i = 0; i < size; i++)
            {
                if (hits[i] < min)
                {
                    min = hits[i];
                    idx = i;
                }
            }
            return idx;
        }
    }
}
