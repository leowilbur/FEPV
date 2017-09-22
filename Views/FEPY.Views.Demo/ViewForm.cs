using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using FEPY.Views.Demo.Properties;
using MIS.Utility;
using System.Globalization;
using BasicLanuage;
using DevExpress.XtraGrid;
using Newtonsoft.Json;
using System.Xml;
using FEPV.BLL;
using System.Collections;


namespace FEPY.Views.Demo
{
    public partial class ViewForm : Infrastructure.BaseForm
    {

        //  GateInfo gateInfo = new GateInfo();

        public ViewForm()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.ViewForm_Load);

        }
        private void ViewForm_Load(object sender, EventArgs e)
        {
            string language = MyLanguage.Language;
            Console.WriteLine("我的语言" + language);
            CultureLanuage.ApplyResourcesFrom(this, "demo", "ViewForm");

            gcItemGrid.Click += gcItemGrid_Click;
        }

        void gcItemGrid_Click(object sender, EventArgs e)
        {
            int rowCount = this.gvItemGrid.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gvItemGrid.GetDataRow(gvItemGrid.GetSelectedRows()[0]);
            txtTcode.Text = row["Tcode"].ToString();
            txtForm.Text = row["FormName"].ToString();
            txtGrid.Text = row["UIType"].ToString();
            WriteTips(1000, "已选中Code" + row["Code"].ToString(), Color.YellowGreen);
        }


        private void btTCode_Click(object sender, EventArgs e)
        {


            //CultureLanuage.LangData = gateInfo.SearchGateBasicLanguage("B_GetBasicSetting", new string[] { "Tcode", "FormName" }, new object[] { "Demo", "EGATE" });  //生存EGATE 

            //   CultureLanuage.LangData = gateInfo.SearchGateBasicLanguage("B_GetBasicSetting", new string[] { "Tcode", "FormName" }, new object[] { "Demo", "GuestInfo" });  //生存EGATE 
            //_TruckInfo.Plan4TruckTable = dtTruck;
            //DataTable langData =   gateInfo.SearchGateBasicLanguage("B_GetBasicSetting", new string[] { "Tcode", "FormName", "UIType" }, new object[] { "Demo", "GuestInfo", "A" });

            //DataTable griddt=  gateInfo.SearchGateGridLanguage("B_GetBasicSetting", new string[] { "Tcode", "FormName", "UIType" }, new object[] { "Demo", "GuestInfo", "gvItemGrid" });
            //  CultureLanuage.LangData = TestData.CreateDataTable();// 测试使用
            //langData.TableName = "LanguageSetting";
            //DataSet ds = new DataSet("LanguageSetting");
            //griddt.TableName = "gvItemGrid";
            //ds.Tables.Add(griddt.Copy());
            //if (CultureLanuage.WriteToXML(langData, ds, "Demo", "GuestInfo"))
            //{
            //    Console.WriteLine("写入成功");
            //}
            //if (CultureLanuage.WriteToXml(CultureLanuage.LangData, "Demo", "EGATE"))
            //{
            //    Console.WriteLine("写入成功");
            //}
        }

        private void btFunction_Click(object sender, EventArgs e)
        {
            ReportBiz biz = new ReportBiz();
            DataTable langData = biz.GetMISReport("Demo_Get_B_Lanuage",
                new string[] { },
                new object[] { }).Tables[0];

            gvItemGrid.Columns.Clear();
            gcItemGrid.DataSource = langData;
            gvItemGrid.BestFitColumns();


            WriteTips(1000, "wewewweewewewew", Color.YellowGreen);
        }

        private void BtExcel_Click(object sender, EventArgs e)
        {
            WriteTips(1000, "wewewweewewewew", Color.Orange);
            this.gvItemGrid.Columns.Clear();
            this.gcItemGrid.DataSource = TestData.CreateDataTable();


            gvItemGrid.BestFitColumns();
        }

        private void butCN_Click(object sender, EventArgs e)
        {
            DataTable gridContent = TestData.GridData("gvItemGrid");
            this.gvItemGrid.Columns.Clear();
            this.gcItemGrid.DataSource = TestData.CreateDataTable();

            gvItemGrid.BestFitColumns();

            //int i = 1;
            //foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvItemGrid.Columns)
            //{

            //    //customize columns
            //    DataRow devmenurow = gridContent.AsEnumerable().Where(p => p.Field<string>("ID") == column.FieldName).FirstOrDefault();
            //    column.Caption = devmenurow["CN"].ToString();
            //    i++;
            //}

        }

        private void butEN_Click(object sender, EventArgs e)
        {
            MyLanguage.Language = "EN";
            DataSet ds = CultureLanuage.ApplyResourcesFrom(this, "demo", "ViewForm");

            CultureLanuage.GridResourcesFrom(gvItemGrid, "gvItemGrid", ds);
            gvItemGrid.BestFitColumns();
        }

        private void gcItemGrid_DoubleClick(object sender, EventArgs e)
        {

            int rowCount = this.gvItemGrid.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gvItemGrid.GetDataRow(gvItemGrid.GetSelectedRows()[0]);
            MessageBox.Show("你选择的是:" + row["ID"].ToString() + row["EN"].ToString() + row["CN"].ToString());
        }

        private void butChinese_Click(object sender, EventArgs e)
        {
            MyLanguage.Language = "CN";
            DataSet ds = CultureLanuage.ApplyResourcesFrom(this, "demo", "ViewForm");
            CultureLanuage.GridResourcesFrom(gvItemGrid, "gvItemGrid", ds);
            gvItemGrid.BestFitColumns();
        }

        private void WriteXMLTest()
        {
            string m_Document = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"resources\" + "sampledata.xml";
            XmlWriter writer = null;

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                writer = XmlWriter.Create(m_Document, settings);
                writer.WriteStartElement("form");

                writer.WriteComment("sample XML fragment");

                // Write an element (this one is the root).
                writer.WriteStartElement("book");

                // Write the namespace declaration.
                writer.WriteAttributeString("xmlns", "bk", null, "urn:samples");

                // Write the genre attribute.
                writer.WriteAttributeString("genre", "novel");

                // Write the title.
                writer.WriteStartElement("title");
                writer.WriteString("The Handmaid's Tale");
                writer.WriteEndElement();

                // Write the price.
                writer.WriteElementString("price", "19.95");

                // Lookup the prefix and write the ISBN element.
                string prefix = writer.LookupPrefix("urn:samples");
                writer.WriteStartElement(prefix, "ISBN", "urn:samples");
                writer.WriteString("1-861003-78");
                writer.WriteEndElement();

                // Write the style element (shows a different way to handle prefixes).
                writer.WriteElementString("style", "urn:samples", "hardcover");

                // Write the close tag for the root element.
                writer.WriteEndElement();
                writer.WriteEndElement();
                // Write the XML to file and close the writer.
                writer.Flush();
                writer.Close();
            }

            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void Invoke_Click(object sender, EventArgs e)
        {
            //EGATETest testFrom = new EGATETest();

            //testFrom.Show();
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            int rowCount = gvItemGrid.SelectedRowsCount;
            if (rowCount == 0)
            {
                Console.WriteLine("没有选中行");
                WriteTips(5, "没有选中行");
                return;
            }
            else if (rowCount == 1)
            {
                Console.WriteLine("选中1行");
                CreateXML(txtTcode.Text.Trim(), txtForm.Text.Trim(), txtGrid.Text.Trim());
                return;
            }
            else
            {
                ArrayList rows = new ArrayList();
                for (int i = 0; i < rowCount; i++)
                {
                    if (gvItemGrid.GetSelectedRows()[i] >= 0)
                        rows.Add(gvItemGrid.GetDataRow(gvItemGrid.GetSelectedRows()[i]));
                }
                //
                foreach (DataRow r in rows)
                {
                    string _Tcode = r["Tcode"].ToString();
                    string _FormName = r["FormName"].ToString();
                    string _UIType = r["UIType"].ToString();
                    Console.WriteLine("CreateXML参数：Tcode[" + _Tcode + "],FormName[" + _FormName + "],UIType[" + _UIType + "]");
                    CreateXML(_Tcode, _FormName, _UIType);
                }
            }            
        }

        public void CreateXML(string Tcode, string FormName, string UIType)
        {
            ReportBiz biz = new ReportBiz();
            DataTable langData = biz.GetMISReport("B_GetBasicSetting", 
                new string[] { "Tcode", "FormName", "UIType" }, 
                new object[] { Tcode, FormName, UIType }).Tables[0];

            if (UIType == "A")
            {
                langData.TableName = "LanguageSetting";
                if (CultureLanuage.WriteToXml(langData, Tcode, FormName))
                {
                    Console.WriteLine("写入成功");
                    WriteTips(5, "写入成功");
                }
            }
            else
            {
                langData.TableName = UIType;
                if (CultureLanuage.WriteGridToXML(langData, Tcode, FormName))
                {
                    Console.WriteLine("写入成功");
                    WriteTips(5, "写入成功");
                }
            }
        }
    }
}
