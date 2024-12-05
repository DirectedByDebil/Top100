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


        private void OnCardScratched(ContentID id)
        {

            Changed?.Invoke(id);
        }
    }
}
