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
        //Инициализация формы
        public Form1()
        {
            InitializeComponent();
        }

        //Обработка нажатия на кнопку для задания 1
        private void button1_Click(object sender, EventArgs e)
        {
            //Инициализация стоимости
            int price;

            //Блок try catch для записи переменной и защиты от ошибок
            try
            {
                price = int.Parse(this.price.Text);
            }
            catch (FormatException)
            {
                return;
            }

            //Получение перевода через класс Logic
            string message = Logic.Сonverter(price);
            label5.Text = message;
        }

        //Запрет на ввод всех символов кроме чисел и BackSpace
        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 13) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        //Добавление перехода по Enter для всей формы
        //(работает только на половине формы, поэтому
        //добавлены дополнительные проверки на полях)
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        //Функция для добавления перехода по Enter
        private void price_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        //Кнопка отмены, которая просто очищает поле
        private void button2_Click(object sender, EventArgs e)
        {
            price.Text = "";
        }

        //Небольшие надстройки для скрытия полей
        private void Form1_Load(object sender, EventArgs e)
        {
            label9.Visible = false;
            numB.Visible = false;
            label10.Visible = false;
            numC.Visible = false;
            button3.Enabled = false;

            label13.Visible = false;
            label12.Visible = false;
        }

        //Чекбокс для демонстрации первого условия
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox1 = (CheckBox)sender;
            if (checkBox1.Checked == true)
            {
                label9.Visible = true;
                numB.Visible = true;
                button4.Top += 100;
                button3.Top += 100;
                label10.Top += 100;
                numC.Top += 100;
                button3.Enabled = true;
                label12.Visible = true;
            }
            else
            {
                label9.Visible = false;
                numB.Visible = false;
                button4.Top -= 100;
                button3.Top -= 100;
                label10.Top -= 100;
                numC.Top -= 100;
                label12.Visible = false;
            }
        }

        //Чекбокс для демонстрации второго условия
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox1 = (CheckBox)sender;
            if (checkBox1.Checked == true)
            {
                label10.Visible = true;
                numC.Visible = true;
                button4.Top += 100;
                button3.Top += 100;
                button3.Enabled = true;
                label13.Visible = true;
            }
            else
            {
                label10.Visible = false;
                numC.Visible = false;
                button4.Top -= 100;
                button3.Top -= 100;
                label13.Visible = false;
            }
        }

        //Запрет на ввод всех символов кроме чисел и BackSpace
        private void numA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        //Запрет на ввод всех символов кроме чисел и BackSpace
        private void numB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        //Запрет на ввод всех символов кроме чисел и BackSpace
        private void numC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        //Кнопка для очистки полей во втором задании
        private void button4_Click(object sender, EventArgs e)
        {
            numA.Text = "";
            numB.Text = "";
            numC.Text = "";
        }

        //Обработчик
        private void button3_Click(object sender, EventArgs e)
        {
            double numA = double.Parse(this.numA.Text);
            double numB;
            double numC;
            try
            {
                numB = double.Parse(this.numB.Text);
            }
            catch (FormatException)
            {
                numB = 0;
            }

            try
            {
                numC = double.Parse(this.numC.Text);
            }
            catch (FormatException)
            {
                numC = 0;
            }

            int restmonth = Logic.ConditionA(numA, numB);
            label12.Text = restmonth.ToString() + " м.";

            int rest = Logic.ConditionB(numA, numC);
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

        //Функция для добавление перехода по Enter
        private void numA_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        //Функция для добавления перехода по Enter
        private void numB_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        //Функция для добавление перехода по Enter
        private void numC_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        //Главный класс для обратки данных и их вывода
        public class Logic
        {
            //Конвертер для получения стоимости товара
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

            //Просчёт превышения процента от вклада за месяц
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

            //Второе значение суммы вклада через n месяцев
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