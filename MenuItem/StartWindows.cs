using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuItem
{
    public partial class StartWindows : Form
    {
        public StartWindows()
        {
            InitializeComponent();
        }

        static public string equation = "x^3 + x^2 + x = 0";
        static public bool createGraph;
        static public int key = 0;

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        static public bool Start(bool r1,bool r2, bool r4,bool cgY,bool cgN)
        {
            if (r1!= true)
            {
                if (r2 == true)
                {
                    equation = "x^4 + x^3 + x = 0";
                }
                else if (r4 == true)
                {
                    equation = "x^2 + x + c = 0";
                }
            }
            if (cgN)
            {
                createGraph = false;
            } else if (cgY)
            {
                createGraph = true;
            }
            key = 1;
            return createGraph;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool r1 = radioButton1.Checked;
            bool r2 = radioButton4.Checked;
            bool r4 = radioButton2.Checked;
            bool cgN = radioButton6.Checked;
            bool cgY = radioButton5.Checked;
            Start(r1,r2,r4,cgY,cgN);
            this.Close();
        }

        private void StartWindows_Load(object sender, EventArgs e)
        {
            this.BackColor = Form1.bColor;
            label1.ForeColor = Form1.ColorText;
            label2.ForeColor = Form1.ColorText;
            radioButton1.ForeColor = Form1.ColorText;
            radioButton2.ForeColor = Form1.ColorText;
            radioButton4.ForeColor = Form1.ColorText;
            radioButton5.ForeColor = Form1.ColorText;
            radioButton6.ForeColor = Form1.ColorText;
            if (!Form1.language)
            {
                this.Text = Form1.Use[52];
                this.button1.Text = Form1.Use[1];
                this.radioButton6.Text = Form1.Use[43];
                this.radioButton5.Text = Form1.Use[42];
                this.label1.Text = Form1.Use[45];
                this.label2.Text = Form1.Use[44];
            }
        }
    }
}
