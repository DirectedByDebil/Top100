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


        private void collectionView_SelectionChanged(object sender,
			
			SelectionChangedEventArgs e)
        {

			SelectionChanged?.Invoke(collectionView.SelectedItem);

			collectionView.SelectedItem = null;
        }
    }
}
