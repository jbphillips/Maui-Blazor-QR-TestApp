using Maui_Blazor_QR_TestApp.Services;

namespace Maui_Blazor_QR_TestApp
{
    public partial class App : Application
    {
        public App(QRCodeService readerService)
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new MainPage(readerService);
        }
    }
}