using System.Collections.Generic;
using Scratches;

namespace Pages
{

	public partial class MoviesPage : ContentPage
	{

		private List<CardData> _cardDatas; 


		public MoviesPage()
		{

			InitializeComponent();


			_cardDatas = new List<CardData>()
			{ 
				
				new CardData(){ Name = "Sex 1", IconPath = "settings.png", Year = 2024 },
				new CardData(){ Name = "Sex 2", IconPath = "dotnet_bot.png", Year = 2025 },
				new CardData(){ Name = "Sex 4", IconPath = "settings.png", Year = 2026 },
				new CardData(){ Name = "Sex 5", IconPath = "settings.png", Year = 2027 },
				new CardData(){ Name = "Sex 6", IconPath = "dotnet_bot.png", Year = 2028 },
				new CardData(){ Name = "Sex 7", IconPath = "dotnet_bot.png", Year = 2029 },
				new CardData(){ Name = "Sex 8", IconPath = "settings.png", Year = 2030 },
				new CardData(){ Name = "Sex 9", IconPath = "dotnet_bot.png", Year = 2031 }
			};


			BindingContext = new PageViewModel(_cardDatas);
		}
	}
}