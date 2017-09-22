using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using Infrastructure;
using CredentialsManager;

namespace Shell.Steps
{

    public partial class Explorer :DockContent
    {
        public static event EventHandler eventTCodeRaised;
        public Explorer()
        {
            InitializeComponent();
            bgwLoadTree.DoWork += new DoWorkEventHandler(bgwLoadTree_DoWork);
            bgwLoadTree.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwLoadTree_RunWorkerCompleted);
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            cmdTree.RightToLeftLayout = RightToLeftLayout;
        }

        void bgwLoadTree_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lcExp.Visible = false;

            if (storeTreeTable.Rows.Count == 0) return;

            if (rootNode == null) return;
            LoadTree("/");

            try
            {
                cmdTree.Nodes[0].Expand();
            }
            catch { }
            
        }

        CredentialsManager.TreeInfo rootNode;
        void bgwLoadTree_DoWork(object sender, DoWorkEventArgs e)
        {
            ITree treeProxy = Shawoo.Core.ServiceFactory.Create<ITree>();
            {
                try
                {
                    //treeProxy.RebuildTree(_ROOT, 1);
                    treeProxy.GetStoreNode(_ROOT, out rootNode);
                    GetStoreTree(rootNode.Lft, rootNode.Rgt, out storeTreeTable);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        public System.ComponentModel.BindingList<TreeInfo> GetStoreTree(int lft, int rgt, out System.Data.DataTable treeTable)
        {
            ITree treeProxy = Shawoo.Core.ServiceFactory.Create<ITree>();

            treeTable = MIS.Utility.DataFormatter.RetrieveDataSetDecompress(treeProxy.GetStoreTree(lft, rgt)).Tables[0];
            BindingList<TreeInfo> storeNodes = new BindingList<TreeInfo>();

            if (treeTable.Rows.Count == 0)
            {
                return storeNodes;
            }

            Stack<Int32> right = new Stack<int>();
            // 获取每一个StoreNode
            foreach (DataRow row in treeTable.Rows)
            {
                //检查栈里面有没有元素
                if (right.Count > 0)
                {
                    // 检查我们是否需要从栈中删除一个节点
                    while (right.Peek() < (int)row["rgt"])
                    {
                        right.Pop();
                    }
                }

                TreeInfo item = new TreeInfo();
                item.Title = (string)row["Title"];
                item.Spec = (string)row["Spec"];
                item.Parent = (string)row["Parent"];
                item.Lft = (int)row["Lft"];
                item.Rgt = (int)row["Rgt"];
                item.Layer = right.Count;
                item.TCode = (string)row["TCode"];
                // 显示缩进的节点标题
                storeNodes.Add(item);
                // 把这个节点添加到栈中
                right.Push((int)row["rgt"]);
            }

            return storeNodes;
        }

        #region 命令树
        DataTable storeTreeTable=new DataTable();

        string _ROOT = "/";

        public void LoadStoreArear(string root)
        {
            if (bgwLoadTree.IsBusy)
                return;

            _ROOT = root;
            lcExp.Visible = true;
            cmdTree.Nodes.Clear();
            bgwLoadTree.RunWorkerAsync();
        }

        private void LoadTree(string root)
        {
             AddTree(rootNode.Title, (TreeNode)null);
        }

        public void AddTree(string parent, TreeNode pNode)
        {
            DataView dvTree = new DataView(storeTreeTable);
            dvTree.RowFilter = string.Format(@"[parent] ='{0}'", parent);
            foreach (DataRowView Row in dvTree)
            {
                if (pNode == null)
                {
                    TreeNode Node = cmdTree.Nodes.Add((string)Row["Spec"]);
                    //(string)Row["Title"] + " " +
                    //(string)Row["Spec"]); //
                    #region SetLevelNum
                    int index = 2;
                    TreeNode tmpNode = Node;
                    while (tmpNode.Parent != null)
                    {
                        tmpNode = tmpNode.Parent;
                        //MessageBox.Show(((StoreNode)tmpNode.Tag).Title);
                        index++;
                    }

                    CredentialsManager.TreeInfo tag = new CredentialsManager.TreeInfo();
                    tag.Title =(string)Row["Title"];
                    tag.Spec = (string)Row["Spec"];
                    tag.Parent = (string)Row["parent"];
                    tag.Lft = (int)Row["Lft"];
                    tag.Rgt = (int)Row["Rgt"];
                    tag.Layer = index - 2;
                    tag.TCode = (string)Row["TCode"];
                    Node.Tag = tag;

                    if ((int)Row["Rgt"] - (int)Row["Lft"] == 1)
                        Node.SelectedImageIndex = 2;
                    Node.ImageIndex = Node.SelectedImageIndex;
                    #endregion
                    AddTree((string)Row["Title"], Node);
                }
                else
                {
                    TreeNode Node = pNode.Nodes.Add((string)Row["Spec"]);
                    //(string)Row["Title"] + " " +
                    //(string)Row["Spec"]); //

                    #region SetLevelNum
                    int index = 2;
                    TreeNode tmpNode = Node;
                    while (tmpNode.Parent != null)
                    {
                        tmpNode = tmpNode.Parent;
                        //MessageBox.Show(((StoreNode)tmpNode.Tag).Title);
                        index++;
                    }

                    CredentialsManager.TreeInfo tag = new CredentialsManager.TreeInfo();
                    tag.Title = (string)Row["Title"];
                    tag.Spec = (string)Row["Spec"];
                    tag.Parent = (string)Row["parent"];
                    tag.Lft = (int)Row["Lft"];
                    tag.Rgt = (int)Row["Rgt"];
                    tag.Layer = index - 2;
                    tag.TCode = (string)Row["TCode"];
                    Node.Tag = tag;
                    
                    if ((int)Row["Rgt"] - (int)Row["Lft"] == 1)
                        Node.SelectedImageIndex = 2;
                    Node.ImageIndex = Node.SelectedImageIndex;
                    #endregion
                    AddTree((string)Row["Title"], Node);
                }
            }
        }
        #endregion

        private void cmdTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CredentialsManager.TreeInfo StorNode = (CredentialsManager.TreeInfo)e.Node.Tag;
            if (((CredentialsManager.TreeInfo)e.Node.Tag).Descendants != 0)
                return;
            //RunCode(StorNode.TCode);
            //if (OnRunCode != null)
            //    OnRunCode(StorNode.TCode);
            //LoadStoreArear("/");
            if (eventTCodeRaised != null)
                eventTCodeRaised(StorNode.TCode, EventArgs.Empty);
            
            
        }

        private void cmdTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.SelectedImageIndex = 0;
            e.Node.ImageIndex = 0;
        }

        private void cmdTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.SelectedImageIndex = 1;
            e.Node.ImageIndex = 1;
        }

        #region ITreeView Members


        public void ClearTree()
        {
            cmdTree.Nodes.Clear();
            //throw new NotImplementedException();
        }

        public void LoadTree()
        {
            //LoadStoreArear("/");
            //throw new NotImplementedException();
            this.Invoke(new delegateLoadTree(LoadStoreArear));
        }

        delegate void delegateLoadTree();
        public void LoadStoreArear()
        {
            if (bgwLoadTree.IsBusy)
                return;

            lcExp.Visible = true;
            cmdTree.Nodes.Clear();
            Console.WriteLine("1");
            bgwLoadTree.RunWorkerAsync();
        }
        #endregion
    }
}