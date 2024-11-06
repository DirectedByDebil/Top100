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

			LoadCardsAsync();
		}


		private async void LoadCardsAsync()
		{

			RestService rest = new RestService();


			_cardDatas = new List<CardData>( await rest.RefreshDataAsync

 				  ("https://api.kinopoisk.dev/v1.4/movie?" +
				  "selectFields=name&selectFields=year&selectFields=poster&" +
				  "year=2023&" +
				  "notNullFields=name&notNullFields=year&notNullFields=poster.url&" +
				  "genres.name=криминал"));
				//("https://api.kinopoisk.dev/v1.4/movie?selectFields=name&selectFields=year&selectFields=poster&id=666&type=movie"));
			

			BindingContext = new PageViewModel(_cardDatas);
		}
	}
}