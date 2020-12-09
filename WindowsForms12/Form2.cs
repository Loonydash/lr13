using System;
using System.Windows.Forms;

namespace WindowsForms12
{
    public partial class Form2 : Form
    {
        string fullName, gender;
        int salary, incSalary = 0, group = 2, norm = 0, percent;
        public Form2()
        {
            InitializeComponent();
        }
        public bool ShowDialogForm(Menu parrent)
        {

            if (ShowDialog(parrent) == DialogResult.OK)
            {

                fullName = Convert.ToString(textBox1.Text);
                gender = Convert.ToString(textBox2.Text);
                salary = Convert.ToInt32(textBox3.Text);
                percent = Convert.ToInt32(textBox4.Text);
                Program.AddWorker(fullName, gender, salary, incSalary, percent, norm, group);
                ListViewItem item = new ListViewItem(fullName);
               
                item.SubItems.Add($"({salary})");
                parrent.listView1.Items.Add(item);
                return true;
            }
            else return false;

        }
    }
}