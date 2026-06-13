using Applications_Image_Filter.Interface;
using Applications_Image_Filter.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications_Image_Filter.Core
{
    public class ImageEditor : IObservable
    {
        private IFilterStrategy? currentFilter;
        private readonly List<IFilterObserver> observers = new List<IFilterObserver>();

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
                string errorMessage = "Filter belum dipilih.";
                Notify("Unknown", imageFileName, errorMessage, isError: true);
                return errorMessage;
            }

            var result = currentFilter.ApplyFilter(imageFileName);
            var filterName = currentFilter.GetType().Name;

            // Notify observers
            Notify(filterName, imageFileName, result, isError: false);

            return result;
        }

        // Observer Pattern Implementation
        public void Attach(IFilterObserver observer)
        {
            if (observer != null && !observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Detach(IFilterObserver observer)
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void Notify(string filterName, string imageFileName, string result, bool isError = false)
        {
            foreach (var observer in observers)
            {
                if (isError)
                {
                    observer.OnFilterError(filterName, imageFileName, result);
                }
                else
                {
                    observer.OnFilterApplied(filterName, imageFileName, result);
                }
            }
        }
    }
}
