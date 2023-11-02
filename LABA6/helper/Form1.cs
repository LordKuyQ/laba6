namespace helper
{
    public partial class Form1 : Form
    {
        private Button button1;
        private Button button2;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            Width = 250;
            Height = 250; 

            button1 = new Button();
            button1.Text = "задача 1";
            button1.Location = new System.Drawing.Point(12, 25);
            button1.Size = new System.Drawing.Size(200, 50);
            button1.Click += Button1_Click; 

            button2 = new Button();
            button2.Text = "задача 2";
            button2.Location = new System.Drawing.Point(12, 100);
            button2.Size = new System.Drawing.Size(200, 50);
            button2.Click += Button2_Click; 

            this.Controls.Add(button1);
            this.Controls.Add(button2);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Num1 num1Form = new Num1();
            num1Form.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Num2 num2Form = new Num2();
            num2Form.Show();
        }
    }
}