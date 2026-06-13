using Applications_Image_Filter.Core;
using Applications_Image_Filter.Interface;
using System;

namespace Applications_Image_Filter.Services
{
    public class FilterService
    {
        private readonly ImageEditor editor;

        public FilterService(ImageEditor editor)
        {
            this.editor = editor ?? throw new ArgumentNullException(nameof(editor));
        }

        public void SetFilterAndApply(string imageFileName, IFilterStrategy filter)
        {
            editor.SetFilter(filter);
            var result = editor.ApplyCurrentFilter(imageFileName);
            Console.WriteLine(result);
        }
    }
}
