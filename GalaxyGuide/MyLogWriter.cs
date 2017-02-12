using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyGuide
{
    interface ILogWriter
    {
        void WriteLog(string s);
    }
    class TextFileWriter : ILogWriter
    {
        string outputFileName = string.Empty;
        StreamWriter writer = null;
        public TextFileWriter(string inputFileName)
        {
            outputFileName += Path.Combine(Path.GetDirectoryName(inputFileName),
                                Path.GetFileNameWithoutExtension(inputFileName)+
                                "_Output"+
                                Path.GetExtension(inputFileName));

            writer = new StreamWriter(outputFileName, false);
            writer.AutoFlush = true;            
        }
        public void WriteLog(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                writer.WriteLine(s); 
            }
        }

        public void Close()
        {
            writer.Flush();
            writer.Close();
        }        
    }

    class MyListBox : ListBox, ILogWriter
    {
        public void WriteLog(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                this.Items.Add(s);                
            }
        }
    }
}
