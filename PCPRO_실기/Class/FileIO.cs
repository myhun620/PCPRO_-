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
        const string Module1FilePath = "Snd_01.txt";
        const string Module2FilePath = "Rcv_01.txt";
        // 반환되는 Log값
        private string[] logString;
       
        public string[] LogString { get => logString; set => logString = value; }

        public FileIO()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">SAVE, LOAD</param>
        /// <param name="module">MODULE1, MODULE2</param>
        /// <param name="msg">SAVE면 문자열입력</param>
        public void FileIOFuction(LogModule mode, LogModule module, string msg)
        {
            if (mode == LogModule.SAVE)
            {
                if (module == LogModule.RECEIVE)
                {
                    FileSave(DirctionaryPath(Module1FilePath), msg);
                }
                else if (module == LogModule.SEND)
                {
                    FileSave(DirctionaryPath(Module2FilePath), msg);
                }
            }
            else if (mode == LogModule.LOAD)
            {
                if (module == LogModule.RECEIVE)
                {
                    logString = FileLoad(DirctionaryPath(Module1FilePath));
                }
                else if (module == LogModule.SEND)
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
            try
            {
                string[] str = System.IO.File.ReadAllLines(fileSaveFilePath);
                return str;
            }
            catch (Exception ex)
            {
                string[] str = new string[1] { "출력 메시지 : " + ex.Message };
                return str;
                throw;
            }
            // Log파일 로드 부분, Return 부분 추가해야됨
        }
    }
}
