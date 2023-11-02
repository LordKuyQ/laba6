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
    public partial class Num2 : Form
    {
        public Num2()
        {
            InitializeComponent();
            start();
        }
        private TextBox tbVisitorName;
        private ComboBox cbUserType;
        private ComboBox cbTicketCost;
        private GroupBox groupBoxTickets;
        private TextBox tbVisiCount;
        private Button btnSubmit;

        private void start()
        {
            Width = 500;
            Height = 375;
            // Создание TextBox для имени посетителя
            tbVisitorName = new TextBox();
            tbVisitorName.Location = new System.Drawing.Point(20, 20);
            tbVisitorName.Text = "Максим";
            this.Controls.Add(tbVisitorName);

            // Создание ComboBox для выбора типа пользователя
            cbUserType = new ComboBox();
            cbUserType.Location = new System.Drawing.Point(20, 60);
            cbUserType.Items.AddRange(new object[] { "Viewer", "Regular", "Student", "Pensioners" });
            this.Controls.Add(cbUserType);

            // Создание ComboBox для выбора стоимости билета
            cbTicketCost = new ComboBox();
            cbTicketCost.Location = new System.Drawing.Point(20, 100);
            cbTicketCost.Items.AddRange(new object[] { "100", "200", "120", "800", "500" });
            this.Controls.Add(cbTicketCost);

            // Создание RadioButtons для выбора количества билетов
            groupBoxTickets = new GroupBox();
            groupBoxTickets.Text = "Number of Tickets";
            groupBoxTickets.Location = new System.Drawing.Point(200, 20);
            groupBoxTickets.Size = new System.Drawing.Size(200, 300);
            this.Controls.Add(groupBoxTickets);

            int radioButtonY = 20;
            for (int i = 1; i <= 10; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = i.ToString();
                radioButton.AutoSize = true;
                radioButton.Location = new System.Drawing.Point(20, radioButtonY);
                groupBoxTickets.Controls.Add(radioButton);

                radioButtonY += 25;
            }

            // Настройки TextBox для количества посещений
            tbVisiCount = new TextBox();
            tbVisiCount.Location = new System.Drawing.Point(20, 150);
            tbVisiCount.Text = "10";
            this.Controls.Add(tbVisiCount);

            // Создание кнопки для обработки значений
            btnSubmit = new Button();
            btnSubmit.Text = "чек";
            btnSubmit.Location = new System.Drawing.Point(20, 300);
            btnSubmit.Click += btnSubmit_Click;
            this.Controls.Add(btnSubmit);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string visitorName = tbVisitorName.Text;
            string userType = cbUserType.SelectedItem.ToString();
            double ticketPrice = int.Parse(cbTicketCost.SelectedItem.ToString());
            int ticketCount = _GetSelectedRadioButton();
            int visitCount = int.Parse(tbVisiCount.Text);

            string result = $"имя посетителя: {visitorName}{Environment.NewLine}" +
                            $"тип гостя: {userType}{Environment.NewLine}" +
                            $"цена: {Cost(userType, ticketPrice, ticketCount, visitCount)}{Environment.NewLine}" +
                            $"количество: {ticketCount}";

            MessageBox.Show(result, "=====чек=====");
        }

        public double Cost(string userType, double ticketPrice, int ticketCount, int visitCount)
        {
            switch (userType)
            {
                case "Viewer":
                    double totalCost = ticketPrice * ticketCount;
                    return totalCost;
                case "Regular":
                    totalCost = ticketPrice * ticketCount;
                    if (visitCount > 30 || visitCount + ticketCount > 30)
                    {
                        totalCost *= 0.8;
                    }
                    else if (visitCount > 20 || visitCount + ticketCount > 20)
                    {
                        totalCost *= 0.9;
                    }
                    else if (visitCount > 10 || visitCount + ticketCount > 10)
                    {
                        totalCost *= 0.95;
                    }
                    return totalCost;
                case "Student":
                    int a = 0;
                    totalCost = 0;
                    for (int i = visitCount; i <= visitCount + ticketCount; i++)
                    {
                        if (i % 3 == 0)
                        {
                            a += 1;
                        }

                    }
                    for (int i = 0; i < a; i++)
                    {
                        totalCost += ticketPrice * 0.5;

                    }
                    totalCost += ticketPrice * (ticketCount - a);

                    return totalCost;
                case "Pensioners":
                    a = 0;
                    totalCost = 0;
                    for (int i = visitCount; i <= visitCount + ticketCount; i++)
                    {
                        if (i % 5 == 0)
                        {
                            a += 1;
                        }

                    }
                    if (a != 0)
                    {
                        for (int i = 0; i < a; i++)
                        {
                            totalCost += ticketPrice * 0;

                        }
                    }
                    totalCost += (ticketPrice * 0.5) * (ticketCount - a);

                    return totalCost;
                default:
                    return 0;
            }
            
        }

        private int _GetSelectedRadioButton()
        {
            foreach (Control control in groupBoxTickets.Controls)
            {
                if (control is RadioButton && ((RadioButton)control).Checked)
                {
                    return int.Parse(control.Text);
                }
            }

            return 0; 
        }
    }
}
