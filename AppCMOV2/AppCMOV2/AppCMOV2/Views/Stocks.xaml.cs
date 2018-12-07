using System;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCMOV2.Models;
using Newtonsoft.Json;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using System.Collections.Generic;

namespace AppCMOV2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stocks : ContentPage
	{
        List<double> stockPrices = new List<double>();

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
                            stockPrices.Add(stock.close);
                        }
                        lbResult.Text = jsonParsed;
                        chartCanvasView.InvalidateSurface();
                    }
                }
                catch (Exception ex)
                {
                    lbResult.Text = ex.ToString();
                }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            if (stockPrices.Count == 0)
            {
                return;
            }

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // AXES
            SKPath path = new SKPath();
            float paddingX = 0.1f * info.Width;
            float paddingY = 0.1f * info.Height;
            // X
            path.MoveTo(paddingX, info.Height - paddingY);
            path.LineTo(info.Width - paddingX, info.Height - paddingY);
            // Y
            path.MoveTo(paddingX, info.Height - paddingY);
            path.LineTo(paddingX, paddingY);

            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 2
            };
            canvas.DrawPath(path, strokePaint);

            // STOCK PRICES
            int numPoints = stockPrices.Count;
            double minPrice = stockPrices[0];
            double maxPrice = stockPrices[0];
            foreach (double price in stockPrices)
            {
                minPrice = Math.Min(minPrice, price);
                maxPrice = Math.Max(maxPrice, price);
            }
            double diffPrices = maxPrice - minPrice;
            double initY = info.Height - paddingY - paddingY * 0.5;
            double endY = paddingY;
            double diffScaleY = - endY + initY;
            double initX = paddingX;
            double endX = info.Width - paddingX;
            double diffScaleX = endX - initX;
            List<double> pricesY = new List<double>();
            List<double> pricesX = new List<double>();
            for (int i = 0; i < stockPrices.Count; i++)
            {
                double price = stockPrices[i];
                double y = initY - (price - minPrice) / diffPrices * diffScaleY;
                pricesY.Add(y);
                double x = initX +  i / (double)(numPoints-1) * diffScaleX;
                pricesX.Add(x);
            }
            

            SKPath pathStockPrices = new SKPath();
            pathStockPrices.MoveTo((float)pricesX[0], (float)pricesY[0]);
            for (int i = 1; i < stockPrices.Count; i++)
            {
                pathStockPrices.LineTo((float)pricesX[i], (float)pricesY[i]);
            }

            SKPaint strokePaintStockPrices = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 2
            };
            canvas.DrawPath(pathStockPrices, strokePaintStockPrices);
        }
    }
}