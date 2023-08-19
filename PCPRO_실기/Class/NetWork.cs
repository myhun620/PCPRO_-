using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// 네트워크 클래스 추가
using System.Net.Sockets;
using System.Net;
// Thread 클래스 추가
using System.Threading;
// 직렬화 클래스
using System.Runtime.Serialization.Formatters.Binary;
// 서버 메시지 전송 프로토콜
using SocketProtocol;

namespace PCPRO_실기
{
    public class NetWork
    {
        public string statusMessage { get; set; }

        TcpClient tcpClient;
        IPEndPoint ipep;
        Thread thd_Network;
        bool bSendMessage;
        Queue<Protocol> sendMessageList;
        public NetWork(string ipAddress, int portNumber)
        {
            ipep = new IPEndPoint(IPAddress.Parse(ipAddress), portNumber);
            bSendMessage = false;
            sendMessageList = new Queue<Protocol>();
            statusMessage = Connect();
        }

        private string Connect()
        {
            string msg = "상태 없음";
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipep);
                // thread = new Thread(new ThreadStart());
                bSendMessage = true;
                thd_Network.Start();
                msg = "Server 접속 성공. Thread 시작합니다.";
            }
            catch (SocketException ex)
            {
                msg = ex.Message;
            }
            catch (Exception ex) 
            {
                msg = ex.Message;
            }

            return msg;
        }

        public void SendMessage(Protocol ptcMessage)
        {
            sendMessageList.Enqueue(ptcMessage);
        }

        private void SendMessageThread()
        {
            while (bSendMessage)
            {
                try
                {
                    if (sendMessageList.Count <= 0)
                        continue;
                    Protocol socketMessage = sendMessageList.Dequeue();

                    NetworkStream ns = tcpClient.GetStream();
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ns, socketMessage);

                    statusMessage = "서버에 메시지 전송을 성공했습니다.";
                }
                catch (ThreadInterruptedException ex)
                {

                }
                catch (ThreadAbortException ex)
                {
                    bSendMessage = false;
                    statusMessage = ex.Message;
                    return;
                }
                catch (SocketException ex)
                {
                    bSendMessage = false;
                    statusMessage = ex.Message;
                    return;
                }
                Thread.Sleep(10);
            }
        }
    }
}
