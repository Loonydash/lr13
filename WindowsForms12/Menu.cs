using System;
using System.Windows.Forms;

namespace WindowsForms12
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public Form1 WorkerH = new Form1();
        public Form2 WorcerC = new Form2();
        public Form3 Dismiss = new Form3();
        //public Form5 Model = new Form5();
       public Form4 PutList = new Form4(); 
      
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 WorkerH = new Form1();
            WorkerH.ShowDialogForm(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 WorkerC = new Form2();
            WorkerC.ShowDialogForm(this);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 Dismiss = new Form3();
            Dismiss.ShowDialogForm(this);
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Program.Serialize();
            MessageBox.Show("Сериализация проведена успешно");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Program.Deserialize();
            MessageBox.Show("Десериализация проведена успешно");
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            Program.ClearDocument();
            MessageBox.Show("Документ успешно очищен");
        }
        public void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

    }
}
