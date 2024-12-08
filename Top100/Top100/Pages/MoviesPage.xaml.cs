using Scratches;
using Web;
using Core;
using System.Xml;

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




            ToolbarItems.Add(new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => { })
            });

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Профиль",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => { })
            });

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Настройки",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => { })
            });

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Начатые подборки",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => { })
            });

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "О нас",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(() => { })
            });




            _collectionsModel = new PageViewModel<
				
				KinopoiskCollectionData>();



			_rest = new RestService();

			_scratchesPage = new ScratchesPage(ContentType.Movies);


            Loaded += OnPageLoaded;


			BindingContext = _collectionsModel;
		}


        private async void OnPageLoaded(object? sender, EventArgs e)
        {

			Loaded -= OnPageLoaded;
			
			await LoadCardsAsync();
        }


        private async Task LoadCardsAsync()
		{

			string request = UrlFactory.GetAllCollections(API);


			KinopoiskData<KinopoiskCollectionData> data = await

				_rest.GetRequestAsync<KinopoiskData
				
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



				IEnumerable<ContentID>? ids =
					
					SessionData.GetConsumed(ContentType.Movies);


				if(ids != null)
				{

					_scratchesPage.UpdateConsumed(ids);
				}


				//#TODO update _scratchesPage Title

				_lastCollection = obj;
			}

			await Navigation.PushAsync(_scratchesPage);
        }
    }
}