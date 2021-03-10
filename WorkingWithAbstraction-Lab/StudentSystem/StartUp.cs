namespace StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystem studentSystem = new StudentSystem();
            while (true)
            {
                studentSystem.ParseCommand();
            }          
        }
    }
}



