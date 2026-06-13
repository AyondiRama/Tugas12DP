using Applications_Image_Filter.Core;
using Applications_Image_Filter.Filters;
using Applications_Image_Filter.Commands;
using Applications_Image_Filter.Invoker;
using Applications_Image_Filter.Services;
using Applications_Image_Filter.Filters.Applications_Image_Filter.Filters;
using Applications_Image_Filter.Observers;


namespace Applications_Image_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var imageEditor = new ImageEditor();
            var invoker = new MenuInvoker();

            // Register observers untuk sistem notifikasi dan riwayat
            var notificationObserver = new NotificationObserver();
            var historyObserver = new HistoryObserver();

            imageEditor.Attach(notificationObserver);
            imageEditor.Attach(historyObserver);

            // Register commands untuk filter
            invoker.SetCommand("1", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.Applications_Image_Filter.Filters.BlackWhiteFilter(), "foto.jpg"));
            invoker.SetCommand("2", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.SepiaFilter(), "foto.jpg"));
            invoker.SetCommand("3", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.Applications_Image_Filter.Filters.BlurFilter(), "foto.jpg"));
            invoker.SetCommand("4", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.SharpenFilter(), "foto.jpg"));
            invoker.SetCommand("5", new ApplyFilterCommand(imageEditor, new Applications_Image_Filter.Filters.NegativeFilter(), "foto.jpg"));
            invoker.SetCommand("s", new SaveCommand("foto.jpg"));

            // Register commands untuk riwayat dan statistik
            invoker.SetCommand("h", new ShowHistoryCommand());
            invoker.SetCommand("t", new ShowStatisticsCommand());
            invoker.SetCommand("c", new ClearHistoryCommand());

            invoker.SetCommand("e", new ExitCommand());

            while (true)
            {
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("          IMAGE FILTER APPLICATION - MAIN MENU");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("FILTER OPTIONS:");
                Console.WriteLine("  1. Apply BlackWhite Filter");
                Console.WriteLine("  2. Apply Sepia Filter");
                Console.WriteLine("  3. Apply Blur Filter");
                Console.WriteLine("  4. Apply Sharpen Filter");
                Console.WriteLine("  5. Apply Negative Filter");
                Console.WriteLine();
                Console.WriteLine("FILE & HISTORY OPTIONS:");
                Console.WriteLine("  s. Save Image");
                Console.WriteLine("  h. Show History");
                Console.WriteLine("  t. Show Statistics");
                Console.WriteLine("  c. Clear History");
                Console.WriteLine();
                Console.WriteLine("  e. Exit");
                Console.WriteLine();
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.Write("Choose option: ");

                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                invoker.Invoke(input.Trim());
            }
        }
    }
}