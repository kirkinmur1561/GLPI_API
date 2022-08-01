using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GLPIDotNet_API.Base
{
    public class Request : IEquatable<Request>
    {
        public readonly Func<Task<HttpResponseMessage>> FuncIn;
        public readonly Action<HttpResponseMessage> ActionOut;

        public Request(Func<Task<HttpResponseMessage>> funcIn, Action<HttpResponseMessage> actionOut)
        {
            FuncIn = funcIn;
            ActionOut = actionOut;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Request);
        }

        public bool Equals(Request other)
        {
            return other is not null &&
                   EqualityComparer<Func<Task<HttpResponseMessage>>>.Default.Equals(FuncIn, other.FuncIn) &&
                   EqualityComparer<Action<HttpResponseMessage>>.Default.Equals(ActionOut, other.ActionOut);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FuncIn, ActionOut);
        }
    }
}
