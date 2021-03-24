using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    class RandomList : List<string>
    {       
        Random randomGenerator = new Random();
        public string RandomString()
        {
           int randomIndex = randomGenerator.Next(this.Count);
            return this[randomIndex];
        }          
    }
}
