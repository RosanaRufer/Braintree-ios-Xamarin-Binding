using System;
using BraintreeBindingiOS;

using Xamarin.Forms;

namespace XFormsApp
{
	public class App : Application
	{
		private string result;
		public App ()
		{
			//WORKS ON SIMULATOR BUT NOT ON DEVICE ;( | TESTED ON IPHONE 5 AND IPHONE 4S
			UseBraintreeLibrary ();
		
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = result,
						}
					}
				}
			};
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

		private void UseBraintreeLibrary ()
		{
			var clientCardRequest = new BTClientCardRequest ();
		}
	}
}

