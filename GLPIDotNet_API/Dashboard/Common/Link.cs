using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Common
{
    public class Link : IEquatable<Link>
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }


        [JsonProperty("href")]
        public Uri Address { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Link);
        }

        public bool Equals(Link other)
        {
            return other != null &&
                   Rel == other.Rel &&
                   Address == other.Address;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rel, Address);
        }

        public static bool operator ==(Link left, Link right)
        {
            return EqualityComparer<Link>.Default.Equals(left, right);
        }

        public static bool operator !=(Link left, Link right)
        {
            return !(left == right);
        }
    }
}
