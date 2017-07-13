using MyMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            

            BindingContextChanged += MainPage_BindingContextChanged;
            BindingContext = new MainPageViewModel();
        }

        private async void MainPage_BindingContextChanged(object sender, System.EventArgs e)
        {
            var model = (MainPageViewModel)BindingContext;

            await model.GetXmlFeed();
        }
    }
}