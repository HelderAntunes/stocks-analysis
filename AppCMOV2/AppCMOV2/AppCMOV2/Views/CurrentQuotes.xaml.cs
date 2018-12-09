using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCMOV2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentQuotes : ContentPage
	{
		public CurrentQuotes ()
		{
			InitializeComponent ();
            callCurrentQuotes();
        }

        private async void callCurrentQuotes()
        {
            using (HttpClient client = new HttpClient())
                try
                {
                    string url = App.base_url + "currentQuotes";
                    HttpResponseMessage message = await client.GetAsync(url);
                    if (message.StatusCode == HttpStatusCode.OK)
                    {
                        string jsonParsed = await message.Content.ReadAsStringAsync();
                        result.Text = jsonParsed;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Some error occurred.(" + message.StatusCode + ")", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Ok");
                }
        }
	}
}