using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NUDev.PlusSharp {
    public static class StringExtension {
        /// <summary>
        /// Returns a random string. Don't use for secure stuff.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <param name="chars">What characters to include.</param>
        /// <returns>A random string.</returns>
        public static string RandomString(this string str, int length, string chars) {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Range(0, s.Length)]).ToArray());
        }

        /// <summary>
        /// Returns a random string. Don't use for secure stuff.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <returns>A random string.</returns>
        public static string RandomString(this string str, int length) {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
              .Select(s => s[Random.Range(0, s.Length)]).ToArray());
        }
    }
}