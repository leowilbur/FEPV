using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Infrastructure.Proxy;
using CredentialsManager;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Actions;

using MIS.Utility;
using BasicLanuage;

namespace FEG.MES
{
    public partial class SE38 : Infrastructure.BaseForm
    {
        public SE38()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "SE38", this.Name);
            _iScript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Python");
            //("JavaScript");
            _iScript.Encoding = System.Text.Encoding.Default;

            Infrastructure.Contract.IReport report = Shawoo.Core.ServiceFactory.Create<Infrastructure.Contract.IReport>();
            tbTCode = DataFormatter.RetrieveDataSetDecompress(report.GetSYSReport("rep_TCodeList", new string[] { }, new object[] { })).Tables[0];
            bsTCodes.DataSource = tbTCode;

            _iEnabled.DataBindings.Add("Checked", bsTCodes, "Enabled");
            _iSpec.DataBindings.Add("Text", bsTCodes, "Spec");
            _iScript.DataBindings.Add("Text", bsTCodes, "Scripts");

            
            _iTCode.Properties.DataSource = bsTCodes;
            _iTCode.Properties.DisplayMember = "TCode";
            _iTCode.Properties.ValueMember = "TCode";
            _iTCode.Properties.Columns.Clear();
            _iTCode.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TCode", 30));
            _iTCode.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Spec", 100));

            _iTCode.EditValueChanged += new EventHandler(_iTCode_EditValueChanged);
            _iTCode.ItemIndex = 1;
        }

        void _iTCode_EditValueChanged(object sender, EventArgs e)
        {
            bsTCodes.Position = _iTCode.ItemIndex;
        }

        DataTable tbTCode;
        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            cmdTree.RightToLeftLayout = RightToLeftLayout;
        }

        void bgwLoadTree_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lcExp.Visible = false;
            cmdTree.Nodes.Clear();

            if (storeTreeTable.Rows.Count == 0) return;

            if (rootNode == null) return;
            
            LoadTree("/");
            //cmdTree.Nodes[0].Expand();
            cmdTree.ExpandAll();

        }

        CredentialsManager.TreeInfo rootNode;
        void bgwLoadTree_DoWork(object sender, DoWorkEventArgs e)
        {

            ITree treeProxy = Shawoo.Core.ServiceFactory.Create<ITree>();
            {
                //treeProxy.ClientCredentials.UserName.UserName = Singleton<XmppClientConnection>.Instance.Username;
                //treeProxy.ClientCredentials.UserName.Password = Singleton<XmppClientConnection>.Instance.Password;
                try
                {
                    treeProxy.RebuildTree(_ROOT, 1);
                    treeProxy.GetStoreNode(_ROOT, out rootNode);

                    GetStoreTree(rootNode.Lft, rootNode.Rgt, out storeTreeTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw ex;
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
        DataTable storeTreeTable = new DataTable();

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
                else
                {
                    string vv = (string)Row["Spec"];
                    string cc = (string)Row["TCode"];
                    if (cc.Trim() != "")
                        vv += ("-" + cc);
                    TreeNode Node = pNode.Nodes.Add(vv);
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
            //StoreNode crStorNode = (StoreNode)e.Node.Tag;
            //if (((StoreNode)e.Node.Tag).Descendants != 0)
            //    return;
            //RunCode(crStorNode.TCode);
            //LoadStoreArear("/");
            //if (OnRunCode != null)
            //    OnRunCode("TCode");

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

        private void btSearch_Click(object sender, EventArgs e)
        {
            lcExp.Visible = true;
            bgwLoadTree.RunWorkerAsync();
        }

        private void menuAddNote_Click(object sender, EventArgs e)
        {
            string parent ="/";
            if (cmdTree.SelectedNode != null)
            {
                parent = ((TreeInfo)cmdTree.SelectedNode.Tag).Title;
            }

            NodeEditer editer = new NodeEditer(parent);
            if (editer.ShowDialog() == DialogResult.OK)
            {
                bgwLoadTree.RunWorkerAsync();
            }
        }
        
        private void menuEditNote_Click(object sender, EventArgs e)
        {

        }

        private void menuDelNote_Click(object sender, EventArgs e)
        {
            ITree treeProxy = Shawoo.Core.ServiceFactory.Create<ITree>();
            {
                if (cmdTree.SelectedNode != null)
                {
                    if (treeProxy.DeleteNode(((TreeInfo)cmdTree.SelectedNode.Tag).Title,
                                              ((TreeInfo)cmdTree.SelectedNode.Tag).Lft
                                             ))
                        //cmdTree.Nodes.Remove(cmdTree.SelectedNode);
                        bgwLoadTree.RunWorkerAsync();
                }
            }
        }

        private void cmdTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmdTree.SelectedNode = cmdTree.GetNodeAt(e.X, e.Y);
                //if (cmdTree.GetNodeAt(e.X, e.Y) == null)
                //{
                //    MessageBox.Show(e.Location.ToString());
                //}
            }  
        }

        private void btScriptChange_Click(object sender, EventArgs e)
        {
            if (bsTCodes.Count == 0)
                return;

            ITCode Proxy = Shawoo.Core.ServiceFactory.Create<ITCode>();
            {
                Proxy.ChangeScript(((DataRowView)bsTCodes.Current)["TCode"].ToString(),
                                   ((DataRowView)bsTCodes.Current)["Scripts"].ToString());
            }
        }

        private void btScriptDelete_Click(object sender, EventArgs e)
        {
            if (bsTCodes.Count == 0)
                return;

            ITCode Proxy = Shawoo.Core.ServiceFactory.Create<ITCode>();
            {
                Proxy.Delete(((DataRowView)bsTCodes.Current)["TCode"].ToString());
            }
        }

        private void _iEnabledChanged(object sender, EventArgs e)
        {
            if (bsTCodes.Count == 0)
                return;

            ITCode Proxy = Shawoo.Core.ServiceFactory.Create<ITCode>();
            {
                Proxy.ChangeState(((DataRowView)bsTCodes.Current)["TCode"].ToString(),
                      !_iEnabled.Checked);
            }
        }

        private void _iScript_TextChanged(object sender, EventArgs e)
        {
            _iScript.Update();
            _iScript.Refresh();
        }
    }
}
