using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppCMOV2.Models
{
    class Company : INotifyPropertyChanged
    {
        public string DisplayName { get; set; }
        public string ImageSource { get; set; }
        public bool Selected { get; set; }
        public string Color { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void SetColor(string newColor)
        {
            this.Color = newColor;
            PropertyChanged(this, new PropertyChangedEventArgs("Color"));
        }
    }
}
