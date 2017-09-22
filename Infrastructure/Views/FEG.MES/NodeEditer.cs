using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CredentialsManager;
using BasicLanuage;

namespace FEG.MES
{
    public partial class NodeEditer : DevExpress.XtraEditors.XtraForm
    {

        string _title;
        public NodeEditer(string parent)
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "SE38", this.Name);
            _title = parent;
            group.Text = parent;
        }

        TreeInfo node;
        private void NodeEditer_Load(object sender, EventArgs e)
        {
            
            //using (TreeProxy treeProxy = new TreeProxy(9000, "TreeService"))
            ITree treeProxy = Shawoo.Core.ServiceFactory.Create<ITree>();
            {
                treeProxy.GetStoreNode(_title, out node);
                _iFullPath.Text = treeProxy.GetNodeFullPath(node.Lft, node.Rgt).ToString();
            }


        }

        private void btOK_Click(object sender, EventArgs e)
        {
            ITree treeProxy = Shawoo.Core.ServiceFactory.Create<ITree>();
            {
                treeProxy.AddNode2Tree(node.Title, 
                                       _iTitle.Text.Trim(), 
                                       _iSpec.Text.Trim(), 
                                       iTCode.Text.Trim(),
                                       node.Descendants + 1);
            }

            Close();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}