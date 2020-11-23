using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class text : Form
    {
        public text()
        {
            InitializeComponent();
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            int[] arraytest = new int[10];
            for (var i = 0; i < arraytest.Length;i++)
            {

                arraytest[i] = i+1;
                label2.Text += $"\n{arraytest[i]}";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] arraytest = new int[10];
        }
    }
}
