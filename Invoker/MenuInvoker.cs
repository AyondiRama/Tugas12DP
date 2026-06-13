using Applications_Image_Filter.Commands;
using System;
using System.Collections.Generic;

namespace Applications_Image_Filter.Invoker
{
    public class MenuInvoker
    {
        private readonly Dictionary<string, ICommand> commands = new();

        public void SetCommand(string key, ICommand command)
        {
            commands[key] = command;
        }

        public void Invoke(string key)
        {
            if (commands.TryGetValue(key, out var command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Perintah tidak dikenal.");
            }
        }
    }
}
