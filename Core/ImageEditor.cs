using Applications_Image_Filter.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications_Image_Filter.Core
{
    public class ImageEditor
    {
        private IFilterStrategy? currentFilter;

        public void SetFilter(IFilterStrategy filter)
        {
            ArgumentNullException.ThrowIfNull(filter);

            currentFilter = filter;
        }

        public string ApplyCurrentFilter(string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName))
            {
                throw new ArgumentException(
                    "Nama file gambar tidak boleh kosong.");
            }

            if (currentFilter == null)
            {
                return "Filter belum dipilih.";
            }

            return currentFilter.ApplyFilter(imageFileName);
        }
    }
}
