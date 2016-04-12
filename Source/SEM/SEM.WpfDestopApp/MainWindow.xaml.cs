using SEM.WpfDestopApp.JournalsServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEM.WpfDestopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public readonly ServiceJournalsAccess service = new ServiceJournalsAccess();
        public MainWindow()
        {
            InitializeComponent();
            
            ServiceJournalsAccessClient service = new ServiceJournalsAccessClient();
            service.ClientCredentials.UserName.UserName = "sergeikrivonos@gmail.com";
            service.ClientCredentials.UserName.Password = "Qwe@123";
            var j = service.GetJournal(
                service.ClientCredentials.UserName.UserName,
                service.ClientCredentials.UserName.Password, 1);
            var subs = service.GetMySubscriptions(
                service.ClientCredentials.UserName.UserName,
                service.ClientCredentials.UserName.Password
                );

            listView.Items.Clear();
            listView.ItemsSource = subs;
            ////var dialog = new LoginDialog();
            ////dialog.ShowAsync().AsTask().ContinueWith(task =>
            //{
            //    //if (task.Status == TaskStatus.RanToCompletion)
            //    //{
            //    //    var result = task.Result;

            //    //    if (result == ContentDialogResult.Primary)
            //    //    {
            //    //        service.ClientCredentials.UserName.UserName = dialog.Login;
            //    //        service.ClientCredentials.UserName.Password = dialog.Password;
            //    //    }
            //    //}
            //    //else {
            //        service.ClientCredentials.UserName.UserName = "sergeikrivonos@gmail.com";
            //        service.ClientCredentials.UserName.Password = "Qwe@123";
            //    //}

            //    GetMySubscriptionsRequest req = new GetMySubscriptionsRequest(
            //        service.ClientCredentials.UserName.UserName,
            //        service.ClientCredentials.UserName.Password);
            //    service.GetMySubscriptionsAsync(req).ContinueWith(t =>
            //    {
            //        CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            //            () =>
            //            {
            //                if (t.Status == TaskStatus.RanToCompletion)
            //                {
            //                    listView.ItemsSource = t.Result;
            //                }
            //                else
            //                {
            //                    listView.Items.Add(t.Exception.Message);
            //                    foreach (var e in t.Exception.InnerExceptions)
            //                    {
            //                        listView.Items.Add(e.Message);
            //                    }
            //                }
            //            });
            //    });

            //});
        }
    }
}
