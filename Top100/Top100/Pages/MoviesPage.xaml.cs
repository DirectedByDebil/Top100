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

                Rest.GetRequestAsync<KinopoiskData

                <KinopoiskCollectionData>>(request);


            _collectionsModel.SetCards(data.Docs);
        }


        protected override async Task<IReadOnlyCollection<CardData>>
			GetCurrentCollectionsAsync(string request)
        {

            KinopoiskData<CardData> cardsData = await
				
				Rest.GetRequestAsync<KinopoiskData<CardData>>(request);


			return cardsData.Docs;
        }
    }
}