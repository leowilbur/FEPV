
using System;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Security.Principal;
using System.Web.Security;
//using System.ServiceModel.Description;

using System.Text;

using System.Data.Sql;
using System.Data.Common;
using System.Data;

using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
namespace CredentialsManager
{

    public partial class TreeService : MarshalByRefObject, ITree
    {
        //Database db = Infrastructure.ServiceImplementation.ServiceHelper.DB;//DatabaseFactory.CreateDatabase("SYS");
        NBear.Data.Gateway db = new NBear.Data.Gateway("IM");//Infrastructure.ServiceImplementation.ServiceHelper.Gate;
        public bool GetStoreNode(string title, out TreeInfo node)
        {
            string strGetNodeSQL =
             @"SELECT CASE WHEN Parent IS NULL THEN ''
                          ELSE Parent
                      END AS Parent,
                      Title,
                      Spec,
                      Lft,
                      Rgt,
                      TCode
                FROM Tree 
                WHERE Title = @Title";
            //DbCommand dbCommand = db.GetSqlStringCommand(strGetNodeSQL);
            //db.AddInParameter(dbCommand, "Title", DbType.String, title);

            //DataTable tree = db.ExecuteDataSet(dbCommand).Tables[0];
            DataTable tree = db.DbHelper.Select(strGetNodeSQL, new object[] { title }).Tables[0];
            tree.TableName = "StoreNode";
            if (tree.Rows.Count != 1)
            {
                node = null;
                return false;
            }

            node = new TreeInfo();
            node.Title = (string)tree.Rows[0]["Title"];
            node.Spec = (string)tree.Rows[0]["Spec"];
            node.Parent = (string)tree.Rows[0]["Parent"];
            node.Lft = (int)tree.Rows[0]["Lft"];
            node.Rgt = (int)tree.Rows[0]["Rgt"];
            node.TCode = (string)tree.Rows[0]["TCode"];
            return true;
        }

        public  /*BindingList<TreeInfo>*/byte[] GetStoreTree(int lft, int rgt/*,out DataTable treeTable*/)
        {
            //DateTime b = DateTime.Now;
            //Console.WriteLine("TREE:"+DateTime.Now.ToString());
            string User = Infrastructure.ServiceImplementation.ServiceHelper.User;
            string IP = Infrastructure.ServiceImplementation.ServiceHelper.IP;
            string CostCenter = string.Empty;
            try
            {
                CostCenter = Infrastructure.ServiceImplementation.ServiceHelper.CostCenter;
            }
            catch { }

            //Console.WriteLine(string.Format("{0}:{1} {2} [{3}]"),DateTime.Now.ToString(),User,IP,CostCenter);

            //            string strGetTreeSQL =
            //             @"SELECT CASE WHEN Parent IS NULL THEN ''
            //                          ELSE Parent
            //                      END AS Parent,
            //                      Title,
            //                      Spec,
            //                      Lft,
            //                      Rgt,
            //                      TCode
            //                FROM Tree 
            //                WHERE lft BETWEEN @Lft AND @Rgt 
            //                ORDER BY lft ASC";
            //            DbCommand dbCommand = db.GetSqlStringCommand(strGetTreeSQL);
            //            db.AddInParameter(dbCommand, "Lft", DbType.Int32, lft);
            //            db.AddInParameter(dbCommand, "Rgt", DbType.Int32, rgt);
            ////DbCommand dbCommand = db.GetStoredProcCommand("proc_GetUsersTree");
            ////db.AddInParameter(dbCommand, "CostCenter", DbType.String, CostCenter);
            ////DataSet tree = db.ExecuteDataSet(dbCommand);
            DataSet tree = db.DbHelper.ExecuteStoredProcedure("proc_GetUsersTree",
                                                              new string[] { "CostCenter" },
                                                              new object[] { CostCenter });
            //tree.TableName = "StoreTree";
            //treeTable = tree;
            //------------------------------------------------------------------------------------
            /*
            BindingList<TreeInfo> storeNodes = new BindingList<TreeInfo>();

            if (tree.Rows.Count == 0)
            {
                return storeNodes;
            }

            Stack<Int32> right = new Stack<int>();
            // 获取每一个StoreNode
            foreach (DataRow row in tree.Rows)
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
                item.Title=(string)row["Title"];
                item.Spec =(string)row["Spec"];
                item.Parent  =(string)row["Parent"];
                item.Lft  =(int)row["Lft"];
                item.Rgt  =(int)row["Rgt"];
                item.Layer = right.Count;
                item.TCode= (string)row["TCode"];
                // 显示缩进的节点标题
                storeNodes.Add(item);
                // 把这个节点添加到栈中
                right.Push((int)row["rgt"]);
            }
             */
            //------------------------------------------------------------------------------------
            //Console.WriteLine(DateTime.Now - b);
            return MIS.Utility.DataFormatter.GetBinaryFormatDataCompress(tree);//storeNodes;
        }

        public StringBuilder GetNodeFullPath(int lft, int rgt)
        {
            StringBuilder pathResult = new StringBuilder();

            string strNotPathSQL =
              @"SELECT title 
                  FROM Tree 
                 WHERE lft < @Lft AND rgt > @Rgt 
                 ORDER BY lft ASC";
            //DbCommand dbCommand = db.GetSqlStringCommand(strNotPathSQL);
            //db.AddInParameter(dbCommand, "Lft", DbType.Int32, lft);
            //db.AddInParameter(dbCommand, "Rgt", DbType.Int32, rgt);
            //using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            using (IDataReader dataReader = db.DbHelper.SelectReadOnly(strNotPathSQL, new object[] { lft, rgt }))
            {
                while (dataReader.Read())
                {
                    pathResult.Append(dataReader["Title"]);
                    pathResult.Append('*');
                }
                if (dataReader != null)
                    dataReader.Close();

                return pathResult;
            }
        }


