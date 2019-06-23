using System;
using System.Drawing;
using System.Text;
using ZedGraph;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;


namespace MenuItem
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            ActivateNamesOfGraph(zedGraphControl);
            openFileDialog1.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        // Начало работы

        private void RunWork()
        {
            createGraph = true;
            this.Enabled = false;
            StartWindows startWidnows = new StartWindows();
            startWidnows.FormClosed += new FormClosedEventHandler(StartWindow_Closed);
            startWidnows.ShowDialog();
            if (StartWindows.key == 1)
            {
                Enabled = true;
                GroupAdd();
            }
            else if (StartWindows.key == 0)
            {
                Application.Exit();
            }
            if (!StartWindows.createGraph)
            {
                zedGraphControl.Visible = false;
                this.groupBox3.Location = new System.Drawing.Point(12, 279);
                this.button1.Location = new System.Drawing.Point(315, 9);
                this.button3.Location = new System.Drawing.Point(6, 9);
                this.groupBox3.Location = new System.Drawing.Point(41, 431);
                this.comboBox1.Visible = false;
                this.Size = new System.Drawing.Size(500, 515);
                createGraph = false;
            } else
            {
                this.zedGraphControl.Location = new System.Drawing.Point(505, 81);
                zedGraphControl.Visible = true;
                this.comboBox1.Visible = true;
                createGraph = true;
                this.ClientSize = new System.Drawing.Size(938, 466);
                this.groupBox3.Location = new System.Drawing.Point(505, 402);
                this.groupBox3.Size = new System.Drawing.Size(421, 40);
                this.button1.Location = new System.Drawing.Point(315, 9);
                this.button3.Location = new System.Drawing.Point(6, 9);
            }
            this.BackColor = bColor;
            equation = StartWindows.equation;
            CheckAboutEquation();
            startWidnows.Dispose();
            dataGridView1.Rows.Clear();
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            this.dataGridView1.Enabled = false;
            label4.Visible = false;
            textBox4.Visible = false;
            zedGraphControl.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.Pink);
        }
        // ---------------------------------


        // Array
        public static string[] Russian = new string[] { "Файл", "Создать", "Открыть", "Сохранить", "Сохранить как",
            "Отправить",
            "Печать", "Выход", "Настройки", "Параметры", "О программе", "Справка", "Проверка обновлений",
            "Отправить отзыв", "О программе", "Сообщить о проблеме", "Отправить предложение", "Уравнение",
            "Данные", "Число", "Корень", "Точность", "Левая граница", "Правая граница", "Очистить поля",
            "Красный", "Синий", "Зеленый", "Черный", "Решить", "График уравнения", "Ось X", "Ось Y",
            "Уравнение", "Решение", "Ошибка", "Исправьте данные!", "Файл сохранен", "Сохранить",
            "Не удалось сохранить файл!", "Файл открыт", "Не удалось открыть файл!", "Да", "Нет",
            "Создать график", "Выберите уравнение", "Кому", "Отправить", "Прикрепить", "Тема сообщения",
            "Отправка", "Начало", "Метод половинного деления","Загружать вместе с Windows","Язык","Цвет фона"  };

        public static string[] English = new string[] {"File", "Create", "Open", "Save", "Save As", "Send",
            "Print", "Exit", "Settings", "Options", "About", "Help", "Check for Updates",
            "Send Feedback", "About the Program", "Report a Problem", "Submit a Proposal", "Equation",
            "Data", "Number", "Answer", "Accuracy", "Left Border", "Right Border", "Clear input",
            "Red", "Blue", "Green", "Black", "Solve", "Equation Graph", "X-axis", "Y-axis",
            "Equation", "Decision", "Error", "Correct data!", "File saved", "Save",
            "Could not save file!", "File open", "Could not open file!", "Yes", "No",
            "Create a graph", "Choose an equation", "To", "Send", "Attach", "Title",
            "Shipment", "Start", "Half division method","Run with Windows","Language","Color of BackGround" };

        public static string[] Use = new string[56] { "Файл", "Создать", "Открыть", "Сохранить", "Сохранить как", "Отправить",
            "Печать", "Выход", "Настройки", "Параметры", "О программе", "Справка", "Проверка обновлений",
            "Отправить отзыв", "О программе", "Сообщить о проблеме", "Отправить предложение", "Уравнение",
            "Данные", "Число", "Корень", "Точность", "Левая граница", "Правая граница", "Очистить поля",
            "Красный", "Синий", "Зеленый", "Черный", "Решить", "График уравнения", "Ось X", "Ось Y",
            "Уравнение", "Решение", "Ошибка", "Исправьте данные!", "Файл сохранен", "Сохранить",
            "Не удалось сохранить файл!", "Файл открыт", "Не удалось открыть файл!", "Да", "Нет",
            "Создать график", "Выберите уравнение", "Кому", "Отправить", "Прикрепить", "Тема сообщения",
            "Отправка", "Начало", "Метод половинного деления","Загружать вместе с Windows","Язык","Цвет фона" };

        private void Language()
        {
            if (language)
            {
                for (int i = 0; i < Russian.Length; i++)
                {
                    Use[i] = Russian[i];
                }
            }
            else
            {
                for (int i = 0; i < Russian.Length; i++)
                {
                    Use[i] = English[i];
                }
            }
            ChangeNames();
        }

        // ---------------------------------

        // Отрисовка графика
        public void ActivateNamesOfGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = Use[30];
            myPane.XAxis.Title.Text = Use[31];
            myPane.YAxis.Title.Text = Use[32];
            myPane.CurveList.Clear();
            zgc.AxisChange();
            zgc.Refresh();
        }

        private Color color;
        PointPairList list1 = new PointPairList();
        PointPairList list2 = new PointPairList();

        private void Eq1()
        {
            eq = x1 + " * x ^ 3 + " + x2 + "* x ^ 2 + " + x3 + " * x = 0";
            list1.Clear();
            double y;
            for (double i = left; i <= right; i += accuracy)
            {
                y = x1 * Math.Pow(i, 3) + x2 * Math.Pow(i, 2) + x3 * i;
                list1.Add(i, y);
            }
            check = false;
        }

        private void Eq2()
        {
            eq = x1 + " * x ^ 4 + " + x2 + "* x ^ 3 + " + x3 + " * x = 0";
            list1.Clear();
            double y;
            for (double i = left; i <= right; i += accuracy)
            {
                y = x1 * Math.Pow(i, 4) + x2 * Math.Pow(i, 3) + x3*i;
                list1.Add(i, y);
            }
            check = false;
        }

        private void Eq3()
        {
            eq = x1 + " * x ^ 2 + " + x2 + "* x - " + x3 + " = 0";
            list1.Clear();
            double y;
            for (double i = left; i <= right; i += accuracy)
            {
                y = x1 * Math.Pow(i, 2) + x2 * i + x3;
                list1.Add(i, y);
            }
            check = false;
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            zgc.ZoomOutAll(myPane);

            LineItem myCurve = myPane.AddCurve(Use[17], list1, color, SymbolType.None); // отрисовываем график
            LineItem myCurve2 = myPane.AddCurve(Use[34], list2, Color.Red, SymbolType.Star); // отрисовываем точку

            myPane.XAxis.MajorGrid.IsVisible = true; // Пунктирные линии Y
            myPane.XAxis.MajorGrid.DashOn = 15; // Длина штрихов равна 10 пикселям
            myPane.XAxis.MajorGrid.DashOff = 10; // затем 5 пикселей - пропуск
            zgc.AxisChange();
            zgc.Refresh();
        }

        private void zedGraphControl_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "Синий"|| (string)comboBox1.SelectedItem=="Blue")
            {
                color = Color.Blue;

            }
            if ((string)comboBox1.SelectedItem == "Красный"|| (string)comboBox1.SelectedItem=="Red")
            {
                color = Color.Red;
            }
            if ((string)comboBox1.SelectedItem == "Зеленый"|| (string)comboBox1.SelectedItem=="Green")
            {
                color = Color.Green;
            }
            if ((string)comboBox1.SelectedItem == "Черный"|| (string)comboBox1.SelectedItem=="Black")
            {
                color = Color.Black;
            }
        }


        // -------------------------------------


        // Меню

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunWork();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fileIsBe)
            {
                SaveAs();
            }
            else
            {
                Save();
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void отправитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendEmail SendEmail = new SendEmail();
            SendEmail.ShowDialog();
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если поток не закрыт, предложить сохранение
            Application.Exit();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm SettingForm = new SettingForm();
            SettingForm.FormClosed += new FormClosedEventHandler(SettingForm_Closed);
            SettingForm.ShowDialog();
            SettingForm.Dispose();
        }

        private void обновлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/view/kegexam/%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F");
        }

        private void сообщитьОПроблемеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendEmail SendEmail = new SendEmail();
            SendEmail.ShowDialog();
        }

        private void отправитьПредложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendEmail SendEmail = new SendEmail();
            SendEmail.ShowDialog();
        }

        private void оПрограммеМетодПоловинногоДеленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задача заключается в нахождении корней нелинейного уравнения."+Environment.NewLine+
                Environment.NewLine+
                "Для начала итераций необходимо знать отрезок значений x, на концах которого функция принимает " +
                "значения противоположных знаков."+Environment.NewLine+Environment.NewLine + 
                "Противоположность знаков значений " +
                "функции на концах отрезка можно определить множеством способов.Один из множества этих способов" +
                " — умножение значений функции на концах отрезка и определение знака произведения путём сравнения" +
                " результата умножения с нулём.","About the Program");
        }

        // ------------------------------------------


        // Загружена форма

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.language = Properties.Settings.Default.Language;
            Form1.bColor = Properties.Settings.Default.bColor;
            Form1.ColorText= Properties.Settings.Default.ColorText;

            Language();
            ChangeNames();
            RunWork();
            ChangedColor();
            comboBox1.KeyPress += (sndr, eva) => eva.Handled = true;
        }

        // ------------------------------------------



        // Члены класса
        public string equation = StartWindows.equation;
        public double left=0;
        public double right=1;
        public double accuracy;
        public double x1, x2, x3, x4;     // данные пользователя
        public bool check = true;         // Пользователь сделал ошибку?
        public bool createGraph = true;  // Надо делать граф?
        public int numberEquation = 1;  // Какое уравнение выбрал юзер
        public string eq;               // Само уравнение
        public int numberOfEq = 1;        // Порядок уравнений в доке
        public bool fileIsBe = false;  // создан ли файл
        public string filename;       // путь до файла
        public double N;
        // Пользовательские настройки
        public static bool language = true;
        public static Color bColor;
        public static Color ColorText;
        //-----------------------------------------


        // Определение того, что выбрал пользователь

        private void CheckAboutEquation()
        {
            switch (equation)
            {
                case "x^3 + x^2 + x = 0":
                    VisibleForF1();
                    break;
                case "x^4 + x^3 + x = 0":
                     VisibleForF2(); numberEquation = 2;
                    break;
                case "x^2 + x + c = 0":
                     VisibleForF3(); numberEquation = 3;
                    break;
            }
        }

        // ----------------------------------------


        // Видимость элементов для каждого выбора

        private void VisibleForF1()
        {
            label1.Text = "x^3";
            label2.Text = "x^2";
            label3.Text = "x";
            label4.Text = Use[20];
            textBox4.Enabled = false;
            label6.Text = "x^3 + x^2 + x = 0";
        }

        private void VisibleForF2()
        {
            label1.Text = "x^4";
            label2.Text = "x^3";
            label3.Text = "x";
            label4.Text = Use[20];
            textBox4.Enabled = false;
            label6.Text = "x^4 + x^3 + x = 0";
        }

        private void VisibleForF3()
        {
            label1.Text = "a";
            label2.Text = "b";
            label3.Text = "c";
            label3.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            label6.Text = "a*x^2+b*x+c=0";
            textBox4.Visible = true;
            label4.Visible = true;
            textBox4.Enabled = false;
            this.label4.Text =Use[20];
        }

        // --------------------------------------

        // Решение уравнений

        private void NumberEquation1(double l,double r)
        {
            double a, b, c;
            a = l;
            b = r;
            while (b - a > accuracy)
            {
                c = (a + b) / 2;
                if (F1(a, x1, x2,x3) * F1(c, x1, x2,x3) <= 0)
                    b = c;
                else
                    a = c;
            }
            if (Math.Round(F1(((a + b) / 2), x1, x2, x3)) == 0)
            {
                textBox4.Text = Convert.ToString(Math.Round(((a + b) / 2), 3));
                dataGridView1.Rows[0].Cells[2].Value = Math.Round((a + b) / 2, 3);
                list2.Add((a + b) / 2, 0);
            }
            else if ((a + b) / 2 == right)
            {
                textBox4.Text = Convert.ToString(Math.Round(((a + b) / 2), 3));
                dataGridView1.Rows[0].Cells[2].Value = Math.Round((a + b) / 2, 3);
                list2.Add((a + b) / 2, 0);
            }
            else
            {
                textBox4.Text = "Нет корня";
                dataGridView1.Rows[0].Cells[2].Value = "Нет корня";
            }
        }

        private void NumberEquation2(double l,double r)
        {
            double a, b, c;
            a = l;
            b = r;
            while (b - a > accuracy)
            {
                c = (a + b) / 2;
                if (F2(a, x1, x2, x3) * F2(c, x1, x2, x3) <= 0)
                    b = c;
                else
                    a = c;
            }
            if (Math.Round(F2(((a + b) / 2), x1, x2, x3)) == 0)
            {
                textBox4.Text = Convert.ToString(Math.Round(((a + b) / 2), 3));
                dataGridView1.Rows[0].Cells[2].Value = Math.Round((a + b) / 2, 3);
                list2.Add((a + b) / 2, 0);
            }
            else if ((a + b) / 2 == right)
            {
                textBox4.Text = Convert.ToString(Math.Round(((a + b) / 2), 3));
                dataGridView1.Rows[0].Cells[2].Value = Math.Round((a + b) / 2, 3);
                list2.Add((a + b) / 2, 0);
            }
            else
            {
                textBox4.Text = "Нет корня";
                dataGridView1.Rows[0].Cells[2].Value = "Нет корня";
            }
        }

        private void NumberEquation3(double l,double r)
        {
            double a, b, c;
            a = l;
            b = r;
            while (b - a > accuracy)
            {
                c = (a + b) / 2;
                if (F3(b,x1,x2,x3) * F3(c,x1,x2,x3) <= 0)
                    a = c;
                else
                    b = c;
            }
            if (Math.Round(F3(((a + b) / 2), x1, x2, x3)) == 0)
            {
                textBox4.Text = Convert.ToString(Math.Round(((a + b) / 2), 3));
                dataGridView1.Rows[0].Cells[2].Value = Math.Round((a + b) / 2, 3);
                double ce = (a + b) / 2;
                list2.Add(ce, 0);
            }
            else if ((a + b) / 2 == right)
            {
                textBox4.Text = Convert.ToString(Math.Round(((a + b) / 2), 3));
                dataGridView1.Rows[0].Cells[2].Value = Math.Round((a + b) / 2, 3);
                list2.Add((a + b) / 2,0);
            }
            else
            {
                textBox4.Text = "Нет корня";
                dataGridView1.Rows[0].Cells[2].Value = "Нет корня";
            }
        }

        private void ConvertToDouble()
        {
            check = false;
            try
            {
                left = Convert.ToDouble(textBox6.Text);
            }
            catch
            {
                textBox6.Text = Use[36];
                check = true;
            }

            try
            {
                right = Convert.ToDouble(textBox7.Text);
            }
            catch
            {
                textBox7.Text = Use[36];
                check = true;
            }

            try
            {
                accuracy = Convert.ToDouble(textBox5.Text);
            }
            catch
            {
                textBox5.Text = Use[36];
                check = true;
            }

            try
            {
                x1 = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                textBox1.Text = Use[36];
                check = true;
            }

            try
            {
                x2 = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
                textBox2.Text = Use[36];
                check = true;
            }

            try
            {
                x3 = Convert.ToDouble(textBox3.Text);
            }
            catch
            {
                textBox3.Text = Use[36];
                check = true;
            }
            try
            {
                N = Convert.ToDouble(textBox8.Text);
            }
            catch
            {
                textBox8.Text = Use[36];
                check = true;
            }
        }

        private void FindSolution1()
        {
            double a=left;
            double b=right;
            double n=N;
            double h=(b-a)/n;

            double x0=a;
            double y0=F1(a,x1,x2,x3);
            double x = x0;

            double y;
            while (!(x>b))
            {
                y = F1(x, x1, x2, x3);
                if (y * y0 < 0)
                {
                    if (x0 == x) { }
                    else
                    {
                        dataGridView1.Rows.Insert(0, 1);
                        dataGridView1.Rows[0].Cells[0].Value = Math.Round(x0, 3);
                        dataGridView1.Rows[0].Cells[1].Value = Math.Round(x, 3);
                        NumberEquation1(x0, x);
                    }
                }
                x0 = x;
                y0 = y;
                x = x + h;
            }
        }

        private void FindSolution2()
        {
            double a = left;
            double b = right;
            double n = 10000;
            double h = (b - a) / n;

            double x0 = a;
            double y0 = F1(a, x1, x2, x3);
            double x = x0;

            double y;
            while (!(x > b))
            {
                y = F2(x, x1, x2, x3);
                if (y * y0 < 0)
                {
                    if (x0 == x) { }
                    else
                    {
                        dataGridView1.Rows.Insert(0, 1);
                        dataGridView1.Rows[0].Cells[0].Value = Math.Round(x0, 3);
                        dataGridView1.Rows[0].Cells[1].Value = Math.Round(x, 3);
                        NumberEquation2(x0, x);
                    }
                }
                x0 = x;
                y0 = y;
                x = x + h;
            }
        }

        private void FindSolution3()
        {
            list2.Clear();
            double a = left;
            double b = right;
            double n = 10000;
            double h = (b - a) / n;

            double x0 = a;
            double y0 = F1(a, x1, x2, x3);
            double x = x0;

            double y;
            while (!(x > b))
            {
                y = F3(x, x1, x2, x3);
                if (y * y0 < 0)
                {
                    if (x0 == x) { }
                    else
                    {
                        dataGridView1.Rows.Insert(0, 1);
                        dataGridView1.Rows[0].Cells[0].Value = Math.Round(x0, 10);
                        dataGridView1.Rows[0].Cells[1].Value = Math.Round(x, 10);
                        NumberEquation3(x0, x);
                    }
                }
                x0 = x;
                y0 = y;
                x = x + h;
            }
        }

        // ----------------------------------------


        // GroupBox Add
        public void GroupAdd()
        {
            groupBox1.Controls.Add(label6);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(textBox7);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label8);
        }
        // -----------------------------------------


        // Уравнения

        private double F1(double x,double x1,double x2, double x3)
        {
            return x1 * Math.Pow(x, 3) + x2 * Math.Pow(x, 2) + x3 * x;
        }

        private double F2(double x, double x1, double x2,double x3)
        {
            return x1 * Math.Pow(x, 4) + x2 * Math.Pow(x, 3) + x3 * x;
        }

        private double F3(double x, double x1, double x2, double c)
        {
            return x1 * (x * x) + x2 * x + c;
        }

        // -----------------------------------------



        //Кнопки

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows.Clear();
            ChangeNames();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list2.Clear();
            ConvertToDouble();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            if (left >= right)
            {
                MessageBox.Show(Use[22] + " >= " + Use[23],Use[35]);
            }
            if (!check)
            {
                switch (numberEquation)
                {
                    case 1:
                        FindSolution1();
                        if (createGraph) { Eq1(); CreateGraph(zedGraphControl); };
                        break;
                    case 2:
                        FindSolution2();
                        if (createGraph) { Eq2(); CreateGraph(zedGraphControl); };
                        break;
                    case 3:
                        FindSolution3();
                        if (createGraph) { Eq3(); CreateGraph(zedGraphControl); 
                        };
                        break;
                }
            }
            else
            {
                MessageBox.Show(Use[36], Use[30]);
            }
        }

        // ------------------------------------------


        // Функция сохранения

        void SaveAs()
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                filename = saveFileDialog1.FileName;
                // сохраняем текст в файл
                if (textBox4.Text!="")
                {
                    System.IO.File.WriteAllText(filename, Use[17] + " " + eq + Environment.NewLine +
                        Use[20] + " " + textBox4.Text + Environment.NewLine);
                    if (createGraph)
                    {
                        zedGraphControl.MasterPane.GetImage().Save(Path.Combine(System.IO.Path.GetDirectoryName(filename),
                            Convert.ToString(numberOfEq) + ".png"));
                    }
                }
                MessageBox.Show("Success", Use[3]);
                numberOfEq++;
                fileIsBe = true;
            }
            catch (IOException e)
            {
                MessageBox.Show(Use[35] + e.Message, Use[30]);
            }
        }

        void Save()
        {
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, true);
                writer.WriteLine(Environment.NewLine + Use[17] + " " + eq);
                for (int j=0;j< dataGridView1.Rows.Count; j++)
                {
                    writer.WriteLine(Environment.NewLine + Use[20] + " "+ dataGridView1.Rows[j].Cells[2].Value
                        +", ");
                }
                writer.Close();
                if (createGraph)
                {
                    zedGraphControl.MasterPane.GetImage().Save(Path.Combine(System.IO.Path.GetDirectoryName(filename),
                        Convert.ToString(numberOfEq) + ".png"));
                }
                numberOfEq++;
            }
            catch (IOException e)
            {
                MessageBox.Show(Use[35] + e.Message, Use[30]);
            }
        }

        //-------------------------------------------


        // Функция открытия
        void Open()
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                filename = openFileDialog1.FileName;
                MessageBox.Show("Success");
                fileIsBe = true;
            }
            catch (IOException e)
            {
                MessageBox.Show(Use[35] + e.Message, Use[30]);
            }
        }

        //------------------------------------------

        // Функция печати

        private void Print()
        {
            PrintDialog printDialog1 = new PrintDialog();
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDialog1.ShowDialog();
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            printDocument1.Print();
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StreamReader TF = new StreamReader(filename, Encoding.Default);
                string TFF = TF.ReadToEnd();
                TF.Dispose();
                e.Graphics.DrawString(TFF, Font, new SolidBrush(Color.Black), new RectangleF(20, 20, 800, 600));
            }
            catch (IOException er)
            {
                MessageBox.Show("Error!"+er.Message,"Error");
            }
        }

        // -----------------------------------------
        

        // Применить новые данные

        private void ChangeNames()
        {
            // Перевод меню
            this.создатьToolStripMenuItem.Text = Use[1];
            this.открытьToolStripMenuItem.Text = Use[2];
            this.сохранитьToolStripMenuItem.Text = Use[3];
            this.сохранитьКакToolStripMenuItem.Text = Use[4];
            this.отправитьToolStripMenuItem.Text = Use[5];
            this.печатьToolStripMenuItem1.Text = Use[6];
            this.выходToolStripMenuItem.Text = Use[7];
            this.файлToolStripMenuItem.Text = Use[0];
            this.настройкиToolStripMenuItem.Text = Use[8];
            this.параметрыToolStripMenuItem.Text = Use[9];
            this.оПрограммеToolStripMenuItem.Text = Use[10];
            this.оПрограммеМетодПоловинногоДеленияToolStripMenuItem.Text = Use[10];
            this.обновлениеToolStripMenuItem.Text = Use[12];
            this.отправитьОтзывToolStripMenuItem.Text = Use[13];
            this.оПрограммеToolStripMenuItem.Text = Use[14];
            this.сообщитьОПроблемеToolStripMenuItem.Text = Use[15];
            this.отправитьПредложениеToolStripMenuItem.Text = Use[16];
            
            //Перевод GroupBox
            this.groupBox1.Text= Use[17];
            this.groupBox2.Text = Use[18];

            //Перевод label 
            this.label4.Text = Use[20];
            this.label7.Text = Use[21];

            // Перевод кнопок
            this.button3.Text = Use[24];
            this.button1.Text = Use[29];

            // Перевод цветов combobox1
            this.comboBox1.Items[1] = Use[28];
            this.comboBox1.Items[0] = Use[25];
            this.comboBox1.Items[2] = Use[26];
            this.comboBox1.Items[3] = Use[27];

            // Graph
            ActivateNamesOfGraph(zedGraphControl);

            //FormName
            this.Text = Use[52];
        }

        private void ChangedColor()
        {
            this.BackColor = Form1.bColor;
            this.label1.ForeColor = Form1.ColorText;
            this.label2.ForeColor = Form1.ColorText;
            this.label3.ForeColor = Form1.ColorText;
            this.label4.ForeColor = Form1.ColorText;
            this.label6.ForeColor = Form1.ColorText;
            this.label7.ForeColor = Form1.ColorText;
            this.groupBox1.ForeColor = Form1.ColorText;
            this.groupBox2.ForeColor = Form1.ColorText;
            this.dataGridView1.BackgroundColor = Form1.bColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "3";
            textBox3.Text = "-4";
            textBox5.Text = "0.001";
            textBox6.Text = "-5";
            textBox7.Text = "0";
        }

        // -----------------------------------------

        // Обновить значения полей

        private void Updating()
        {
            ActivateNamesOfGraph(zedGraphControl);
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";

        }

        // -----------------------------------------

        // По закрытию окна делать ...

        private void SettingForm_Closed(object sender, EventArgs e)
        {
            Language();
            ChangedColor();
        }

        private void StartWindow_Closed(object sender, FormClosedEventArgs e)
        {
            Updating();
        }

        // -----------------------------------------

    }
}
