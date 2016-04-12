using SEM.DesktopClient.ServiceJournalAccessReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SEM.DesktopClient
{
    public static partial class Extensions
    {
        static string ToString(this Subscription s)
        {
            return s.Title + " [" + s.JournalId + "]";
        }
    }
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static MainPage()
        {

        }


        public MainPage()
        {
            this.InitializeComponent();

            var dialog = new LoginDialog();
            dialog.ShowAsync().AsTask().ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    var result = task.Result;
                    if (result == ContentDialogResult.Primary)
                    {
                        App.Service.ClientCredentials.UserName.UserName = dialog.Login;
                        App.Service.ClientCredentials.UserName.Password = dialog.Password;
                    }
                }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        var listDialog = new ChooseJournal();
                        listDialog.ShowAsync().AsTask().ContinueWith(chooseTask =>
                        {
                            if (chooseTask.Status == TaskStatus.RanToCompletion
                                && chooseTask.Result == ContentDialogResult.Primary)
                            {
                                var journalRequest = new GetJournalRequest(
                                    App.Service.ClientCredentials.UserName.UserName,
                                    App.Service.ClientCredentials.UserName.Password,
                                    listDialog.JournalId);
                                App.Service.GetJournalAsync(journalRequest).ContinueWith(getJournalTask =>
                                {
                                    if (getJournalTask.Status == TaskStatus.RanToCompletion
                                        && getJournalTask.Result.GetJournalResult != null)
                                    {
                                        // PDF View
                                        CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                                        {
                                            var pdfView = new PdfView(getJournalTask.Result.GetJournalResult);
                                            pdfView.ShowAsync();
                                        });
                                    }
                                });

                            }

                        });
                    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            });
        }
    }
}
