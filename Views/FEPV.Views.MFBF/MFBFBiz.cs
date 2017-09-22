using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FEPV.BLL;

namespace FEPV.Views
{
    public class MFBFBiz
    {
        public MFBFBiz()
        {
            AddColumns();
        }

        void AddColumns()
        {
            gradetable = new DataTable();
            gradetable.Columns.Add("Grade", typeof(string));

            linetable = new DataTable();
            linetable.Columns.Add("Line", typeof(string));

            planttable = new DataTable();
            planttable.Columns.Add("Plant", typeof(string));
            planttable.Columns.Add("InPlant", typeof(string));
            planttable.Columns.Add("OutPlant", typeof(string));
            planttable.Columns.Add("Tranfered", typeof(string));

            centeridtable.Columns.Add("CenterID", typeof(string));
        }

        string _StoreName_Batch = "";

        public string StoreName_Batch
        {
            get { return _StoreName_Batch; }
            set { _StoreName_Batch = value; }
        }

        string _StoreName_Goods = "";

        public string StoreName_Goods
        {
            get { return _StoreName_Goods; }
            set { _StoreName_Goods = value; }
        }

        public string ProdType { get; set; }

        public string MT { get; set; }

        public string TransID { get; set; }

        public bool IsConvertMatreial { get; set; }

        DataTable centeridtable = new DataTable();

        public List<string> dt_CenterID
        {
            set
            {
                Conversion(value, centeridtable);
            }
        }

        public List<string> dt_Loc
        {
            set
            {
                Conversion(value, planttable, "Tranfered");
            }
        }

        public List<string> dtLoc
        {
            set
            {
                Conversion(value, planttable, "OutPlant");
            }
        }

        public List<string> dt_Plant
        {
            set
            {
                Conversion(value, planttable, "InPlant");
            }
        }

        DataTable planttable;

        public List<string> dtPlant
        {
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    DataRow row = planttable.NewRow();
                    planttable.Rows.Add(row);
                }

