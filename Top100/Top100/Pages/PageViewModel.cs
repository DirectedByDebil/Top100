using System.ComponentModel;
using System.Collections.ObjectModel;
using Core;
using Scratches;

namespace Pages
{

    public sealed class PageViewModel<T> : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;


        public ObservableCollection<T>? Cards { get; private set; }


        public void SetCards(IReadOnlyCollection<T> cardsDatas)
        {

            if(cardsDatas != Cards)
            {

                Cards = new ObservableCollection<T>(cardsDatas);
                

                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(Cards)));
            }
        }


        public void CheckConsumed(IEnumerable<ContentID> consumed)
        {

            if(Cards == null)
            {

                return;
            }

            IEnumerable<CardData> cards = Cards.OfType<CardData>();


            foreach (CardData card in cards)
            {

                ContentID id = new (card.Name, card.Year);


                if(consumed.Contains(id))
                {

                    card.IsLocked = false;
                }
            }
        }


        public void InvokePropertyChanged(PropertyChangedEventArgs args)
        {

            PropertyChanged?.Invoke(this, args);
        }
    }
}
