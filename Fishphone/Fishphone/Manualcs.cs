using System;
using System.Collections.Generic;
using System.Text;

namespace Fishphone
{
    public class Manualcs
    {
        public long id { get; set; }
        public string nameitem { get; set; }
        public string pictureref { get; set; }
        public string opis { get; set; }
        public string prev { get; set; }
        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nameitem) || nameitem.Length == 0)
                    return "?";

                return nameitem[0].ToString().ToUpper();
            }
        }
    }

}
