using System;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCMOV2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stocks : ContentPage
	{
		public Stocks ()
		{
			InitializeComponent();
            btCall.Clicked += BtCall_Clicked;
        }

        private async void BtCall_Clicked(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
                try
                {
                    // HttpResponseMessage message = await client.GetAsync(string.Format("http://data.fixer.io/api/latest?access_key=30d32b83f4fe085e9d7d25174db2e2bb&symbols={0}", "EUR"));
                    HttpResponseMessage message = await client.GetAsync("http://localhost:3000/api/stocks?company=INTC&type=monthly&startDate=20180701");
                    lbResult.Text = message.StatusCode.ToString();
                    if (message.StatusCode == HttpStatusCode.OK)
                        lbResult.Text = await message.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    lbResult.Text = ex.Message;
                }
        }
    }
}