using Core;

namespace Scratches
{

	public partial class CurrentCollectionView : ContentView
	{

		public event Action<ContentID>? Changed;


		public CurrentCollectionView()
		{

			InitializeComponent();
		}


        private void OnSelectionChanged(object sender,
			
			SelectionChangedEventArgs e)
        {

			object item = e.CurrentSelection[0];


			if(item is CardData card)
			{

				card.IsLocked = false;


				ContentID id = new (card.Name, card.Year);

				Changed?.Invoke(id);
			}
        }
    }
}
