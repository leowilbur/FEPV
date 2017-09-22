using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MIS.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BasicLanuage
{
    public class CultureLanuage
    {
        private void GetGrid()
        {

        }

        /// <summary>
        /// 返回资源文件变量的值(多语言)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetTranslation(string name)
        {
            return MyLanguage.rm.GetString(name, MyLanguage.currentCultureInfo);
        }

        /// <summary> 
        /// 读取多语言的资源文件 Basic Grid
        /// </summary> 
        /// <param name="frmName">窗体的Name</param> 
        /// <param name="lang">要显示的语言(如ZH或EN)</param> 
        /// <returns></returns> 
        public static FrmLanguage ReadResource(string tcode, string frmName)
        {
            FrmLanguage frmlan = new FrmLanguage();
            DataSet ds = new DataSet("LanguageSetting");
            string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"resources\" + tcode + "_" + frmName + ".xml";

            if (File.Exists(filepath))
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filepath);
                XmlNode root = xmlDoc.SelectNodes("/Form/DataTable")[0];
                frmlan.FrmDt = AddDataTable(root);
                //  ds.Tables.Add(basicdt);
                //   Console.WriteLine(JsonConvert.SerializeObject(frmlan.FrmDt));
                XmlNodeList gridsNode = xmlDoc.SelectNodes("/Form/GridTable");
                foreach (XmlNode gridNode in gridsNode)
                {
                    DataTable griddt = AddDataTable(gridNode);
                    Console.WriteLine(JsonConvert.SerializeObject(griddt));
                    ds.Tables.Add(griddt);
                }

                frmlan.GridDs = ds;
            }



            return frmlan;

        }

        private static DataTable AddDataTable(XmlNode root)
        {
            DataTable dt = new DataTable();

            //读取表名
            dt.TableName = ((XmlElement)root).GetAttribute("TableName");
            //Console.WriteLine("读取表名： {0}", dt.TableName);
            //读取行数
            int CountOfRows = 0;
            if (!int.TryParse(((XmlElement)root).
             GetAttribute("CountOfRows").ToString(), out CountOfRows))
            {
                throw new Exception("行数转换失败");
            }
            //读取列数
            int CountOfColumns = 0;
            if (!int.TryParse(((XmlElement)root).
             GetAttribute("CountOfColumns").ToString(), out CountOfColumns))
            {
                throw new Exception("列数转换失败");
            }
            //从第一行中读取记录的列名
            foreach (XmlAttribute xa in root.ChildNodes[0].Attributes)
            {
                dt.Columns.Add(xa.Value);
                //Console.WriteLine("建立列： {0}", xa.Value);
            }
            //从后面的行中读取行信息
            for (int i = 1; i < root.ChildNodes.Count; i++)
            {
                string[] array = new string[root.ChildNodes[0].Attributes.Count];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = root.ChildNodes[i].Attributes[j].Value.ToString();
                }
                dt.Rows.Add(array);


            }

            return dt;
        }

        public static DataTable LangData { set; get; }
        public static DataSet GridDataSet { set; get; }
        public static DataSet ApplyResourcesFrom(Control parent, string tcode, string language, string frmName)
        {
            FrmLanguage frmlan = ReadResource(tcode, frmName);
            LangData = frmlan.FrmDt;
            GridDataSet = frmlan.GridDs;
            if (LangData != null)
            {
                ApplyResources(parent, language);
            }
            return GridDataSet;
        }

        public static void ApplyResources(Control parent, string language)
        {
            if (LangData.Rows.Count > 0)
            {
                DataRow drow = LangData.AsEnumerable().Where(p => p.Field<string>("ID") == parent.Name).FirstOrDefault();
                if (drow != null)
                {
                    Console.WriteLine("current:" + parent.Name);
                    parent.Text = drow[language].ToString();
                }
                if (parent is ToolStrip)
                {
                    ToolStrip menu = parent as ToolStrip;
                    foreach (ToolStripItem item in menu.Items)
                    {

                        DataRow menurow = LangData.AsEnumerable().Where(p => p.Field<string>("ID") == item.Name).FirstOrDefault();

                        if (menurow != null)
                        {
                            item.Text = menurow[language].ToString();
                        }
                    }
                }



                if (parent is DevComponents.DotNetBar.Bar)
                {

                    DevComponents.DotNetBar.Bar bar = parent as DevComponents.DotNetBar.Bar;
                    foreach (DevComponents.DotNetBar.ButtonItem item1 in bar.Items)
                    {
                        DataRow devmenurow = LangData.AsEnumerable().Where(p => p.Field<string>("ID") == item1.Name).FirstOrDefault();

                        if (devmenurow != null)
                        {
                            item1.Text = devmenurow[language].ToString();
                        }
                    }
                }
                foreach (Control ctl in parent.Controls)
                {
                    Console.WriteLine("sub:" + ctl.Name);
                    ApplyResources(ctl, language);
                }
            }

        }

        public static DataTable GridHeader(DataSet dsgrid, string gridname)
        {
            DataTable griddata = new DataTable();
            DataTable dt = dsgrid.Tables[gridname];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    griddata.Columns.Add(row["ID"].ToString());
                }
                return griddata;

            }
            return null;
        }
        /// <summary>
        /// 获得XML的翻译字段和Grid Header
        /// </summary>
        /// <param name="parent">当前窗体</param>
        /// <param name="tcode">Tcode</param>
        /// <param name="frmName">Form Name</param>
        public static DataSet ApplyResourcesFrom(Control parent, string tcode, string frmName)
        {
            string language = MyLanguage.Language;
            FrmLanguage frmlan = ReadResource(tcode, frmName);
            LangData = frmlan.FrmDt;
            GridDataSet = frmlan.GridDs;
            if (LangData != null)
            {
                ApplyResources(parent, language);
            }
            return GridDataSet;
        }

        public static void GridResourcesFrom(DevExpress.XtraGrid.Views.Grid.GridView gvItemGrid, string name, string language, DataSet ds)
        {
            DataTable gridContent = ds.Tables[name];
            if (gridContent != null)
            {
                int i = 1;
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvItemGrid.Columns)
                {
                    //customize columns
                    DataRow devmenurow = gridContent.AsEnumerable().Where(p => p.Field<string>("ID") == column.FieldName).FirstOrDefault();
                    column.Caption = devmenurow[language].ToString();
                    i++;
                }
            }
        }

        public static void GridResourcesFrom(DevExpress.XtraGrid.Views.Grid.GridView gvItemGrid, string name, DataSet ds)
        {
            Console.WriteLine("name");
            string language = MyLanguage.Language;
            DataTable gridContent = ds.Tables[name];
            if (gridContent != null)
            {
                Console.WriteLine(gridContent.Rows.Count);
                int i = 1;
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvItemGrid.Columns)
                {
                    Console.WriteLine(column.FieldName);
                    //customize columns
                    DataRow devmenurow = gridContent.AsEnumerable().Where(p => p.Field<string>("ID") == column.FieldName).FirstOrDefault();

                    column.Caption = devmenurow[language].ToString();
                    i++;
                }
            }
        }

        private static void WriteDataTable(DataTable dt, string tagname, string tablename, XmlTextWriter writer)
        {
            //DataTable GridTable
            writer.WriteComment(tagname + ":" + dt.TableName);
            writer.WriteStartElement(tagname); //DataTable开始
            writer.WriteAttributeString("TableName", tablename);
            writer.WriteAttributeString("CountOfRows", dt.Rows.Count.ToString());
            writer.WriteAttributeString("CountOfColumns", dt.Columns.Count.ToString());
            writer.WriteStartElement("ClomunName", ""); //ColumnName开始
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                writer.WriteAttributeString(
                 "Column" + i.ToString(), dt.Columns[i].ColumnName);
            }
            writer.WriteEndElement(); //ColumnName结束
            //按行各行
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                writer.WriteStartElement("Row" + j.ToString(), "");
                //打印各列
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    writer.WriteAttributeString(
                     "Column" + k.ToString(), dt.Rows[j][k].ToString().Trim());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); //DataTable结束
        }

        public static bool WriteGridToXML(DataTable griddt, string tcode, string frmName)
        {
            XmlTextWriter writer = null;
            try
            {
                string address = System.AppDomain.CurrentDomain.BaseDirectory.ToString()
                     + @"resources\" + tcode + "_" + frmName + ".xml";
                //如果文件DataTable.xml存在则直接删除
                if (File.Exists(address))
                {
                    File.Delete(address);
                }
                writer = new XmlTextWriter(address, Encoding.GetEncoding("utf-8"));

                writer.Formatting = System.Xml.Formatting.Indented;
                //XML文档创建开始
                writer.WriteStartDocument();
                writer.WriteStartElement("Form");
                //  basicsetting  LanguageSetting
                //WriteDataTable(basicdt, "DataTable", basicdt.TableName, writer);
                //DataTable结束
                //foreach (DataTable griddt in gridds.Tables)
                //{
                WriteDataTable(griddt, "GridTable", griddt.TableName, writer);
                // }

                writer.WriteEndElement(); //Form结束
                writer.WriteEndDocument();
                writer.Close();
                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static bool WriteToXml(DataTable dt, string tcode, string frmName)
        {
            XmlTextWriter writer = null;
            try
            {
                string address = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"resources\" + tcode + "_" + frmName + ".xml";
                //如果文件DataTable.xml存在则直接删除
                if (File.Exists(address))
                {
                    File.Delete(address);
                }
                writer =
                new XmlTextWriter(address, Encoding.GetEncoding("utf-8"));
                writer.Formatting = System.Xml.Formatting.Indented;
                //XML文档创建开始
                writer.WriteStartDocument();
                writer.WriteStartElement("Form");
                WriteDataTable(dt, "DataTable", dt.TableName, writer);

                writer.WriteEndElement(); //Form结束
                writer.WriteEndDocument();
                writer.Close();
                writer.Dispose();
                return true;
                //XML文档创建结束
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }

    public class FrmLanguage
    {
        public DataSet GridDs { set; get; }
        public DataTable FrmDt { set; get; }
    }
}
