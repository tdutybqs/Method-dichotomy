using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MenuItem
{
    public partial class Common : Form
    {
        public Common()
        {
            InitializeComponent();
        }

        private void Common_Load(object sender, EventArgs e)
        {
            ChangeNamesbColor();
            AddGroupBox();
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            ChangeNamesLanguage();
            ChangeNamesFColor();
            comboBox1.KeyPress += (sndr, eva) => eva.Handled = true;
            comboBox2.KeyPress += (sndr, eva) => eva.Handled = true;
        }


        private void ChangeNamesLanguage()
        {
            if (Form1.language)
            {
                comboBox1.SelectedText = "Русский";
            }
            else
            {
                comboBox1.SelectedText = "English";
            }
        }

        private void ChangeNamesbColor()
        {
            if (Form1.language) 
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Белый");
                comboBox2.Items.Add("Черный");
                comboBox2.Items.Add("Синий");
                comboBox2.Items.Add("Красный");
                comboBox2.Items.Add("Голубой");
            }
            else
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("White");
                comboBox2.Items.Add("Black");
                comboBox2.Items.Add("Blue");
                comboBox2.Items.Add("Red");
                comboBox2.Items.Add("LightSkyBlue");
            }

            if (Form1.bColor == Color.White)
            {
                if (Form1.language)
                {
                    comboBox2.SelectedText = "Белый";
                }
                else
                    comboBox2.SelectedText = "White";
            }
            else if (Form1.bColor == Color.Black)
            {
                if (Form1.language)
                {
                    comboBox2.SelectedText = "Черный";
                }
                else
                    comboBox2.SelectedText = "Black";
            }
            else if (Form1.bColor == Color.Blue)
            {
                if (Form1.language)
                {
                    comboBox2.SelectedText = "Синий";
                }
                else
                    comboBox2.SelectedText = "Blue";
            }
            else if (Form1.bColor == Color.Red)
            {
                if (Form1.language)
                {
                    comboBox2.SelectedText = "Красный";
                }
                else
                    comboBox2.SelectedText = "Red";
            }
            else if (Form1.bColor == Color.LightSkyBlue)
            {
                if (Form1.language)
                {
                    comboBox2.SelectedText = "Голубой";
                }
                else
                    comboBox2.SelectedText = "LightSkyBlue";
            }
        }



        private void ChangeNamesFColor()
        {
            if (Form1.language)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Белый");
                comboBox3.Items.Add("Черный");
                comboBox3.Items.Add("Синий");
                comboBox3.Items.Add("Красный");
                comboBox3.Items.Add("Голубой");
            }
            else
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("White");
                comboBox3.Items.Add("Black");
                comboBox3.Items.Add("Blue");
                comboBox3.Items.Add("Red");
                comboBox3.Items.Add("LightSkyBlue");
            }

            if (Form1.ColorText == Color.White)
            {
                if (Form1.language)
                {
                    comboBox3.SelectedText = "Белый";
                }
                else
                    comboBox3.SelectedText = "White";
            }
            else if (Form1.ColorText == Color.Black)
            {
                if (Form1.language)
                {
                    comboBox3.SelectedText = "Черный";
                }
                else
                    comboBox3.SelectedText = "Black";
            }
            else if (Form1.ColorText == Color.Blue)
            {
                if (Form1.language)
                {
                    comboBox3.SelectedText = "Синий";
                }
                else
                    comboBox3.SelectedText = "Blue";
            }
            else if (Form1.ColorText == Color.Red)
            {
                if (Form1.language)
                {
                    comboBox3.SelectedText = "Красный";
                }
                else
                    comboBox3.SelectedText = "Red";
            }
            else if (Form1.ColorText == Color.LightSkyBlue)
            {
                if (Form1.language)
                {
                    comboBox3.SelectedText = "Голубой";
                }
                else
                    comboBox3.SelectedText = "LightSkyBlue";
            }
        }

        private void AddGroupBox()
        {
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(comboBox2);
        }

        private void CheckLanguage()
        {
            if ((string)(comboBox1.SelectedItem) == "Русский")
            {
                Form1.language = true;
            }
            else if((string)(comboBox1.SelectedItem) == "English")
            {
                Form1.language = false;
            }
        }

        private void CheckColor()
        {
            if ((string)comboBox2.SelectedItem == "Белый" || (string)comboBox2.SelectedItem == "White")
            {
                Form1.bColor = Color.White;
            }
            else if ((string)comboBox2.SelectedItem == "Черный" || (string)comboBox2.SelectedItem == "Black")
            {
                Form1.bColor = Color.Black;
            }
            else if ((string)comboBox2.SelectedItem == "Синий" || (string)comboBox2.SelectedItem == "Blue")
            {
                Form1.bColor = Color.Blue;
            }
            else if ((string)comboBox2.SelectedItem == "Голубой" || (string)comboBox2.SelectedItem == "LightSkyBlue")
            {
                Form1.bColor = Color.LightSkyBlue;
            }
            else if ((string)comboBox2.SelectedItem == "Красный" || (string)comboBox2.SelectedItem == "Red")
            {
                Form1.bColor = Color.Red;
            }
        }

        private void CheckColorText()
        {
            if ((string)comboBox3.SelectedItem == "Белый" || (string)comboBox3.SelectedItem == "White")
            {
                Form1.ColorText = Color.White;
            }
            else if ((string)comboBox3.SelectedItem == "Черный" || (string)comboBox3.SelectedItem == "Black")
            {
                Form1.ColorText = Color.Black;
            }
            else if ((string)comboBox3.SelectedItem == "Синий" || (string)comboBox3.SelectedItem == "Blue")
            {
                Form1.ColorText = Color.Blue;
            }
            else if ((string)comboBox3.SelectedItem == "Голубой" || (string)comboBox3.SelectedItem == "LightSkyBlue")
            {
                Form1.ColorText = Color.LightSkyBlue;
            }
            else if ((string)comboBox3.SelectedItem == "Красный" || (string)comboBox3.SelectedItem == "Red")
            {
                Form1.ColorText = Color.Red;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            CheckLanguage();
            CheckColor();
            CheckColorText();

            Properties.Settings.Default.Language = Form1.language;
            Properties.Settings.Default.bColor = Form1.bColor;
            Properties.Settings.Default.ColorText = Form1.ColorText;
            Properties.Settings.Default.Save();
            this.Close();
        }

    }
}
