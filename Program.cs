using Applications_Image_Filter.Core;
using Applications_Image_Filter.Filters;
using Applications_Image_Filter.Filters.Applications_Image_Filter.Filters;

namespace Applications_Image_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageEditor imageEditor = new();

            imageEditor.SetFilter(new BlackWhiteFilter());
            Console.WriteLine(
                imageEditor.ApplyCurrentFilter("foto.jpg"));

            imageEditor.SetFilter(new SepiaFilter());
            Console.WriteLine(
                imageEditor.ApplyCurrentFilter("foto.jpg"));

            imageEditor.SetFilter(new BlurFilter());
            Console.WriteLine(
                imageEditor.ApplyCurrentFilter("foto.jpg"));

            imageEditor.SetFilter(new SharpenFilter());
            Console.WriteLine(
                imageEditor.ApplyCurrentFilter("foto.jpg"));

            imageEditor.SetFilter(new NegativeFilter());
            Console.WriteLine(
                imageEditor.ApplyCurrentFilter("foto.jpg"));

            Console.ReadKey();
        }
    }
}