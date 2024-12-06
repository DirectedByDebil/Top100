using System;

namespace Scratches
{

	public partial class ScratchCollectionView : ContentView
	{

		public event Action<object>? SelectionChanged;


		public ScratchCollectionView()
		{

			InitializeComponent();
		}


        private void OnSelectionChanged(object sender,
			
			SelectionChangedEventArgs e)
        {

			object item = collectionView.SelectedItem;


			if (item != null)
			{

				SelectionChanged?.Invoke(item);
				
				collectionView.SelectedItem = null;
			}
        }
    }
}
