namespace ShopApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        public string AppName => AppInfo.Current.Name;
        public string AppVersion => AppInfo.Current.VersionString;


        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var uri = new Uri("https://github.com/xNaughty/BugBountyTips");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    } 
} 