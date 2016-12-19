using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SoftwarePac.Procurement
{
    public class Reader
    {
        private readonly string locale;

        public readonly List<Software> Storage;

        public Reader(string locale)
        {
            Storage = new List<Software>();
            this.locale = locale;
        }

        /// <summary>
        /// Look into directory location and parse all .json files.
        /// </summary>
        /// <returns>Success or failure</returns>
        public bool Parse()
        {
            crawl(locale);
            return Storage.Count > 0;
        }

        /// <summary>
        /// Crawls a directory and its sub directories for package files
        /// </summary>
        /// <param name="path"></param>
        private void crawl(string path)
        {
            if (!Directory.Exists(locale)) return;
            foreach (var entry in Directory.GetFileSystemEntries(locale))
            {
                if (!entry.EndsWith(".json")) continue;
                var pac = JsonConvert.DeserializeObject<Software[]>(File.ReadAllText(entry));
                Storage.AddRange(pac);
            }
            // Recur
            foreach (var directory in Directory.GetDirectories(path))
                crawl(directory);
        }
    }
}
