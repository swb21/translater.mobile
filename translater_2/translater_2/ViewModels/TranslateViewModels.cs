using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using translater_2.Models;
using translater_2.Services;
using Xamarin.Forms;

namespace translater_2.ViewModels
{
    public class TranslateViewModels : ContentPage
    {
        public string Word { get; set; }
        public string TranslatedString { get; set; }
        public string PartOfSpeech { get; set; }

        private readonly Page _page;
        public TranslateViewModels(Page page)
        {
            _page = page;
        }

        public async Task<ObservableCollection<DefModel>> Translate(string lang)
        {
            var dataService = DataService.GetInstance();
            var response = await dataService.TranslateAsync(lang, Word);

            if (response.def.Count == 0)
            {
                await _page.DisplayAlert("Упс...", "Мы не знаем перевода такого слова", "Ок");
                return new ObservableCollection<DefModel>();
            } else
            {
                TranslatedString = $"{response.def[0].text} [{response.def[0].ts}] - {response.def[0].tr[0].text}";
                PartOfSpeech = response.def[0].pos;
                return response.def;
            }
        }
    }
}
