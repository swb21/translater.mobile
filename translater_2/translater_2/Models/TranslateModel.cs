using System.Collections.ObjectModel;

namespace translater_2.Models
{
    public class TranslateModel
    {
        public string text { get; set; }
        public string pos { get; set; }
        public ObservableCollection<SynMeanModel> syn { get; set; }
        public ObservableCollection<SynMeanModel> mean { get; set; }
        public ObservableCollection<ExampleModel> ex { get; set; }
    }
}
