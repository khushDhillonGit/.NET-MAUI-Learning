
namespace TestMaui.Models
{
    public class Search
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string GetFormattedDate { get { return string.Format($"{CheckIn.ToShortDateString()} - {CheckOut.ToShortDateString()}"); } }
    }
}
