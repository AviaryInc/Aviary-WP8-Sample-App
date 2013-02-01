using Aviary.SDKs.WP8.TestApp.Resources;

namespace Aviary.SDKs.WP8.TestApp
{
   /// <summary>
   /// Provides access to string resources.
   /// </summary>
   public class LocalizedStrings
   {
      private static AppResources _localizedResources = new AppResources();

      public AppResources LocalizedResources { get { return _localizedResources; } }
   }
}