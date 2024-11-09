using Scratches;
using Web;

namespace Pages
{

	public partial class ScratchesPage : ContentPage
	{

		private readonly PageViewModel<CardData> _cardsModel;


		public ScratchesPage()
		{

			InitializeComponent();
		

			_cardsModel = new PageViewModel<CardData>();


			BindingContext = _cardsModel;
		}


		public void UpdateScratches(KinopoiskData<CardData> cardsData)
		{

			_cardsModel.SetCards(cardsData.Docs);
		}
	}
}