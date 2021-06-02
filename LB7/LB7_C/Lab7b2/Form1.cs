using System;
using System.Windows.Forms;

namespace Lab7b
{
    public partial class Form1 : Form
    {
        ServiceReference.MyServiceClient client;

        public Form1()
        {
            InitializeComponent();

            this.client = new ServiceReference.MyServiceClient();
        }

        private void Get_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = Convert.ToString(this.client.GetAll());
        }

        private void Post_Click(object sender, EventArgs e)
        {
            string name = this.name.Text;
            string number = this.num.Text;

            if (this.client.AddDict(name, number) == "OK")
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void Put_Click(object sender, EventArgs e)
        {
            string name = this.name.Text;
            string number = this.num.Text;
            int id = Convert.ToInt32(this.id.Text);

            if (this.client.UpdDict(id, name, number) == "OK")
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.id.Text);

            if (this.client.DelDict(id) == "OK")
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void num_textChanged(object sender, EventArgs e)
        {

        }
    }
}
