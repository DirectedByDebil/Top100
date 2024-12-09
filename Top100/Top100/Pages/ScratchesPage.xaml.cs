using Scratches;
using Web;
using Core;
using System.ComponentModel;

namespace Pages
{

	public partial class ScratchesPage : ContentPage
	{

		private readonly ContentType _contentType;

		private readonly PageViewModel<CardData> _cardsModel;


		public ScratchesPage(ContentType contentType)
		{

			InitializeComponent();
		

			_contentType = contentType;


			_cardsModel = new PageViewModel<CardData>();


			BindingContext = _cardsModel;
		}


		public void UpdateScratches(IReadOnlyCollection<CardData> cards)
		{

			_cardsModel.SetCards(cards);
		}


		public void UpdateConsumed(IEnumerable<ContentID> ids)
		{

			_cardsModel.CheckConsumed(ids);
		}


        private void OnScratched(ContentID id)
        {

			SessionData.AddConsumed(_contentType, id);
        }
    }
}