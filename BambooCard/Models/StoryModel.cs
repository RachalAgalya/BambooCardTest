using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BambooCard.Models
{
    public class StoryModel
    {
        public int Id { get; set; }
        public string? By { get; set; }
        public int Descendants { get; set; }
        public List<int>? Kids { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
    }

    public class StoryDetailModel
    {
        public string? Title { get; set; }
        public string? Uri { get; set; }
        public string? PostedBy { get; set; }
        public DateTime Time { get; set; }
        public int Score { get; set; }
        public int CommentCount { get; set; }       
    }
}
