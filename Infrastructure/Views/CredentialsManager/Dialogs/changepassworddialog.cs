// ?2007 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using CredentialsManager;

namespace CredentialsManagerClient
{
   partial class ChangePasswordDialog : Form
   {
      string m_Url;
      string m_Application;
//      PasswordManagerProxy m_PasswordManager;
      IPasswordManager m_PasswordManager;

      public ChangePasswordDialog(string url,string application,string user)
      {
         InitializeComponent();

         m_Url = url;
         m_Application = application;
         m_UserNameTextBox.Text = user;

         //m_PasswordManager = new PasswordManagerProxy(m_Url);
         m_PasswordManager = Shawoo.Core.ProxyHelper<IPasswordManager>.GetService();
         m_PasswordQuestionTextBox.Text = m_PasswordManager.GetPasswordQuestion(application,user);

         IMembershipManager membershipManager = Shawoo.Core.ProxyHelper<IMembershipManager>.GetService();
         m_PasswordAnswerTextBox.Enabled = false;// m_PasswordManager.RequiresQuestionAndAnswer(application);
         m_PasswordAnswerTextBox.Text = membershipManager.GetUserInfo(application, user).PasswordAnswer;
      }
      void OnChange(object sender,EventArgs e)
      {
         if(m_PasswordAnswerTextBox.Text == String.Empty && m_PasswordAnswerTextBox.Enabled)
         {
            m_Validator.SetError(m_PasswordAnswerTextBox,"Password answer cannot be empty");
            return;
         }
         m_Validator.Clear();

         if(m_NewPasswordTextBox.Text == String.Empty)
         {
            m_Validator.SetError(m_NewPasswordTextBox,"New password cannot be empty");
            return;
         }
         m_Validator.Clear();

         if(m_PasswordAnswerTextBox.Enabled)
         {
            try
            {
               m_PasswordManager.ChangePasswordWithAnswer(m_Application,m_UserNameTextBox.Text,m_PasswordAnswerTextBox.Text,m_NewPasswordTextBox.Text);
            }
            catch(SoapException exception)
            {
               if(exception.Message.Contains("The password-answer supplied is wrong"))
               {
                  MessageBox.Show("The password-answer supplied is wrong. Please try agian.","Credentials Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  return;
               }
               if(exception.Message.Contains("The user account has been locked out"))
               {
                  MessageBox.Show("The user account has been locked out","Credentials Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  Close();
                  return;
               }
               throw;
            }
         }
         else
         {
            try
            {
               m_PasswordManager.ChangePassword(m_Application,m_UserNameTextBox.Text,m_NewPasswordTextBox.Text);
            }
            catch(SoapException exception)
            {
               if(exception.Message.Contains("The user account has been locked out"))
               {
                  MessageBox.Show("The user account has been locked out","Credentials Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  Close();
                  return;
               }
               throw;
            }
         }
         Close();
      }

      void OnClosed(object sender,FormClosedEventArgs e)
      {
         //m_PasswordManager.Close();
      }
   }
}