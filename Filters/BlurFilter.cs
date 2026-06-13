using Applications_Image_Filter.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications_Image_Filter.Filters
{
    namespace Applications_Image_Filter.Filters
    {
        public class BlurFilter : IFilterStrategy
        {
            public string ApplyFilter(string imageFileName)
            {
                return $"{imageFileName} berhasil diberi filter Blur.";
            }
        }
    }
}
