using System;
using System.ComponentModel.DataAnnotations;

namespace Codecool.HackerNewsClient.Models
{
    public class TopNews
    {
        public int Id { get; set; }
        [Display(Name = "Title(display)")]
        public string Title { get; set; }

        [Display(Name = "Link(display)")]
        public string Link { get; set; }

        [Display(Name = "Author(display)")]
        public string TitleAuthor { get; set; }

        [Display(Name = "Time Ago(display)")]
        public string TimeAgo { get; set; }
        public string Time { get; set; }
        public string Points { get; set; }

        //[DataType(DataType.Date)]
        //    public DateTime ReleaseDate { get; set; }



    }
}
