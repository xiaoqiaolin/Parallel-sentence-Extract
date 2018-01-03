using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextProcess
{
    public partial class Form2 : Form
    {
        DataTable datas = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select * from searchType");
            //string typeid = "";
            //string searchtype = "";
            DataTable typeTable = DbHelperSQL.Query(sql).Tables[0];
            string sql1 = string.Format("select * from searchResult");
            datas = DbHelperSQL.Query(sql1).Tables[0];
            showstrict("段间排比");
        }
        private void showstrict(string typeid)
        {
            DataTable dt = new DataTable();
            dt=datas.Clone();
            DataRow[] drs = datas.Select("typeId LIKE '%"+typeid+"%'");
            for (int i = 0; i < drs.Length; i++)
            {
                DataRow dr = drs[i];
                dt.Rows.Add(dr.ItemArray);
            }
            showdatas(dt);
        }
        private void showcloseMatch(string typeid)
        {
            DataTable dt = new DataTable();
            dt = datas.Clone();
            DataRow[] drs = datas.Select("typeid LIKE '%" + typeid + "%'");
            for (int i = 0; i < drs.Length; i++)
            {
                dt.Rows.Add(drs[i].ItemArray);
            }
            showdatas(dt);
        }
        private void showcontainMark(string typeid)
        {
            DataTable dt = new DataTable();
            dt = datas.Clone();
            DataRow[] drs = datas.Select("typeid LIKE '%" + typeid + "%'");
            for (int i = 0; i < drs.Length; i++)
            {
                dt.Rows.Add(drs[i].ItemArray);
            }
            showdatas(dt);
        }
        private void showSimilarity(string typeid)
        {
            DataTable dt = new DataTable();
            dt = datas.Clone();
            DataRow[] drs = datas.Select("typeid LIKE '%" + typeid + "%'");
            for (int i = 0; i < drs.Length; i++)
            {
                dt.Rows.Add(drs[i].ItemArray);
            }
            showdatas(dt);
        }
        private void showdatas(DataTable dt)
        {
            allDataGridView.AutoGenerateColumns = false;
            allDataGridView.DataSource = dt;
            allDataGridView.Columns["id"].DataPropertyName = dt.Columns["id"].ToString();
            allDataGridView.Columns["Text"].DataPropertyName = dt.Columns["Text"].ToString();
        }
        private void allDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void strict_Click(object sender, EventArgs e)
        {
            showstrict("段间排比");
        }
        private void closeMatch_Click(object sender, EventArgs e)
        {
            showcloseMatch("段内排比");
        }
        private void containMark_Click(object sender, EventArgs e)
        {
            showcontainMark("引用排比");
        }
        private void Similarity_Click(object sender, EventArgs e)
        {
            showSimilarity("邻近检索");
        }
        private void searchType_Paint(object sender, PaintEventArgs e)
        {

        }
        private void search_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int fileid =0;
            if (comboBox1.SelectedItem.ToString().Equals("主题"))
            {
                string sql = string.Format("select * from KeyWords");
                DataTable keyWords = DbHelperSQL.Query(sql).Tables[0];
                var dataRows = keyWords.AsEnumerable().Where<DataRow>(C => C["keywords"].ToString().Contains(text));
                int row = dataRows.Count<DataRow>();
                foreach (var datarow in dataRows)
                {
                    fileid =(int)datarow.ItemArray[0];
                }
                string sql1 = string.Format("select * from searchResult where fileID={0}", fileid);
                datas = DbHelperSQL.Query(sql1).Tables[0];
                allDataGridView.AutoGenerateColumns = false;
                allDataGridView.DataSource = datas;
                allDataGridView.Columns["id"].DataPropertyName = datas.Columns["id"].ToString();
                allDataGridView.Columns["text"].DataPropertyName = datas.Columns["text"].ToString();
            }
            else if (comboBox1.SelectedItem.ToString().Equals("内容"))
            {
                string sql1 = string.Format("select * from searchResult where Text like '%{0}%'", text);
                datas = DbHelperSQL.Query(sql1).Tables[0];
                allDataGridView.AutoGenerateColumns = false;
                allDataGridView.DataSource = datas;
                allDataGridView.Columns["id"].DataPropertyName = datas.Columns["id"].ToString();
                allDataGridView.Columns["text"].DataPropertyName = datas.Columns["text"].ToString();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            showSimilarity("句号排比");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            showSimilarity("逗号排比");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            showSimilarity("分号排比");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            showSimilarity("包含顿号");
        }

        private void allDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = allDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            string[] details = text.Split(' ');
            string detail = "";
            for (int i = 0; i < details.Length; i++)
            {
                detail += details[i] + "\n";
            }
            MessageBox.Show(detail);
        }


    }
}
