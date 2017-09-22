using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class BomTree : UserControl
    {
        public BomTree()
        {
            InitializeComponent();
            treeView.Nodes.Clear();
        }

        //TreeNode root;
        public void ListVersions(string Material, string Plant, string Version, string Spec, string STLAL)
        {
            treeView.Nodes.Clear();

            //NodeMat rootMat = new NodeMat(Material, Plant, Version, Spec, STLAL);
            NodeVer rootVer = new NodeVer(Material, Plant, Version, Spec, STLAL);

            foreach (var m in rootVer.Mats)
            {
                treeView.Nodes.Add(m.ToString()).Tag = m;
            }

            //foreach (NodeVer v in rootMat.Vers)
            //{
            //    root.Nodes.Add(v.ToString()).Tag = v;
            //}
        }

        public string VER
        {
            get
            {
                versions = new Versions("");
                foreach (TreeNode n in treeView.Nodes)
                {
                    versions.DIV();
                    Throught(n, versions);
                }
                return versions.ToString().TrimStart('┃');
            }
        }

        Versions versions = new Versions("");

        private void Throught(TreeNode node, Versions ver)
        {

            if (node.Checked && typeof(NodeVer).IsInstanceOfType(node.Tag))
            {
                NodeVer v = (NodeVer)node.Tag;
                versions.Push(v.VER, v.Material);
            }

            foreach (TreeNode i in node.Nodes)
            {
                Throught(i, ver);
            }
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode n = e.Node;
            if (n.Checked == false)
            {
                n.Nodes.Clear();
                return;
            }

            if (typeof(NodeMat).IsInstanceOfType(n.Tag))
            //try
            {
                NodeMat m = (NodeMat)n.Tag;
                foreach (var v in m.Vers)
                {
                    n.Nodes.Add(v.ToString()).Tag = v;
                }
            }

            //catch { }


            if (typeof(NodeVer).IsInstanceOfType(n.Tag))
            //try
            {
                NodeVer v = (NodeVer)n.Tag;
                foreach (var m in v.Mats)
                {
                    n.Nodes.Add(m.ToString()).Tag = m;
                }
            }
            //catch { }
            if (n.Checked)
                n.Expand();

        }
    }

    public class NodeMat
    {
        string _Material, _Plant, _Ver, _Spec, _STLAL;
        BindingList<NodeVer> _Vers = null;
        public static UIReporting Query = new UIReporting();
        public NodeMat(string Material, string Plant, string Ver, string Spec, string STLAL)
        {
            _Material = Material;
            _Plant = Plant;
            _Ver = Ver;
            _Spec = Spec;
            _STLAL = STLAL;
        }

        public BindingList<NodeVer> Vers
        {
            get
            {
                if (_Vers != null)
                    return _Vers;

                _Vers = new BindingList<NodeVer>();
                _Vers.Clear();
                foreach (DataRow r in
     Query.GetMISReport("Q_VER", new string[] { "MaterialNO", "Plant" },
                                 new object[] { _Material, _Plant }).Tables[0].Rows)
                {
                    _Vers.Add(new NodeVer((string)r["MaterialNO"],
                                          (string)r["Plant"],
                                          (string)r["VER"],
                                          (string)r["Spec"],
                                          (string)r["STLAL"]));
                }
                return _Vers;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", _Material, _STLAL);
        }
    }

    public class NodeVer
    {
        string _Material, _Plant, _Ver, _Spec, _STLAL;
        BindingList<NodeMat> _Mats = null;
        public NodeVer(string Material, string Plant, string Ver, string Spec, string STLAL)
        {
            _Material = Material;
            _Plant = Plant;
            _Ver = Ver;
            _Spec = Spec;
            _STLAL = STLAL;
        }

        public BindingList<NodeMat> Mats
        {
            get
            {
                if (_Mats != null)
                    return _Mats;

                _Mats = new BindingList<NodeMat>();
                _Mats.Clear();
                foreach (DataRow r in
     NodeMat.Query.GetMISReport("Q_BOM", new string[] { "MaterialNO", "Plant", "STLAL" },
                                 new object[] { _Material, _Plant, _STLAL }).Tables[0].Rows)
                {
                    _Mats.Add(new NodeMat((string)r["IDNRK"],
                                          (string)r["Plant"],
                                          _Ver,
                                          _Spec,
                                          _STLAL));
                }
                return _Mats;
            }
        }

        public string VER { get { return _Ver; } }
        public string Material { get { return _Material; } }

        public override string ToString()
        {
            return string.Format("{0} {1}", _Ver, _Spec);
        }
    }
}
