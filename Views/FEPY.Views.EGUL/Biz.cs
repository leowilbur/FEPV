using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class EGUL : Infrastructure.BaseForm
    {
        ReportBiz rep = new ReportBiz();
        DataTable dtTruck = new DataTable();
        DataTable dtGuest = new DataTable();
        DataTable dtContractor = new DataTable();

        private void TruckUnlock()
        {
            _TruckInfo.TruckUnlock();
        }

        private void TruckExcel()
        {
            _TruckInfo.TruckExcel();
        }

        private void TruckQueryPlan()
        {
            dtTruck = rep.GetMISReport("Q_BlackLists_Truck", _TruckInfo.Parameters, _TruckInfo.Values).Tables[0];
            _TruckInfo.Plan4TruckTable = dtTruck;
            MainMsg = "";
        }

        private void GuestQueryPlan()
        {
            dtGuest = rep.GetMISReport("Q_BlackLists_Guest", _GuestInfo.Parameters, _GuestInfo.Values).Tables[0];
            _GuestInfo.Plan4GuestTable = dtGuest;
            MainMsg = "";
        }

        private void GuestExcel()
        {
            _GuestInfo.GuestExcel();
        }

        private void GuestUnlock()
        {
            _GuestInfo.GuestUnlock();
        }

        private void ContractorQueryPlan()
        {
            dtContractor = rep.GetMISReport("Q_BlackLists_Contractor", _ContractorInfo.Parameters, _ContractorInfo.Values).Tables[0];
            _ContractorInfo.Plan4ContractorTable = dtContractor;
            MainMsg = "";
        }

        private void ContractorExcel()
        {
            _ContractorInfo.ContractorExcel();
        }

        private void ContractorUnlock()
        {
            _ContractorInfo.ContractorUnlock();
        }
    }
}
