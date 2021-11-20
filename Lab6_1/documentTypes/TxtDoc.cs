using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab6_1
{
    class TxtDoc : AbstractHandler<string>
    {
        public TxtDoc(string path)
        {
            Path = path;
            GivenContent = "";
        }
        public override void OpenDocument()
        {
            File = new FileStream(Path,FileMode.Open);
            var streamReader = new StreamReader(File);
            RecievedContent = streamReader.ReadToEnd();
        }
        public override void CreateDocument()
        {
            File = new FileStream(Path,FileMode.CreateNew);
        }
        public override void EditDocument()
        {
            File = new FileStream(Path,FileMode.Append);
            var streamWrite = new StreamWriter(File);
            streamWrite.Write(GivenContent);
        }
    }
}
