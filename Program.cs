using Applications_Image_Filter.Core;
using Applications_Image_Filter.Filters;
using Applications_Image_Filter.Commands;
using Applications_Image_Filter.Invoker;
using Applications_Image_Filter.Services;
using Applications_Image_Filter.Filters.Applications_Image_Filter.Filters;


namespace Applications_Image_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var imageEditor = new ImageEditor();
            var invoker = new MenuInvoker();

            // Register commands for menu
            invoker.SetCommand("1", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.Applications_Image_Filter.Filters.BlackWhiteFilter(), "foto.jpg"));
            invoker.SetCommand("2", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.SepiaFilter(), "foto.jpg"));
            invoker.SetCommand("3", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.Applications_Image_Filter.Filters.BlurFilter(), "foto.jpg"));
            invoker.SetCommand("4", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.SharpenFilter(), "foto.jpg"));
            invoker.SetCommand("5", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.NegativeFilter(), "foto.jpg"));
            invoker.SetCommand("s", new SaveCommand("foto.jpg"));
            invoker.SetCommand("e", new ExitCommand());

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Apply BlackWhite");
                Console.WriteLine("2. Apply Sepia");
                Console.WriteLine("3. Apply Blur");
                Console.WriteLine("4. Apply Sharpen");
                Console.WriteLine("5. Apply Negative");
                Console.WriteLine("s. Save");
                Console.WriteLine("e. Exit");
                Console.Write("Choose option: ");

                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                invoker.Invoke(input.Trim());
            }
        }
    }
}