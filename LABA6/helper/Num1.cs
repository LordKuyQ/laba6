using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helper
{
    public partial class Num1 : Form
    {
        private TextBox nameTextBox;
        private TextBox ageTextBox;
        private Button processButton;
        private Label resultLabel;
        public Num1()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            nameTextBox = new TextBox();
            ageTextBox = new TextBox();
            processButton = new Button();
            resultLabel = new Label();

            // Настройки TextBox для имени
            nameTextBox.Location = new System.Drawing.Point(12, 12);
            nameTextBox.Size = new System.Drawing.Size(200, 20);
            nameTextBox.Text = "Максим";


            // Настройки TextBox для возраста
            ageTextBox.Location = new System.Drawing.Point(12, 38);
            ageTextBox.Size = new System.Drawing.Size(200, 20);
            ageTextBox.Text = "999";

            // Настройки Button
            processButton.Location = new System.Drawing.Point(12, 64);
            processButton.Text = "старт";
            processButton.Click += ProcessButton_Click;

            // Настройки Label для отображения результата
            resultLabel.Location = new System.Drawing.Point(12, 90);
            resultLabel.AutoSize = true;

            // Настройки формы
            Width = 250;
            Height = 250;
            Controls.Add(nameTextBox);
            Controls.Add(ageTextBox);
            Controls.Add(processButton);
            Controls.Add(resultLabel);
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            string name = "василий";
            if (nameTextBox.Text != "василий")
            {
                MessageBox.Show($"Я не {nameTextBox.Text}, а {name}!");
            }
            else
                name = nameTextBox.Text;

            int helpage = int.Parse(ageTextBox.Text);
            int age = 0;
            if (helpage < 0) { age = 0; } else if (helpage > 122) { age = 122; } else { age = helpage; }


            string result = $"Меня зовут {name}, Мне {age} {GetAgeEnding(age)}.";

            resultLabel.Text = result;
        }

        private string GetAgeEnding(int age)
        {
            int Digit = age % 10;

            if (Digit == 1 && age != 11)
            {
                return "год";
            }
            else if ((Digit >= 2 && Digit <= 4) && (age < 12 || age > 14))
            {
                return "года";
            }
            else
            {
                return "лет";
            }
        }
    }
}