        public int RebuildTree(string parent, int left)
        {
            //Database dbSpec = DatabaseFactory.CreateDatabase("FEIT");

            int right = left + 1;

            string strTreeChildSQL = @"
                                      SELECT Title FROM Tree
                                       WHERE Parent=@Parent
                                       ORDER BY Power,Title ASC
                                      ";
            //DbCommand dbCommand = dbSpec.GetSqlStringCommand(strTreeChildSQL);
            //dbSpec.AddInParameter(dbCommand, "Parent", DbType.String, parent);

            //DataTable result = dbSpec.ExecuteDataSet(dbCommand).Tables[0];
            DataTable result = db.DbHelper.Select(strTreeChildSQL, new object[] { parent }).Tables[0];

            foreach (DataRow row in result.Rows)
            {
                right = RebuildTree((string)row["Title"], right);
            }

            string updateCmdSQL = @"
                                   UPDATE Tree SET Lft = @Lft,
                                                   Rgt = @Rgt
                                    WHERE Title = @Parent
                                  ";
            //DbCommand updateCmd = dbSpec.GetSqlStringCommand(updateCmdSQL);
            //dbSpec.AddInParameter(updateCmd, "Lft", DbType.Int32, left);
            //dbSpec.AddInParameter(updateCmd, "Rgt", DbType.Int32, right);
            //dbSpec.AddInParameter(updateCmd, "Parent", DbType.String, parent);

            //db.ExecuteNonQuery(updateCmd);
            db.DbHelper.ExecuteNonQuery(updateCmdSQL, new object[] { left, right, parent });
            ;
            return right + 1;
        }

        public bool AddNode2Tree(string parent, string title, string spec, string tCode, int point)
        {
            if (title.Trim() == "")
                return false;

            bool result = false;
            string updateRgtSQL = @"UPDATE tree SET rgt=rgt+2 WHERE rgt>@point";
            string updateLftSQL = @"UPDATE tree SET lft=lft+2 WHERE lft>@point";
            string InsertNodeSQL = @"INSERT INTO Tree(parent,title,lft,rgt,Spec,tCode)
                                          VALUES (@Parent,@Title,@point1+1,@point2+2,@Spec,@TCode)";

            //DbCommand updateRgtCmd = db.GetSqlStringCommand(updateRgtSQL);
            //db.AddInParameter(updateRgtCmd, "point", DbType.Int32, point);

            //DbCommand updateLftCmd = db.GetSqlStringCommand(updateLftSQL);
            //db.AddInParameter(updateLftCmd, "point", DbType.Int32, point);

            //DbCommand InsertNodeCmd = db.GetSqlStringCommand(InsertNodeSQL);
            //db.AddInParameter(InsertNodeCmd, "Parent", DbType.String, parent);
            //db.AddInParameter(InsertNodeCmd, "Title", DbType.String, title);
            //db.AddInParameter(InsertNodeCmd, "Spec", DbType.String, spec);
            //db.AddInParameter(InsertNodeCmd, "TCode", DbType.String, tCode);
            //db.AddInParameter(InsertNodeCmd, "point", DbType.Int32, point);

            using (DbTransaction transaction = db.BeginTransaction())
            {
                try
                {
                    db.DbHelper.ExecuteNonQuery(updateRgtSQL, new object[] { point }, transaction);
                    db.DbHelper.ExecuteNonQuery(updateLftSQL, new object[] { point }, transaction);
                    db.DbHelper.ExecuteNonQuery(InsertNodeSQL, new object[] { parent, title, point, point, spec, tCode }, transaction);
                    //db.ExecuteNonQuery(updateRgtCmd, transaction);
                    //db.ExecuteNonQuery(updateLftCmd, transaction);
                    //db.ExecuteNonQuery(InsertNodeCmd, transaction);

                    transaction.Commit();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    ;
                }
                return result;
            }
        }

        public bool DeleteNode(string title, int point)
        {
            bool result = false;
            string updateRgtSQL = @"UPDATE tree SET rgt=rgt-2 WHERE rgt>@point";
            string updateLftSQL = @"UPDATE tree SET lft=lft-2 WHERE lft>@point";
            string InsertNodeSQL = @"DELETE FROM Tree
                                     WHERE Title = @Title";

            //DbCommand updateRgtCmd = db.GetSqlStringCommand(updateRgtSQL);
            //db.AddInParameter(updateRgtCmd, "point", DbType.Int32, point);

            //DbCommand updateLftCmd = db.GetSqlStringCommand(updateLftSQL);
            //db.AddInParameter(updateLftCmd, "point", DbType.Int32, point);

            //DbCommand InsertNodeCmd = db.GetSqlStringCommand(InsertNodeSQL);
            //db.AddInParameter(InsertNodeCmd, "Title", DbType.String, title);

            using (DbTransaction transaction = db.BeginTransaction())
            {
                try
                {
                    db.DbHelper.ExecuteNonQuery(updateRgtSQL, new object[] { point }, transaction);
                    db.DbHelper.ExecuteNonQuery(updateLftSQL, new object[] { point }, transaction);
                    db.DbHelper.ExecuteNonQuery(InsertNodeSQL, new object[] { title }, transaction);

                    transaction.Commit();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    ;
                }
                return result;
            }
        }
    }
}