using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace DemoWinForm
{
    public partial class frmCommunication : Form
    {
        string strReceiveIPAddress;
        ushort ushtReceivePort;
        string strDestinationIPAddress;
        ushort ushtDestinationPort;
        Int32 i32BufferSize;
        string strIPAddressLocal;

        public frmCommunication()
        {
            InitializeComponent();
        }

    //    bool SendMessage()
    //    {

    //        ArrayList multicastGroups = new ArrayList();

    //        IPAddress localAddress = IPAddress.Any, destAddress = IPAddress.Parse(strDestinationIPAddress);

    //        ushtDestinationPort = 1721;

    //        bool udpSender = true;

    //        int bufferSize = 256, sendCount = 5, i;

    //        localAddress = IPAddress.Parse(strIPAddressLocal);
    //        //bufferSize = System.Convert.ToInt32(args[++i]);


    //        UdpClient udpSocket = null;

    //        byte[] sendBuffer = new byte[bufferSize], receiveBuffer = new byte[bufferSize];

    //        int rc;



    //        try
    //        {

    //            // Create an unconnected socket since if invoked as a receiver we don't necessarily

    //            //    want to associate the socket with a single endpoint. Also, for a sender socket

    //            //    specify local port of zero (to get a random local port) since we aren't receiving

    //            //    anything.

    //            //Console.WriteLine("Creating connectionless socket...");

    //            //if (udpSender == false)

    //                //udpSocket = new UdpClient(new IPEndPoint(localAddress, portNumber));

    //            //else


    //            udpSocket = new UdpClient(new IPEndPoint(localAddress, 0));



    //            // Join any multicast groups specified

    //            //Console.WriteLine("Joining any multicast groups specified...");

    //            for (i = 0; i < multicastGroups.Count; i++)
    //            {

    //                if (localAddress.AddressFamily == AddressFamily.InterNetwork)
    //                {

    //                    // For IPv4 multicasting only the group is specified and not the

    //                    //    local interface to join it on. This is bad as on a multihomed

    //                    //    machine, the application won't really know which interface

    //                    //    it is joined on (and there is no way to change it via the UdpClient).

    //                    udpSocket.JoinMulticastGroup((IPAddress)multicastGroups[i]);

    //                }

    //                else if (localAddress.AddressFamily == AddressFamily.InterNetworkV6)
    //                {

    //                    // For some reason, the IPv6 multicast join allows the local interface index

    //                    //    to be specified such that the application can join multiple groups on

    //                    //    any interface which is great (but lacking in IPv4 multicasting with the

    //                    //    UdpClient). IPv6 multicast groups should be specified with the scope id

    //                    //    when passed on the command line (e.g. fe80::1%4).

    //                    udpSocket.JoinMulticastGroup((int)((IPAddress)multicastGroups[i]).ScopeId, (IPAddress)multicastGroups[i]);

    //                }

    //            }



    //            // If you want to send data with the UdpClient it must be connected -- either by

    //            //    specifying the destination in the UdpClient constructor or by calling the

    //            //    Connect method. You can call the Connect method multiple times to associate

    //            //    a different endpoint with the socket.

    //            udpSocket.Connect(destAddress, ushtDestinationPort);
    //            Console.WriteLine("Connect() is OK...");


    //            // Send the requested number of packets to the destination

    //            Console.WriteLine("Sending the requested number of packets to the destination, Send()...");

    //            for (i = 0; i < sendCount; i++)
    //            {

    //                rc = udpSocket.Send(sendBuffer, sendBuffer.Length);
    //                Console.WriteLine("Sent {0} bytes to {1}", rc, destAddress.ToString());

    //            }

    //            // Send a few zero length datagrams to indicate to the receive to exit. Put a short

    //            //    sleep between them since UDP is unreliable and zero byte datagrams are really

    //            //    fast (and the local stack can actually drop datagrams before they even make it

    //            //    onto the wire).

    //            Console.WriteLine("Having some sleep, Sleep(250)...");

    //            for (i = 0; i < 3; i++)
    //            {

    //                rc = udpSocket.Send(sendBuffer, 0);
    //                System.Threading.Thread.Sleep(250);

    //            }    
    //    }

    //    catch (SocketException err)
    //    {

    //        Console.WriteLine("Socket error occurred: {0}", err.Message);
    //        Console.WriteLine("Stack: {0}", err.StackTrace);

    //    }

    //    finally
    //    {

    //        if (udpSocket != null)
    //        {

    //            // Clean things up by dropping any multicast groups we joined

    //            Console.WriteLine("Cleaning things up by dropping any multicast groups we joined...");

    //            for (i = 0; i < multicastGroups.Count; i++)
    //            {

    //                if (localAddress.AddressFamily == AddressFamily.InterNetwork)
    //                {
    //                    udpSocket.DropMulticastGroup((IPAddress)multicastGroups[i]);
    //                }

    //                else if (localAddress.AddressFamily == AddressFamily.InterNetworkV6)
    //                {

    //                    // IPv6 multicast groups should be specified with the scope id when passed

    //                    //    on the command line

    //                    udpSocket.DropMulticastGroup(

    //                        (IPAddress)multicastGroups[i],

    //                        (int)((IPAddress)multicastGroups[i]).ScopeId

    //                        );
    //                }

    //            }

    //            // Free up the underlying network resources

    //            Console.WriteLine("Closing the socket...");

    //            udpSocket.Close();

    //        }

    //    }

    //}

        //bool ReceiveMessage()
        //{

        //    string strReceiveIPAddress;
        //    ushort ushtReceivePort;
        //    Int32 i32BufferSize;
        //    string strIPAddressLocal;

        //    ArrayList multicastGroups = new ArrayList();
        //    IPAddress localAddress = IPAddress.Any, destAddress = null;
        //    ushort portNumber = 1721;
        //    bool udpSender = false;
        //    int bufferSize = 256, sendCount = 5, i;


        //    // Parse the command line

           

        //    UdpClient udpSocket = null;

        //    byte[] sendBuffer = new byte[bufferSize], receiveBuffer = new byte[bufferSize];

        //    int rc;



        //    try
        //    {

        //        // Create an unconnected socket since if invoked as a receiver we don't necessarily

        //        //    want to associate the socket with a single endpoint. Also, for a sender socket

        //        //    specify local port of zero (to get a random local port) since we aren't receiving

        //        //    anything.

        //        txtConsoleMessages.Text = "\r\n" + "Creating connectionless socket...";

        //        udpSocket = new UdpClient(new IPEndPoint(localAddress, portNumber));

                

        //        // Join any multicast groups specified

        //        txtConsoleMessages.Text = "\r\n" + "Joining any multicast groups specified...";

        //        for (i = 0; i < multicastGroups.Count; i++)
        //        {

        //            if (localAddress.AddressFamily == AddressFamily.InterNetwork)
        //            {

        //                // For IPv4 multicasting only the group is specified and not the

        //                //    local interface to join it on. This is bad as on a multihomed

        //                //    machine, the application won't really know which interface

        //                //    it is joined on (and there is no way to change it via the UdpClient).

        //                udpSocket.JoinMulticastGroup((IPAddress)multicastGroups[i]);

        //            }

        //            else if (localAddress.AddressFamily == AddressFamily.InterNetworkV6)
        //            {

        //                // For some reason, the IPv6 multicast join allows the local interface index

        //                //    to be specified such that the application can join multiple groups on

        //                //    any interface which is great (but lacking in IPv4 multicasting with the

        //                //    UdpClient). IPv6 multicast groups should be specified with the scope id

        //                //    when passed on the command line (e.g. fe80::1%4).

        //                udpSocket.JoinMulticastGroup((int)((IPAddress)multicastGroups[i]).ScopeId, (IPAddress)multicastGroups[i]);

        //            }

        //        }



        //        // If you want to send data with the UdpClient it must be connected -- either by

        //        //    specifying the destination in the UdpClient constructor or by calling the

        //        //    Connect method. You can call the Connect method multiple times to associate

        //        //    a different endpoint with the socket.
                
                
        //        IPEndPoint senderEndPoint = new IPEndPoint(localAddress, 0);

        //            // Receive datagrams in a loop until a zero byte datagram is received.

        //            //    Note the difference with the UdpClient in that the source address

        //            //    is simply an IPEndPoint that doesn't have to be cast to and EndPoint

        //            //    object as is the case with the Socket class.                

                    
        //        txtConsoleMessages.Text = "\r\n" + "Receiving datagrams in a loop until a zero byte datagram is received...";
                    
        //        while (true)
        //            {
        //                receiveBuffer = udpSocket.Receive(ref senderEndPoint);

        //                txtConsoleMessages.Text = "\r\n" + "Read {0} bytes from {1}" + 
        //                            receiveBuffer.Length + senderEndPoint.ToString();
                        

        //                if (receiveBuffer.Length == 0)
        //                    break;
        //            }
        //    }


        //    catch (SocketException err)
        //    {
        //        txtErrors.Text = "\r\n" + "Receiveing Socket error occurred: {0}" + err.Message;
        //        txtErrors.Text = "\r\n" + "Receiving Stack: {0}" + err.StackTrace;
        //    }

        //    finally
        //    {
        //        if (udpSocket != null)
        //        {

        //            // Clean things up by dropping any multicast groups we joined

        //            txtConsoleMessages.Text = "\r\n" + "Cleaning things up by dropping any multicast groups we joined...";

        //            for (i = 0; i < multicastGroups.Count; i++)
        //            {

        //                if (localAddress.AddressFamily == AddressFamily.InterNetwork)
        //                {

        //                    udpSocket.DropMulticastGroup((IPAddress)multicastGroups[i]);

        //                }

        //                else if (localAddress.AddressFamily == AddressFamily.InterNetworkV6)
        //                {

        //                    // IPv6 multicast groups should be specified with the scope id when passed

        //                    //    on the command line

        //                    udpSocket.DropMulticastGroup(

        //                        (IPAddress)multicastGroups[i],

        //                        (int)((IPAddress)multicastGroups[i]).ScopeId

        //                        );
        //                }
        //            }

        //            // Free up the underlying network resources
        //            txtConsoleMessages.Text = "\r\n" + "Closing the socket...";
        //            udpSocket.Close();

        //        }
        //    }
        //}

        private void frmCommunication_Load(object sender, EventArgs e)
        {

        }
    }
}
