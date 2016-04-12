using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Data.Pdf;
using Windows.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SEM.DesktopClient
{
    public sealed partial class PdfView : ContentDialog
    {
        private byte[] pdf;

        public PdfView()
        {
            this.InitializeComponent();
        }

        public PdfView(byte[] pdf) : this()
        {
            this.pdf = pdf;
            var capacity = pdf.Length;
            var buf = new Windows.Storage.Streams.Buffer((uint)capacity);
            buf.AsStream().Read(pdf, 0, capacity);
            //webView.NavigateWithHttpRequestMessage(new Windows.Web.Http.HttpRequestMessage()
            //{
            //    RequestUri = new System.Uri(@"C:\sources\Sergiy_Kryvonos_SEM_Journals_NET\Source\SEM\SEM.DesktopClient\pdfjs-1.3.91-dist\build\pdf.js"),
            //    Content = new HttpBufferContent (buf),
            //});
            var ms = new MemoryStream(pdf);
            var pdfDocLoadTask = PdfDocument.LoadFromStreamAsync(ms.AsRandomAccessStream());
            pdfDocLoadTask.AsTask().ContinueWith(task => {
                if(task.Status==System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    PdfDocument pdfDoc = task.Result;
                    var page = pdfDoc.GetPage(0);
                    MemoryStream msImg = new MemoryStream();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        BitmapImage img = new BitmapImage(
                        );
                        var rndImgStream = msImg.AsRandomAccessStream();
                        page.RenderToStreamAsync(rndImgStream).AsTask().ContinueWith(pageRenderTask =>
                        {
                            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                            {
                                img.SetSource(rndImgStream);
                                image.Source = img;
                            });

                        });
                    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }
                    
            });
            
            
            //webView.InvokeScriptAsync("pdfjs-1.3.91-dist/build/pdf.js", new string[] { @"C:\\sources\\oo\\evince\\browser-plugin\\tests\\test.pdf" }).AsTask().ContinueWith(str=>
            //{

            //});
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
