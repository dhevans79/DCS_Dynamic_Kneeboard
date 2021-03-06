using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace DCS_Dynamic_Kneeboard
{
	public partial class App : Application
	{
		public App ()
		{
            // LOAD FORM - Initialise Xaml
			InitializeComponent();

			MainPage = new NavigationPage(new MainMenu());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
