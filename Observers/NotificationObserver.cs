using System;

namespace Applications_Image_Filter.Observers
{
    /// <summary>
    /// Observer yang menampilkan notifikasi real-time ke console saat filter diterapkan.
    /// </summary>
    public class NotificationObserver : IFilterObserver
    {
        public void OnFilterApplied(string filterName, string imageFileName, string result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         FILTER BERHASIL DITERAPKAN      ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"Filter   : {filterName}");
            Console.WriteLine($"File     : {imageFileName}");
            Console.WriteLine($"Status   : {result}");
            Console.WriteLine($"Waktu    : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine();
        }

        public void OnFilterError(string filterName, string imageFileName, string errorMessage)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║          TERJADI KESALAHAN              ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"Filter   : {filterName}");
            Console.WriteLine($"File     : {imageFileName}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error    : {errorMessage}");
            Console.ResetColor();
            Console.WriteLine($"Waktu    : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine();
        }
    }
}
