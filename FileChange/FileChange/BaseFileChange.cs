using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChangeWindows
{
    abstract class BaseFileChange : IChangeInterface
    {
        protected string readPath { get; set; }

        protected string writePath { get; set; }

        protected string readData { get; set; }

        protected string writeData { get; set; }

        public async Task Reader()
        {
            string readFile = string.Empty;

            using (StreamReader reader = new StreamReader(readPath))
            {
                // テキストを非同期で読み込む
                readFile = await reader.ReadToEndAsync();
            }
            readData = readFile;
        }

        public async Task Writer()
        {
            Encoding enc = Encoding.GetEncoding("UTF-8");

            using (StreamWriter writer = new StreamWriter(writePath, false, enc))
            {
                // テキストを非同期で書き込む
                await writer.WriteAsync(writeData);
            }
        }

        public abstract Task Change();
    }
}
