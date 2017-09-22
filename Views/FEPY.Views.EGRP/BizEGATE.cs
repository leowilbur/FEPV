using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;
using FEPV.BLL;
using FEPV.Model;

namespace FEPV.Views
{
    public partial class EGRP
    {
        ReportBiz rep = new ReportBiz();

        /// <summary>
        /// 车辆计划查询
        /// </summary>
        private void TruckQueryPlan()
        {
            _TruckInfo.Plan4TruckTable = rep.GetMISReport("Q_Logs_TruckPlan", _TruckInfo.Parameters, _TruckInfo.Values).Tables[0];
            MainMsg = "";
        }

        /// <summary>
        /// 访客计划查询
        /// </summary>
        private void GuestQueryPlan()
        {
            _GuestInfo.Plan4GuestTable = rep.GetMISReport("Q_Logs_GuestPlan", _GuestInfo.Parameters, _GuestInfo.Values).Tables[0];
            MainMsg = "";
        }

        /// <summary>
        /// 物品计划查询
        /// </summary>
        private void GoodsQueryPlan()
        {
            _GoodsInfo.Plan4GoodsTable = rep.GetMISReport("Q_Logs_GoodsPlan", _GoodsInfo.Parameters, _GoodsInfo.Values).Tables[0];
            MainMsg = "";
        }
        
        /// <summary>
        /// 未回厂物品查询
        /// </summary>
        private void GoodsNoBackQueryPlan()
        {
            _GoodsNobackInfo.Plan4GoodsTable = rep.GetMISReport("Q_Logs_GoodsPlan", _GoodsInfo.Parameters, _GoodsInfo.Values).Tables[0];
            MainMsg = "";
        }

        //
        private void GuestForRepPrint()
        {
            DataTable dtGuest4Rep = rep.GetMISReport("Q_Logs_GuestPlan4Rep", _GuestInfo.Parameters, _GuestInfo.Values).Tables[0];
            RepForGuest _repForGuest = new RepForGuest();
            _repForGuest.InitializeValues(dtGuest4Rep);
            _repForGuest.Values = new string[] { Convert.ToDateTime(_GuestInfo.Values[0]).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(_GuestInfo.Values[1]).ToString("yyyy-MM-dd") };
            _repForGuest.ShowPreview();
            MainMsg = "";
        }

        private void GuestGetDetails()
        {
            _GuestInfo.GuestGetDetails();
        }

        private void TruckExcel()
        {
            _TruckInfo.TruckExcel();
        }

        private void GuestExcel()
        {
            _GuestInfo.GuestExcel();
        }

        private void GoodsExcel()
        {
            _GoodsInfo.GoodsExcel();
        }

        private void GoodsNobackExcel()
        {
            _GoodsNobackInfo.GoodsExcel();
        }

        WorkflowBiz wf = new WorkflowBiz();
        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="VoucherID"></param>
        /// <returns></returns>
        public void GetTasksWF(string businessKey)
        {
            string requrl = string.Format("?processInstanceBusinessKey={0}", businessKey);
            BPMTask[] tasks = wf.GetGateTaskUrl(requrl);
            if (tasks.Count() > 0)
            {
                MainMsg = "Task ID：" + tasks[0].id;

                StringBuilder str = new StringBuilder();
                int i = 0;
                foreach (BPMTask task in tasks)
                {
                    i = i + 1;
                    str.Append(i.ToString() + "：");
                    str.Append("Current node【" + task.name + "】|");
                    str.Append("UserID【" + task.assignee + "】|");
                    str.Append("Details【" + task.description + "】");
                    str.Append("\n");
                }
                MessageBox.Show(str.ToString(), "Current node");
            }
            else
            {
                MessageBox.Show("No task information!", "Current node");
            }
        }
    }
}
