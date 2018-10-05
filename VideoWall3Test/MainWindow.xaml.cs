using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoWall3Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Socket telnet;
        byte[] bytes = new byte[1024];
        public MainWindow()
        {
            InitializeComponent();
            IPHostEntry ipHost = Dns.GetHostEntry("192.168.10.10");
            IPAddress ipAddr = ipHost.AddressList[3];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 3040);
            telnet = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            telnet.Connect(ipEndPoint);
            label.Content = telnet.Connected.ToString();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("run \"Timeline 1\"\n");

            // Отправляем данные через сокет
            int bytesSent = telnet.Send(msg);

           // int bytesRec = telnet.Receive(bytes);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("run \"Timeline 2\"\n");

            // Отправляем данные через сокет
            int bytesSent = telnet.Send(msg);

            // int bytesRec = telnet.Receive(bytes);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("run \"Timeline 3\"\n");

            // Отправляем данные через сокет
            int bytesSent = telnet.Send(msg);

            // int bytesRec = telnet.Receive(bytes);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("run \"Timeline 1\"\nrun \"Timeline 2\"\nrun \"Timeline 3\"\nrun \"Timeline 4\"\n");

            // Отправляем данные через сокет
            int bytesSent = telnet.Send(msg);

            // int bytesRec = telnet.Receive(bytes);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("reset\n");

            // Отправляем данные через сокет
            int bytesSent = telnet.Send(msg);

            // int bytesRec = telnet.Receive(bytes);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string temp = "setInput \"jkl\" " + (Math.Round((sender as Slider).Value, 2)).ToString("0.00",CultureInfo.InvariantCulture) + "\n";
            byte[] msg = Encoding.UTF8.GetBytes(temp);

            // Отправляем данные через сокет
            if (telnet != null)
                telnet.Send(msg);

        }

    }
}
