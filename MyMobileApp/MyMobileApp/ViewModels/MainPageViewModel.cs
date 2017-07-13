using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyMobileApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FeedItem> FeedItems { get; set; } = new ObservableCollection<FeedItem>();

        public async Task GetXmlFeed()
        {
            var feedXml = "";

            IsBusy = true;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://feeds.reuters.com/Reuters/worldNews");

                feedXml = await response.Content.ReadAsStringAsync();
            }

            ;
            try
            {
                var doc = XDocument.Parse(feedXml);
                var items = doc.Element("rss").Element("channel").Elements("item")
                               .Select(i => new FeedItem {
                                   Title = i.Element("title").Value,
                                   Description = Regex.Replace(i.Element("description").Value, "<.*?>", "").Trim(),
                                   Url = i.Element("link").Value
                               });

                foreach (var item in items)
                {
                    FeedItems.Add(item);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
