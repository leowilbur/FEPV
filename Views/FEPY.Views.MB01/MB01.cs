using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FEPV.BLL;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class MB01 : Infrastructure.BaseForm
    {
        public MB01()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "MB01", "MB01");
            btSearch.Click+=btSearch_Click;
            btExcel.Click+=btExcel_Click;
            btReturn.Click+=btReturn_Click;
            btn2txt.Click+=btn2txt_Click;
        }

        ParametersView parametersview = new ParametersView();
        ShowVoucherView voucherview = new ShowVoucherView();

        void Input()
        {
            Workspace.Show(parametersview);
            btSearch.Visible = true;
            btExcel.Visible = false;
            btn2txt.Visible = false;
            btReturn.Visible = false;
            bar1.Refresh();
        }

        void Output()
        {
            Workspace.Show(voucherview);
            btSearch.Visible = false;
            btExcel.Visible = true;
            btn2txt.Visible = false;
            btReturn.Visible = true;
            bar1.Refresh();
        }

        ReportBiz rep = new ReportBiz();
        DataTable tb = new DataTable();

        private void MB52_Load(object sender, EventArgs e)
        {
            Input();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            tb = rep.GetMISReport("MB01_Query_vCardLogs", this.parametersview.Parameters, this.parametersview.Values).Tables[0];
            this.voucherview.StockTable = tb;
            Output();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Export to Excel";
            sfd.FileName = DateTime.Now.ToString("DataListyyyyMMddHHmm") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.voucherview.VouList.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success", "information");
            }      
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            Input();
        }

        private void btn2txt_Click(object sender, EventArgs e)
        {
            DataTable dt = tb;
            string str = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Txt(*.txt)|*.txt";
            sfd.Title = "Data list to txt";
            sfd.FileName = DateTime.Now.ToString("DataListyyMMddHHmmss") + ".txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName, false); // true 追加 false 覆盖 
                //sw.Write("写入字符"); 
                foreach (DataRow row in dt.Rows)
                {
                    str = "";
                    str += "0101" + row["ContractorID"].ToString() + "!"
                        + row["OperateTime"].ToString().Substring(2, 2)
                        + row["OperateTime"].ToString().Substring(5, 2)
                        + row["OperateTime"].ToString().Substring(8, 2)
                        + "!9!"
                        + row["OperateTime"].ToString().Substring(11, 2)
                        + row["OperateTime"].ToString().Substring(14, 2)
                        + row["OperateTime"].ToString().Substring(17, 2) + "!"
                        + ((row["Operate"].ToString() == "Out" ? "01" : "02")) + "!";

                    sw.WriteLine(str);
                }
                sw.Flush();
                sw.Close();
                MessageBox.Show("Success", "information");
            }
        }   
    }
}
