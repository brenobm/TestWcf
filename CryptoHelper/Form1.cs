using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoHelper
{
    public partial class Form1 : Form
    {
        private const string SHARED_SECRET = "a7d035fa-ddbe-4db5-889b-4de913e8b6fc";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Crypto.Encrypt(textBox1.Text, SHARED_SECRET);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Crypto.Decrypt(textBox2.Text, SHARED_SECRET);
        }
    }
}
