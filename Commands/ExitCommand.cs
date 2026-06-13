using System;

namespace Applications_Image_Filter.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(0);
        }
    }
}
