using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Lab6_1
{
    class WordDoc : AbstractHandler<string>
    {
        Application Application { set; get; }
        Document doc { get; set; }

        public WordDoc(string path)
        {
            Path = path;
            GivenContent = "";
            Application = new Application();
        }
        public override void OpenDocument()
        {
            File = new FileStream(Path, FileMode.Open);
            try
            {
                Application.ScreenUpdating = true;
                Application.Visible = true;
                doc = Application.Documents.Open(FileName: Path, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                RecievedContent = "";
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                    if (temp != string.Empty)
                        RecievedContent += temp;
                }
                Application.Documents.Close(Missing.Value, Missing.Value, Missing.Value);
            }
            catch 
            {
                Console.WriteLine("Доступ к документу запрещен");
            }
            
        }
        public override void CreateDocument()
        {
            File = new FileStream(Path, FileMode.CreateNew);
            doc = Application.Documents.Add(Path);
        }
        public override void EditDocument()
        {
            File = new FileStream(Path, FileMode.Append);
            try
            {
                doc = Application.Documents.Open(FileName: Path, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Selection currentSelection = Application.Selection;
                Application.Options.Overtype = false;
                if (currentSelection.Type == WdSelectionType.wdSelectionIP)
                {
                    currentSelection.TypeText(GivenContent);
                    currentSelection.TypeParagraph();
                }
                doc.Save();
            }
            catch 
            {
                Console.WriteLine("Доступ к документу запрещен");
            }
            
        }
    }
}
