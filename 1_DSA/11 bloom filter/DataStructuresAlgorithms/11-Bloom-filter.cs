using System.Collections.Generic;
using System;
using System.IO;

namespace DataStructuresAlgorithms
{
    public class BloomFilter
    {
        public int filter_len;
        private int _filter;
        private List<Func<string, int>> _hashFunctions;

        public BloomFilter(int f_len) // f_len <= 32
        {
            filter_len = f_len;
            _filter = 0;
            _hashFunctions = new List<Func<string, int>>
            {
                Hash1,
                Hash2
            };
        }

        public int Hash1(string str1) => InternalHashGeneral(str1, 17);

        public int Hash2(string str1) => InternalHashGeneral(str1, 223);

        public void Add(string str1)
        {
            foreach (var fun in _hashFunctions) _filter = _filter | InternalIntToPosition(fun(str1));
        }

        public bool IsValue(string str1)
        {
            foreach (var fun in _hashFunctions) if (!InternalIsCodeInFilter(fun(str1))) return false;
            return true;
        }

        private int InternalHashGeneral(string inputStr, int multiplier)
        {
            int code = 0;
            for (int i = 0; i < inputStr.Length; i++)
                code = (code * multiplier + (int)inputStr[i]) % filter_len;
            return code;
        }

        private static int InternalIntToPosition(int code) => 1 << code;
        private bool InternalIsCodeInFilter(int code)
        {
            int pos = InternalIntToPosition(code);
            return (_filter & pos) == pos;
        }
    }
}

