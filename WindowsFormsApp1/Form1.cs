using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {

  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();

      // initialize statusstrip
      this.statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right;
      this.toolStripStatusLabel1.Text = $"0 selected ";
    }

    private void button1_Click(object sender, EventArgs e) {

      // reset columns/items
      this.listView1.Columns.Clear();
      this.listView1.Items.Clear();

      // initialize listview
      this.listView1.View = View.Details;
      this.listView1.FullRowSelect = true;
      this.listView1.Font = new Font("Consolas", 10f);
      this.listView1.Columns.Add(new ColumnHeader { Text = "Name", Width = 110 });
      this.listView1.Columns.Add(new ColumnHeader { Text = "Size", Width = 60 });
      this.listView1.Columns.Add(new ColumnHeader { Text = "Date modified", Width = 150 });

      // create image list
      ImageList imageList = new ImageList();
      imageList.Images.Add("file", Image.FromFile("./images/icons8-file-100.png"));
      imageList.Images.Add("folder", Image.FromFile("./images/icons8-folder-100.png"));
      imageList.ImageSize = new Size(18, 18);
      this.listView1.SmallImageList = imageList;

      // add items
      ListViewItem lvItem1 = this.listView1.Items
        .Add(key: "D:\\Dropbox", text: "Dropbox", imageKey: "folder");
      lvItem1.SubItems.Add("100 MB");
      lvItem1.SubItems.Add("5/17/2022 3:56 PM");

      ListViewItem lvItem2 = this.listView1.Items
        .Add(key: "D:\\GoogleDrive", text: "GoogleDrive", imageKey: "folder");
      lvItem2.SubItems.Add("59 MB");
      lvItem2.SubItems.Add("5/01/2019 8:28 PM");

      ListViewItem lvItem3 = this.listView1.Items
        .Add(key: "D:\\aaa.txt", text: "aaa.txt", imageKey: "file");
      lvItem3.SubItems.Add("15 KB");
      lvItem3.SubItems.Add("5/16/2022 12:30 PM");

    }

    private void listView1_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.A) {
        foreach (ListViewItem item in listView1.Items) {
          item.Selected = true;
        }
      }

      if (e.Control && e.KeyCode == Keys.C) {
        List<ListViewItem> selectedItems = 
          listView1.SelectedItems.Cast<ListViewItem>().ToList();
        string fileFullPaths = 
          string.Join(Environment.NewLine, selectedItems.Select(x => x.Name));
        Clipboard.SetText(fileFullPaths);
      }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
      this.toolStripStatusLabel1.Text = 
        $"{this.listView1.SelectedItems.Count} selected ";
    }

    private void button2_Click(object sender, EventArgs e) {

      // clear all items
      this.treeView1.Nodes.Clear();

      // initialize treeview
      this.treeView1.Font = new Font("Consolas", 10f);

      // create image list
      ImageList imageList = new ImageList();
      imageList.Images.Add("file", Image.FromFile("./images/icons8-file-100.png"));
      imageList.Images.Add("folder", Image.FromFile("./images/icons8-folder-100.png"));
      imageList.ImageSize = new Size(18, 18);
      this.treeView1.ImageList = imageList;

      // add items
      TreeNode treeNode1 = this.treeView1.Nodes
        .Add(key: "D:\\Dropbox", text: "Dropbox", imageKey: "folder", selectedImageKey: "folder");
      treeNode1.Nodes.Add("D:\\Dropbox\\text1.txt", text: "text1.txt", imageKey: "file", selectedImageKey: "file");

      TreeNode treeNode2 = this.treeView1.Nodes
        .Add(key: "D:\\GoogleDrive", text: "GoogleDrive", imageKey: "folder", selectedImageKey: "folder");
      treeNode2.Nodes.Add(key: "D:\\GoogleDrive\\Docs", text: "Docs", imageKey: "folder", selectedImageKey: "folder");
      treeNode2.Nodes.Add(key: "D:\\GoogleDrive\\readme.md", text: "readme.md", imageKey: "file", selectedImageKey: "file");

      TreeNode treeNode3 = this.treeView1.Nodes
        .Add(key: "D:\\aaa.txt", text: "aaa.txt", imageKey: "file");
    }
  }
}
