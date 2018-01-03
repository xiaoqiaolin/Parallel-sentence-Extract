using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextProcess
{
    public partial class Form1 : Form
    {
        string searchtype = "";
       
        public Form1()
        {
            InitializeComponent();
            temps.dts = new DataSet();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void strict(string allTxt,string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.preSetence(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s,type);
        }

        private void resultToDt(string result,string typeid)
        {
            string[] resultArray = result.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("text");
            dt.Columns.Add("typeid");
            for (int i = 0; i < resultArray.Length; i++)
            {
                DataRow dr = dt.NewRow();
                resultArray[i] = resultArray[i].Replace("\r\n", "  ");
                dr["id"] = i;
                dr["text"] = resultArray[i];
                dr["typeid"] = typeid;
                dt.Rows.Add(dr);
            }
            temps.dts.Tables.Add(dt);
            result1.AutoGenerateColumns = false;
            result1.DataSource = dt;
            result1.Columns["id"].DataPropertyName = dt.Columns["id"].ToString();
            result1.Columns["text"].DataPropertyName = dt.Columns["text"].ToString();
        }
        private void Similarity(string allTxt, string type)
        {
            SimilarProcess sp = new SimilarProcess();
            List<String> text = null;
            text = sp.preSetence(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r")
                {
                    continue;
                }
                s += value + "\r\n";
                    
            } 
            resultToDt(s,type);
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            string keywords = "";
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                {
                    keywords = NLPIR.GetFileKeyWords(ofp.FileName, 6, false);
                }
                string fileName = System.IO.Path.GetFileName(ofp.FileName);
                filePath.Text = ofp.FileName;
                //string sql = string.Format("select * from KeyWords");
                //DataTable keyWords = DbHelperSQL.Query(sql).Tables[0];
                //var dataRows = keyWords.AsEnumerable().Where<DataRow>(C => C["filename"].ToString() == fileName && C["keywords"].ToString() == keywords);
                //int row = dataRows.Count<DataRow>();
                //if (row==1)
                //{
                //    MessageBox.Show("该文章记录已存在,您可以从历史记录中查找！"); 
                //}
                keyword.Text = keywords;
            }
        }

        private void filePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeMatch(string allTxt,string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.closeMatch1(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            
            resultToDt(s,type);
        }

        private void containMark(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.everySetence(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s,type);
        }

        private void inStrictMatch(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.inStrictMatch(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s, type);
        }

        private void commaSearch(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.closeMatch(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s, type);
        }

        private void setenceSearch(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.setenceMatchs(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s, type);
        }
        private void allin(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.allin(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s, type);
        }

        private void outStrictMatch(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.allout(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s, type);
        }

        private void citeSearchMatch(string allTxt, string type)
        {
            strictProcess sp = new strictProcess();
            List<String> text = null;
            text = sp.citeSearchMatch(allTxt);
            string s = "";
            foreach (String value in text)
            {
                if (value == "\r\n" || value == " ")
                {
                    continue;
                }
                s += value + "\r\n";
            }
            resultToDt(s, type);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (filePath.Text == "")
            {
                MessageBox.Show("请选择文件！");
            }
            else
            {
                string path = filePath.Text;
                String allTxt = "";
                if (File.Exists(path))
                {
                    FileStream fs = File.OpenRead(path);
                    StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                    allTxt = read.ReadToEnd();
                }
                allText.Text = allTxt;
                
                foreach (Control c in searchType.Controls)
                {
                    if (c is RadioButton)
                    {
                        if (((RadioButton)c).Checked)
                        {
                            searchtype = c.Text;
                        }
                    }
                }
                if (searchtype == "邻近检索")
                {
                    closeMatch(allTxt, "邻近检索");
                }
                else if (searchtype == "包含顿号")
                {
                    containMark(allTxt, "包含顿号");
                }
                else if (searchtype == "分号排比")
                {
                    inStrictMatch(allTxt, "分号排比");
                }
                else if (searchtype == "段间排比")
                {
                    outStrictMatch(allTxt, "段间排比");
                }
                else if (searchtype == "引用排比")
                {
                    citeSearchMatch(allTxt, "引用排比");
                }
                else if (searchtype == "段内排比")
                {
                    allin(allTxt, "段内排比");
                }
                else if (searchtype == "逗号排比")
                {
                    commaSearch(allTxt, "逗号排比");
                }
                else if (searchtype == "句号排比")
                {
                    setenceSearch(allTxt, "句号排比");
                }
            }
            

        }
        private void alltextsearch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void alltextsearch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void result1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void save_Click(object sender, EventArgs e)
        {
            string selectkeysql = string.Format("select * from KeyWords");
            DataTable keyWords = DbHelperSQL.Query(selectkeysql).Tables[0];
            var dataRows = keyWords.AsEnumerable().Where<DataRow>(C => C["filename"].ToString() == System.IO.Path.GetFileName(filePath.Text) && C["keywords"].ToString() == keyword.Text);
            int row = dataRows.Count<DataRow>();
            if (row == 0)
            {
                string keysql = string.Format("insert into KeyWords(filename,keywords) values('{0}','{1}')", System.IO.Path.GetFileName(filePath.Text), keyword.Text);
                string id = DbHelperSQL.ExecuteSql(keysql).ToString();
            }
            string fileIDsql = string.Format("select fileID from KeyWords where keywords='{0}'", keyword.Text);
            DataTable fileid = DbHelperSQL.Query(fileIDsql).Tables[0];

            string fileids = "";
            for (int m = 0; m < fileid.Rows.Count; m++)
            {
                fileids = fileid.Rows[m].ItemArray[0].ToString();
            }
            int num = 0;
            int count = 0;
            for (int i = 0; i < result1.RowCount; i++)
            {
                if (result1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    string selectsql = string.Format("select * from searchResult where fileID='{0}'",fileids);
                    DataTable result = DbHelperSQL.Query(selectsql).Tables[0];
                    var dataRows1 = result.AsEnumerable().Where<DataRow>(C => C["Text"].ToString() == result1.Rows[i].Cells[2].Value.ToString());
                    int row1 = dataRows1.Count<DataRow>();
                    if (row1 == 0)
                    {
                        string sql = string.Format("insert into searchResult(Text,typeId,keyWords,fileID) values('{0}','{1}','{2}','{3}')", result1.Rows[i].Cells[2].Value.ToString(), searchtype, keyword.Text, fileids);
                        num = DbHelperSQL.ExecuteSql(sql);
                        count++;
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("该数据已存在！");
                    }
                }
            }
            //if (num > 0)
            //{
            //    MessageBox.Show("保存成功");
            //}
        }

        private void record_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();  
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1); 
        }

        private void pomes_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            //splitContainer1.Panel2.Controls.Add(flowLayoutPanel2); 
            //flowLayoutPanel2.DisplayRectangle = true;
            
        }

        private void saveAll_Click(object sender, EventArgs e)
        {
            string selectkeysql = string.Format("select * from KeyWords");
            DataTable keyWords = DbHelperSQL.Query(selectkeysql).Tables[0];
            var dataRows = keyWords.AsEnumerable().Where<DataRow>(C => C["filename"].ToString() == System.IO.Path.GetFileName(filePath.Text) && C["keywords"].ToString() == keyword.Text);
            int row = dataRows.Count<DataRow>();
            if (row == 0)
            {
                string keysql = string.Format("insert into KeyWords(filename,keywords) values('{0}','{1}')", System.IO.Path.GetFileName(filePath.Text), keyword.Text);
                string id = DbHelperSQL.ExecuteSql(keysql).ToString();
            }
            string fileIDsql = string.Format("select fileID from KeyWords where keywords='{0}'", keyword.Text);
            DataTable fileid = DbHelperSQL.Query(fileIDsql).Tables[0];

            string fileids = "";
            for (int m = 0; m < fileid.Rows.Count; m++)
            {
                fileids = fileid.Rows[m].ItemArray[0].ToString();
            }

            int num = 0; 

            for (int i = 0; i < temps.dts.Tables.Count; i++)
            {
                for (int j = 0; j < temps.dts.Tables[i].Rows.Count; j++)
                {
                    string selectsql = string.Format("select * from searchResult where fileID='{0}'",fileids);
                    DataTable result = DbHelperSQL.Query(selectsql).Tables[0];
                    var dataRows1 = result.AsEnumerable().Where<DataRow>(C => C["Text"].ToString() == temps.dts.Tables[i].Rows[j]["Text"].ToString());
                    int row1 = dataRows1.Count<DataRow>();
                    if (row1 == 0)
                    {
                        string sql = string.Format("insert into searchResult(Text,typeId,keyWords,fileID) values('{0}','{1}','{2}','{3}')", temps.dts.Tables[i].Rows[j]["Text"].ToString(), temps.dts.Tables[i].Rows[j]["typeid"].ToString(), keyword.Text, fileids);
                        num = DbHelperSQL.ExecuteSql(sql);
                    }
                    else
                    {
                        string sql = string.Format("update searchResult set typeId=typeId+' {0}' where Text='{1}' and typeId not like '%{0}%'", temps.dts.Tables[i].Rows[j]["typeid"].ToString(), temps.dts.Tables[i].Rows[j]["Text"].ToString());
                        num = DbHelperSQL.ExecuteSql(sql);
                    }   
                }
                //if (num >= 0)
                //{
                //    MessageBox.Show("保存成功");
                //}
            }
            
        }

        private void readyHave_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void keyWords_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string path = "";
            String allTxt = "";
            int num = 0;
            if (filePath.Text == "")
            {
                MessageBox.Show("请选择文件！");
            }
            else
            {
                path = filePath.Text;
                fileName = System.IO.Path.GetFileName(path);
            }
            if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
            {

                string keywords = NLPIR.GetFileKeyWords(path, 6, false);
                keyword.Text = keywords;
                //string sql = string.Format("insert into KeyWords(filename,keywords) values('{0}','{1}')", fileName, keywords);
               // num = DbHelperSQL.ExecuteSql(sql);
            }
            
        }

        private void result1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = result1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string[] details = text.Split(' ');
            string detail = "";
            for (int i = 0; i < details.Length; i++)
            {
                detail += details[i]+"\n";
            }
            MessageBox.Show(detail);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("操作将删除所有抽取数据，确定进行吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string sql = "delete from KeyWords";
                DbHelperSQL.ExecuteSql(sql);
                string sql1 = "delete from searchResult";
                DbHelperSQL.ExecuteSql(sql1);
                MessageBox.Show("初始化成功");
            }
        }
    }
}
