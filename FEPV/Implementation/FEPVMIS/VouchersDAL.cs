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
using System.ServiceModel;

namespace FEPV.Implementation
{
    public class VouchersDAL : MarshalByRefObject, IVouchers
    {
        public VouchersDAL()
        {
            acMIS.RegisterSqlLogger(new NBear.Common.LogHandler(Logger.Trace));
            
        }
        //Using MIS Database ----------------------------------------------------
        protected static NBear.Data.Gateway acMIS = new NBear.Data.Gateway("MIS");

        #region Services
        public bool Pick(string voucherID, string goodsID)
        {
            Console.WriteLine("VouchersDAL - bool Pick: VoucherID:" + voucherID + ", GoodsID: " + goodsID + " - " + DateTime.Now.ToString());
            try
            {
                string msg = "";

                //Get UserID
                string UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
                string typeName = GetTableName(voucherID);

                return Pick(voucherID, goodsID, UserID, out msg);
            }
            catch (Exception e)
            {
                ExceptionDetail d = new ExceptionDetail(e);
                throw new FaultException<ExceptionDetail>(d, e.Message);
            }
        }

        public bool Pick(string voucherID, string BarCode, string pickID, out string msg)
        {
            Console.WriteLine("VouchersDAL - bool Pick: VoucherID:" + voucherID + ", BarCode: " + BarCode + " - " + DateTime.Now.ToString());
            DataTable tbVou = acMIS.SelectDataSet("SELECT * FROM Voucher WHERE VoucherID = @VoucherID", new object[] { voucherID }).Tables[0];
            if (tbVou.Rows.Count == 0)
                throw new Exception("FEPV Alert: VoucherID is not exits: " + voucherID);
            Console.WriteLine("1");
            DataTable tbMT = acMIS.SelectDataSet("SELECT * FROM MovingType WHERE MT = @MT", new object[] { (string)tbVou.Rows[0]["MT"] }).Tables[0];
            if (tbMT.Rows.Count == 0)
                throw new Exception("FEPV Alert: Invalid MoveType: " + (string)tbVou.Rows[0]["MT"]);
            Console.WriteLine("2");
            DataTable tbGds = acMIS.SelectDataSet("SELECT * FROM Goods WHERE BarCode = @BarCode", new object[] { BarCode }).Tables[0];
            if (tbGds.Rows.Count == 0)
                throw new Exception("Barcode is not exist: " + BarCode);
            Console.WriteLine("3");
            string vmsg = "Picking";
            if (tbGds.Rows[0]["LastVouID"].ToString() != "")
            {
                if (tbGds.Rows[0]["LastVouID"].ToString() == voucherID)
                    vmsg = string.Format("The voucherid: {0} is picking", voucherID);
                else
                    vmsg = string.Format(
                    @"Note: The package number has been picked by other Voucher,
                            The last Voucherid: {0}", tbGds.Rows[0]["LastVouID"].ToString());
            }
            Console.WriteLine("4");
            if (!AssertEqual(tbMT.Rows[0]["PreState"], tbGds.Rows[0]["State"], string.Format(
                @"Status is invalid 
                    P.{0}
                    N.New 
                    I.InStock 
                    S.Sell 
                    T.Transfer
                ", vmsg), out msg))
                return false;

            if (!AssertEqual((string)tbVou.Rows[0]["MaterialNO"], (string)tbGds.Rows[0]["MaterialNO"], "Material is not match", out msg))
                return false;
            if (!AssertEqual((string)tbVou.Rows[0]["CenterID"], (string)tbGds.Rows[0]["CenterID"], "CostCenter is not match", out msg))
                return false;

            if (!AssertEqual((string)tbVou.Rows[0]["Batch"], (string)tbGds.Rows[0]["Batch"], "Batch is not match", out msg))
                return false;

            object[] outParamResults;
            acMIS.ExecuteStoredProcedureNonQuery(string.Format("vou_{0}_{1}", GetTableName(voucherID), "Pick"),
                                                new string[] { "VoucherID", "BarCode", "UserID" },
                                                new object[] { voucherID, BarCode, pickID },
                                                new string[] { "Result" },
                                                new DbType[] { DbType.Int32 },
                                                out outParamResults);
            Console.WriteLine("5");
            return (1 == (int)outParamResults[0]);
        }

        public string Insert(Voucher voucherInfo)
        {
            Console.WriteLine("VouchersDAL - string Insert: VoucherInfo:" + voucherInfo .ToString() + " - " + DateTime.Now.ToString());

            Console.WriteLine("1");
            DataTable tb = acMIS.SelectDataSet("SELECT * FROM AccountRange WHERE Ayear = @year AND Amonth = @month",
                              new object[] { voucherInfo.AccDate.ToString("yyyy"), voucherInfo.AccDate.ToString("MM") }).Tables[0];
            if (tb.Rows.Count != 1)
                throw new Exception(voucherInfo.AccDate.ToString("yyyy-MM ") + "The AccountRange Date does not exist");

            DataRow ar = tb.Rows[0];
            if (!(bool)ar["Enabled"])
                throw new Exception(voucherInfo.AccDate.ToString("yyyy-MM ") + "The AccountRange has been closed");

            Console.WriteLine("2");

            Console.WriteLine("----insert ----" + voucherInfo.TableName);
            string strvoucherid="";
            voucherInfo.UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
            
            strvoucherid = CreateVoucherID(voucherInfo); 

            Console.WriteLine("----insert ----" + strvoucherid);

            try
            {
                acMIS.ExecuteNonQuery(@"INSERT INTO Voucher(VoucherID,MT,TransID,MaterialNo,CenterID,Plant,Loc,Batch,TotalNum,TotalCount,SAP,Sysnc,State,UserID,CheckID,Counter,Stamp,Checker,AccDate,TableName,Remark,_MaterialNo,_CenterID,_Plant,_Loc,_Batch)
                                   VALUES(@VoucherID,@MT,@TransID,@MaterialNo,@CenterID,@Plant,@Loc,@Batch,@TotalNum,@TotalCount,@SAP,@Sysnc,@State,@UserID,@CheckID,@Counter,@Stamp,@Checker,@AccDate,@TableName,@Remark,@_MaterialNo,@_CenterID,@_Plant,@_Loc,@_Batch)
                                  ", 
                                       new object[] 
                                   {
                                       voucherInfo.VoucherID =strvoucherid,//VoucherID,
                                       voucherInfo.MT,//MT,
                                       voucherInfo.TransID,
                                       voucherInfo.MaterialNO,
                                       voucherInfo.CenterID,//CenterID,
                                       voucherInfo.Plant,//Plant,
                                       voucherInfo.Loc,//Loc,
                                       voucherInfo.Batch,
                                       voucherInfo.TotalNum,// 0m,//TotalNum,
                                       voucherInfo.TotalCount,// 0,//.TotalCount,
                                       "",//SAP,
                                       null,//Sysnc,
                                       "N",//State,
                                       voucherInfo.UserID,
                                       "",//CheckID,
                                       0,//Counter,
                                       DateTime.Now,//Stamp,
                                       Guid.NewGuid(),//Checker,
                                       voucherInfo.AccDate,
                                       voucherInfo.TableName,
                                       "",//Remark
                                       voucherInfo._MaterialNO,
                                       voucherInfo._CenterID,
                                       voucherInfo._Plant,
                                       voucherInfo._Loc,
                                       voucherInfo._Batch
                                   }
                                       );
                acMIS.DbHelper.Insert(voucherInfo.TableName, voucherInfo.COLUMNS, voucherInfo.VALUES, "VoucherID");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return voucherInfo.VoucherID;
        }

        public bool CancelPick(string voucherID, string BarCode)
        {
            Console.WriteLine("VouchersDAL - bool CancelPick: VoucherID:" + voucherID +", Barcode: " +BarCode + " - " + DateTime.Now.ToString());

            DataTable tbVou = acMIS.SelectDataSet("SELECT * FROM Voucher WHERE VoucherID = @VoucherID", new object[] { voucherID }).Tables[0];
            if (tbVou.Rows.Count == 0)
                throw new Exception("FEPV Alert: VoucherID :" + voucherID+" is not exist!");


            DataTable tbMT = acMIS.SelectDataSet("SELECT * FROM MovingType WHERE MT = @MT", new object[] { (string)tbVou.Rows[0]["MT"] }).Tables[0];
            if (tbMT.Rows.Count == 0)
                throw new Exception("FEPV Alert: Invalid MoveType: " + (string)tbVou.Rows[0]["MT"]);


            DataTable tbGds = acMIS.SelectDataSet("SELECT * FROM Goods WHERE BarCode = @BarCode", new object[] { BarCode }).Tables[0];
            if (tbGds.Rows.Count == 0)
                throw new Exception("FEPV Alert: No exist this Barcode:" + BarCode);

            object[] outParamResults;
            acMIS.ExecuteStoredProcedureNonQuery(string.Format("vou_{0}_{1}", GetTableName(voucherID), "CancelPick"),
                                                new string[] { "VoucherID", "BarCode" },
                                                new object[] { voucherID, BarCode },
                                                new string[] { "Result" },
                                                new DbType[] { DbType.Int32 },
                                                out outParamResults);
            return (1 == (int)outParamResults[0]);
        }

        public bool Cancel(string voucherID)
        {
            Console.WriteLine("VouchersDAL - bool Cancel: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            object[] outParamResults;
            acMIS.ExecuteStoredProcedureNonQuery(string.Format("vou_{0}_{1}", GetTableName(voucherID), "Delete"),
                                                new string[] { "VoucherID" },
                                                new object[] { voucherID },
                                                new string[] { "Result" },
                                                new DbType[] { DbType.Int32 },
                                                out outParamResults);
            return (1 == (int)outParamResults[0]);
        }

        public bool Commit2Flow(string voucherID, out string msg)
        {
            Console.WriteLine("VouchersDAL - bool Commit2Flow: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            msg = "";
            object[] outParamResults;
            acMIS.ExecuteStoredProcedureNonQuery("vou_FEPV_SIH_Commit2Flow_CheckTotalCount",
                                                new string[] { "VoucherID" },
                                                new object[] { voucherID },
                                                new string[] { "Result" },
                                                new DbType[] { DbType.String },
                                                out outParamResults);
            if (!string.IsNullOrEmpty((string)outParamResults[0]))
            {
                msg = (string)outParamResults[0];
                //return false;
                throw new Exception("MES Error:" + msg);
            }

            acMIS.ExecuteNonQuery("UPDATE Voucher SET State = 'F' WHERE VoucherID = @VoucherID AND State IN ('P','N') ",
                                  new object[] { voucherID });
            return 1 == acMIS.SelectScalar<int>("SELECT Count(VoucherID) FROM Voucher WHERE VoucherID = @VoucherID AND State = 'F' ",
                                               new object[] { voucherID });

        }

        public static string GetTableName(string voucherID)
        {
            string mt = string.Empty;
            string voucherid = string.Empty;

            try
            {
                voucherid = voucherID.Split('|')[0];
                mt = voucherID.Split('|')[1];
            }
            catch { }

            //  Console.WriteLine(string.Format("VoucherID:{0},MT:{1}", voucherID, mt));            
            string result = acMIS.SelectScalar<string>(@"SELECT TOP 1 TableName 
                                                 FROM Voucher 
                                                WHERE VoucherID = @VoucherID",
                                 new object[] { voucherid });
            if (result == null)
                result = acMIS.SelectScalar<string>(@"SELECT TOP 1 TableName 
                                                   FROM Voucher
                                                 WHERE (
                                                         (Master =@VoucherID1 AND @MT1= '101' AND MT = '101' ) 
                                                    OR   
                                                         (Master =@VoucherID2 AND @MT2 <> '101' AND MT <> '101')
                                                      )",
                               new object[] { voucherid, mt, voucherid, mt });

            if (result == null)
                result = acMIS.SelectScalar<string>(@"SELECT TOP 1 TableName 
                                                    FROM Voucher
                                                    WHERE Master = @Master",
                               new object[] { voucherid });

            if (result == null)
                throw new Exception("VoucherID is not exist: " + voucherid);

            return result;
        }

        public byte[] TakeDetails(string voucherID)
        {
            Console.WriteLine("VouchersDAL - byte[] TakeDetails: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            try
            {
                //Get UserID
                string UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
                DataSet ds = acMIS.ExecuteStoredProcedure
                    ("vou_" + GetTableName(voucherID) + "_details",
                    new string[] { "voucherID", "costCenters", "userID" }, new object[] { voucherID, GetCostCenterId(UserID), UserID });
                return DataFormatter.GetBinaryFormatDataCompress(ds);
            }
            catch (Exception e)
            {

                ExceptionDetail d = new ExceptionDetail(e);
                throw new FaultException<ExceptionDetail>(d, e.Message);
            }
        }

        public byte[] TakeMaster(string voucherID)
        {
            Console.WriteLine("VouchersDAL - byte[] TakeMaster: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            try
            {
                //Get UserID
                string UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
                DataSet ds = acMIS.ExecuteStoredProcedure
                    ("vou_" + GetTableName(voucherID) + "_master",
                    new string[] { "voucherID", "costCenters", "userID" }, new object[] { voucherID, GetCostCenterId(UserID), UserID });

                return DataFormatter.GetBinaryFormatDataCompress(ds);
            }
            catch (Exception e)
            {
                ExceptionDetail d = new ExceptionDetail(e);
                throw new FaultException<ExceptionDetail>(d, e.Message);
            }
        }

        public bool Qpass(string voucherID)
        {
            Console.WriteLine("VouchersDAL - bool Qpass: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());

            try
            {
            //Get UserID
            string UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
            if (1 == acMIS.SelectScalar<int>("SELECT Count(VoucherID) FROM Voucher WHERE VoucherID = @VoucherID AND State = 'Q' ",
                                               new object[] { voucherID }))
                return true;

            acMIS.ExecuteNonQuery("UPDATE Voucher SET State = 'Q',CheckID = @CheckID WHERE VoucherID = @VoucherID AND State = 'F' ",
                                  new object[] { UserID, voucherID });
            return 1 == acMIS.SelectScalar<int>("SELECT Count(VoucherID) FROM Voucher WHERE VoucherID = @VoucherID AND State = 'Q' ",
                                               new object[] { voucherID });
            }
            catch (Exception e)
            {
                ExceptionDetail d = new ExceptionDetail(e);
                throw new FaultException<ExceptionDetail>(d, e.Message);
            }
        }

        public bool Sync2SAP(string voucherID, out string msg)
        {
            Console.WriteLine("VouchersDAL - bool Sync2SAP: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            string voucherid = voucherID.Split('|')[0];
            msg = voucherid + ": already submitted to SAP";
            if (GetSync2SapState(voucherID))
                return true;
            else
            {
                msg = "";
                Console.WriteLine("Start...Do2Sap");
                if (!FEPVInterface.Doc2Sap(voucherid, GetTableName(voucherID), out msg))
                    return false;
            }

            acMIS.ExecuteNonQuery("UPDATE Voucher SET SAP = '*' ,Sysnc = GetDate() WHERE VoucherID = @VoucherID AND STATE IN ('Q','S') AND SAP <> '*' ",
                                  new object[] { voucherid });

            return GetSync2SapState(voucherid);
        }

        public bool GetSync2SapState(string voucherID)
        {
            Console.WriteLine("VouchersDAL - bool GetSync2SapState: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            string mt = string.Empty;
            string voucherid = string.Empty;
            try
            {
                voucherid = voucherID.Split('|')[0];
                mt = voucherID.Split('|')[1];
            }
            catch { }

            if (!(1 == acMIS.SelectScalar<int>("SELECT Count(VoucherID) FROM Voucher WHERE VoucherID = @VoucherID AND STATE  IN ('S','Q') ",
                        new object[] { voucherID })))
                throw new Exception("Unapproved and can not be submitted to SAP : " + voucherID);

            if (!(0 == acMIS.SelectScalar<int>(@"SELECT Count(VoucherID)
                                              FROM Voucher
                                              WHERE Master = @VoucherID 
                                              AND STATE NOT IN ('S','Q')
                                              AND (
                                                         (Master =@VoucherID1 AND @MT1= '101' AND MT = '101' ) 
                                                    OR   
                                                         (Master =@VoucherID2 AND @MT2 <> '101' AND MT <> '101')
                                                      )
                                            ",    
                       new object[] { voucherid, voucherid, mt, voucherid, mt, voucherid, mt })))
                throw new Exception("There are items that are not audited and can not be submitted to SAP : " + voucherID);

            int kk = acMIS.SelectScalar<int>(@"SELECT Count(VoucherID) FROM Voucher WHERE VoucherID = @VoucherID AND SAP = '*'
                                                 OR (
                                                         (Master =@VoucherID1 AND @MT1= '101' AND MT = '101' ) 
                                                    OR   
                                                         (Master =@VoucherID2 AND @MT2 <> '101' AND MT <> '101')
                                                      )",
                                    new object[] { voucherid, voucherid, mt, voucherid, mt });

            Console.WriteLine("Query out the results" + kk.ToString());
            return 0 < kk;
        }

        public bool Submit2Stock(string voucherID)
        {
            Console.WriteLine("VouchersDAL - bool Submit2Stock: VoucherID:" + voucherID + " - " + DateTime.Now.ToString());
            object[] outParamResults;
            Console.WriteLine("Submit2Stock-----------------:" + voucherID);
            acMIS.ExecuteStoredProcedureNonQuery(string.Format("vou_{0}_{1}", GetTableName(voucherID), "Submit2Stock"),
                                                new string[] { "VoucherID" },
                                                new object[] { voucherID },
                                                new string[] { "Result" },
                                                new DbType[] { DbType.Int32 },
                                                out outParamResults);
            return (1 == (int)outParamResults[0]);
        }

        public bool Withdrawal(string voucherId, string remark, out string msg)
        {
            Console.WriteLine("VouchersDAL - bool Withdrawal: VoucherID:" + voucherId +", Remark: "+remark+ " - " + DateTime.Now.ToString());
            msg = "";
            //Get UserID
            string UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
            object[] outParamResults;
            acMIS.ExecuteStoredProcedureNonQuery(string.Format("vou_{0}_{1}", "FEPV_XXX", "Withdrawal"),
                                                new string[] { "VoucherID", "UserID", "Remark" },
                                                new object[] { voucherId, UserID, remark },
                                                new string[] { "Result" },
                                                new DbType[] { DbType.String },
                                                out outParamResults);
            msg = (string)outParamResults[0];
            return ("" == msg);
        }

        public DataTable BarCodeList(string StoreName_Goods, string[] paramenters, object[] values)
        {
            Console.WriteLine("VouchersDAL - bool BarCodeList: Stored:" + StoreName_Goods + " - " + DateTime.Now.ToString());
            DataTable dt = new DataTable();
            try
            {
                List<string> ps = paramenters.ToList();
                ps.Add("UserID");
                paramenters = ps.ToArray();
                List<object> vs = values.ToList();
                vs.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
                values = vs.ToArray();

                DataSet ds = acMIS.DbHelper.ExecuteStoredProcedure(StoreName_Goods, paramenters, values);
                return CloneTable(DataFormatter.RetrieveDataSetDecompress(DataFormatter.GetBinaryFormatDataCompress(ds)).Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        #endregion

        #region Functions
        protected string CreateVoucherID(Voucher voucherInfo)
        {
            Console.WriteLine("VouchersDAL - string CreateVoucherID_POLY: VoucherInfo:" + voucherInfo.ToString() + " - " + DateTime.Now.ToString());
            
            string pre = string.Empty;

            switch (voucherInfo.TableName)
            {
                case "FEPV_POLY_SIH":
                    POLY_SIH poly_sih = (POLY_SIH)voucherInfo;
                    pre = string.Format("L{0}{1}{2}",
                                                 poly_sih.MT.Trim().TrimEnd('-').ToUpper(),
                                                 poly_sih.Line.Trim().ToUpper(),
                                                 poly_sih.AccDate.ToString("ddMMyy"));
                    break;
                case "FEPV_POLY_RPH":
                    POLY_RPH poly_rph = (POLY_RPH)voucherInfo;
                    pre = string.Format("L{0}{1}{2}",
                                                 poly_rph.MT.Trim().TrimEnd('-').ToUpper(),
                                                 poly_rph.Line.Trim().ToUpper(),
                                                 poly_rph.AccDate.ToString("ddMMyy"));
                    break;
                case "FEPV_SSP_SIH":
                    SSP_SIH ssp_sih = (SSP_SIH)voucherInfo;
                    pre = string.Format("C{0}{1}{2}",
                                                 ssp_sih.MT.Trim().TrimEnd('-').ToUpper(),
                                                 ssp_sih.Line.Trim().ToUpper(),
                                                 ssp_sih.AccDate.ToString("ddMMyy"));
                    break;
                case "FEPV_SSP_RPH":
                    SSP_RPH ssp_rph = (SSP_RPH)voucherInfo;
                    pre = string.Format("C{0}{1}{2}",
                                                 ssp_rph.MT.Trim().TrimEnd('-').ToUpper(),
                                                 ssp_rph.Line.Trim().ToUpper(),
                                                 ssp_rph.AccDate.ToString("ddMMyy"));
                    break;
                default:
                    throw new Exception("Can not find the table name :" + voucherInfo.ToString());
            }
            
            int flow = acMIS.SelectScalar<Int32>(string.Format(@"
                                     SELECT Count(VoucherID)+1 
                                      FROM {0}
                                     WHERE VoucherID LIKE @Pre", voucherInfo.TableName),
                                              new object[] { pre + "%" });
            return pre + flow.ToString().PadLeft(2, '0');
        }

        protected static DataTable CloneTable(DataTable dt)
        {
            DataTable dtClone = dt.Clone();
            for (int i = 0; i < dtClone.Columns.Count; i++)
            {
                if (dtClone.Columns[i].DataType != typeof(string))
                    dtClone.Columns[i].DataType = typeof(string);
            }

            foreach (DataRow dr in dt.Rows)
            {
                dtClone.ImportRow(dr);
            }
            return dtClone;
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

        protected bool AssertEqual(object src, object des, string property, out string msg)
        {
            if (src.ToString().Trim() != des.ToString().Trim())
            {
                msg = string.Format("{0}: {1} != {2}", property, src.ToString(), des.ToString());
                Console.WriteLine(msg);
                return false;
            }

            msg = "";
            return true;
        }
        #endregion
    }
}
