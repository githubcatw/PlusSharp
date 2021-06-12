using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace NUDev.PlusSharp {
    public static class StringExtension {
        /// <summary>
        /// Returns a random string. Don't use for secure stuff.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <param name="chars">What characters to include.</param>
        /// <returns>A random string.</returns>
        public static string RandomString( int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789") {
            var st = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Range(0, s.Length)]).ToArray());
			return st;
        }

        /// <summary>
        /// Split a string to equally sized chunks.
        /// </summary>
        /// <param name="chunkSize">Chunk size</param>
        /// <returns></returns>
        public static string[] Split(this string str, int chunkSize) {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize)).ToArray();
        }
        
        // Based on https://stackoverflow.com/posts/17253735/
        /// <summary>
        /// Takes a substring between two anchor strings (or the end of the string if that anchor is null).
        /// </summary>
        /// <param name="this">A string.</param>
        /// <param name="from">An optional string to search after.</param>
        /// <param name="until">An optional string to search before.</param>
        /// <param name="comparison">An optional comparison for the search.</param>
        /// <returns>A substring based on the search.</returns>
        public static string SubstringBetween(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
        {
            var fromLength = (from ?? string.Empty).Length;
            var startIndex = !string.IsNullOrEmpty(from) 
                ? @this.IndexOf(from, comparison) + fromLength
                : 0;

            if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }

            var endIndex = !string.IsNullOrEmpty(until) 
                ? @this.IndexOf(until, startIndex, comparison) 
                : @this.Length;

            if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }

            var subString = @this.Substring(startIndex, endIndex - startIndex);
            return subString;
        }
    }
}