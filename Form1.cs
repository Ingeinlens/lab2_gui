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

        private void label1_Click(object sender, EventArgs e)
        {
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

        private void price_TextChanged(object sender, EventArgs e)
        {
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
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
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}