using Scratches;
using Web;

namespace Pages
{

	public partial class MoviesPage : ContentPage
	{

		private List<CardData> _cardDatas; 


		public MoviesPage()
		{

			InitializeComponent();

			_cardDatas = new List<CardData>();

			LoadCardsAsync();
		}


		private async void LoadCardsAsync()
		{

			RestService rest = new RestService();


			var test = new List<KinopoiskCollectionData>

				(await rest.LoadDataAsync<KinopoiskCollectionData>(

                "https://api.kinopoisk.dev/v1.4/list?" +
				"page=1&limit=10&" +
				"selectFields=name&selectFields=category&selectFields=moviesCount&selectFields=cover&" +
				"notNullFields=name&notNullFields=category&notNullFields=moviesCount&notNullFields=cover.previewUrl"
                ));

			/*
 				  ("https://api.kinopoisk.dev/v1.4/movie?" +
				  "selectFields=name&selectFields=year&selectFields=poster&" +
				  "year=2023&" +
				  "notNullFields=name&notNullFields=year&notNullFields=poster.url&" +
				  "genres.name=криминал"));

				*/
            //("https://api.kinopoisk.dev/v1.4/movie?
			//selectFields=name&selectFields=year&selectFields=poster&
			//id=666&type=movie"));

            /*
			 
				https://api.kinopoisk.dev/v1.4/list?
			page=1&limit=10&
			selectFields=name&selectFields=category&selectFields=moviesCount&selectFields=cover&
			notNullFields=name&notNullFields=category&notNullFields=moviesCount&notNullFields=cover.previewUrl
			 
			 */


            BindingContext = new PageViewModel(_cardDatas);
		}
	}
}