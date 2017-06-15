using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translater_2.ViewModels;
using Xamarin.Forms;

namespace translater_2.Views
{
    public partial class TranslatePage : ContentPage
    {
        private bool clicked { get; set; } = false;

        public TranslatePage()
        {
            InitializeComponent();
            BindingContext = new TranslateViewModels();
        }

        public void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            header.Text = "Вы выбрали: "; ;
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            if (!clicked)
            {
                Label label1 = new Label()
                {
                    Text = "Перевод: "
                };

                Label label2 = new Label()
                {
                    TextColor = Color.FromHex("#ffffff"),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                };

                Binding binding1 = new Binding { Path = "TraslatedWord", Mode = BindingMode.OneWay };
                label2.SetBinding(Label.TextProperty, binding1);

                StackLayout stackLayout = new StackLayout()
                {
                    BackgroundColor = Color.FromHex("#FF9B2E"),
                    Children = { label2 }
                };
                stackLayout.Padding = new Thickness(5, 40, 5, 40);

                translate.Children.Add(label1);
                translate.Children.Add(stackLayout);

                clicked = !clicked;
            }
        }
    }
}
