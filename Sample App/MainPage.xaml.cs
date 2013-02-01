using Aviary.SDKs.WP8;
using Aviary.SDKs.WP8.TestApp.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Aviary.SDKs.WP8.TestApp
{
   public partial class MainPage : PhoneApplicationPage
   {
      // Constructor
      public MainPage()
      {
         InitializeComponent();

         // Sample code to localize the ApplicationBar
         //BuildLocalizedApplicationBar();
      }

      private static async Task<Stream> GetSmileyFileStream()
      {
         StorageFolder store = Windows.ApplicationModel.Package.Current.InstalledLocation;
         StorageFile file = await store.GetFileAsync(@"Assets\smiley.jpg");
         Stream str = await file.OpenStreamForReadAsync();
         return str;
      }

      private void LaunchSDK(object sender, RoutedEventArgs e)
      {
         AsyncApplyEffect();
      }

      private async Task AsyncApplyEffect()
      {
         Stream smiley = await GetSmileyFileStream();
         AviaryTask tsk = new AviaryTask(smiley);
         tsk.Completed += tsk_Completed;
         tsk.Show();
      }

      private void tsk_Completed(object sender, AviaryTaskResultArgs e)
      {
         if (e.AviaryResult == AviaryResult.OK)
         {
            img.Source = e.PhotoResult;
         }
      }

      // Sample code for building a localized ApplicationBar
      //private void BuildLocalizedApplicationBar()
      //{
      //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
      //    ApplicationBar = new ApplicationBar();

      //    // Create a new button and set the text value to the localized string from AppResources.
      //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
      //    appBarButton.Text = AppResources.AppBarButtonText;
      //    ApplicationBar.Buttons.Add(appBarButton);

      //    // Create a new menu item with the localized string from AppResources.
      //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
      //    ApplicationBar.MenuItems.Add(appBarMenuItem);
      //}
   }
}