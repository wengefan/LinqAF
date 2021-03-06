﻿using System;

namespace LinqAF
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
    public struct ReverseEnumerator<TItem> : IStructEnumerator<TItem>
    {
        public TItem Current { get; private set; }

        TItem[] Inner;
        int Index;
        int StartIndex;
        internal ReverseEnumerator(TItem[] inner, int startIndex)
        {
            Inner = inner;
            StartIndex = startIndex;
            Index = StartIndex;
            Current = default(TItem);
        }

        public bool IsDefaultValue()
        {
            return Inner == null;
        }

        public void Dispose()
        {
            Inner = null;
        }

        public bool MoveNext()
        {
            if(Index < 0)
            {
                return false;
            }

            Current = Inner[Index];
            Index--;
            return true;
        }

        public void Reset()
        {
            Index = StartIndex;
            Current = default(TItem);
        }
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
    public partial struct ReverseEnumerable<TItem, TEnumerable, TEnumerator>:
        IStructEnumerable<TItem, ReverseEnumerator<TItem>>
        where TEnumerable: struct, IStructEnumerable<TItem, TEnumerator>
        where TEnumerator: struct, IStructEnumerator<TItem>
    {
        TEnumerable Inner;
        internal ReverseEnumerable(ref TEnumerable inner)
        {
            Inner = inner;
        }

        public bool IsDefaultValue() => Inner.IsDefaultValue();

        public ReverseEnumerator<TItem> GetEnumerator()
        {
            // we _have_ to buffer this, but not until the enumerator is actually called
            int count;
            var arr = Impl.CommonImplementation.Buffer<TItem, TEnumerable, TEnumerator>(ref Inner, out count);
            return new ReverseEnumerator<TItem>(arr, count - 1);
        }
    }
}
