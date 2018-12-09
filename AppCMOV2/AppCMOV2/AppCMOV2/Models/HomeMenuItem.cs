using System;
using System.Collections.Generic;
using System.Text;

namespace AppCMOV2.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Stocks,
        CurrentQuotes
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
