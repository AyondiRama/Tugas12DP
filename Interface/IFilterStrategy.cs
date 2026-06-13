using System;
using System.Collections.Generic;
using System.Text;

namespace Applications_Image_Filter.Interface
{
    public interface IFilterStrategy
    {
        string ApplyFilter(string imageFileName);
    }
}
