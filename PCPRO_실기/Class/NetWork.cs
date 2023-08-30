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

        public TcpClient tcpClient;
        IPEndPoint ipep;
        public Thread thd_Network, thd_Receive;
        public bool bSendMessage;
        Queue<Protocol> sendMessageList;
        public Queue<Protocol> ReceiveMessageList;
        public Protocol receiveData;
        public bool connected;
        public NetWork(string ipAddress, int portNumber)
        {
            ipep = new IPEndPoint(IPAddress.Parse(ipAddress), portNumber);
            bSendMessage = false;
            sendMessageList = new Queue<Protocol>();
            ReceiveMessageList = new Queue<Protocol>();
            statusMessage = Connect();
        }

        private string Connect()
        {
            string msg = "상태 없음";
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipep);
                thd_Network = new Thread(new ThreadStart(SendMessageThread));
                thd_Receive = new Thread(new ThreadStart(ReceiveMessageThread));
                bSendMessage = true;
                thd_Network.Start();
                thd_Receive.Start();
                msg = "Server 접속 성공. Thread 시작합니다.";
            }
            catch (SocketException)
            {
                connected = false;
            }
            catch (Exception ex) 
            {
                msg = ex.Message;
            }

            return msg;
        }

        public void DisConnect()
        {
            if (tcpClient.Connected)
            {
                bSendMessage = false;
                thd_Network.Join();
                thd_Receive.Join();
                tcpClient.Close();
            }
        }

        public void SendMessage(Protocol ptcMessage)
        {
            sendMessageList.Enqueue(ptcMessage);
        }

        public Protocol ReceiveMessage()
        {
            Protocol ptcMessage = ReceiveMessageList.Dequeue();
            return ptcMessage;
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

                    statusMessage = "서버에 메시지 전송 했습니다.";
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

        private void ConnetedCheck()
        {
            if (tcpClient.Client.Poll(0, SelectMode.SelectRead) && tcpClient.Available == 0)
                connected = false;
            else
                connected = true;
        }

        private void ReceiveMessageThread()
        {
            while (bSendMessage)
            {
                try
                {
                    //ConnetedCheck();

                    if (tcpClient.Available > 0)
                    {
                        NetworkStream ns = tcpClient.GetStream();
                        BinaryFormatter bf = new BinaryFormatter();

                        receiveData = (Protocol)bf.Deserialize(ns);

                        ReceiveMessageList.Enqueue(receiveData);

                        statusMessage = "서버에서 메시지를 받았습니다.";
                    }
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
