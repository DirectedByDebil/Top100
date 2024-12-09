using Core;
using System;

namespace Scratches
{

    public partial class CardView : ContentView
    {

        public event Action<ContentID>? Scratched;


        public CardView()
        {

            InitializeComponent();
        }


        private void OnCardBackScratched()
        {

            if (BindingContext is CardData card)
            {

                card.IsLocked = false;


                ContentID id = new(card.Name, card.Year);

                Scratched?.Invoke(id);
            }
        }
    }
}