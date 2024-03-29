﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace CSharpNetUtilities
{
    public static class LinkExtension
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }

        public static bool Compare<T>(this IEnumerable<T> list, IEnumerable<T> other)
        {
            if (list.Except(other).Any())
                return false;
            if (other.Except(list).Any())
                return false;
            return true;
        }

        public static IEnumerable<T> FilterEnums<T>(this string search)
        {
            search ??= "";
            return Enum.GetValues(typeof(T)).Cast<T>().Where(m => m!.ToString()!.ToLower().Contains(search.ToLower()));
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            foreach (T item in sequence)
            {
                action(item);
            }
        }
    }
}