using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            if (new_capacity < 16)
                new_capacity = 16;
            T[] newArray = new T[new_capacity];
            if(array != null)
            {
                Array.Copy(array, newArray, count);
            }
            array = newArray;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count)
                // return default(T);
                throw new IndexOutOfRangeException();
            return array[index];
        }

        public void Append(T itm)
        {
            if (count == capacity)
            {
                MakeArray(capacity * 2);
            }
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();
            if (count == capacity)
            {
                MakeArray(capacity * 2);
            }
            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
                // .net 8+ : ArgumentOutOfRangeException.ThrowIfZero<T>(T, String) and others
            count--;
            for (int i = index; i < count; i++)
            {
                array[i] = array[i + 1];
            }
            if (count < capacity / 2)
            {
                int potentialCapacity = (int)(capacity / 1.5);
                if (potentialCapacity < 16)
                    potentialCapacity = 16;
                MakeArray(potentialCapacity);
            }
        }

    }
}

