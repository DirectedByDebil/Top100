using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Pages
{

    public sealed class PageViewModel<T> : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;


        public ObservableCollection<T> Cards { get; private set; }


        public void SetCards(IReadOnlyCollection<T> cardsDatas)
        {

            if(cardsDatas != Cards)
            {

                Cards = new ObservableCollection<T>(cardsDatas);


                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(Cards)));
            }
        }


        private void InvokePropertyChanged(PropertyChangedEventArgs args)
        {

            PropertyChanged?.Invoke(this, args);
        }
    }
}
