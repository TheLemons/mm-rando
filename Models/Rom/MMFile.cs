﻿
namespace MMRandomizer.Models.Rom
{
    public class MMFile
    {
        public int Addr;
        public int End;
        public int Cmp_Addr;
        public int Cmp_End;
        public byte[] Data;
        public bool IsCompressed;
        public bool WasEdited;
    }
}
