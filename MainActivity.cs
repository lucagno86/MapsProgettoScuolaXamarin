using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace Maps.Droid
{
	//specifiche per l'aspetto
    [Activity(Label = "Maps", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true
		, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode
		| ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
		
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;

		//prende i permessi da AndroidManifest
        readonly string[] LocalPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

		//funzione che viene chiamata all'avvio dell'app
        protected override void OnStart()
        {
            base.OnStart();

			//si accerta di avere i permessi per la posizione
            if((int)Build.VERSION.SdkInt >= 23)
            {
                if(CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocalPermissions, RequestLocationId);
                }
            }
        }

		//funzione chiamata la prima volta che si avvia l'app
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}
