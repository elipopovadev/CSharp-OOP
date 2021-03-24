using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("Gosho");
            randomList.Add("Misho");
            randomList.Add("Pesho");
           
            string randomString = randomList.RandomString();
            Console.WriteLine(randomString);                  
        }
    }
}
