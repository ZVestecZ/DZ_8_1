using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public class Report
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Person Author { get; set; }
        public Report(string text, Person author)
        {
            Text = text;
            Date = DateTime.Now;
            Author = author;
        }
    }
}
