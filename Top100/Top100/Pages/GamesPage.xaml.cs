using Core;
using Scratches;
using Web;

namespace Pages
{

	public partial class GamesPage : ApiPage
	{

        protected override ContentType ContentType
        {

            get => ContentType.Games;
        }


        protected override KeyValuePair<string, string> ApiToken
        {

            get => new("key", "4ac16da180e847b3ba4cce6525a8bfdf");
        }



        private readonly PageViewModel<RawgTag> _collectionsModel;


        public GamesPage()
		{

			InitializeComponent();


            _collectionsModel = new PageViewModel<RawgTag>();


            BindingContext = _collectionsModel;
        }


        protected override async Task GetAllCollectionsAsync(string request)
        {


            RawgCollection collection = await 
                
                Rest.GetAsync<RawgCollection>(request);


            for (int i = 0; i < collection.Results.Count; i++)
            {

                RawgTag tag = collection.Results[i];

                tag.Category = tag.GamesCount.ToString();


                string url = tag.ImageBackground;

                tag.Poster = new PosterData(url, url);


                collection.Results[i] = tag;
            }


            _collectionsModel.SetCards(collection.Results);
        }


        protected override async Task<IReadOnlyCollection<CardData>>
            GetCurrentCollectionsAsync(string request)
        {


            RawgCollection collection = await 
                
                Rest.GetAsync<RawgCollection>(request);


            List<CardData> cards = new (collection.Results.Count);


            for (int i = 0; i < collection.Results.Count; i++)
            {

                RawgTag rawg = collection.Results[i];


                CardData card = new()
                {

                    Name = rawg.Name,

                    Poster = new PosterData(rawg.BackgroundImage, rawg.BackgroundImage),

                    Year = rawg.Id
                };


                cards.Add(card);
            }


            return cards;
        }
    }
}