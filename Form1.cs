using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price;
            try
            {
                price = int.Parse(this.price.Text);
            }
            catch (FormatException)
            {
                return;
            }

            string message = Logic.Сonverter(price);
            label5.Text = message;
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        public class Logic
        {
            public static string Сonverter(int price)
            {
                //просчитывание стоимости товара в рублях и копейках
                int penny = price % 100;
                int rubles = price / 100;

                //объявление переменных отвечающих за правильное название стоимостей
                string rublesName;
                string pennyName;

                //проверка условия, если 1, то рубль, если 2-4, то рубля, если 5, то рублей и так далее, для всех чисел
                if ((rubles % 10) == 1 && rubles != 11)
                {
                    rublesName = "рубль";
                }
                else if (2 <= (rubles % 10) && (rubles % 10) <= 4 && rubles != 12 && rubles != 13 && rubles != 14)
                {
                    rublesName = "рубля";
                }
                else
                {
                    rublesName = "рублей";
                }

                //такая же проверка, только для копеек
                if ((penny % 10) == 1 && penny != 11)
                {
                    pennyName = "копейка";
                }
                else if (2 <= (penny % 10) && (penny % 10) <= 4 && penny != 12 && penny != 13 && penny != 14)
                {
                    pennyName = "копейки";
                }
                else
                {
                    pennyName = "копеек";
                }

                //вывод стоимости с проверкой, если 0 рублей, то только цена в копейках,
                //если 0 копеек, то N рублей ровно или вывод всей стоимости
                string message = " ";
                if (rubles == 0)
                {
                    message = penny + " " + pennyName;
                }
                else if (penny == 0)
                {
                    message = rubles + " " + rublesName + " ровно";
                }
                else
                {
                    message = rubles + " " + rublesName + " " + penny + " " + pennyName;
                }
                return message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            price.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label9.Visible = false;
            textBox2.Visible = false;
            label10.Visible = false;
            textBox3.Visible = false;
            button3.Enabled = false;

            label13.Visible = false;
            label12.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox1 = (CheckBox)sender;
            if (checkBox1.Checked == true)
            {
                label9.Visible = true;
                textBox2.Visible = true;
                button4.Top += 100;
                button3.Top += 100;
                label10.Top += 100;
                textBox3.Top += 100;
                button3.Enabled = true;
                label12.Visible = true;
            }
            else
            {
                label9.Visible = false;
                textBox2.Visible = false;
                button4.Top -= 100;
                button3.Top -= 100;
                label10.Top -= 100;
                textBox3.Top -= 100;
                label12.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox1 = (CheckBox)sender;
            if (checkBox1.Checked == true)
            {
                label10.Visible = true;
                textBox3.Visible = true;
                button4.Top += 100;
                button3.Top += 100;
                button3.Enabled = true;
                label13.Visible = true;
            }
            else
            {
                label10.Visible = false;
                textBox3.Visible = false;
                button4.Top -= 100;
                button3.Top -= 100;
                label13.Visible = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double numA = double.Parse(this.textBox1.Text);
            double numB;
            double numC;
            try
            {
                numB = double.Parse(this.textBox2.Text);
            }
            catch (FormatException)
            {
                numB = 0;
            }

            try
            {
                numC = double.Parse(this.textBox3.Text);
            }
            catch (FormatException)
            {
                numC = 0;
            }

            int restmonth = Logic2.ConditionA(numA, numB);
            label12.Text = restmonth.ToString() + " м.";

            int rest = Logic2.ConditionB(numA, numC);
            label13.Text = rest.ToString() + " м.";

            if (numC == 0)
            {
                label13.Text = "пока пусто";
            }

            if (numB == 0)
            {
                label12.Text = "пока пусто";
            }
        }

        public class Logic2
        {
            public static int ConditionA(double numA, double numB)
            {
                //Текущее значение месяца
                int monthNum = 3;

                //Величина увеличения
                double percentValue = numA * 0.02;

                //Разница месяцев текущего и месяца вклада
                int restMonth = 0;

                //Обработка программы
                for (int i = 0; percentValue <= numB; i++)
                {
                    numA = numA * 1.02;
                    percentValue = numA * 0.02;
                    monthNum++;
                    restMonth = monthNum - 3;
                }
                return restMonth;
            }

            public static int ConditionB(double numA, double numC)
            {
                //Инициализация номера месяца
                int monthNum = 3;

                //Переменная для проверки, чтобы избежать повторного вывода
                int checkB = 0;

                //Проверка условия для задания B
                int rest = 0;
                for (int i = 0; i < 1200; i++)
                {
                    //Увеличение значения текущего месяца
                    monthNum++;

                    //Увеличение суммы вклада на 0.02% каждый месяц (сложный процент)
                    numA = numA * 1.02;

                    if (numA > numC && checkB == 0)
                    {
                        checkB = 1;
                        rest = monthNum - 3;
                    }
                }
                return rest;
            }
        }
    }
}