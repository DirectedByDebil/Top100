using Web;
using Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Scratches;

namespace Pages
{

	public abstract partial class ApiPage : ContentPage
	{

        protected RestService Rest { get; private set; }


        protected abstract ContentType ContentType { get; }

        protected abstract KeyValuePair<string, string> ApiToken { get; }


        private readonly ScratchesPage _scratchesPage;


        private object? _lastCollection;



        public ApiPage()
		{

            Rest = new RestService();

            Rest.AddHeader(ApiToken.Key, ApiToken.Value);
           


			InitializeComponent();

            Loaded += OnPageLoadedAsync;


            _scratchesPage = new ScratchesPage(ContentType);



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
        }


        protected abstract Task GetAllCollectionsAsync(string request);


        protected abstract Task<IReadOnlyCollection<CardData>>
            GetCurrentCollectionsAsync(string request);



        private async void OnPageLoadedAsync(object? sender, EventArgs e)
        {

            Loaded -= OnPageLoadedAsync;

            await LoadCardsAsync();
        }


        private async Task LoadCardsAsync()
        {

            string request = UrlFactory.GetAllCollections(ContentType);


            await GetAllCollectionsAsync(request);
        }


        private async void OnSelectionChanged(object obj)
        {

            if (_lastCollection != obj &&

                UrlFactory.TryGetCurrentCollection(ContentType,

                obj, out string request))
            {

                Task<IReadOnlyCollection<CardData>> task =
                
                    GetCurrentCollectionsAsync(request);
                

                IEnumerable<ContentID>? ids =

                    SessionData.GetConsumed(ContentType);


                _scratchesPage.UpdateScratches(await task);

                
                if (ids != null)
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