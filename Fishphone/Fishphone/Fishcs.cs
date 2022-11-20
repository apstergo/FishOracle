using System;
using System.Collections.Generic;
using System.Text;

namespace Fishphone
{
    public class Fishcs
    {
        public long id { get; set; }
        public string nameitem { get; set; }
        public string pictureref { get; set; }
        public string opis { get; set; }
        public string prev { get; set; }
        public string type { get; set; }
        public string rod { get; set; }
        public string fam { get; set; }
        public string type_feed { get; set; }
        public string areal { get; set; }
        public string area { get; set; }
        public string feed { get; set; }
        public string reprod { get; set; }
        public string lifestyle { get; set; }
        public string naj { get; set; }
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
