using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TxtDoc doc = new TxtDoc(@"docs\text.txt");
            doc.OpenDocument();

            Console.WriteLine(doc.RecievedContent);
            Console.WriteLine();
            Console.WriteLine();
            WordDoc wordDoc = new WordDoc(@"C:\Users\user\source\repos\Lab6_1\Lab6_1\bin\Debug\docs\word.docx");
            wordDoc.GivenContent = "new text";
            wordDoc.EditDocument();
            

            Console.ReadKey();
        }
    }
}
