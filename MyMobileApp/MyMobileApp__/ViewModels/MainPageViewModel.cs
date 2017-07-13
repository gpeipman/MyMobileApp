using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyMobileApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {           
            //try
            //{
            //    var doc = XDocument.("http://feeds.reuters.com/Reuters/worldNews");
            //    var x = doc.Root.ToString();
            //    var items = doc.Element("channel").Elements("item").ToList();
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
