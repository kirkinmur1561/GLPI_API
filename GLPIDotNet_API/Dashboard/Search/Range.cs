using System;

namespace GLPIDotNet_API.Dashboard.Search
{
    public class Range
    {       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <exception cref="ArgumentException"></exception>
        public Range(long start = 0, long end = 50)
        {
            if (start > end) throw new ArgumentException("Value the start > value the end");
            Start = start;
            End = end;
        }

        public readonly long Start;
        public readonly long End;
        public override string ToString() =>
            $"{Start}-{End}";
    }
}
