using Applications_Image_Filter.Core;
using Applications_Image_Filter.Interface;
using System;

namespace Applications_Image_Filter.Commands
{
    public class ApplyFilterCommand : ICommand
    {
        private readonly ImageEditor receiver;
        private readonly IFilterStrategy filter;
        private readonly string imageFileName;

        public ApplyFilterCommand(ImageEditor receiver, IFilterStrategy filter, string imageFileName)
        {
            this.receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            this.filter = filter ?? throw new ArgumentNullException(nameof(filter));
            this.imageFileName = imageFileName ?? throw new ArgumentNullException(nameof(imageFileName));
        }

        public void Execute()
        {
            receiver.SetFilter(filter);
            var result = receiver.ApplyCurrentFilter(imageFileName);
            Console.WriteLine(result);
        }
    }
}
