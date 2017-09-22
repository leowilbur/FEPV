using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.IO.Ports;
using Microsoft.Practices.CompositeUI.SmartParts;
using Infrastructure;
using System.Diagnostics;
using FEPV.BLL;
using System.Xml.Linq;
using FEPV.Model;
using System.IO;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class JobGuestView : UserControl
    {
        public JobGuestView()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "EGT2", this.Name);
            tbFilePath.Click += new EventHandler(tbFilePath_Click);
            cbAbsent.CheckedChanged += cbAbsent_CheckedChanged; //Leo add 2017-05-08 checkbox Absent
        }

        void cbAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAbsent.Checked)
            {
                CardNO = "A-" + label9.Text;
            }
            else if (CardNO == ("A-" + label9.Text)) //Re-Check
                CardNO = "";
        }

        /// <summary>
        /// Look at photos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbFilePath_Click(object sender, EventArgs e)
        {
            Image imagetmp = pictureBox1.Image;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg;*.jpeg;*.bmp;*png|*.jpg;*.jpeg;*.bmp;*png)|gif(*.gif)|*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                ImageCon = image;
                if (ImageCon.Width > 1024 || ImageCon.Height > 768)
                {
                    tbFilePath.Text = "";
                    ImageCon = imagetmp;
                    MessageBox.Show("Pictures larger than1024*768, please cut out！");
                }
                else
                {
                    tbFilePath.Text = openFileDialog.FileName;
                    //
                    ImgUpdate();
                }
            }
        }

        public Image ImageCon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public event EventHandler eventShowCamera;
        /// <summary>
        /// Camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCamera_Click(object sender, EventArgs e)
        {
            if (eventShowCamera != null)
            {
                eventShowCamera(this, null);
            }
        }

        public Dictionary<string, object> Parameters
        {
            set
            {
                Image image = Image.FromFile((string)value["filename"]);
                ImageCon = image;
                tbFilePath.Text = (string)value["filename"];
            }
        }

        public string _NameVerification { get; set; }
        public string _IDCardVerification { get; set; }
        public Dictionary<string, object> Paras
        {
            set
            {
                tbName.Text = value["GuestName"].ToString();
                _NameVerification = tbName.Text;
                tbEnterprise.Text = value["Enterprise"].ToString();
                tbCalleeNo.Text = value["Respondent"].ToString();
                tbMac.Text = value["CardNO"].ToString();
                tbIDCard.Text = value["IdCard"].ToString();
                _IDCardVerification = tbIDCard.Text;
                Flag = value["Types"].ToString();
                KeyValue = value["VoucherID"].ToString();
                _ID.Text = value["ID"].ToString();
                _Reason.Text = value["Content"].ToString();
                _Region.Text = value["Region"].ToString();
                _ExtNO.Text = value["ExtNO"].ToString();
                tbRemark.Text = value["Remark"].ToString();
                cbAbsent.Checked = value["CardNO"].ToString().Length>0?
                    (value["CardNO"].ToString().Substring(0, 1) == "A" ? true : false):false;//Convert.ToBoolean(value["IsAbsent"].ToString());
                tbFilePath.Text = "";
                lblWorkFlow.Text = "";

                DataTable tbCallee = rep.GetMISReport("FK_AC_GuestItem_Callee", new string[] { "CalleeNo" }, new object[] { tbCalleeNo.Text }).Tables[0];
                if (tbCallee.Rows.Count == 1)
                {
                    DataRow rowCallee = tbCallee.Rows[0];
                    tbCalleeName.Text = rowCallee["Name"].ToString();
                    tbCalleeDepart.Text = rowCallee["Specification"].ToString();

                    //
                    if (Convert.ToString(rowCallee["Photo"]) != "")
                    {
                        MemoryStream ms = new MemoryStream((byte[])rowCallee["Photo"]);
                        Image image = Image.FromStream(ms, true);
                        pictureBox2.Image = image;
                    }
                    else
                    {
                        pictureBox2.Image = pictureBox2.InitialImage;
                    }
                }
                else
                {
                    tbCalleeName.Text = "-";
                    tbCalleeDepart.Text = "-";
                    pictureBox2.Image = pictureBox2.InitialImage;
                }

                #region
                DataTable tbImage = new DataTable();
                if (_ID.Text != "-")
                {
                    RemarkVisible = true;
                    tbImage = rep.GetMISReport("FK_AC_GuestItem_Image", new string[] { "ID" }, new object[] { new Guid(_ID.Text) }).Tables[0];
                }
                else if (Flag == "HS")
                {
                    RemarkVisible = false;
                    tbImage = rep.GetMISReport("HS_Q_Contractor_Image", new string[] { "IdCard", "Employer" }, new object[] { tbIDCard.Text.Trim(), tbEnterprise.Text }).Tables[0];
                }
                //
                DataRow row = tbImage.Rows[0];

                if (Convert.ToString(row["Image"]) != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                    Image image = Image.FromStream(ms, true);
                    pictureBox1.Image = image;
                }
                else
                {
                    pictureBox1.Image = pictureBox1.InitialImage;
                }
                #endregion

                #region Grasping the process log
                if (_ID.Text != "-")
                {
                    DataRow rowWorkFlow = rep.GetMISReport("FK_AC_Q_GuestWorkFlow", new string[] { "VoucherID" }, new object[] { (string)value["VoucherID"] }).Tables[0].Rows[0];
                    string _InTime = rowWorkFlow["InTime"].ToString();
                    string _Complete = rowWorkFlow["Complete"].ToString();
                    if (!string.IsNullOrEmpty(_InTime))
                    {
                        if (!string.IsNullOrEmpty(_Complete))
                        {
                            lblWorkFlow.Text = "The time of entry:" + _InTime + " Confirm the time:" + _Complete;
                        }
                        else
                        {
                            lblWorkFlow.Text = "The time of entry:" + _InTime + "    No confirmation required";
                        }
                    }
                }
                #endregion
            }
        }

        public bool RemarkVisible
        {
            set
            {
                label8.Visible = value;
                panel8.Visible = value;
                tbRemark.Visible = value;
            }
        }

        #region Property
        public string KeyValue
        {
            get { return _VoucherID.Text; }
            set { _VoucherID.Text = value; }
        }

        public Guid ID
        {
            get { return new Guid(_ID.Text); }
            set { _ID.Text = value.ToString(); }
        }

        public string Flag
        {
            get { return _Flag.Text; }
            set { _Flag.Text = value; }
        }

        public string CardNO
        {
            get { return tbMac.Text.Trim(); }
            set { tbMac.Text = value; }
        }

        public string GuestName
        {
            get { return tbName.Text.Trim(); }
            set { tbName.Text = value; }
        }

        public string IDCard
        {
            get { return tbIDCard.Text.Trim(); }
            set { tbIDCard.Text = value; }
        }

        public string Enterprise
        {
            get { return tbEnterprise.Text.Trim(); }
            set { tbEnterprise.Text = value; }
        }

        public string FilePath
        {
            get { return tbFilePath.Text.Trim(); }
            set { tbFilePath.Text = value; }
        }

        public string Remark
        {
            get { return tbRemark.Text.Trim(); }
            set { tbRemark.Text = value; }
        }
        public bool IsAbsent
        {
            get { return cbAbsent.Checked; }
            set { cbAbsent.Checked = value; }
        }

        #endregion

        string _msg = string.Empty;
        public string MsgGuest
        {
            get { return _msg; }
            set { _msg = value; }
        }
        /// <summary>
        /// check data
        /// </summary>
        public bool IsReady
        {
            get
            {
                StringBuilder msg = new StringBuilder();
                if (string.IsNullOrEmpty(tbMac.Text))
                    msg.Append("CardNo cannot be empty");
                if (string.IsNullOrEmpty(tbName.Text))
                    msg.Append("/Name cannot be empty");
                //if (string.IsNullOrEmpty(tbIDCard.Text))
                //    msg.Append("/IDCard cannot be empty");
                if (string.IsNullOrEmpty(tbEnterprise.Text))
                    msg.Append("/Enterprise cannot be empty");

                _msg = "" + msg;

                if (_msg == "")
                    return true;
                else
                    return false;
            }
        }


        Int32 result;
        IDCardReader.PERSONINFOW info = new IDCardReader.PERSONINFOW();
        /// <summary>
        /// To read the ID card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btIDCardReader_Click(object sender, EventArgs e)
        {
            try
            {
                result = IDCardReader.GetPersonMsgW(ref info, "");

                if (string.IsNullOrEmpty(info.cardId))
                {
                    MessageBox.Show("Unable to read the magnetic strip ID card, please replace the other ID card and try again!", "Prompt information");
                    return;
                }

                IDCard = info.cardId;
                tbName.Text = info.name;
                cbDriveABCD.Text = "ID card";

                //wait 500ms
                System.Threading.Thread.Sleep(1000);

                string filename = "IDImages\\" + info.cardId + ".bmp";
                IDCardReader.GetPersonMsgW(ref info, filename);

                //wait 500ms
                System.Threading.Thread.Sleep(1000);

                Image image = Image.FromFile(filename);
                ImageCon = image;
                tbFilePath.Text = filename;

                //
                if (_NameVerification != tbName.Text)
                {
                    tbName.Text = _NameVerification;
                    MessageBox.Show("Visitor Information does not match the name and identity card!", "Prompt information");
                }
                if (_IDCardVerification != IDCard)
                {
                    tbIDCard.Text = _IDCardVerification;
                    MessageBox.Show("The Contractor does not match the information of documents and identity cards!", "Prompt information");
                }
                else
                {
                    //
                    ImgUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred while reading ID card");
            }
        }

        ReportBiz rep = new ReportBiz();

        /// <summary>
        /// Uploading photos function
        /// </summary>
        public void ImgUpdate()
        {
            if (string.IsNullOrEmpty(tbFilePath.Text))
            {
                MessageBox.Show("Please select photos！", "Prompt information");
            }
            else
            {
                FileStream fs = new FileStream(tbFilePath.Text, FileMode.OpenOrCreate, FileAccess.Read);
                byte[] MyData = new byte[fs.Length];
                fs.Read(MyData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();

                if (_ID.Text != "-")
                {
                    rep.GetMISReport("FK_AC_Update_GuestItem_Image", new string[] { "ID", "Image" }, new object[] { new Guid(_ID.Text), MyData });
                }
                else if (Flag == "HS")
                {
                    rep.GetMISReport("HS_Q_Update_Contractor_Image", new string[] { "IdCard", "Employer", "Image" }, new object[] { tbIDCard.Text.Trim(), tbEnterprise.Text, MyData });
                }

                MessageBox.Show("Uploaded photos succeed！");
            }
        }
    }
}
