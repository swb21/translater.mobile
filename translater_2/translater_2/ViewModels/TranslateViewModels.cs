using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace translater_2.ViewModels
{
    public class TranslateViewModels : ContentPage
    {
        public string Word { get; set; } = "dog";
        public string TraslatedWord { get; set; } = "собака";
        public TranslateViewModels()
        {
            
        }
    }
}
