using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest
{
    public partial class Form1 : Form
    {
        string URL = "http://localhost:8080/szop/";
        String ROUTE = "index.php";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.GET);
            listBox1.Items.Add("All bluerays:");

            IRestResponse<List<Blueray>> response = client.Execute<List<Blueray>>(request);
            foreach (Blueray v in response.Data)
            {
                listBox1.Items.Add("ID:" + v.id + " title: " + v.title + " director: " + v.director + " actor:" + v.actor + " genre:" + v.genre +
                    " playtime:" + v.playtime + " price:" + v.price);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = "index.php?id=" + numericUpDown1.Value;
            var request = new RestRequest(ROUTE, Method.GET);

            if (numericUpDown1.Value != 0)
            {
                listBox1.Items.Add("Blueray by id:" + numericUpDown1.Value);
            }
            else
            {
                listBox1.Items.Add("All Blueray:");
            }

            IRestResponse<List<Blueray>> response = client.Execute<List<Blueray>>(request);
            foreach (Blueray v in response.Data)
            {
                listBox1.Items.Add("ID:" + v.id + " title: " + v.title + " director: " + v.director + " actor:" + v.actor + " genre:" + v.genre +
                                  " playtime:" + v.playtime + " price:" + v.price);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            string ROUTE = "index.php/{id}";
            var request = new RestRequest(ROUTE, Method.DELETE);
            request.AddParameter("id", numericUpDown2.Value);
            IRestResponse response = client.Execute(request);
            MessageBox.Show("Blueray is Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new Blueray
            {
                title = textBox1.Text,
                director = textBox2.Text,
                actor = textBox3.Text,
                genre = textBox4.Text,
                playtime = (int)numericUpDown3.Value,
                price = (int)numericUpDown4.Value,
            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show("Blueray is Inserted");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {

            var client = new RestClient(URL);
            string ROUTE = "index.php/{id}";
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", numericUpDown7.Value);

            request.AddBody(new Blueray
            {
                id = (int)numericUpDown7.Value,
                title = textBox8.Text,
                director = textBox7.Text,
                actor = textBox6.Text,
                genre = textBox5.Text,
                playtime = (int)numericUpDown6.Value,
                price = (int)numericUpDown5.Value,
            });
            IRestResponse response = client.Execute(request);
            MessageBox.Show("Blueray is updated!");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
