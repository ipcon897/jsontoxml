using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;

namespace ChangeWindows
{
    class ChangeXmlToJson : BaseFileChange
    {
        public ChangeXmlToJson(string filePath)
        {
            readPath = filePath;
            writePath = Path.ChangeExtension(filePath, ".json");
        }

        // XML => JSON
        public override async Task Change()
        {
            await Reader();

            XDocument xdoc = XDocument.Parse(readData);

            // XDocumentをJSON形式の文字列に変換
            writeData = JsonConvert.SerializeXNode(xdoc, Formatting.Indented);

            await Writer();

        }
    }
}
