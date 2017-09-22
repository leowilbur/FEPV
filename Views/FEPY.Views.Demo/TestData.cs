using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPY.Views.Demo
{
  public  class TestData
    {

      public static DataTable CreateDataTable(){


          DataTable table = new DataTable();
          // Add three column objects to the table.
          DataColumn idColumn = new DataColumn();
          idColumn.DataType = System.Type.GetType("System.String");
          idColumn.ColumnName = "ID";

          table.Columns.Add(idColumn);

          DataColumn ENColumn = new DataColumn();
          ENColumn.DataType = System.Type.GetType("System.String");
          ENColumn.ColumnName = "EN";
          table.Columns.Add(ENColumn);

          DataColumn CNColumn = new DataColumn();
          CNColumn.DataType = System.Type.GetType("System.String");
          CNColumn.ColumnName = "CN";
          table.Columns.Add(CNColumn);
          DataRow row;
          row = table.NewRow();
          row["ID"] = "lbCard";
          row["EN"] = "Card ID";
          row["CN"] = "卡   号";
          table.Rows.Add(row);

          DataRow row1;
          row1 = table.NewRow();
          row1["ID"] = "lbTruck";
          row1["EN"] = "Truck ID";
          row1["CN"] = "车号";
          table.Rows.Add(row1);
           DataRow row2;
          row2 = table.NewRow();
          row2["ID"] = "btRole";
          row2["EN"] = "Role Setting";
          row2["CN"] = "角色";
          table.Rows.Add(row2);
              DataRow row3;
          row3 = table.NewRow();
          row3["ID"] = "_ParameterPanel";
          row3["EN"] = "Parameter Setting";
          row3["CN"] = "参数设置";
          table.Rows.Add(row3);
          
           DataRow row4;
           row4 = table.NewRow();
           row4["ID"] = "btTCode";
           row4["EN"] = "TCode Setting";
           row4["CN"] = "模块";
           table.Rows.Add(row4);
          
          return table;
      }




      public static DataTable GridData(string name ) {

          DataTable table = new DataTable(name);
          // Add three column objects to the table.
          DataColumn idColumn = new DataColumn();
          idColumn.DataType = System.Type.GetType("System.String");
          idColumn.ColumnName = "ID";
          table.Columns.Add(idColumn);

          DataColumn ENColumn = new DataColumn();
          ENColumn.DataType = System.Type.GetType("System.String");
          ENColumn.ColumnName = "EN";
          table.Columns.Add(ENColumn);

          DataColumn CNColumn = new DataColumn();
          CNColumn.DataType = System.Type.GetType("System.String");
          CNColumn.ColumnName = "CN";
          table.Columns.Add(CNColumn);
          DataRow row;
          row = table.NewRow();
          row["ID"] = "ID";
          row["EN"] = "Code";
          row["CN"] = "编号";
          table.Rows.Add(row);

          DataRow row1;
          row1 = table.NewRow();
          row1["ID"] = "EN";
          row1["EN"] = "English Name";
          row1["CN"] = "英文名";
          table.Rows.Add(row1);
          DataRow row2;
          row2 = table.NewRow();
          row2["ID"] = "CN";
          row2["EN"] = "Chinese Name";
          row2["CN"] = "中文名";
          table.Rows.Add(row2);
         

          return table;
      
      }
    }
}
