using Scratches;
using Web;
using Core;
using System.Collections.Generic;

namespace Pages
{

	public partial class MoviesPage : ApiPage
	{

		protected override ContentType ContentType
		{

			get => ContentType.Movies;
		}

		protected override KeyValuePair<string, string> ApiToken
		{

			get => new ("X-API-KEY", "1C34DM1-T0P43D3-KJM6SXA-BASTTPZ");
		}



        private readonly PageViewModel<
			
			KinopoiskCollectionData> _collectionsModel;       


		public MoviesPage()
		{

            InitializeComponent();


            _collectionsModel = new PageViewModel<
				
				KinopoiskCollectionData>();


			BindingContext = _collectionsModel;
		}


        protected override async Task GetAllCollectionsAsync(string request)
        {

            KinopoiskData<KinopoiskCollectionData> data = await

                Rest.GetAsync<KinopoiskData

                <KinopoiskCollectionData>>(request);


            _collectionsModel.SetCards(data.Docs);
        }


        protected override async Task<IReadOnlyCollection<CardData>>
			GetCurrentCollectionsAsync(string request)
        {

            KinopoiskData<CardData> cardsData = await
				
				Rest.GetAsync<KinopoiskData<CardData>>(request);


			return cardsData.Docs;
        }
    }
}