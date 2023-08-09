using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace PCPRO_실기
{
    internal class FileIO
    {
        // 모듈별 파일명
        string Module1FilePath = "Module1Log.txt";
        string Module2FilePath = "Module2Log.txt";
        
        // 반환되는 Log값
        public string[] logString;

        public FileIO()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">1: save, 2: load</param>
        /// <param name="module">1: MD1, 2: MD2</param>
        /// <param name="msg"></param>
        public void FileIOFuction(int mode, int module, string msg)
        {
            if (mode == 1)
            {
                if (module == 1)
                {
                    FileSave(Module1FilePath, msg);
                }
                else if (module == 2)
                {
                    FileSave(Module2FilePath, msg);
                }
            }
            else if (mode == 2)
            {
                if (module == 1)
                {
                    logString = FileLoad(Module1FilePath);
                }
                else if (module == 2)
                {
                    logString = FileLoad(Module2FilePath);
                }
                // 추가해야됨
            }
        }

        private void FileSave(string fileSaveFilePath, string msg)
        { 
            StreamWriter sw = File.AppendText(fileSaveFilePath);
            sw.WriteLine(msg);
            sw.Close();
        }

        private string[] FileLoad(string fileSaveFilePath)
        {
            string[] str = System.IO.File.ReadAllLines(fileSaveFilePath);
            return str;
            // Log파일 로드 부분, Return 부분 추가해야됨
        }
    }
}
