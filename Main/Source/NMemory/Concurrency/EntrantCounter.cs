﻿// ----------------------------------------------------------------------------------
// <copyright file="EntrantCounter.cs" company="NMemory Team">
//     Copyright (C) 2012-2014 NMemory Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// ----------------------------------------------------------------------------------

namespace NMemory.Concurrency
{
    using System.Collections.Generic;

    internal class EntrantCounter
    {
        private Dictionary<long, int> counter;

        public EntrantCounter()
        {
            this.counter = new Dictionary<long, int>();
        }

        public int Increment(long id)
        {
            int count = 0;
            if (this.counter.TryGetValue(id, out count))
            {
                count++;
            }

            this.counter[id] = count;
            return count;
        }

        public int Decrement(long id)
        {
            int count = 0;
            if (!this.counter.TryGetValue(id, out count))
            {
                return 0;
            }

            if (count > 0)
            {
                count--;
                this.counter[0] = count;
            }

            return count;
        }
    }
}
