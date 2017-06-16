using System.Collections.ObjectModel;

namespace translater_2.Models
{
    public class ExampleModel
    {
        public string text { get; set; }
        public ObservableCollection<SimpleTranslateModel> tr { get; set; }
        public string num { get; set; }
        public string pos { get; set; }
        public string gen { get; set; }
    }
}
