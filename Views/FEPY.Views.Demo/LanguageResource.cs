using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FEPY.Views.Demo
{
  public  class LanguageResource
    {


      public static DataTable LangData { set; get; }

      public static void ApplyResources(Control parent, string lang)
       {


           DataRow drow = LangData.AsEnumerable().Where(p => p.Field<string>("ID") == parent.Name).FirstOrDefault();
         
           if (drow != null)
           {
               Console.WriteLine("current:"+parent.Name);
               parent.Text = drow["EN"].ToString();
           }
           if (parent is ToolStrip)
           {
               ToolStrip menu = parent as ToolStrip;
               foreach (ToolStripItem item in menu.Items)
               {

                   DataRow menurow = LangData.AsEnumerable().Where(p => p.Field<string>("ID") == item.Name).FirstOrDefault();

                   if (menurow != null)
                   {
                       item.Text = menurow["EN"].ToString();
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
                       item1.Text = devmenurow["EN"].ToString();
                   }
               }
           }
            foreach (Control ctl in parent.Controls)
            {
                Console.WriteLine("sub:"+ctl.Name);
                ApplyResources(ctl, lang);
            }

          
        }


      /// <summary>
      /// 从XML文件中读取一个DataTable
      /// </summary>
      /// <param name="dt">数据源</param>
      /// <param name="address">XML文件地址</param>
      /// <returns></returns>
      public static DataTable ReadFromXml(string address)
      {
          DataTable dt = new DataTable();
          try
          {
              if (!File.Exists(address))
              {
                  throw new Exception("language file isn't here !");
                 
              }
              XmlDocument xmlDoc = new XmlDocument();
              xmlDoc.Load(address);
              XmlNode root = xmlDoc.SelectSingleNode("DataTable");
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
                  //Console.WriteLine("行插入成功");
              }
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              return new DataTable();
          }
          return dt;
      }

    }
}
