﻿using System;
using System.Collections.Generic;

namespace LinqAF.Impl
{
    static partial class CommonImplementation
    {
        public static
            GroupJoinDefaultEnumerable<
                TOutItem,
                TKeyItem,
                TLeftItem,
                TLeftEnumerable,
                TLeftEnumerator,
                TRightItem,
                TRightEnumerable,
                TRightEnumerator
            > GroupJoin<TOutItem,TKeyItem,TLeftItem,TLeftEnumerable,TLeftEnumerator,TRightItem,TRightEnumerable,TRightEnumerator>(
                ref TLeftEnumerable outer,
                ref TRightEnumerable inner,
                Func<TLeftItem, TKeyItem> outerKeySelector,
                Func<TRightItem, TKeyItem> innerKeySelector,
                Func<TLeftItem, GroupedEnumerable<TKeyItem, TRightItem>, TOutItem> resultSelector
            )
            where TLeftEnumerable: struct, IStructEnumerable<TLeftItem, TLeftEnumerator>
            where TLeftEnumerator: struct, IStructEnumerator<TLeftItem>
            where TRightEnumerable: struct, IStructEnumerable<TRightItem, TRightEnumerator>
            where TRightEnumerator: struct, IStructEnumerator<TRightItem>
        {
            if (outer.IsDefaultValue()) throw new ArgumentException("Argument uninitialized", nameof(outer));
            if (inner.IsDefaultValue()) throw new ArgumentException("Argument uninitialized", nameof(inner));
            if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return
                GroupJoinImpl<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(
                    ref outer,
                    ref inner,
                    outerKeySelector,
                    innerKeySelector,
                    resultSelector
                );
        }

        internal static
            GroupJoinDefaultEnumerable<
                TOutItem,
                TKeyItem,
                TLeftItem,
                TLeftEnumerable,
                TLeftEnumerator,
                TRightItem,
                TRightEnumerable,
                TRightEnumerator
            > GroupJoinImpl<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(
                ref TLeftEnumerable outer,
                ref TRightEnumerable inner,
                Func<TLeftItem, TKeyItem> outerKeySelector,
                Func<TRightItem, TKeyItem> innerKeySelector,
                Func<TLeftItem, GroupedEnumerable<TKeyItem, TRightItem>, TOutItem> resultSelector
            )
            where TLeftEnumerable : struct, IStructEnumerable<TLeftItem, TLeftEnumerator>
            where TLeftEnumerator : struct, IStructEnumerator<TLeftItem>
            where TRightEnumerable : struct, IStructEnumerable<TRightItem, TRightEnumerator>
            where TRightEnumerator : struct, IStructEnumerator<TRightItem>
        {
            return new GroupJoinDefaultEnumerable<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(ref outer, ref inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        public static
            GroupJoinSpecificEnumerable<
                TOutItem,
                TKeyItem,
                TLeftItem,
                TLeftEnumerable,
                TLeftEnumerator,
                TRightItem,
                TRightEnumerable,
                TRightEnumerator
            > GroupJoin<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(
                ref TLeftEnumerable outer,
                ref TRightEnumerable inner,
                Func<TLeftItem, TKeyItem> outerKeySelector,
                Func<TRightItem, TKeyItem> innerKeySelector,
                Func<TLeftItem, GroupedEnumerable<TKeyItem, TRightItem>, TOutItem> resultSelector,
                IEqualityComparer<TKeyItem> comparer
            )
            where TLeftEnumerable : struct, IStructEnumerable<TLeftItem, TLeftEnumerator>
            where TLeftEnumerator : struct, IStructEnumerator<TLeftItem>
            where TRightEnumerable : struct, IStructEnumerable<TRightItem, TRightEnumerator>
            where TRightEnumerator : struct, IStructEnumerator<TRightItem>
        {
            if (outer.IsDefaultValue()) throw new ArgumentException("Argument uninitialized", nameof(outer));
            if (inner.IsDefaultValue()) throw new ArgumentException("Argument uninitialized", nameof(inner));
            if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return
                GroupJoinImpl<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(
                    ref outer,
                    ref inner,
                    outerKeySelector,
                    innerKeySelector,
                    resultSelector,
                    comparer
                );
        }

        internal static
            GroupJoinSpecificEnumerable<
                TOutItem,
                TKeyItem,
                TLeftItem,
                TLeftEnumerable,
                TLeftEnumerator,
                TRightItem,
                TRightEnumerable,
                TRightEnumerator
            > GroupJoinImpl<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(
                ref TLeftEnumerable outer,
                ref TRightEnumerable inner,
                Func<TLeftItem, TKeyItem> outerKeySelector,
                Func<TRightItem, TKeyItem> innerKeySelector,
                Func<TLeftItem, GroupedEnumerable<TKeyItem, TRightItem>, TOutItem> resultSelector,
                IEqualityComparer<TKeyItem> comparer
            )
            where TLeftEnumerable : struct, IStructEnumerable<TLeftItem, TLeftEnumerator>
            where TLeftEnumerator : struct, IStructEnumerator<TLeftItem>
            where TRightEnumerable : struct, IStructEnumerable<TRightItem, TRightEnumerator>
            where TRightEnumerator : struct, IStructEnumerator<TRightItem>
        {
            return new GroupJoinSpecificEnumerable<TOutItem, TKeyItem, TLeftItem, TLeftEnumerable, TLeftEnumerator, TRightItem, TRightEnumerable, TRightEnumerator>(ref outer, ref inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }
    }
}