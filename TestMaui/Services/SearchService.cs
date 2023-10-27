using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMaui.Models;

namespace TestMaui.Services
{
    public class SearchService : ISearchService
    {
        List<Search> _search;

        public SearchService() 
        {
            _search = new List<Search>()
            {
                new Search{ Id = 1, CheckOut = new DateTime(2016,11,1) , Location = "West Hollywood, CA, United States", CheckIn = new DateTime(2016,09,1)},
                new Search{ Id = 2, CheckOut = new DateTime(2016,11,1) , Location = "Santa Monica, CA, United States", CheckIn = new DateTime(2016,09,1)}
            };
        }

        public void DeleteSearch(int searchId)
        {
            _search.Remove(_search.FirstOrDefault(a => a.Id == searchId));
        }

        public IEnumerable<Search> GetSearches(string filter = null)
        {
            
            if (string.IsNullOrWhiteSpace(filter)) 
            {
                return _search;
            }

            return _search.Where(a=>a.Location.ToLower().StartsWith(filter.ToLower()));

        }
    }
}
