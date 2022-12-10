using System;
using LensDotNet.Core;

namespace LensDotNet
{
    /// <summary>
    /// Represents a StringEnum of the available networks.
    /// Create a new instance of <see cref="Network"/> if you need to define a custom one.
    /// </summary>
	public class Network : Enumeration
    {
        public static Network PolygonMainnet = new Network(1, "https://api.lens.dev/");
        public static Network MumbaiTestNet = new Network(2, "https://api-mumbai.lens.dev/");
        public Network(int id, string name) : base(id, name) { }
    }
}

