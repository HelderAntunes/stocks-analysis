using System;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCMOV2.Models;
using Newtonsoft.Json;

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
                    HttpResponseMessage message = await client.GetAsync(App.base_url);
                    lbResult.Text = message.StatusCode.ToString();
                    if (message.StatusCode == HttpStatusCode.OK)
                    {
                        StockList r = JsonConvert.DeserializeObject<StockList>(await message.Content.ReadAsStringAsync());
                        string jsonParsed = r.results[0].symbol + " - " + r.results.Count + "\n";
                        foreach (var stock in r.results)
                        {
                            jsonParsed += stock.tradingDay + " - " + stock.close + "\n";
                        }
                        lbResult.Text = jsonParsed;
                    }
                }
                catch (Exception ex)
                {
                    lbResult.Text = ex.ToString();
                }
        }
    }
}