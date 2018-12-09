using AppCMOV2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<QuoteItem> quotes = new ObservableCollection<QuoteItem>();
        public CurrentQuotes ()
		{
			InitializeComponent ();
            QuotesView.ItemsSource = quotes;
            QuotesView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                ((ListView)sender).SelectedItem = null;
            };
            QuotesView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                ((ListView)sender).SelectedItem = null;
            };
            callCurrentQuotes();
            btUpdate.Clicked += BtCall_Clicked;
        }

        private async void BtCall_Clicked(object sender, EventArgs e)
        {
            btUpdate.IsEnabled = false;
            callCurrentQuotes();
        }

        private async void callCurrentQuotes()
        {
            quotes.Clear();
            using (HttpClient client = new HttpClient())
                try
                {
                    string url = App.base_url + "currentQuotes";
                    Loader.IsVisible = true;
                    Loader.IsRunning = true;
                    HttpResponseMessage message = await client.GetAsync(url);
                    Loader.IsRunning = false;
                    Loader.IsVisible = false;
                    if (message.StatusCode == HttpStatusCode.OK)
                    {
                        string jsonParsed = await message.Content.ReadAsStringAsync();
                        QuoteList r = JsonConvert.DeserializeObject<QuoteList>(jsonParsed);
                        string FinalRes = "";
                        for (int i = 0; i < r.results.Count; i++)
                        {
                            r.results[i].currentInfo = r.results[i].lastPrice + " USD";
                            r.results[i].changeInfo = r.results[i].percentChange + "%";

                            double percentChange = r.results[i].percentChange;
                            if (percentChange < 0)
                            {
                                r.results[i].color = "RED";
                            } else if (percentChange > 0)
                            {
                                r.results[i].color = "GREEN";
                            } else
                            {
                                r.results[i].color = "GRAY";
                            }

                            string symbol = r.results[i].symbol;
                            if (symbol.Equals("AAPL"))
                            {
                                r.results[i].companyName = "Apple";
                                r.results[i].image = "apple_logo.jpg";
                            }
                            else if (symbol.Equals("IBM"))
                            {
                                r.results[i].companyName = "IBM";
                                r.results[i].image = "ibm_logo.png";
                            }
                            else if (symbol.Equals("HPE"))
                            {
                                r.results[i].companyName = "Hewlett Packard";
                                r.results[i].image = "hp_logo.jpg";
                            }
                            else if (symbol.Equals("MSFT"))
                            {
                                r.results[i].companyName = "Microsoft";
                                r.results[i].image = "microsoft_logo.jpg";
                            }
                            else if (symbol.Equals("ORCL"))
                            {
                                r.results[i].companyName = "Oracle";
                                r.results[i].image = "oracle_logo.jpg";
                            }
                            else if (symbol.Equals("GOOGL"))
                            {
                                r.results[i].companyName = "Google";
                                r.results[i].image = "google_logo.png";
                            }
                            else if (symbol.Equals("FB"))
                            {
                                r.results[i].companyName = "Facebook";
                                r.results[i].image = "facebook_logo.png";
                            }
                            else if (symbol.Equals("TWTR"))
                            {
                                r.results[i].companyName = "Twitter";
                                r.results[i].image = "twitter_logo.png";
                            }
                            else if (symbol.Equals("INTC"))
                            {
                                r.results[i].companyName = "Intel";
                                r.results[i].image = "intel_logo.png";
                            }
                            else if (symbol.Equals("AMD"))
                            {
                                r.results[i].companyName = "AMD";
                                r.results[i].image = "amd_logo.jpg";
                            }

                            quotes.Add(r.results[i]);
                            FinalRes += r.results[i].name + "-" + r.results[i].percentChange + "\n";
                        }
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
            btUpdate.IsVisible = true;
            btUpdate.IsEnabled = true;
        }
	}
}