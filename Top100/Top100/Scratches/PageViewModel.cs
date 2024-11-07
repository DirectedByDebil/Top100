using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Scratches
{

    public sealed class PageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;


        public ObservableCollection<CardData> Cards { get; }


        public PageViewModel(IReadOnlyCollection<CardData> cardsDatas)
        {

            Cards = new ObservableCollection<CardData>(cardsDatas);
        }
    }
}
