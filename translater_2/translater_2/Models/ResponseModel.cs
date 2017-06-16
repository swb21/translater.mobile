using System.Collections.ObjectModel;

namespace translater_2.Models
{
    public class ResponseModel
    {
        public HeadModel head { get; set; }
        public ObservableCollection<DefModel> def { get; set; }
    }
}
