using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_1
{
    abstract class AbstractHandler<TContentType>
    {
        public string Path { get; set; }
        protected FileStream File { get; set; }

        public TContentType RecievedContent { protected set; get; }
        public TContentType GivenContent { set; get; }

        abstract public void OpenDocument();
        abstract public void CreateDocument();
        abstract public void EditDocument();
    }
}
