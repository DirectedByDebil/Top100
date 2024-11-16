using Scratches;
using Web;

namespace Pages
{

	public partial class MoviesPage : ContentPage
	{

		private const Api API = Api.Kinopoisk;


		private readonly PageViewModel<
			
			KinopoiskCollectionData> _collectionsModel;       


		private readonly RestService _rest;

		private readonly ScratchesPage _scratchesPage;


		private object? _lastCollection;


		public MoviesPage()
		{

			InitializeComponent();


			_collectionsModel = new PageViewModel<
				
				KinopoiskCollectionData>();



			_rest = new RestService();

			_scratchesPage = new ScratchesPage();


			BindingContext = _collectionsModel;


			LoadCardsAsync();
		}


		private async void LoadCardsAsync()
		{

			RestService rest = new RestService();


			string request = UrlFactory.GetAllCollections(API);


			KinopoiskData<KinopoiskCollectionData> data = await

				rest.GetRequestAsync<KinopoiskData
				
				<KinopoiskCollectionData>>(request);

			_collectionsModel.SetCards(data.Docs);
		}


        private async void OnSelectionChanged(object obj)
        {

			if(_lastCollection != obj &&
				
				UrlFactory.TryGetCurrentCollection(API,	
				
				obj, out string request))
			{

				KinopoiskData<CardData> cardsData = await

					_rest.GetRequestAsync<KinopoiskData<CardData>>(request);


				_scratchesPage.UpdateScratches(cardsData);

				//#TODO update _scratchesPage Title

				_lastCollection = obj;
			}

			await Navigation.PushAsync(_scratchesPage);
        }
    }
}