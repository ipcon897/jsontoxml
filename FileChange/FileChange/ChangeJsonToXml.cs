using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChangeWindows
{
    class  ChangeJsonToXml : BaseFileChange
    {

        public ChangeJsonToXml(string filePath)
        {
            readPath = filePath;
            writePath = Path.ChangeExtension(filePath,".xml");
        }


        // JSON => XML
        public override async Task Change()
        {
            await Reader();

            // JSON形式の文字列をXDocumentに変換
            XDocument xdoc = JsonConvert.DeserializeXNode(readData);

            writeData = xdoc.Declaration.ToString() + "\r\n";

            writeData += xdoc.ToString();

            await Writer();

        }

    }
}
