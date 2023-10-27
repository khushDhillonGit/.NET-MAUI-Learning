using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaui.Models
{
    public class SearchGroup:List<Search>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public SearchGroup(string title, string shortTitle) 
        {
            Title = title;
            ShortTitle = shortTitle;
        }
    }
}