                Conversion(value, planttable, "Plant");
            }
        }

        DataTable gradetable;

        public List<string> dtGrade
        {
            set
            {
                Conversion(value, gradetable);
            }
        }

        DataTable linetable;

        public List<string> dtLine
        {
            set
            {
                Conversion(value, linetable);
            }
        }

        void Conversion(List<string> list, DataTable table)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DataRow row = table.NewRow();
                row[table.Columns[0].ColumnName] = list[i];
                table.Rows.Add(row);
            }
        }

        void Conversion(List<string> list, DataTable table, string ColumnName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                table.Rows[i][ColumnName] = list[i];
            }
        }

        #region 5 Step Views
        IMFBFView _IMFBFView;

        IUnsettledJobsView _IUnsettledJobsView;

        IQueryBatchView _IQueryBatchView;

        IQueryGoodsView _IQueryGoodsView;

        IQueryVoucherView _IQueryVoucherView;

        public IQueryVoucherView QueryVoucherView
        {
            get { return _IQueryVoucherView; }
            set
            {
                _IQueryVoucherView = value;
            }
        }

        public IQueryGoodsView QueryGoodsView
        {
            get { return _IQueryGoodsView; }
            set
            {
                _IQueryGoodsView = value;
                _IQueryGoodsView.ShowSelectGoodsInformation += new EventHandler(_IQueryGoodsView_ShowSelectGoodsInformation);
            }
        }

        void _IQueryGoodsView_ShowSelectGoodsInformation(object sender, EventArgs e)
        {
            ShowSelectGoodsInformationArgs sArgs = (ShowSelectGoodsInformationArgs)e;
            _IQueryGoodsView.ParamentersView.TotalCount = sArgs.TotalCount;
            _IQueryGoodsView.ParamentersView.TotalWeight = sArgs.TotalWeight;
        }

        public IQueryBatchView QueryBatchView
        {
            get { return _IQueryBatchView; }
            set
            {
                _IQueryBatchView = value;
                _IQueryBatchView.eventBatchSelected += new EventHandler(_IQueryBatchView_eventBatchSelected);
            }
        }

        void _IQueryBatchView_eventBatchSelected(object sender, EventArgs e)
        {
            Batch4VoucherArgs ags = (Batch4VoucherArgs)e;

            ags.Paramenters.Add("MT", this.MT);
            ags.Paramenters.Add("TransID", this.TransID);
            ags.Paramenters.Add("ProdType", this.ProdType);

            _IQueryGoodsView.ParamentersView.VoucherParamenters = ags.Paramenters;

            this.GetPlant4Material();
            this.SearchGoods();

            QueryGoodsView.ParamentersView.dtCenterID = centeridtable;
        }

        public IMFBFView MFBFView
        {
            get { return _IMFBFView; }
            set { _IMFBFView = value; }
        }

        public IUnsettledJobsView UnsettledJobsView
        {
            get { return _IUnsettledJobsView; }
            set
            {
                _IUnsettledJobsView = value;
                _IUnsettledJobsView.eventVoucherSelected += new EventHandler(_IUnsettledJobsView_eventVoucherSelected);
            }
        }

        void _IUnsettledJobsView_eventVoucherSelected(object sender, EventArgs e)
        {
            Voucher4SearchArgs ags = (Voucher4SearchArgs)e;
            ViewVoucher(ags.VoucherID);
        }

        #endregion

        UIReporting query = new UIReporting();

        VoucherBiz voucher = new VoucherBiz();

        public bool Ready2Work()
        {
            GotoStep(Step.UnsettledVouchers);
            return true;
        }

        private bool GotoStep(Step step)
        {
            MFBFView.MSG = "@_@";
            _IMFBFView.STEP = step;
            frmUpdate();
            return true;
        }

        void frmUpdate()
        {
            switch (_IMFBFView.STEP)
            {
                case Step.UnsettledVouchers:
                    QueryUnsettledVouchers();
                    break;
                case Step.QueryBatchs:
                    QueryBatch();
                    break;

            }
        }

        public void Back()
        {
            if (_IMFBFView.STEP == Step.AddGoods2Voucher)
            {
                _IQueryVoucherView.Master = voucher.TakeMaster(_IQueryVoucherView.SelectVoucherID);
                _IQueryVoucherView.Detail = voucher.TakeDetails(_IQueryVoucherView.SelectVoucherID);
            }
            _IMFBFView.MSG = "@_@";
            _IMFBFView.STEP -= 1;
            frmUpdate();

        }

        public void GetUnSettledVouchers()
        {
            GotoStep(Step.UnsettledVouchers);
            QueryUnsettledVouchers();
        }

        void QueryUnsettledVouchers()
        {
            string[] p = _IUnsettledJobsView.ParamentersView.Paramenters;
            object[] v = _IUnsettledJobsView.ParamentersView.Values;
            AddInParamenter("MT", this.MT, ref p, ref v);
            AddInParamenter("ProdType", this.ProdType, ref p, ref v);

            _IUnsettledJobsView.tbJobs = query.GetMISReport("Q_unFinishedVoucher", p, v).Tables[0];
        }

        public void ViewVoucher(string voucherID)
        {
            GotoStep(Step.QueryVoucher);

            _IQueryVoucherView.Master = voucher.TakeMaster(voucherID);
            _IQueryVoucherView.Detail = voucher.TakeDetails(voucherID);

        }

        public void SearchBatch()
        {
            if (_IMFBFView.STEP != Step.QueryBatchs)
            {
                _IQueryBatchView.ParamentersView.dtGrade = gradetable;
                _IQueryBatchView.ParamentersView.dtPlant = planttable;
                GotoStep(Step.QueryBatchs);
                return;
            }
            else
            {
                QueryBatch();
            }
        }

        void QueryBatch()
        {
            string[] p = _IQueryBatchView.ParamentersView.Paramenters;
            object[] v = _IQueryBatchView.ParamentersView.Values;
            AddInParamenter("MT", this.MT, ref p, ref v);
            AddInParamenter("ProdType", this.ProdType, ref p, ref v);
            AddInParamenter("TransID", this.TransID, ref p, ref v);

            if (ProdType == "L" || ProdType == "C")
            {
                _IQueryBatchView.tbBatches = voucher.BarCodeList(this.StoreName_Batch, p, v);
            }

            QueryGoodsView.ParamentersView._Plant = planttable;
            QueryGoodsView.ParamentersView.IsConvertMaterialno = IsConvertMatreial;
        }

        public void SearchGoods()
        {
            GotoStep(Step.QueryGoods);
            _IMFBFView.MSG = "SearchGoods";
            _IQueryGoodsView.ParamentersView.TransID = this.TransID;
            string[] p = _IQueryBatchView.ParamentersView.Paramenters;

            List<object> list = _IQueryGoodsView.ParamentersView.SelectParameters.ToList();
            list.Insert(_IQueryGoodsView.ParamentersView.SelectParameters.Count() - 4, _IQueryBatchView.ParamentersView.Values[_IQueryBatchView.ParamentersView.Values.Count() - 1]);
            object[] v = list.ToArray();
            object[] newobject = new object[] { };
            AddInParamenter("CenterID", "", ref p, ref newobject);
            AddInParamenter("Version0", "", ref p, ref newobject);
            AddInParamenter("Version", "", ref p, ref newobject);
            AddInParamenter("PACKING_TYPE", "", ref p, ref newobject);
            AddInParamenter("MT", this.MT, ref p, ref v);

            _IQueryGoodsView.tbGoods = query.GetMISReport(this.StoreName_Goods, p, v).Tables[0];
        }

        public void GetPlant4Material()
        {
            if (ProdType == "C")
            {
                string[] parameter = new string[] { "MaterialNO", "BOM", "Batch" };
                object[] value = new object[] { _IQueryGoodsView.ParamentersView.MaterialNO, _IQueryGoodsView.ParamentersView.BOM, _IQueryGoodsView.ParamentersView.Batch131 };
                _IQueryGoodsView.ParamentersView.Plants = query.GetMISReport("Q_WerksFORMaterialSSP", parameter, value).Tables[0];
            }
            if (ProdType == "L")
            {
                string[] parameter = new string[] { "MaterialNO" };
                object[] value = new object[] { _IQueryGoodsView.ParamentersView.MaterialNO };
                _IQueryGoodsView.ParamentersView.Plants = query.GetMISReport("Q_WerkSFORMaterial", parameter, value).Tables[0];
            }
        }

        public void DoRequest()
        {
            if (MT == "999")
            {
                _IMFBFView.MSG = "No package number to create the certificate......";
            }

            if (_IQueryGoodsView.ParamentersView.IsReady)
            {
                _IMFBFView.DialogTitle = "Create New Voucher";
                _IMFBFView.DialogMsg = string.Format("Total Package:{0}, Total Net Weight:{1}{2}Version: {3} Pre-Version:{4}{5}Continue to create this voucher?",
                         _IQueryGoodsView.BarCode2Pick.Count(), 
                         _IQueryGoodsView.TotalNum,
                         Environment.NewLine,
                         _IQueryGoodsView.ParamentersView.Version[0], 
                         _IQueryGoodsView.ParamentersView.Version[1],
                         Environment.NewLine);
                if (_IMFBFView.IsNotarize)
                {
                    string[] barcodes = _IQueryGoodsView.BarCode2Pick;
                    FEPV.Model.Voucher vou = _IQueryGoodsView.ParamentersView.Voucher2Request;
                    vou.MT = this.MT;
                    vou.TransID = this.TransID;
                    vou.TotalNum = _IQueryGoodsView.TotalNum;
                    vou.TotalCount = barcodes.Count();

                    string voucherId = voucher.Insert(vou);
                    _IMFBFView.MSG = "Create the voucher completion and start generating the picking packet number: " + voucherId;
                    if (!string.IsNullOrEmpty(voucherId))
                    {
                        if (barcodes.Count() != 0)
                        {
                            string[] successGoodsIDs = voucher.Pick(voucherId, barcodes);
                            if (successGoodsIDs.Count() > 0)
                            {
                                for (int i = 0; i < successGoodsIDs.Count(); i++)
                                {
                                    _IMFBFView.MSG = string.Format("VoucherID :{0} Add goods:{1} successful", voucherId, successGoodsIDs[i]);
                                }
                            }
                        }
                        ViewVoucher(voucherId);
                    }
                }
            }
            else
            {
                _IMFBFView.MSG = _IQueryGoodsView.ParamentersView.Msg;
            }

        }

        public bool RemoveGoods4Voucher()
        {
            string[] goodIDs = _IQueryVoucherView.SelectGoods;
            string voucherID = _IQueryVoucherView.SelectVoucherID;

            bool rValue = false;
            if (goodIDs != null && goodIDs.Count() > 0 && !string.IsNullOrEmpty(voucherID))
            {
                _IMFBFView.DialogTitle = "Confirm Unpick Goods";
                _IMFBFView.DialogMsg = string.Format("Whether to modify the voucher:{0} ?{1}Number of Barcode UnPick:{2}{3}The total GWT UnPick:{4}"
                                       ,voucherID,Environment.NewLine,goodIDs.Count().ToString(), Environment.NewLine,_IQueryVoucherView.SelectTotalNum.ToString());

                if (_IMFBFView.IsNotarize)
                {
                    string[] successGoodsIDs = voucher.CancelPick(voucherID, goodIDs);
                    if (successGoodsIDs.Count() > 0)
                    {
                        for (int i = 0; i < successGoodsIDs.Count(); i++)
                        {
                            _IMFBFView.MSG = string.Format("In voucher:{0} Remove goods:{1} success", voucherID, successGoodsIDs[i]);
                        }
                        _IQueryVoucherView.Detail = voucher.TakeDetails(voucherID);
                        _IQueryVoucherView.Master = voucher.TakeMaster(voucherID);
                    }
                }
            }
            else
            {
                _IMFBFView.MSG = "No goods is choose/Goods not exist";
            }
            return rValue;
        }

        public bool CancelVoucher()
        {
            bool rValue = false;
            string voucherID = _IQueryVoucherView.SelectVoucherID;
            _IMFBFView.DialogMsg = string.Format("Confirm delete voucher:{0}?", voucherID);
            _IMFBFView.DialogTitle = "Confirm Delete!";
            if (_IMFBFView.IsNotarize)
            {
                if (voucherID != null)
                {
                    rValue = voucher.Cancel(voucherID);
                    if (rValue)
                    {
                        GotoStep(Step.QueryBatchs);
                    }
                }
            }
            return rValue;
        }

        public bool Commit2Flow()
        {
            bool rValue = false;
            string voucherID = _IQueryVoucherView.SelectVoucherID;
            _IMFBFView.DialogMsg = string.Format("Do you want to submit voucher:{0}?", voucherID);
            _IMFBFView.DialogTitle = "Confirm submit";
            if (_IMFBFView.IsNotarize)
            {
                if (voucherID != null)
                {
                    if (MT == "942" || MT == "952")
                    {
                        if (IsAffirm)
                        {
                            query.GetMISReport("Q_MFBF_SaveRphRemarks", new string[] { "voucherID", "Remark", "ProdType" },
                                                                        new object[] { voucherID, Remarks, ProdType });
                        }
                        else
                        {
                            _IMFBFView.MSG = "Please enter the reason to recall！";
                            return rValue;
                        }
                    }

                    string msg = string.Empty;
                    rValue = voucher.Commit2Flow(voucherID, out msg);
                    if (rValue)
                    {
                        GotoStep(Step.QueryBatchs);
                    }
                }
            }
            return rValue;

        }

        #region Reason
        MISRemark remark = new MISRemark();
        public bool IsAffirm
        {
            get
            {
                remark.ShowDialog();
                return remark.RValue;
            }
        }

        public string Remarks
        {
            get { return remark.Msg; }
        }
        #endregion

        public void PrintVoucher()
        {
            switch (MT)
            {
                case "311":
                    ShowRTSReport();
                    break;
                case "311-":
                    ShowRTSReport();
                    break;
                default:
                    ReportMaster rep = new ReportMaster();
                    rep.dataSource = GetRepSource();
                    rep.ShowPreview();
                    break;
            }
        }

        void ShowRTSReport()
        {
            ReportRTS reprts = new ReportRTS();
            reprts.dataSource = GetRTSReportSource();
            reprts.ShowPreview();
        }

        List<RTSElements> GetRTSReportSource()
        {
            List<RTSElements> listVoucher = new List<RTSElements>();
            int i = 1;
            foreach (DataRow row in voucher.TakeMaster(QueryVoucherView.SelectVoucherID).Rows)
            {

                listVoucher.Add(new RTSElements
                {
                    _ID=i,
                    _VouNo = (string)row["VoucherID"],
                    _MaterialNo = (string)row["MaterialNO"],
                    _Unit = "KG",
                    _Batch = (string)row["Batch"],
                    _Spec = (string)row["ProdSpec"],
                    _TotalPackage = row["TotalCount"].ToString(),
                    _TotalNum = row["TotalNum"].ToString(),
                    _CenterID = (string)row["CenterID"],
                    _TakeUnit = (string)row["领用单位"],
                    _PickDate = Convert.ToDateTime(row["AccDate"]).ToString("yyyy-MM-dd")
                });
                i++;
            }
            return listVoucher;
        }

        List<MasterElements> GetRepSource()
        {
            List<MasterElements> listVoucher = new List<MasterElements>();
            int i = 1;
            foreach (DataRow row in voucher.TakeMaster(QueryVoucherView.SelectVoucherID).Rows)
            {
                listVoucher.Add(new MasterElements
                {
                    M_ID=i++.ToString("000"),
                    M_VouNo = (string)row["VoucherID"],
                    M_AccDate = ((DateTime)row["AccDate"]).ToString("yyyy-MM-dd"),
                    M_MaterialNO = (string)row["MaterialNO"],
                    M_ProdSpec = (string)row["ProdSpec"],
                    M_Batch = (string)row["Batch"],
                    M_CenterID = (string)row["CenterID"],
                    M_Version0 = (string)row["Version0"],
                    M_Version = (string)row["Version"],
                    M_TotalCount = (int)row["TotalCount"],
                    M_TotalNum = (decimal)row["TotalNum"],
                    Goodses = DetailsInfo()
                });
            }
            return listVoucher;
        }

        List<DetailElements> DetailsInfo()
        {
            List<DetailElements> listVoucherDetails = new List<DetailElements>();
            foreach (DataRow row in voucher.TakeDetails(QueryVoucherView.SelectVoucherID).Rows)
            {
                listVoucherDetails.Add(new DetailElements
                {
                    _BarCode = (string)row["BarCode"],
                    _Num = (decimal)row["Num"],
                    _GWT = (decimal)row["GWT"]
                });
            }
            return listVoucherDetails;
        }

        public void Complete()
        {
            GotoStep(Step.QueryBatchs);
            SearchBatch();
        }

        public static void AddInParamenter(string paramenter, object value, ref string[] paramenters, ref object[] values)
        {
            List<string> ps = paramenters.ToList();
            ps.Add(paramenter);
            paramenters = ps.ToArray();

            List<object> vs = values.ToList();
            vs.Add(value);
            values = vs.ToArray();
        }
    }

    public enum Step
    {
        UnsettledVouchers, QueryBatchs, QueryGoods, QueryVoucher, AddGoods2Voucher
    }
}
