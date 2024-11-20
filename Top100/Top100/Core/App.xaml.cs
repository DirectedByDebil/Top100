using System.Text.Json;

namespace Core
{
    public partial class App : Application
    {

        private readonly JsonSerializerOptions _options;

        private readonly string _consumedContent;


        public App()
        {

            InitializeComponent();


            MainPage = new AppShell();


            _options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };


            _consumedContent = Path.Combine(FileSystem.Current.AppDataDirectory,
                
                "Consumed Content.json");
        }


        protected override async void OnStart()
        {

            base.OnStart();


            await SessionData.LoadAsync(_consumedContent, _options);
        }


        protected override async void OnSleep()
        {

            base.OnSleep();


            await SessionData.SaveAsync(_consumedContent, _options);
        }
    }
}
