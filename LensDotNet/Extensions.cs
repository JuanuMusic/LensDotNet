using System;
namespace LensDotNet
{
	public static class Extensions
	{
        public static string ToCamelCase(this string input)
        {
            if (char.IsLower(input[0]))
            {
                return input;
            }
            return input.Substring(0, 1).ToLower() + input.Substring(1);
        }
    }
}

