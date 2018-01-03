using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// download by http://down.liehuo.net
namespace TreeViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        private void InitTreeView(TreeView treeView)
        {
            treeView.CheckBoxes = false;//不显示复选框
            treeView.FullRowSelect = true;
            ImageList imageList = new ImageList();
            imageList.Images.Add(new Icon("Folder.ico"));
            imageList.Images.Add(new Icon("OpenFolder.ico"));
            imageList.Images.Add(new Icon("Book.ico"));
            treeView.ImageList = imageList;//设置图像集合
            treeView.LabelEdit = false;//设置不能编辑
            treeView.PathSeparator = "\\";//用\符号为分隔符
            treeView.Scrollable = true;//显示滚动条
            treeView.ShowLines = true;//显示连线
            treeView.ShowNodeToolTips = true;
            treeView.ShowPlusMinus = true;//显示+-号
            treeView.ShowRootLines = true;
             treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
        }

        void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Book book = e.Node.Tag as Book;
                this.txtPath.Text = e.Node.FullPath;
                this.txtBookName.Text = book.BookName;
                this.txtAuthor.Text = book.Author;
                this.txtPrice.Text = book.Price;
             }
        }
        private void AddNode(TreeView treeView)
        {
            //添加节点
            TreeNode MainNode = treeView.Nodes[0];
            treeView.BeginUpdate();
            MainNode.Nodes.Clear();
            //增加第一个分类节点
            TreeNode Catalog1 = new TreeNode("计算机技术");
            Catalog1.ImageIndex = 0;
            Catalog1.SelectedImageIndex = 1;
            Book Book1 = new Book();
            Book1.BookName = "计算机技术";
            Book1.Author = "小王";
            Book1.Price = "20.00";
            TreeNode BookNode1 = new TreeNode(Book1.BookName);
            BookNode1.ImageIndex = 2;
            BookNode1 .SelectedImageIndex = 2;
            BookNode1.Tag = Book1;//
            Book Book2 = new Book();
            Book2.BookName = "Windows技术";
            Book2.Author = "小李";
            Book2.Price = "60.00";
            TreeNode BookNode2 = new TreeNode(Book2.BookName);
            BookNode2.ImageIndex = 2;
            BookNode2.SelectedImageIndex = 2;
            BookNode2.Tag = Book2;//
            Catalog1.Nodes.Add(BookNode1);
            Catalog1.Nodes.Add(BookNode2);
            MainNode.Nodes.Add(Catalog1);
            //增加第二个分类节点
            TreeNode Catalog2 = new TreeNode("文学小说");
            Catalog2.ImageIndex = 0;
            Catalog2.SelectedImageIndex = 1;
            Book Book3 = new Book();
            Book3.BookName = "Love";
            Book3.Author = "LN";
            Book3.Price = "39.00";
            TreeNode BookNode3 = new TreeNode(Book3.BookName);
            BookNode3.ImageIndex = 2;
            BookNode3.SelectedImageIndex = 2;
            BookNode3.Tag = Book1;//
            Book Book4 = new Book();
            Book4.BookName = "Hello";
            Book4.Author = "Lily";
            Book4.Price = "20.00";
            TreeNode BookNode4 = new TreeNode(Book4.BookName);
            BookNode4.ImageIndex = 2;
            BookNode4.SelectedImageIndex = 2;
            BookNode4.Tag = Book4;//
            Catalog2.Nodes.Add(BookNode3);
            Catalog2.Nodes.Add(BookNode4);
            MainNode.Nodes.Add(Catalog2);
            treeView.EndUpdate();
        }
        public class Book
        {
            public string BookName = string.Empty;
            public string Author = string.Empty;
            public string Price = string.Empty;
        }

        private void btExpand_Click(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void btCollapse_Click(object sender, EventArgs e)
        {
            this.treeView1.CollapseAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitTreeView(this.treeView1);
            this.AddNode(this.treeView1);
        }
    }
}
