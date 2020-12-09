using System;
using System.Windows.Forms;

namespace WindowsForms12
{
    public partial class Form1 : Form
    {
        string fullName, gender;
        int salary, incSalary, group = 1, norm, percent = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public bool ShowDialogForm(Menu parrent)
        {
            
                if (ShowDialog(parrent) == DialogResult.OK)
                {
                    
                    fullName = Convert.ToString(textBox1.Text);
                    gender= Convert.ToString(textBox2.Text);
                    salary = Convert.ToInt32(textBox3.Text);
                    incSalary = Convert.ToInt32(textBox4.Text);
                    norm = Convert.ToInt32(textBox5.Text);
                    Program.AddWorker(fullName, gender, salary, incSalary, percent, norm, group);
                ListViewItem item = new ListViewItem(fullName);
               
                item.SubItems.Add($"{salary}");
                parrent.listView1.Items.Add(item);


                return true;
                } 
                else return false;
            
        }

    }
}
