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


            ApplyTheme(Current.RequestedTheme);


            Current.RequestedThemeChanged += (s, e) => ApplyTheme(e.RequestedTheme);

            
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

        private void ApplyTheme(AppTheme theme)
        {
            if (theme == AppTheme.Dark)
            {
                Resources.MergedDictionaries.Add(new Top100.Resources.Styles.DarkTheme());
            }
            else
            {
                Resources.MergedDictionaries.Add(new Top100.Resources.Styles.LightTheme());
            }
        }





        protected override async void OnSleep()
        {

            base.OnSleep();


            await SessionData.SaveAsync(_consumedContent, _options);
        }
    }
}
