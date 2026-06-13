using System;

namespace Applications_Image_Filter.Commands
{
    public class SaveCommand : ICommand
    {
        private readonly string imageFileName;

        public SaveCommand(string imageFileName)
        {
            this.imageFileName = imageFileName ?? throw new ArgumentNullException(nameof(imageFileName));
        }

        public void Execute()
        {
            // For the purposes of this exercise, simulate save action.
            Console.WriteLine($"{imageFileName} berhasil disimpan.");
        }
    }
}
