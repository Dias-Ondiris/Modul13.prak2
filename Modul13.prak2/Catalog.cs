using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Modul13.prak2
{
    public class Catalog
    {
        private Hashtable cds = new Hashtable();

        public void AddCD(string title, List<string> songs)
        {
            cds[title] = songs;
        }

        public void RemoveCD(string title)
        {
            cds.Remove(title);
        }

        public void AddSong(string title, string song)
        {
            if (cds.ContainsKey(title))
            {
                ((List<string>)cds[title]).Add(song);
            }
        }

        public void RemoveSong(string title, string song)
        {
            if (cds.ContainsKey(title))
            {
                ((List<string>)cds[title]).Remove(song);
            }
        }

        public void PrintCatalog()
        {
            foreach (DictionaryEntry cd in cds)
            {
                Console.WriteLine($"CD: {cd.Key}, Песни: {string.Join(", ", (List<string>)cd.Value)}");
            }
        }
    }
}
