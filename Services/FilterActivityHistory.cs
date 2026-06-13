using System;
using System.Collections.Generic;

namespace Applications_Image_Filter.Services
{
    /// <summary>
    /// Data class untuk menyimpan informasi aktivitas filter.
    /// </summary>
    public class FilterActivity
    {
        public int Id { get; set; }
        public string FilterName { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public bool IsError { get; set; }

        public override string ToString()
        {
            var status = IsError ? "ERROR" : "SUCCESS";
            return $"[{Id}] [{status}] {Timestamp:yyyy-MM-dd HH:mm:ss} | Filter: {FilterName} | File: {ImageFileName}";
        }
    }

    /// <summary>
    /// Service untuk menyimpan dan mengelola riwayat aktivitas filter.
    /// Mengimplementasikan Singleton Pattern untuk memastikan hanya ada satu instance.
    /// </summary>
    public class FilterActivityHistory
    {
        private static FilterActivityHistory? instance;
        private static readonly object lockObject = new object();

        private readonly List<FilterActivity> activities = new List<FilterActivity>();
        private int activityIdCounter = 1;

        private FilterActivityHistory() { }

        public static FilterActivityHistory GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new FilterActivityHistory();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Menambahkan aktivitas filter ke riwayat.
        /// </summary>
        public void AddActivity(string filterName, string imageFileName, string result, bool isError = false)
        {
            var activity = new FilterActivity
            {
                Id = activityIdCounter++,
                FilterName = filterName,
                ImageFileName = imageFileName,
                Result = result,
                Timestamp = DateTime.Now,
                IsError = isError
            };

            activities.Add(activity);
        }

        /// <summary>
        /// Mendapatkan semua aktivitas yang tersimpan.
        /// </summary>
        public List<FilterActivity> GetAllActivities()
        {
            return new List<FilterActivity>(activities);
        }

        /// <summary>
        /// Mendapatkan aktivitas berdasarkan ID.
        /// </summary>
        public FilterActivity? GetActivityById(int id)
        {
            return activities.Find(a => a.Id == id);
        }

        /// <summary>
        /// Mendapatkan aktivitas berdasarkan nama filter.
        /// </summary>
        public List<FilterActivity> GetActivitiesByFilter(string filterName)
        {
            return activities.FindAll(a => a.FilterName.Equals(filterName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Mendapatkan jumlah total aktivitas.
        /// </summary>
        public int GetTotalActivityCount()
        {
            return activities.Count;
        }

        /// <summary>
        /// Mendapatkan jumlah aktivitas yang sukses.
        /// </summary>
        public int GetSuccessfulActivityCount()
        {
            return activities.FindAll(a => !a.IsError).Count;
        }

        /// <summary>
        /// Mendapatkan jumlah aktivitas yang error.
        /// </summary>
        public int GetErrorActivityCount()
        {
            return activities.FindAll(a => a.IsError).Count;
        }

        /// <summary>
        /// Menghapus semua riwayat aktivitas.
        /// </summary>
        public void ClearHistory()
        {
            activities.Clear();
            activityIdCounter = 1;
        }

        /// <summary>
        /// Mendapatkan N aktivitas terakhir.
        /// </summary>
        public List<FilterActivity> GetRecentActivities(int count)
        {
            int startIndex = Math.Max(0, activities.Count - count);
            return activities.GetRange(startIndex, activities.Count - startIndex);
        }
    }
}
