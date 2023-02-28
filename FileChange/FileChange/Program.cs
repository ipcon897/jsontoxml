using ChangeWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileChange
{
    class Program
    {
        static void Main(string[] args)
        {
            //フォルダパス読み込み
            string filePath = args[0];

            //フォルダパスからファイル名を獲得
            string[] files = Directory.GetFiles(filePath, "*");

            List<BaseFileChange> change = new List<BaseFileChange>();

            foreach (string fileData in files)
            {
                //拡張子だけ抽出
                string extension = Path.GetExtension(fileData);

                //JSON→XML
                if (extension.Equals(".json"))
                {
                    change.Add(new ChangeJsonToXml(fileData));
                }
                //XML→JSON
                else if (extension.Equals(".xml"))
                {
                    change.Add(new ChangeXmlToJson(fileData));
                }
            }
            List<Task> threadList = new List<Task>();

            foreach (BaseFileChange changeData in change)
            {
                //変換クラスnullチェック
                if (change != null)
                {
                    //非同期として呼び出す
                    threadList.Add(changeData.Change());
                }
            }
            Task[] threadArray = threadList.ToArray();

            //全部のスレッドが完了するまで待機
            Task.WaitAll(threadArray);
        }
    }
}
