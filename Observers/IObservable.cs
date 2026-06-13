using System;

namespace Applications_Image_Filter.Observers
{
    /// <summary>
    /// Interface untuk Subject yang mengimplementasikan Observer Pattern.
    /// Memungkinkan observer untuk subscribe dan unsubscribe dari perubahan filter.
    /// </summary>
    public interface IObservable
    {
        /// <summary>
        /// Mendaftarkan observer untuk menerima notifikasi.
        /// </summary>
        /// <param name="observer">Observer yang akan didaftarkan</param>
        void Attach(IFilterObserver observer);

        /// <summary>
        /// Menghapus observer dari daftar notifikasi.
        /// </summary>
        /// <param name="observer">Observer yang akan dihapus</param>
        void Detach(IFilterObserver observer);

        /// <summary>
        /// Mengirim notifikasi ke semua observer yang terdaftar.
        /// </summary>
        void Notify(string filterName, string imageFileName, string result, bool isError = false);
    }
}
