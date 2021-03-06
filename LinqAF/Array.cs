﻿namespace LinqAF
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
    public struct ArrayEnumerator<TItem> : IStructEnumerator<TItem>
    {
        public TItem Current { get; private set; }

        TItem[] Inner;
        int Index;

        internal ArrayEnumerator(TItem[] inner)
        {
            Inner = inner;
            Index = 0;
            Current = default(TItem);
        }

        public bool IsDefaultValue()
        {
            return Inner == null;
        }

        public bool MoveNext()
        {
            if (Index < Inner.Length)
            {
                Current = Inner[Index];
                Index++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Index = 0;
            Current = default(TItem);
        }

        public void Dispose()
        {
            Inner = null;
        }
    }
}
