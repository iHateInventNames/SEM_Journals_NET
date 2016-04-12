using SEM.DesktopClient.ServiceJournalAccessReference;
using System;
using System.Collections.Generic;
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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SEM.DesktopClient
{
    public sealed partial class ChooseJournal : ContentDialog
    {
        private class JournalInfoWrapper : Subscription
        {
            public JournalInfoWrapper(Subscription s) {
                JournalId = s.JournalId;
                Title = s.Title;
            }

            public override string ToString()
            {
                return this.Title + " [" + JournalId + "]";
            }
        }

        public ChooseJournal()
        {
            this.InitializeComponent();

            GetMySubscriptionsRequest req = new GetMySubscriptionsRequest(
                App.Service.ClientCredentials.UserName.UserName,
                App.Service.ClientCredentials.UserName.Password);
            App.Service.GetMySubscriptionsAsync(req).ContinueWith(t =>
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        if (t.Status == TaskStatus.RanToCompletion)
                        {
                            listView.ItemsSource = t.Result.GetMySubscriptionsResult.Select(j => new JournalInfoWrapper(j));
                        }
                        else
                        {
                            listView.Items.Add(t.Exception.Message);
                            foreach (var e in t.Exception.InnerExceptions)
                            {
                                listView.Items.Add(e.Message);
                            }
                        }
                    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            });


        }

        public int JournalId { get; private set; }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            JournalId = (e.ClickedItem as Subscription).JournalId;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            JournalId = (listView.SelectedItem as Subscription).JournalId;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
