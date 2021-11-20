using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_2
{
    class PlayerItem
    {
        public IMedia File { get; set; }
        public string fileName { get; set; }
        public PlayerItem(IMedia file)
        {
            File = file;
        }
        public PlayerItem()
        {
            File = null;
        }
    }
}
