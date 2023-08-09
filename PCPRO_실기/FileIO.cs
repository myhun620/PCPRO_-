using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Windows.Forms;

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
                    FileSave(DirctionaryPath(Module1FilePath), msg);
                }
                else if (module == 2)
                {
                    FileSave(DirctionaryPath(Module2FilePath), msg);
                }
            }
            else if (mode == 2)
            {
                if (module == 1)
                {
                    logString = FileLoad(DirctionaryPath(Module1FilePath));
                }
                else if (module == 2)
                {
                    logString = FileLoad(DirctionaryPath(Module2FilePath));
                }
                // 추가해야됨
            }

            string DirctionaryPath(string filePath)
            {
                string str = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString();
                DirectoryInfo di = new DirectoryInfo(str);

                if (di.Exists == false)
                {
                    di.Create();
                }

                return str + "\\" + filePath;
            }   // 로컬함수, 오늘날짜 폴더 생성 및 폴더파일경로 반환
        }

        private void FileSave(string fileSaveFilePath, string msg)
        { 
            StreamWriter sw = File.AppendText(fileSaveFilePath);
            sw.WriteLine(LogDataTime() + msg);
            sw.Close();
                        
            string LogDataTime()
            {
                string str = DateTime.Now.Year.ToString() + "_" +
                                DateTime.Now.Month.ToString() + "/" +
                                DateTime.Now.Day.ToString() + "_" +
                                DateTime.Now.Hour.ToString() + ":" +
                                DateTime.Now.Minute.ToString() + ":" +
                                DateTime.Now.Second.ToString() + " ";

                return str;
            }   // 로컬함수, 로그메시지 앞단 날짜시간 추가
        }

        private string[] FileLoad(string fileSaveFilePath)
        {
            string[] str = System.IO.File.ReadAllLines(fileSaveFilePath);
            return str;
            // Log파일 로드 부분, Return 부분 추가해야됨
        }

    
    }
}
