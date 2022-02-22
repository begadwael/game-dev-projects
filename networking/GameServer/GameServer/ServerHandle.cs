using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clintIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint}" +
                $" connected successfully and is now player {_fromClient}.");

            if (_fromClient != _clintIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient} has assumed the wrong client ID ({_clintIdCheck})!");
            }
        }

        public static void UDPTestReceived(int _fromClient, Packet _packet)
        {
            string _msg = _packet.ReadString();

            Console.WriteLine($"Received packet via UDP. contains message: {_msg}");
        }
    }
}
