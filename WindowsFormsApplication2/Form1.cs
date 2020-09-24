using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        SqlConnection Sqlconnection;
        SqlDataAdapter sqlDataAdapter = null;
 
        DataSet dataSet = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Студенты]",Sqlconnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Студенты");
                dataGridView1.DataSource = dataSet.Tables["Студенты"];
                for (int i =0;i<dataGridView1.Rows.Count;i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7,i] = linkCell;
                }
            }
            catch
            {

            }

        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["Студенты"].Clear();
                sqlDataAdapter.Fill(dataSet, "Студенты");
                dataGridView1.DataSource = dataSet.Tables["Студенты"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch
            {

            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\danii\OneDrive\Документы\Visual Studio 2012\Projects\WindowsFormsApplication2\WindowsFormsApplication2\Database1.mdf;Integrated Security=True";

            Sqlconnection = new SqlConnection(ConnectionString);

            await Sqlconnection.OpenAsync();
            LoadData();

           

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sqlconnection != null && Sqlconnection.State != ConnectionState.Closed)
                Sqlconnection.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;

            if (
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Студенты] (ID_студента,Фамилия,Имя,Отчество,Общежитие,Группа,Стипендия) VALUES (@ID,@Name,@Fam,@Otch,@Obszh,@Group,@Stip)", Sqlconnection);

                command.Parameters.AddWithValue("ID", textBox1.Text);
                command.Parameters.AddWithValue("Name", textBox2.Text);
                command.Parameters.AddWithValue("Fam", textBox3.Text);
                command.Parameters.AddWithValue("Otch", textBox4.Text);
                command.Parameters.AddWithValue("Obszh", textBox5.Text);
                command.Parameters.AddWithValue("Group", textBox6.Text);
                command.Parameters.AddWithValue("Stip", textBox7.Text);

                await command.ExecuteNonQueryAsync();
            }
                else if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле 'Фамилия' должно быть заполнено";
            }
            else if (string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле 'Имя' должно быть заполнено";
            }
            else if (string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrWhiteSpace(textBox4.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле 'Отчество' должно быть заполнено";
            }
            else if (string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле 'Общежитие' должно быть заполнено";
            }
            else if (string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrWhiteSpace(textBox6.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле 'Группа' должно быть заполнено";
            }
            else if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrWhiteSpace(textBox7.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле 'Стипендия' должно быть заполнено";
            }
           
        }


    
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReloadData();
           
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            if (label15.Visible)
                label15.Visible = false;

            if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {

                SqlCommand command = new SqlCommand("UPDATE [Студенты] SET [Имя]=@Name,[Фамилия]=@Fam,[Отчество]=@Otch,[Общежитие]=@Obszh,[Группа]=@Group,[Стипендия]=@Stip WHERE [ID_студента]=@ID", Sqlconnection);

                command.Parameters.AddWithValue("ID", textBox14.Text);
                command.Parameters.AddWithValue("Name", textBox12.Text);
                command.Parameters.AddWithValue("Fam", textBox13.Text);
                command.Parameters.AddWithValue("Otch", textBox11.Text);
                command.Parameters.AddWithValue("Obszh", textBox10.Text);
                command.Parameters.AddWithValue("Group", textBox9.Text);
                command.Parameters.AddWithValue("Stip", textBox8.Text);
                await command.ExecuteNonQueryAsync();
            }

            else if (string.IsNullOrEmpty(textBox13.Text) && string.IsNullOrWhiteSpace(textBox13.Text))
            {
                label15.Visible = true;
                label15.Text = "Поле 'Фамилия' должно быть заполнено";
            }

            else if (string.IsNullOrEmpty(textBox12.Text) && string.IsNullOrWhiteSpace(textBox12.Text))
            {
                label15.Visible = true;
                label15.Text = "Поле 'Имя' должно быть заполнено";
            }

            else if (string.IsNullOrEmpty(textBox11.Text) && string.IsNullOrWhiteSpace(textBox11.Text))
            {
                label15.Visible = true;
                label15.Text = "Поле 'Отчество' должно быть заполнено";
            }

            else if (string.IsNullOrEmpty(textBox10.Text) && string.IsNullOrWhiteSpace(textBox10.Text))
            {
                label15.Visible = true;
                label15.Text = "Поле 'Общежитие' должно быть заполнено";
            }

            else if (string.IsNullOrEmpty(textBox9.Text) && string.IsNullOrWhiteSpace(textBox9.Text))
            {
                label15.Visible = true;
                label15.Text = "Поле 'Группа' должно быть заполнено";
            }

            else if (string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrWhiteSpace(textBox8.Text))
            {
                label15.Visible = true;
                label15.Text = "Поле 'Стипендия' должно быть заполнено";
            }

              
            
            }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            if (label18.Visible)
                label18.Visible = false;

            if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Студенты] WHERE [ID_студента]=@ID", Sqlconnection);

                command.Parameters.AddWithValue("ID", textBox15.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label18.Visible = true;
                label18.Text = "ID должен быть заполнен";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Студенты]",Sqlconnection);
                sqlDataAdapter = new SqlDataAdapter("SELECT ID_Студента,ID_предмета,AVG(Оценка) as Средний_Бал  FROM Зачетная_книжка GROUP BY ID_Предмета,ID_Студента", Sqlconnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Зачетная_книжка");
                dataGridView2.DataSource = dataSet.Tables["Зачетная_книжка"];
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[3, i] = linkCell;
                }
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
           
                sqlDataAdapter = new SqlDataAdapter("SELECT Расписание.Дата, Студенты.Фамилия, Студенты.Имя, Студенты.Отчество, Расписание.Предмет, Вид_занятия.Название,Расписание.Группа, Журнал_посещаемости.Отсутствие FROM Расписание,  Журнал_посещаемости, Студенты, Вид_занятия WHERE Расписание.ID_расп = Журнал_посещаемости.ID_Дня and Студенты.ID_студента = Журнал_посещаемости.ID_студента and Расписание.Вид_занятия = Вид_занятия.ID_вида  and Расписание.Дата = '2020.09.16'", Sqlconnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Расписание");
                sqlDataAdapter.Fill(dataSet, "Журнал_посещаемости");
                sqlDataAdapter.Fill(dataSet, "Студенты");
                sqlDataAdapter.Fill(dataSet, "Вид_занятия");
                dataGridView3.DataSource = dataSet.Tables["Расписание"];
                dataGridView3.DataSource = dataSet.Tables["Журнал_посещаемости"];
                dataGridView3.DataSource = dataSet.Tables["Студенты"];
                dataGridView3.DataSource = dataSet.Tables["Вид_занятия"];
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView3[8, i] = linkCell;
                }
            }
            catch
            {

            }
        }
  }
}
    

