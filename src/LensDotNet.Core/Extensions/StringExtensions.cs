using System;
using System.Linq;
using System.Threading.Tasks;

namespace LensDotNet.Core.Extensions
{
	public static class StringExtensions
	{
		
        /// <summary>
        /// Extension function to convert a HEX string into a <see cref="byte[]"/> reprsentation.
        /// </summary>
        /// <param name="hex">The hex string to convert from.</param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(this string hex)
            => Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();

        /// <summary>
        /// Converts a byte array into its hex string representation.
        /// </summary>
        /// <param name="bytes">The byte array</param>
        /// <returns>A hex string representing the data</returns>
        public static string ToHexString(this byte[] bytes)
         => BitConverter.ToString(bytes);
    }
}

