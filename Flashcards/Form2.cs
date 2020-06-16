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
    public partial class Form2 : Form
    {
        public string mode;
        public string lang;
        private List<Word> words = new List<Word>();
        private Word currentWord;
        //public bool guessed;
        Random rand = new Random();

        public Form2()
        {
        }

        public Form2(string m, string l)
        {
            InitializeComponent();
            mode = m;
            lang = l;

            if (mode == "new")
            {
                if (!System.IO.File.Exists("words.txt")) {
                    MessageBox.Show("You need to have a file named 'words.txt' in the same folder where you have the .exe file.\nTerminating program...");
                    this.Close();
                    Application.Exit();
                }
                try
                {
                    readWordsNormal("words.txt");
                }
                catch
                {
                    words = new List<Word>();
                    readWords("words.txt");
                }
            }
            else
            {
                try
                {
                    readWordsNormal("active_words.txt");
                }
                catch
                {
                    MessageBox.Show("You don't have a saved progress.\nClick OK to start a new session.");
                    readWords("words.txt");
                }
            }
            //setWord("example");
            //foreach (Word myWord in words)
            //{
            //    Console.WriteLine(myWord.foreign);
            //}
            showNextWord();
            //Flashcards flash = new Flashcards(mode);
        }

        public void showNextWord()
        {
            Word w = getNextWord();
            currentWord = w;
            if (lang == "foreign")
            {
                setWord(w.foreign);
            }
            else
            {
                setWord(w.known);
            }
        }

        public void removeWord()
        {
            words.Remove(currentWord);
        }

        public void setWord(string word)
        {
            label3.Text = word;
        }

        public void readWords(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] fields = line.Split('\t');
                Word w = new Word(fields[1], fields[0]);
                words.Add(w);
                try
                {
                    Word w2 = new Word(fields[3], fields[2]);
                    words.Add(w2);
                }
                catch
                {
                }
            }
        }

        public void readWordsNormal(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] fields = line.Split('\t');
                Word w = new Word(fields[1], fields[0]);
                words.Add(w);
            }
        }

        private Word getNextWord()
        {
            int r = rand.Next() % words.Count;
            Word w = words[r];
            return w;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lang=="foreign")
            {
                Form3 form3 = new Form3(currentWord.known, this);
                form3.Show();
            }
            else
            {
                Form3 form3 = new Form3(currentWord.foreign, this);
                form3.Show();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveProgress();
            this.Close();
            Application.Exit();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveProgress();
            Application.Exit();
        }

        public void saveProgress()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("active_words.txt"))
            {
                foreach (Word w in words)
                {
                    file.WriteLine(w.foreign + '\t' + w.known);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = "THE REMAINING WORDS ARE:\n";
            foreach (Word w in words)
            {
                if (lang=="foreign")
                {
                    text += w.foreign + '\n';
                }
                else
                {
                    text += w.known + '\n';
                }
            }
            MessageBox.Show(text);
        }

        ////this function  will accept codepage in integer and accented characters in string
        //public string ConvertAccentedString(string accentedString)
        //{
        //    int codepage = 1252;
        //    return System.Text.Encoding.ASCII.GetString(System.Text.Encoding.GetEncoding(codepage).GetBytes(accentedString));
        //}
    }
}
