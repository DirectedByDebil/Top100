using System;

namespace Scratches
{

	public partial class AllCollectionsView : ContentView
	{

		public event Action<object>? SelectionChanged;


		public AllCollectionsView()
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
