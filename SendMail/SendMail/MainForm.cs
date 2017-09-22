using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);
            btTaskReminder.Click += btTaskReminder_Click;
            //读取配置文件
            Email_host = (string)(configurationAppSettings.GetValue("host", typeof(string)));
            Email_domain = (string)(configurationAppSettings.GetValue("domain", typeof(string)));
            Email_port = (int)(configurationAppSettings.GetValue("port", typeof(int)));
            Email_user = (string)(configurationAppSettings.GetValue("user", typeof(string)));
            Email_pass = (string)(configurationAppSettings.GetValue("pass", typeof(string)));
            Email_from = (string)(configurationAppSettings.GetValue("from", typeof(string)));
            RestUrl = (string)(configurationAppSettings.GetValue("RestUrl", typeof(string)));

            this.Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            _timer.Start();
        }

        private static System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
        public string Email_host { get; set; }//STMP服务器地址
        public string Email_domain { get; set; }//SMTP服务域名
        public int Email_port { get; set; }//SMTP服务端口
        public string Email_user { get; set; }//SMTP服务帐号
        public string Email_pass { get; set; }//SMTP服务密码
        public string Email_from { get; set; }//发送方邮件地址
        public string RestUrl { get; set; }//Task url地址

        Timer _timer = new Timer();
        SqlService _sqlService = new SqlService();
        TaskService _taskService = new TaskService();
        #region
        void btTaskReminder_Click(object sender, EventArgs e)
        {
            btTaskReminder.Enabled = false;
            TaskReminder();
            btTaskReminder.Enabled = true;
        }
        #endregion

        #region
        void _timer_Tick(object sender, EventArgs e)
        {
            //everyday : send email for task
            if (DateTime.Now.ToString("HH:mm:ss") == "15:00:00")
            {
                TaskReminder();
            }
        }

        /// <summary>
        /// send email for task
        /// </summary>
        void TaskReminder()
        {
            listBox1.Items.Add("Send email begin:" + DateTime.Now.ToString());

            /*
            0.得到流程的节点，这个数据库取
            1.得到所有需要发邮件的任务:http://10.20.46.23:9999/default/bpm-rest-api/task?processDefinitionId="+definId+"&taskDefinitionKey="+taskDefinitionKey;
            2.得到任务处理的人http://10.20.46.23:9999/default/bpm-rest-api/task/75ba00ef-23e0-11e7-895c-0050568c22a6/identity-links
            3.Userid查找到发邮件地址
            4.统计
            */
            //得到流程的节点
            DataTable dtNodes = _sqlService.GetProcessNode();
            if (dtNodes.Rows.Count > 0)
            {
                List<Candidates> listCandidates = new List<Candidates>();//所有userid,WorkFlow务列表
                Candidates _candidates = null;
                foreach (DataRow row in dtNodes.Rows)
                {
                    //得到需要发邮件的任务
                    List<BPMTask> listBPMTask = _taskService.GetUserTasks(row["ProcessDefinitionId"].ToString(), row["TaskDefinitionKey"].ToString());
                    if (listBPMTask.Count > 0)
                    {
                        foreach (BPMTask item in listBPMTask)
                        {
                            List<Candidates> listuserid = _taskService.GetUseridByTaskid(item.id);
                            if (listuserid.Count > 0)
                            {
                                foreach (Candidates uid in listuserid)
                                {
                                    _candidates = new Candidates();
                                    if (uid.userId.Contains("fepv"))
                                    { 
                                        _candidates.userId = uid.userId.ToUpper(); 
                                    }
                                    else
                                    {
                                        _candidates.userId = uid.userId;
                                    }
                                    _candidates.WorkFlow = row["WorkFlow"].ToString();
                                    //if (_candidates.userId == "981023")//test **********************
                                    listCandidates.Add(_candidates);
                                }
                            }
                        }
                    }
                }
                //按照userId分组
                IEnumerable<IGrouping<string, Candidates>> query1 = listCandidates.GroupBy(pet => pet.userId, pet => pet);
                foreach (IGrouping<string, Candidates> info in query1)
                {
                    List<Candidates> sl = info.ToList<Candidates>();//分组后的集合 

                    Console.WriteLine("-----------------" + sl[0].userId + "-----------------");
                    //获取邮箱
                    string email = _sqlService.GetMailsByUserID(sl[0].userId);
                    Console.WriteLine("email:" + email);
                    if (!string.IsNullOrEmpty(email))
                    {
                        StringBuilder emailbody = new StringBuilder();
                        emailbody.Append("<html><font font-family=microsoftyahei; size='3'>Dear:<br/><br/>");
                        emailbody.Append("&nbsp;&nbsp;&nbsp;&nbsp;<a href='http://10.20.46.22'>FEPV MIS 系統</a>(http://10.20.46.22)<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;【信息列表】:<br/>");
                        emailbody.Append("<ul>");
                        //按照WorkFlow再分组
                        IEnumerable<IGrouping<string, Candidates>> query2 = sl.GroupBy(pet2 => pet2.WorkFlow, pet2 => pet2);
                        foreach (IGrouping<string, Candidates> info2 in query2)
                        {
                            List<Candidates> sl2 = info2.ToList<Candidates>();//分组后的集合 
                            //Console.WriteLine(sl2[0].WorkFlow + "-" + sl2.Count);
                            emailbody.Append("<li>" + sl2[0].WorkFlow + ":" + sl2.Count + "个</li>");
                            //邮件内容
                            /*
                            <font font-family=microsoftyahei; size='3'>
                            Dear:<br/><br/>
                            &nbsp;&nbsp;FEPV MIS 系統(<a href='http://10.20.46.23:843'>http://10.20.46.23:843</a>)<br/><br/>&nbsp;&nbsp;【信息列表】:<br/>
                            <ul>
                            <li>物品出厂审核(Xuất vật phẩm ra ngoài):2个</li>
                            <li>访客申请审核(Đăng ký khách vào công ty):2个</li>
                            </ul>
                            </font>
                            <br/>
                            IT應用系統為您服務:請進入<a href='http://10.20.46.23:843'>FEPV MIS 系統</a>查看<font color="#FF0000"><b>我的任務</b></font>進行處理！<br/>
                            備註：提醒郵件每天下午三點發送一次，若您已對該單據進行過處理，請忽略本次提示。<br/>
                            請經常主動進入FEPV MIS 系統進行單據處理，以保證單據的及時處理，提高效率。<br/>
                            */
                        }
                        emailbody.Append("</ul></font><br/>");
                        emailbody.Append("IT應用系統為您服務:請進入<a href='http://10.20.46.22'>FEPV MIS 系統</a>查看<font color='#FF0000'><b>我的任務</b></font>進行處理！<br/>");
                        emailbody.Append("備註：提醒郵件每天下午三點發送一次，若您已對該單據進行過處理，請忽略本次提示。<br/>");
                        emailbody.Append("請經常主動進入FEPV MIS 系統進行單據處理，以保證單據的及時處理，提高效率。<br/>");
                        emailbody.Append("</html>");
                        Console.WriteLine(emailbody.ToString());
                        System.Threading.Thread.Sleep(15000);    //停15秒
                        SendTaskMailNet(email, "FEPV MIS System task reminder(" + DateTime.Today.ToString("yyyy-MM-dd") + ")", emailbody.ToString());
                    }
                    else
                    {
                        Console.WriteLine(sl[0].userId+":email is empty!!!");
                    }
                }
            }
            listBox1.Items.Add("Send email end:" + DateTime.Now.ToString());
        }
        #endregion

        private static readonly ILog Loger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void SendTaskMailNet(string mailto, string mailsubject, string mailbody)
        {
            MailMessage _mailMessage = new MailMessage();
            _mailMessage.From = new MailAddress(Email_from, "FEPV MIS EMAIL");
            string[] strMailNames = mailto.Split(';');
            foreach (string strMailName in strMailNames)
            {
                _mailMessage.To.Add(new MailAddress(strMailName));
            }
            _mailMessage.Subject = mailsubject;//主题
            _mailMessage.Body = mailbody;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级

            try
            {
                using (SmtpClient _smtpClient = new SmtpClient(Email_host, Email_port))
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
                    _smtpClient.Credentials = new NetworkCredential(Email_user, Email_pass, Email_domain);//用户名和密码
                    _smtpClient.Send(_mailMessage);
                }
                Loger.Info("Send email success-" + mailto + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception e)
            {
                Loger.Error("Exception:" + e.Message + e.StackTrace);
            }
        }
    }
}
