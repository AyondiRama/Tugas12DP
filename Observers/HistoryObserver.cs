using Applications_Image_Filter.Services;

namespace Applications_Image_Filter.Observers
{
    /// <summary>
    /// Observer yang menyimpan riwayat setiap kali filter diterapkan.
    /// Data disimpan melalui FilterActivityHistory.
    /// </summary>
    public class HistoryObserver : IFilterObserver
    {
        private readonly FilterActivityHistory history;

        public HistoryObserver()
        {
            history = FilterActivityHistory.GetInstance();
        }

        public void OnFilterApplied(string filterName, string imageFileName, string result)
        {
            history.AddActivity(filterName, imageFileName, result, isError: false);
        }

        public void OnFilterError(string filterName, string imageFileName, string errorMessage)
        {
            history.AddActivity(filterName, imageFileName, errorMessage, isError: true);
        }
    }
}
