using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using System.Data;
using Shawoo.Core;
using Shawoo.Common;

namespace FEPV.Implementation
{
    public class GoodsDAL : MarshalByRefObject, IGoods
    {
        public GoodsDAL()
        {
            acMIS.RegisterSqlLogger(new NBear.Common.LogHandler(Logger.Trace));
        }
        //FEPV MIS
        protected static NBear.Data.Gateway acMIS = new NBear.Data.Gateway("MIS");

        #region Goods Service

        public DataTable iGetMaterialByAB(string[] ps, object[] vs, string UserId)
        {
            Console.WriteLine("GoodsDAL - DataTable iGetMaterialByAB()" + " - " + DateTime.Now.ToString());
            DataTable dt = acMIS.DbHelper.ExecuteStoredProcedure("I_XD00_GetMaterialByAB", ps, vs).Tables[0];
            return dt;
        }

        public DataTable GetGoodList(string[] ps, object[] vs)
        {
            Console.WriteLine("GoodsDAL - DataTable GetGoodList()" + " - " + DateTime.Now.ToString());
            DataTable dt = acMIS.DbHelper.ExecuteStoredProcedure("Q_XD00_goods4CreatGoods", ps, vs).Tables[0];
            return dt;
        }

        public DataTable ExeProcedureUI(string pn, string[] ps, object[] vs)
        {
            Console.WriteLine("GoodsDAL - DataTable ExeProcedureUI(): " + pn + " - " + DateTime.Now.ToString());
            List<string> paramenters = ps.ToList();
            paramenters.Add("UserID");
            ps = paramenters.ToArray();
            List<object> values = vs.ToList();
            values.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
            vs = values.ToArray();
            DataTable dt = acMIS.DbHelper.ExecuteStoredProcedure(pn, ps, vs).Tables[0];
            return dt;
        }

