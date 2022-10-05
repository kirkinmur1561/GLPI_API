﻿namespace GLPIDotNet_API.Base
{
    public class Range
    {
        public Range()
        {
        }

        public Range(long start = 0, long end = 50)
        {
            Start = start;
            End = end;
        }

        public long Start { get; set; }
        public long End { get; set; }
        public override string ToString() =>
            $"{Start}-{End}";
        

    }
}
