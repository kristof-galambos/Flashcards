using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flashcards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lang = "foreign";
            if (radioButton1.Checked)
            {
                lang = "known";
            }
            Form2 form2 = new Form2("new", lang);
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lang = "foreign";
            if (radioButton1.Checked)
            {
                lang = "known";
            }
            Form2 form2 = new Form2("load", lang);
            form2.Show();
            this.Hide();
        }
    }
}