        public string Produce(UIGoods goods)
        {
            try
            {
                Console.WriteLine("GoodsDAL - string Produce(): " + DateTime.Now.ToString());
                //Get UserID
                string UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
                //Get CenterID
                string CenterID = GetCostCenterId(UserID);
                Console.WriteLine("User ID:" + UserID + ", Center ID:" + CenterID);
                string BarCode = "";
                if (goods.TableName == "FEPV_POLY")
                    BarCode = CreateBarCodePOLY(goods);
                if (goods.TableName == "FEPV_SSP")
                    BarCode = CreateBarCodeSSP(goods);

                //Update new Goods
                acMIS.DbHelper.ExecuteNonQuery(@"INSERT INTO Goods(BarCode,MaterialNO,ProdSpec,CenterID,Plant,Loc,Batch,Num,Version0,Version,ProdDate,State,UserID,Counter,Stamp,Checker,LastVouId,PrevVouID,TableName,Remark,Store)
                                  Values(@BarCode,@MaterialNO,@ProdSpec,@CenterID,@Plant,@Loc,@Batch,@Num,@Version0,@Version,@ProdDate,@State,@UserID,@Counter,@Stamp,@Checker,@LastVouId,@PrevVouID,@TableName,@Remark,@Store)"
                        , new object[] {
                                     goods.BarCode = BarCode,//BarCode
                                     goods.MaterialNO,//MaterialNO
                                     goods.ProdSpec,//ProdSpec
                                     goods.CenterID=CenterID,//CenterID 
                                     "",//Plant
                                     "",//Loc
                                     goods.Batch,//Batch
                                     goods.Num,//Num
                                     "",//Version0
                                     "",//Version
                                     goods.ProdDate,//ProdDate
                                     goods.State==null?"N":goods.State,//State
                                     goods.UserID=UserID,//UserID 
                                     0,//Counter
                                     DateTime.Now,//Stamp
                                     Guid.NewGuid(),//Checker
                                     "",//LastVouId
                                     "",//PrevVouID
                                     goods.TableName,//TableName
                                     "",//Remark
                                     ""//Store
                        });
                Console.WriteLine("Good" + goods.ToString() + goods.VALUES.ToString());
                //Update FEPV_POLY,FEPV_SSP
                acMIS.DbHelper.ExecuteNonQuery(string.Format(@"INSERT INTO {0}
                                               ([BarCode]
                                               ,[LINE]
                                               ,[GRADE]
                                               ,[GRADES]
                                               ,[GWT]
                                               ,[CheckID]
                                               ,[PackID]
                                               ,[Chip])
                                                VALUES
                                                (@BarCode,@LINE,@GRADE,@GRADES,@GWT,@CheckID,@PackID,@Chip)", goods.TableName),
                                            new object[] {
                                                goods.VALUES[0].ToString(),
                                                goods.VALUES[1].ToString(),
                                                goods.VALUES[2].ToString(),
                                                goods.VALUES[3].ToString(),
                                                goods.VALUES[4].ToString(),
                                                goods.VALUES[5].ToString(),
                                                goods.VALUES[6].ToString(),
                                                goods.VALUES[7].ToString()
                                            });

            }
            catch (Exception ex) { Console.WriteLine(ex); return ""; }
            return goods.BarCode;
        }

        public bool Update(UIGoods goods)
        {
            try
            {
                acMIS.DbHelper.Update("Goods", new string[] { "MaterialNO", "ProdSpec", "CenterID", "Plant", "Loc", "Batch", "Num", "Version", "ProdDate", "State", "UserID", "Counter", "Stamp", "Checker", /*"LastVouId", "PrevVouID", "TableName",*/ "Remark", "Store" },
                                             new object[] 
                                             { 
                                                 goods.MaterialNO,goods.ProdSpec,
                                                 goods.CenterID,goods.Plant,goods.Loc,goods.Batch,goods.Num,
                                                 goods.Version,goods.ProdDate,
                                                 goods.State,
                                                 goods.UserID,goods.Counter,
                                                 DateTime.Now,  //Stamp,
                                                 Guid.NewGuid(),//Checker,
                                                                //LastVouId,
                                                                //PrevVouID,
                                                                //TableName,
                                                 goods.Remark,
                                                 goods.Store
                                             },
                                             "BarCode = @BarCode AND State = 'N' ", new object[] { goods.BarCode });

                acMIS.DbHelper.Update(goods.TableName, goods.COLUMNS, goods.VALUES, "BarCode = @BarCode2", new object[] { goods.BarCode });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public string CreateBarCodePOLY(UIGoods goods)
        {
            POLY poly = (POLY)goods;
            string pre = string.Format("L{0}{1}{2}", poly.Line.Trim().ToUpper(),
                                                 poly.ProdDate.ToString("ddMM"),
                                                 poly.ProdDate.ToString("yyyy").Substring(3, 1));
            int flow = (int)acMIS.DbHelper.SelectScalar("SELECT Count(BarCode)+1 FROM FEPV_POLY WHERE BarCode LIKE @Pre", new object[] { pre + "%" });
            Console.WriteLine("CreateBarCode: SELECT Count(BarCode)+1 FROM Goods WHERE BarCode LIKE " + pre + "%");
            Console.WriteLine(pre + flow.ToString().PadLeft(4, '0'));
            return GetCheckSum(pre + flow.ToString().PadLeft(4, '0'));
        }

        public string CreateBarCodeSSP(UIGoods goods)
        {
            SSP ssp = (SSP)goods;
            string pre = string.Format("C{0}{1}{2}", ssp.Line.Trim().ToUpper(),
                                                 ssp.ProdDate.ToString("ddMM"),
                                                 ssp.ProdDate.ToString("yyyy").Substring(3, 1));
            int flow = (int)acMIS.DbHelper.SelectScalar("SELECT Count(BarCode)+1 FROM FEPV_SSP WHERE BarCode LIKE @Pre", new object[] { pre + "%" });

            return GetCheckSum(pre + flow.ToString().PadLeft(4, '0'));
        }

        public string GetCheckSum(string sVar)
        {
            int nJ;
            int nI;
            nJ = (char)sVar.ToCharArray(0, 1).GetValue(0) - 'A' + 10;
            try
            {
                for (nI = 1; nI <= 11; nI++)
                {
                    int m = 0;
                    if ((char)sVar.ToCharArray(nI, 1).GetValue(0) > '9')
                        m = (char)sVar.ToCharArray(nI, 1).GetValue(0) - 'A';
                    else
                        m = (char)sVar.ToCharArray(nI, 1).GetValue(0) - '0';
                    if (nI % 2 != 0)
                    {
                        nJ = nJ + m * 2;
                    }
                    else
                    {
                        nJ = nJ + m;
                    }
                }
            }
            catch
            {
                throw;
            }
            nJ = nJ % 10;
            if (nJ != 0) nJ = 10 - nJ;
            Console.WriteLine("CheckSum: " + sVar + nJ.ToString());
            return sVar + nJ.ToString();
        }

        public string Print(string barCode, int point)
        {
            Console.WriteLine("GoodsDAL - DataTable Print()" + " - " + DateTime.Now.ToString());
            acMIS.DbHelper.ExecuteNonQuery(@"UPDATE Goods 
                                      SET Counter = Counter + 1,
                                          Checker = @Checker,
                                          Stamp = @Stamp 
                                    WHERE BarCode = @BarCode",
                                  new object[] { Guid.NewGuid(), DateTime.Now, barCode }
                                         );
            return "";
        }

        public string GetTableName(string barCode)
        {
            Console.WriteLine("Result: " + barCode + " TableName" + acMIS.SelectScalar<string>(@"SELECT TOP 1 TableName 
                                                 FROM Goods 
                                                WHERE BarCode = @BarCode",
                                             new object[] { barCode }));
            return acMIS.SelectScalar<string>(@"SELECT TOP 1 TableName 
                                                 FROM Goods 
                                                WHERE BarCode = @BarCode",
                                             new object[] { barCode });

        }

        public UIGoods GetInfo(string BarCode)
        {
            string TableName = GetTableName(BarCode);
            UIGoods goods = null;

            foreach (DataRow row in acMIS.DbHelper.Select(string.Format(@"
                                                                   SELECT * FROM v{0}
                                                                   WHERE BarCode = @BarCode", TableName),
                                                                   new object[] { BarCode }).Tables[0].Rows)
            {
                if (TableName == "FEPV_POLY")
                    return goods = new POLY()
                    {
                        BarCode = (string)row["BarCode"],
                        MaterialNO = (string)row["MaterialNO"],
                        ProdSpec = (string)row["ProdSpec"],
                        CenterID = (string)row["CenterID"],
                        Plant = (string)row["Plant"],
                        Loc = (string)row["Loc"],
                        Num = (decimal)row["Num"],
                        Version = (string)row["Version"],
                        ProdDate = (DateTime)row["ProdDate"],
                        State = (string)row["State"],
                        UserID = (string)row["UserID"],
                        Counter = (int)row["Counter"],
                        Stamp = (DateTime)row["Stamp"],
                        Checker = (Guid)row["Checker"],
                        LastVouID = (string)row["LastVouID"],
                        PrevVouID = (string)row["PrevVouID"],
                        Remark = (string)row["Remark"],
                        Store = (string)row["Store"],
                        // -----------------------------------------------
                        Line = (string)row["Line"],
                        Grade = (string)row["Grade"],
                        GradeS = (string)row["GradeS"],
                        GrossWeight = (decimal)row["GWT"],
                        Chip = (string)row["Chip"],
                        CheckID = (string)row["CheckID"],
                        PackID = (string)row["PackID"]

                    };

                if (TableName == "FEPV_SSP")
                    return goods = new SSP()
                    {
                        BarCode = (string)row["BarCode"],
                        MaterialNO = (string)row["MaterialNO"],
                        ProdSpec = (string)row["ProdSpec"],
                        CenterID = (string)row["CenterID"],
                        Plant = (string)row["Plant"],
                        Loc = (string)row["Loc"],
                        Num = (decimal)row["Num"],
                        Version = (string)row["Version"],
                        ProdDate = (DateTime)row["ProdDate"],
                        State = (string)row["State"],
                        UserID = (string)row["UserID"],
                        Counter = (int)row["Counter"],
                        Stamp = (DateTime)row["Stamp"],
                        Checker = (Guid)row["Checker"],
                        LastVouID = (string)row["LastVouID"],
                        PrevVouID = (string)row["PrevVouID"],
                        Remark = (string)row["Remark"],
                        Store = (string)row["Store"],
                        // -----------------------------------------------
                        Line = (string)row["Line"],
                        Grade = (string)row["Grade"],
                        GradeS = (string)row["GradeS"],
                        GrossWeight = (decimal)row["GWT"],
                        Chip = (string)row["Chip"],
                        CheckID = (string)row["CheckID"],
                        PackID = (string)row["PackID"]

                    };
            }
            return goods;
        }

        public int Cancel(string BarCode)
        {
            //string typeName = GetTableName(BarCode);
            //UIGoods _UIGood = CreateGoods(typeName);
            acMIS.ExecuteNonQuery("UPDATE Goods SET State = 'X',Stamp = GETDATE() WHERE BarCode = @BarCode AND State IN ('0','N','T')",
                                  new object[] { BarCode });
            return acMIS.SelectScalar<Int32>("SELECT Count(BarCode) FROM Goods WHERE BarCode = @BarCode AND State = 'X'",
                                             new object[] { BarCode });
        }

        protected static string GetCostCenterId(string UserID)
        {
            DataTable tb = acMIS.DbHelper.Select("SELECT * FROM [IM].[dbo].vEmployeeInCostCenter WHERE UserName = @UserName AND Serves = '1'",
                                new object[] { UserID }).Tables[0];
            if (tb.Rows.Count == 1)
            {
                return (string)tb.Rows[0]["CostCenterID"];
            }
            return "";
        }

        #endregion
    }

}
