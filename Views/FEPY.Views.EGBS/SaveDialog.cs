using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FEPV.BLL;
using System.IO;

namespace FEPV.Views
{
    public partial class SaveDialog : Infrastructure.StyleForm
    {
        public SaveDialog()
        {
            InitializeComponent();
            btImgUpdate.Click += btImgUpdate_Click;
            btCancel.Click += btCancel_Click;
            tbFilePath.Click += new EventHandler(tbFilePath_Click);
            this.Load += new EventHandler(SaveDialog_Load);
        }

        void SaveDialog_Load(object sender, EventArgs e)
        {
            //办证串口
            try
            {
                porisManage = new Poris(ManageCOM);
                porisManage.eventPassportScaned += new EventHandler(porisManage_eventPassportScaned);
            }
            catch (Exception exc)
            {
                MessageBox.Show("PorisManage读卡器故障 : " + exc.Message, "提示信息");
            }
        }

        public delegate void CardIDelegate(string cardid);
        Poris porisManage = null;
        public string ManageCOM { get; set; }//办证COM串口
        string rData = string.Empty;
        //访客办证串口
        void porisManage_eventPassportScaned(object sender, EventArgs e)
        {
            rData = (string)sender;
            MyInvoke(rData);
            rData = string.Empty;
        }
        public void MyInvoke(string cardid)
        {
            try
            {
                CardIDelegate mygate = new CardIDelegate(ReadCardIdByporisManage);
                this.Invoke(mygate, new object[] { cardid });
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void ReadCardIdByporisManage(string cardid)
        {
            tbMac.Text = cardid;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (porisManage != null)
                porisManage.Dispose();

            base.OnClosed(e);
        }

        /// <summary>
        /// 浏览相片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbFilePath_Click(object sender, EventArgs e)
        {
            Image imagetmp = pictureBox1.Image;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件(*.jpg;*.jpeg;*.bmp;*png|*.jpg;*.jpeg;*.bmp;*png)|gif(*.gif)|*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                ImageCon = image;
                if (ImageCon.Width > 1024 || ImageCon.Height > 768)
                {
                    tbFilePath.Text = "";
                    ImageCon = imagetmp;
                    MessageBox.Show("照片大于1024*768，请裁剪！");
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

        ReportBiz rep = new ReportBiz();

        void btCancel_Click(object sender, EventArgs e)
        {
            rValue = false;
            this.Close();
        }

        void btImgUpdate_Click(object sender, EventArgs e)
        {
            SaveCardNo();
            //ImgUpdate();
            rValue = true;
            this.Close();
        }

        public void SaveCardNo()
        {
            if (string.IsNullOrEmpty(tbMac.Text.Trim()))
            {
                MessageBox.Show("请输入卡号信息！", "注意");
                return;
            }
            //保存人员信息
            if (Flag == "FK")
            {
                string str = rep.GetMISReport("FK_AC_Update_GuestItem_CardNO_Check",
                                new string[] { "CardNO" },
                                new object[] { tbMac.Text.Trim() }).Tables[0].Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    MessageBox.Show(str, "提示信息");
                    return;
                }
                rep.GetMISReport("FK_AC_Update_GuestItem_CardNO", new string[] { "ID", "CardNO" }, new object[] { new Guid(_ID), tbMac.Text.Trim() });
            }
            else
            {
                string str = rep.GetMISReport("HS_Q_Update_Contractor_CardNO",
                                new string[] { "CardNO", "Name", "IdCard", "Employer" },
                                new object[] { tbMac.Text.Trim(), GuestName, IdCard, Employer }).Tables[0].Rows[0][0].ToString();

                if (!string.IsNullOrEmpty(str))
                {
                    MessageBox.Show(str, "提示信息");
                    return;
                }
            }
        }
        /// <summary>
        /// 相片上传
        /// </summary>
        public void ImgUpdate()
        {
            if (string.IsNullOrEmpty(tbFilePath.Text))
            {
                MessageBox.Show("请选择要上传的相片！", "注意");
            }
            else
            {
                FileStream fs = new FileStream(tbFilePath.Text, FileMode.OpenOrCreate, FileAccess.Read);
                byte[] MyData = new byte[fs.Length];
                fs.Read(MyData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();

                if (_ID != "-")
                {
                    rep.GetMISReport("FK_AC_Update_GuestItem_Image", new string[] { "ID", "Image" }, new object[] { new Guid(_ID), MyData });
                }
                else if (Flag == "HS")
                {
                    rep.GetMISReport("HS_Q_Update_Contractor_Image", new string[] { "IdCard", "Employer", "Image" }, new object[] { IdCard, Employer, MyData });
                }

                MessageBox.Show("相片上传成功！");
            }
        }

        public Dictionary<string, object> Paras
        {
            set
            {
                _ID = value["ID"].ToString();
                Flag = value["标识"].ToString();
                IdCard = value["证件号码"].ToString();
                Employer = value["工作单位"].ToString();
                GuestName = value["姓名"].ToString();
                tbMac.Text = value["卡号"].ToString();

                #region 抓取访客相片
                DataTable tbImage = new DataTable();
                if (_ID != "-")
                {
                    tbImage = rep.GetMISReport("FK_AC_GuestItem_Image", new string[] { "ID" }, new object[] { new Guid(_ID) }).Tables[0];
                }
                else if (Flag == "HS")
                {
                    tbImage = rep.GetMISReport("HS_Q_Contractor_Image", new string[] { "IdCard", "Employer" }, new object[] { IdCard, Employer }).Tables[0];
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
            }
        }

        bool rValue = false;
        public bool RValue { get { return rValue; } }

        public string _ID { get; set; }
        public string Flag { get; set; }
        public string IdCard { get; set; }
        public string Employer { get; set; }
        public string GuestName { get; set; }
    }
}
