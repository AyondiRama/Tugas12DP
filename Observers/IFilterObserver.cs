using System;

namespace Applications_Image_Filter.Observers
{
    /// <summary>
    /// Interface untuk observer yang ingin mendengarkan perubahan filter pada ImageEditor.
    /// Mengimplementasikan Observer Pattern.
    /// </summary>
    public interface IFilterObserver
    {
        /// <summary>
        /// Dipanggil ketika filter berhasil diterapkan pada gambar.
        /// </summary>
        /// <param name="filterName">Nama filter yang diterapkan</param>
        /// <param name="imageFileName">Nama file gambar yang difilter</param>
        /// <param name="result">Hasil atau pesan dari penerapan filter</param>
        void OnFilterApplied(string filterName, string imageFileName, string result);

        /// <summary>
        /// Dipanggil ketika ada error dalam penerapan filter.
        /// </summary>
        /// <param name="filterName">Nama filter yang gagal</param>
        /// <param name="imageFileName">Nama file gambar</param>
        /// <param name="errorMessage">Pesan error</param>
        void OnFilterError(string filterName, string imageFileName, string errorMessage);
    }
}
