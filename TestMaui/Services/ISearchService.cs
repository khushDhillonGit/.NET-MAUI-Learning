using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestMaui.Models;

namespace TestMaui.Services
{
    public interface ISearchService
    {
        IEnumerable<Search> GetSearches(string filter = null);
        void DeleteSearch(int searchId);
    }
}
