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
    public partial class Form3 : Form
    {
        public Form2 form2;
        public Form3(string word, Form2 f2)
        {
            InitializeComponent();

            form2 = f2;
            label3.Text = word;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form2.saveProgress();
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
            //form2.guessed = false;
            form2.showNextWord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
            //form2.guessed = true;
            form2.removeWord();
            form2.showNextWord();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2.saveProgress();
            Application.Exit();
        }
    }
}
