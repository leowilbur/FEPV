using System;
using System.Data;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CredentialsManager
{
    public interface ITree
    {
    bool GetStoreNode(string title, out TreeInfo node);

    //BindingList<TreeInfo> GetStoreTree(int lft,int rgt,out DataTable treeTable);
    byte[] GetStoreTree(int lft, int rgt);

    StringBuilder GetNodeFullPath(int lft,int rgt);

    int RebuildTree(string parent, int left);

    bool AddNode2Tree(string parent,string title,string spec,string tCode,int point);

    bool DeleteNode(string title,int point);
   }

    [Serializable]
    public class TreeInfo
    {
        string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        string _Parent;

        public string Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }

        int _Lft;

        public int Lft
        {
            get { return _Lft; }
            set { _Lft = value; }
        }

        int _Rgt;

        public int Rgt
        {
            get { return _Rgt; }
            set { _Rgt = value; }
        }

        string _Spec;

        public string Spec
        {
            get { return _Spec; }
            set { _Spec = value; }
        }

        int _Layer;
        
        public int Layer
        {
            get { return _Layer; }
            set { _Layer = value; }
        }

        public int Descendants
        {
            get { return (_Rgt - _Lft - 1) / 2; }
        }

        string _TCode;
        
        public string TCode
        {
            get { return _TCode; }
            set { _TCode = value; }
        }
    }
}