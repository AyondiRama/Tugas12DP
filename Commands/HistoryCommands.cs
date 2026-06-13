using Applications_Image_Filter.Services;
using System;

namespace Applications_Image_Filter.Commands
{
    /// <summary>
    /// Command untuk menampilkan riwayat semua aktivitas filter yang telah diterapkan.
    /// </summary>
    public class ShowHistoryCommand : ICommand
    {
        public void Execute()
        {
            var history = FilterActivityHistory.GetInstance();
            var activities = history.GetAllActivities();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              RIWAYAT AKTIVITAS FILTER                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            if (activities.Count == 0)
            {
                Console.WriteLine("Tidak ada riwayat aktivitas.");
            }
            else
            {
                Console.WriteLine($"Total Aktivitas: {activities.Count}");
                Console.WriteLine($"├─ Sukses: {history.GetSuccessfulActivityCount()}");
                Console.WriteLine($"└─ Error: {history.GetErrorActivityCount()}");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Daftar Aktivitas:");
                Console.ResetColor();

                foreach (var activity in activities)
                {
                    if (activity.IsError)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(activity.ToString());
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Command untuk menampilkan statistik penggunaan filter.
    /// </summary>
    public class ShowStatisticsCommand : ICommand
    {
        public void Execute()
        {
            var history = FilterActivityHistory.GetInstance();
            var activities = history.GetAllActivities();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              STATISTIK PENGGUNAAN FILTER                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            if (activities.Count == 0)
            {
                Console.WriteLine("Tidak ada data statistik.");
            }
            else
            {
                Console.WriteLine($"Total Aktivitas   : {history.GetTotalActivityCount()}");
                Console.WriteLine($"Aktivitas Sukses  : {history.GetSuccessfulActivityCount()}");
                Console.WriteLine($"Aktivitas Error   : {history.GetErrorActivityCount()}");
                Console.WriteLine();

                // Statistik per filter
                var filterGroups = new Dictionary<string, int>();
                foreach (var activity in activities)
                {
                    if (!activity.IsError)
                    {
                        if (filterGroups.ContainsKey(activity.FilterName))
                        {
                            filterGroups[activity.FilterName]++;
                        }
                        else
                        {
                            filterGroups[activity.FilterName] = 1;
                        }
                    }
                }

                if (filterGroups.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Filter Terpopuler:");
                    Console.ResetColor();

                    foreach (var group in filterGroups.OrderByDescending(g => g.Value))
                    {
                        Console.WriteLine($"  • {group.Key}: {group.Value}x");
                    }
                }
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Command untuk menghapus semua riwayat aktivitas.
    /// </summary>
    public class ClearHistoryCommand : ICommand
    {
        public void Execute()
        {
            var history = FilterActivityHistory.GetInstance();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Apakah Anda yakin ingin menghapus semua riwayat? (y/n): ");
            Console.ResetColor();

            var input = Console.ReadLine();
            if (input?.ToLower() == "y")
            {
                history.ClearHistory();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Riwayat berhasil dihapus.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Pembatalan.");
            }

            Console.WriteLine();
        }
    }
}
