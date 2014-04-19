using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Classroom { 
    public class Client
    {
           
        private TcpClient tcpClient;

        private const string REQ_SEND_CLASS_LIST = "sndclslt";
        private const string REQ_ADD_CLASS =       "addclass";
        private const string REQ_SEND_STUD_LIST =  "sndstdlt";
        private const string CMD_START_CLASSLIST = "stclassl";
        private const string CMD_END_LIST =        "end_list";
        private const string CMD_START_STUDLIST =  "ststudlt";
        private const string CMD_SEND_CLASS_ID   = "sndclsid";
        private const string CMD_SEND_CLASS_NAME = "sndclsnm";

        public bool OpenConnection()
        {
            try
            {
                tcpClient = new TcpClient();
                Console.WriteLine("Connecting.....");
                    
                tcpClient.Connect("192.168.0.105", 666);
                // use the ipaddress as in the server program
                    
                Console.WriteLine("Connected");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }   

        public void CloseConnection(){
            try 
    	    {	        
	    	    tcpClient.Close();
	        }
    	    catch (Exception)
	        {
		        throw;
    	    }
        }

        public List<string> GetClassList(){
            List<string> result = new List<string>();
            Stream stm = tcpClient.GetStream();

            string line = REQ_SEND_CLASS_LIST;
            byte[] bytesToSend = Encoding.ASCII.GetBytes(line);
            Console.WriteLine("Requesting class list....");

            stm.Write(bytesToSend, 0, bytesToSend.Length);
                
            byte[] bytesReceived = new byte[8];
            stm.Read(bytesReceived, 0, bytesReceived.Length);

            Console.WriteLine("Received//" + Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length) + "//");


            if(Encoding.ASCII.GetString(bytesReceived, 0,bytesReceived.Length)==CMD_START_CLASSLIST)
            {
                Console.WriteLine("Receiveing class list.");
                ReceiveDataList(stm, result);
            }
            return result;
        }

        public List<string> GetStudentsList(string class_id)
        {
            List<string> result = new List<string>();
            Stream stm = tcpClient.GetStream();

            string line = REQ_SEND_STUD_LIST;
            byte[] bytesToSend = Encoding.ASCII.GetBytes(line);
            Console.WriteLine("Requesting students list....");
            stm.Write(bytesToSend, 0, bytesToSend.Length);

            byte[] bytesReceived = new byte[8];
            stm.Read(bytesReceived, 0, bytesReceived.Length);
            Console.WriteLine("Received//" + Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length) + "//");

            if (Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length) == CMD_SEND_CLASS_ID)
            {
                Console.WriteLine("Sending class_id: " + class_id);
                stm.Write(GenerateClassID(class_id), 0, 5);
            }

            bytesReceived = new byte[8];
            stm.Read(bytesReceived, 0, bytesReceived.Length);

            Console.WriteLine("Received//" + Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length) + "//");

            if (Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length) == CMD_START_STUDLIST)
            {
                Console.WriteLine("Receiveing student list.");
                ReceiveDataList(stm, result);
            }

            return result;
        }

        private byte[] GenerateClassID(string class_id)
        {

            string strToConvert = class_id;

            for (int i = 0; i < 5 - class_id.Length; i++ )
            {
                strToConvert += " ";
            }

            return Encoding.ASCII.GetBytes(strToConvert);
        }

        private void ReceiveDataList(Stream stm, List<string> list)
        {
            string stringMsg = "";

            while (stringMsg != CMD_END_LIST)
            {
                byte[] bytesReceived = new byte[1];
                stm.Read(bytesReceived, 0, bytesReceived.Length);
                int lengthOfNextLine = Convert.ToInt32(bytesReceived[0]);
                Console.WriteLine("Received length//" + lengthOfNextLine + "//");

                bytesReceived = new byte[lengthOfNextLine];
                stm.Read(bytesReceived, 0, bytesReceived.Length);
                stringMsg = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length);


                if (stringMsg != CMD_END_LIST)
                {
                    list.Add(stringMsg);
                }

                Console.WriteLine("Received//" + stringMsg + "//");
            }
        }

        internal bool AddClass(string className)
        {
            string msgToSend = REQ_ADD_CLASS;
            byte[] bytesToSend = Encoding.ASCII.GetBytes(msgToSend);
            NetworkStream stream = tcpClient.GetStream();
            stream.Write(bytesToSend, 0, bytesToSend.Length);

            byte[] bytesReceived = new byte[8];
            stream.Read(bytesReceived, 0, bytesReceived.Length);
            string stringMsg = Encoding.ASCII.GetString(bytesReceived);

            if (stringMsg == CMD_SEND_CLASS_NAME)
            {
                msgToSend = className;
                bytesToSend = Encoding.ASCII.GetBytes(msgToSend);
                stream.Write(bytesToSend, 0, bytesToSend.Length);

            }
            return false;
        }
    }
}