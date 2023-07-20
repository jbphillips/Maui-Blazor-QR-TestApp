using Maui_Blazor_QR_TestApp.Services;
using ZXing;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using BarcodeFormat = ZXing.Net.Maui.BarcodeFormat;

namespace Maui_Blazor_QR_TestApp
{

    public partial class MainPage : ContentPage
    {
        QRCodeService readerService;
        ZXing.Net.Maui.Controls.CameraBarcodeReaderView qrView = null;

        public MainPage(QRCodeService readerService)
        {
            InitializeComponent();
            this.readerService = readerService;
            this.readerService.QRShowEvent += QRShowCamera;
            this.readerService.QRHideEvent += QRHideCamera;
        }

        async Task QRShowCamera()
        {
            Dispatcher.Dispatch(() =>
            {
                scanner.IsVisible = true;
                qrView = CreateQRView();
                scanner.Content = qrView;
            });
        }
        async Task QRHideCamera()
        {
            Dispatcher.Dispatch(() =>
            {
                scanner.IsVisible = false;
                scanner.Content = null;
                // qrView.Dispose ???
            });
        }

        ZXing.Net.Maui.Controls.CameraBarcodeReaderView CreateQRView()
        {
            var view = new ZXing.Net.Maui.Controls.CameraBarcodeReaderView() { WidthRequest = 300, HeightRequest = 300, IsDetecting = true };
            view.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormat.QrCode,
                AutoRotate = true,
                Multiple = true
            };

            view.BarcodesDetected += View_BarcodesDetected;
            return view;
        }

        protected async void View_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            Dispatcher.Dispatch(() =>
            {
                readerService.SetCodeContent(e.Results.First().Value);
            });
            await QRHideCamera();
        }
    }
}
