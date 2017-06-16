using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translater_2.Services;
using translater_2.ViewModels;
using Xamarin.Forms;

namespace translater_2.Views
{
    public partial class TranslatePage : ContentPage
    {
        private TranslateViewModels translateViewModel { get; set; }

        public string Lang { get; set; } = "en-ru";
        public string Word { get; set; }

        public TranslatePage()
        {
            InitializeComponent();
            translateViewModel = new TranslateViewModels(this);
            BindingContext = translateViewModel;
        }

        public void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            header.Text = "Вы выбрали: ";

            if (picker.SelectedIndex == 0)
            {
                Lang = "en-ru";
            } else
            {
                Lang = "ru-en";
            }
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            translate.Children.Clear();
            meanSt.Children.Clear();
            synSt.Children.Clear();
            exSt.Children.Clear();

            var Def = await translateViewModel.Translate(Lang);

            if (Def[0].text != null)
            {
                Label label1 = new Label()
                {
                    Text = "Перевод: ",
                };

                Label label2 = new Label()
                {
                    TextColor = Color.FromHex("#ffffff"),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                };

                Label label3 = new Label()
                {
                    TextColor = Color.FromHex("#DEDEDE"),
                };

                Binding binding1 = new Binding { Path = "TranslatedString", Mode = BindingMode.OneWay };
                label2.SetBinding(Label.TextProperty, binding1);

                Binding binding2 = new Binding { Path = "PartOfSpeech", Mode = BindingMode.OneWay };
                label3.SetBinding(Label.TextProperty, binding2);

                if (Def[0].tr.Count > 1)
                {
                    Label otherTranslates = new Label()
                    {
                        Text = "Другие переводы: ",
                    };

                    StackLayout OtherTranslates = new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#EEEEEE")
                    };

                    for (int i = 1; i < Def[0].tr.Count; i++)
                    {
                        Label otherTranslatesLabel = new Label()
                        {
                            Text = $"{Def[0].tr[i].text} - {Def[0].tr[i].pos}",
                        };
                        OtherTranslates.Children.Add(otherTranslatesLabel);
                    }

                    OtherTranslates.Padding = new Thickness(5, 15, 5, 15);
                    otherTranslatesSt.Children.Add(otherTranslates);
                    otherTranslatesSt.Children.Add(OtherTranslates);
                }

                if (Def[0].tr[0].mean != null)
                {
                    Label mean = new Label()
                    {
                        Text = "Значения: ",
                    };

                    StackLayout Mean = new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#EEEEEE")
                    };

                    for (int i = 0; i < Def[0].tr[0].mean.Count; i++)
                    {
                        Label meanLabel = new Label()
                        {
                            Text = Def[0].tr[0].mean[i].text,
                        };
                        Mean.Children.Add(meanLabel);
                    }

                    Mean.Padding = new Thickness(5, 15, 5, 15);
                    meanSt.Children.Add(mean);
                    meanSt.Children.Add(Mean);
                }

                if (Def[0].tr[0].syn != null)
                {
                    Label syn = new Label()
                    {
                        Text = "Синонимы: ",
                    };

                    StackLayout Syn = new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#EEEEEE")
                    };

                    for (int i = 0; i < Def[0].tr[0].syn.Count; i++)
                    {
                        Label synLabel = new Label()
                        {
                            Text = Def[0].tr[0].syn[i].text,
                        };
                        Syn.Children.Add(synLabel);
                    }

                    Syn.Padding = new Thickness(5, 15, 5, 15);
                    synSt.Children.Add(syn);
                    synSt.Children.Add(Syn);
                }

                if (Def[0].tr[0].ex != null)
                {
                    Label ex = new Label()
                    {
                        Text = "Примеры: ",
                    };

                    StackLayout Ex = new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#EEEEEE")
                    };

                    for (int i = 0; i < Def[0].tr[0].ex.Count; i++)
                    {
                        Label exLabel = new Label()
                        {
                            Text = $"{Def[0].tr[0].ex[i].text} - {Def[0].tr[0].ex[i].tr[0].text}",
                        };
                        Ex.Children.Add(exLabel);
                    }

                    Ex.Padding = new Thickness(5, 15, 5, 15);
                    exSt.Children.Add(ex);
                    exSt.Children.Add(Ex);
                }

                if (Def.Count > 1)
                {
                    Label similar = new Label()
                    {
                        Text = "Части речи: ",
                    };

                    StackLayout Similar = new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#EEEEEE")
                    };

                    for (int i = 0; i < Def.Count; i++)
                    {
                        Label similarLabel = new Label()
                        {
                            Text = $"{Def[i].tr[0].text} - {Def[i].pos}",
                        };
                        Similar.Children.Add(similarLabel);
                    }

                    Similar.Padding = new Thickness(5, 15, 5, 15);
                    similarSt.Children.Add(similar);
                    similarSt.Children.Add(Similar);
                }

                StackLayout stackLayout = new StackLayout()
                {
                    BackgroundColor = Color.FromHex("#FF9B2E"),
                    Children = { label2, label3 }
                };

                stackLayout.Padding = new Thickness(5, 25, 5, 25);
                translate.Children.Add(label1);
                translate.Children.Add(stackLayout);
            }
        }
    }
}
