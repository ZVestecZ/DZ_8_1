using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal class Song
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public Song Prev { get; private set; }


        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }

        public Song(string name, string author, Song Prevsong)
        {
            Name = name;
            Author = author;
            Prev = Prevsong;
        }

        public Song()
        {

        }

        public string Title()
        {
            return $"{Name} от {Author}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song other = (Song)obj;
            return Name == other.Name && Author == other.Author;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Author.GetHashCode();
        }
    }
}
