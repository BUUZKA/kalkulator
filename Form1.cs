using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void CalculateIP(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(IPAdressTextBox.Text);
            IPAddress maskAddress = IPAddress.Parse(MaskTextBox.Text);
            byte[] ip = ipAddress.GetAddressBytes();
            byte[] mask = maskAddress.GetAddressBytes();
            byte[] network = new byte[4];
            byte[] broadcast = new byte[4];
            for (int i = 0; i < 4; i++) 
            {
                network[i] = (byte)(ip[i] & mask[i]);
            }
            Array.Copy(network, broadcast, 4);
            string networkAddressString = "";
            string broadcastAddressString = "";
            for (int i = 0; i < 4; i++)
            {
                String ipFragment = network[i].ToString();
                ipFragment = ipFragment.PadLeft(3, '0');
                networkAddressString += ipFragment;

                ipFragment = broadcast[i].ToString();
                ipFragment = ipFragment.PadLeft(3, '0');
                broadcastAddressString += ipFragment;
            }
            networkAddressTextBox.Text = networkAddressString;
        }
    }
}
