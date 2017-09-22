
using System.Windows.Forms;
using CredentialsManagerClient.Properties;
namespace CredentialsManagerClient
{
   partial class CredentialsManagerForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise,false.</param>
      protected override void Dispose(bool disposing)
      {
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
          System.Windows.Forms.ColumnHeader usersToAssignHeader;
          System.Windows.Forms.ColumnHeader columnApplications;
          System.Windows.Forms.MenuStrip mainMenu;
          System.Windows.Forms.ToolStripMenuItem usersMenuItem;
          System.Windows.Forms.ToolStripSeparator usersSeparator1;
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CredentialsManagerForm));
          System.Windows.Forms.ToolStripSeparator usersSeparator2;
          System.Windows.Forms.ToolStripMenuItem rolesMenuItem;
          System.Windows.Forms.ToolStripSeparator rolesSeparator1;
          System.Windows.Forms.ToolStripMenuItem passwordsMenuItem;
          System.Windows.Forms.ToolStripMenuItem serviceMenuItem;
          System.Windows.Forms.ToolStripMenuItem testMenuItem;
          System.Windows.Forms.ToolStripMenuItem helpMenuItem;
          System.Windows.Forms.TabPage servicePage;
          System.Windows.Forms.GroupBox addressGroupBox;
          System.Windows.Forms.TabPage passwordsPage;
          System.Windows.Forms.GroupBox generatePassorgGroupBox;
          System.Windows.Forms.Label lengthLabel;
          System.Windows.Forms.Label nonAlphanumericLabel;
          System.Windows.Forms.GroupBox passwordSetupGroupBox;
          System.Windows.Forms.Label minLengthLabel;
          System.Windows.Forms.Label attemptWindowLabel;
          System.Windows.Forms.Label minNonAlpha;
          System.Windows.Forms.Label passwordRegularExpressionLabel;
          System.Windows.Forms.Label maxInvalidLabel;
          System.Windows.Forms.Label requiresQuestionAndAnswerLabel;
          System.Windows.Forms.Label passwordRetrievalLabel;
          System.Windows.Forms.Label passwordResetLabel;
          System.Windows.Forms.TabPage rolesPage;
          System.Windows.Forms.GroupBox rolesGroupBox;
          System.Windows.Forms.Label usersInRoleLabel;
          System.Windows.Forms.ColumnHeader rolesHeader;
          System.Windows.Forms.GroupBox usersGroupBox;
          System.Windows.Forms.Label rolesForUserLabel;
          System.Windows.Forms.ColumnHeader userToassignHeader;
          System.Windows.Forms.TabPage usersPage;
          System.Windows.Forms.GroupBox usersGoupBox;
          System.Windows.Forms.ColumnHeader usersHeader;
          System.Windows.Forms.GroupBox usersStatus;
          System.Windows.Forms.Label onlineUsersLabel;
          System.Windows.Forms.Label onlineTimeWindowLabel;
          System.Windows.Forms.TabPage applicationsTab;
          System.Windows.Forms.GroupBox applicationsGroupBox;
          System.Windows.Forms.ColumnHeader applicationsHeader;
          System.Windows.Forms.PictureBox applicationPictureBox;
          System.Windows.Forms.TabControl tabControl;
          this.m_CreateUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_UpdateUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_DeleteUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_DeleteAllUsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_ChangePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_ResetPasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_RefreshUsersStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_CreateRoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_DeleteRoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_DeleteAllRolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_AssignUsertoRoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_RemoveUserFromRoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_RemoveUserFromAllRolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_GeneratePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_SelectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_LogOnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.m_AuthorizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
          this.m_AddressLabel = new System.Windows.Forms.Label();
          this.m_ViewButton = new System.Windows.Forms.Button();
          this.m_AddressTextbox = new System.Windows.Forms.TextBox();
          this.m_WebBrowser = new System.Windows.Forms.WebBrowser();
          this.m_SelectButton = new System.Windows.Forms.Button();
          this.m_GeneratePassword = new System.Windows.Forms.Button();
          this.m_NonAlphanumericTextBox = new System.Windows.Forms.TextBox();
          this.m_LengthTextBox = new System.Windows.Forms.TextBox();
          this.m_MinLength = new System.Windows.Forms.Label();
          this.m_MinNonAlphanumeric = new System.Windows.Forms.Label();
          this.m_AttemptWindow = new System.Windows.Forms.Label();
          this.m_MaxInvalidAttempts = new System.Windows.Forms.Label();
          this.m_PasswordRegularExpression = new System.Windows.Forms.Label();
          this.m_PasswordRetrieval = new System.Windows.Forms.Label();
          this.m_RequiresQuestionAndAnswerLabel = new System.Windows.Forms.Label();
          this.m_PasswordReset = new System.Windows.Forms.Label();
          this.m_PopulatedLabel = new System.Windows.Forms.Label();
          this.m_DeleteRoleButton = new System.Windows.Forms.Button();
          this.m_CreateRoleButton = new System.Windows.Forms.Button();
          this.m_DeleteAllRolesButton = new System.Windows.Forms.Button();
          this.m_ThrowIfPopulatedCheckBox = new System.Windows.Forms.CheckBox();
          this.m_RolesListView = new CredentialsManagerClient.ListViewEx();
          this.m_UsersInRoleComboBox = new ComboBoxEx();
          this.m_AssignButton = new System.Windows.Forms.Button();
          this.m_RemoveUserFromRoleButton = new System.Windows.Forms.Button();
          this.m_RemoveUserFromAllRolesButton = new System.Windows.Forms.Button();
          this.m_UsersToAssignListView = new CredentialsManagerClient.ListViewEx();
          this.m_RolesForUserComboBox = new ComboBoxEx();
          this.m_CreateUserButton = new System.Windows.Forms.Button();
          this.m_DeleteUserButton = new System.Windows.Forms.Button();
          this.m_UpdateUser = new System.Windows.Forms.Button();
          this.m_DeleteAllUsersButton = new System.Windows.Forms.Button();
          this.m_RelatedDataCheckBox = new System.Windows.Forms.CheckBox();
          this.m_ResetPasswordButton = new System.Windows.Forms.Button();
          this.m_ChangePasswordButton = new System.Windows.Forms.Button();
          this.m_UsersListView = new CredentialsManagerClient.ListViewEx();
          this.m_UsersOnline = new System.Windows.Forms.Label();
          this.m_OnlineTimeWindow = new System.Windows.Forms.Label();
          this.m_UsersStatusRefresh = new System.Windows.Forms.Button();
          this.m_DeleteApplicationButton = new System.Windows.Forms.Button();
          this.m_CreateApplicationButton = new System.Windows.Forms.Button();
          this.m_DeleteAllApplicationsButton = new System.Windows.Forms.Button();
          this.m_ApplicationListView = new CredentialsManagerClient.ListViewEx();
          usersToAssignHeader = new System.Windows.Forms.ColumnHeader();
          columnApplications = new System.Windows.Forms.ColumnHeader();
          mainMenu = new System.Windows.Forms.MenuStrip();
          usersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          usersSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          usersSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          rolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          rolesSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          passwordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          serviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          testMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          servicePage = new System.Windows.Forms.TabPage();
          addressGroupBox = new System.Windows.Forms.GroupBox();
          passwordsPage = new System.Windows.Forms.TabPage();
          generatePassorgGroupBox = new System.Windows.Forms.GroupBox();
          lengthLabel = new System.Windows.Forms.Label();
          nonAlphanumericLabel = new System.Windows.Forms.Label();
          passwordSetupGroupBox = new System.Windows.Forms.GroupBox();
          minLengthLabel = new System.Windows.Forms.Label();
          attemptWindowLabel = new System.Windows.Forms.Label();
          minNonAlpha = new System.Windows.Forms.Label();
          passwordRegularExpressionLabel = new System.Windows.Forms.Label();
          maxInvalidLabel = new System.Windows.Forms.Label();
          requiresQuestionAndAnswerLabel = new System.Windows.Forms.Label();
          passwordRetrievalLabel = new System.Windows.Forms.Label();
          passwordResetLabel = new System.Windows.Forms.Label();
          rolesPage = new System.Windows.Forms.TabPage();
          rolesGroupBox = new System.Windows.Forms.GroupBox();
          usersInRoleLabel = new System.Windows.Forms.Label();
          rolesHeader = new System.Windows.Forms.ColumnHeader();
          usersGroupBox = new System.Windows.Forms.GroupBox();
          rolesForUserLabel = new System.Windows.Forms.Label();
          userToassignHeader = new System.Windows.Forms.ColumnHeader();
          usersPage = new System.Windows.Forms.TabPage();
          usersGoupBox = new System.Windows.Forms.GroupBox();
          usersHeader = new System.Windows.Forms.ColumnHeader();
          usersStatus = new System.Windows.Forms.GroupBox();
          onlineUsersLabel = new System.Windows.Forms.Label();
          onlineTimeWindowLabel = new System.Windows.Forms.Label();
          applicationsTab = new System.Windows.Forms.TabPage();
          applicationsGroupBox = new System.Windows.Forms.GroupBox();
          applicationsHeader = new System.Windows.Forms.ColumnHeader();
          applicationPictureBox = new System.Windows.Forms.PictureBox();
          tabControl = new System.Windows.Forms.TabControl();
          mainMenu.SuspendLayout();
          servicePage.SuspendLayout();
          addressGroupBox.SuspendLayout();
          passwordsPage.SuspendLayout();
          generatePassorgGroupBox.SuspendLayout();
          passwordSetupGroupBox.SuspendLayout();
          rolesPage.SuspendLayout();
          rolesGroupBox.SuspendLayout();
          usersGroupBox.SuspendLayout();
          usersPage.SuspendLayout();
          usersGoupBox.SuspendLayout();
          usersStatus.SuspendLayout();
          applicationsTab.SuspendLayout();
          applicationsGroupBox.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(applicationPictureBox)).BeginInit();
          tabControl.SuspendLayout();
          this.SuspendLayout();
          // 
          // usersToAssignHeader
          // 
          usersToAssignHeader.Text = "";
          usersToAssignHeader.Width = 186;
          // 
          // columnApplications
          // 
          columnApplications.Text = "Select Application:";
          columnApplications.Width = 186;
          // 
          // mainMenu
          // 
          mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            usersMenuItem,
            rolesMenuItem,
            passwordsMenuItem,
            serviceMenuItem,
            testMenuItem,
            helpMenuItem});
          mainMenu.Location = new System.Drawing.Point(0, 0);
          mainMenu.Name = "mainMenu";
          mainMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
          mainMenu.Size = new System.Drawing.Size(824, 25);
          mainMenu.TabIndex = 1;
          mainMenu.Text = "m_MainMenu";
          // 
          // usersMenuItem
          // 
          usersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_CreateUserMenuItem,
            this.m_UpdateUserMenuItem,
            this.m_DeleteUserMenuItem,
            this.m_DeleteAllUsersMenuItem,
            usersSeparator1,
            this.m_ChangePasswordMenuItem,
            this.m_ResetPasswordMenuItem,
            usersSeparator2,
            this.m_RefreshUsersStatusMenuItem});
          usersMenuItem.Name = "usersMenuItem";
          usersMenuItem.Size = new System.Drawing.Size(53, 21);
          usersMenuItem.Text = "Users";
          // 
          // m_CreateUserMenuItem
          // 
          this.m_CreateUserMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.CreateIUser;
          this.m_CreateUserMenuItem.Name = "m_CreateUserMenuItem";
          this.m_CreateUserMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_CreateUserMenuItem.Text = "Create User";
          this.m_CreateUserMenuItem.Click += new System.EventHandler(this.OnCreateUser);
          // 
          // m_UpdateUserMenuItem
          // 
          this.m_UpdateUserMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.Update;
          this.m_UpdateUserMenuItem.Name = "m_UpdateUserMenuItem";
          this.m_UpdateUserMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_UpdateUserMenuItem.Text = "Update User";
          this.m_UpdateUserMenuItem.Click += new System.EventHandler(this.OnUpdateUser);
          // 
          // m_DeleteUserMenuItem
          // 
          this.m_DeleteUserMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.DeleteUser;
          this.m_DeleteUserMenuItem.Name = "m_DeleteUserMenuItem";
          this.m_DeleteUserMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_DeleteUserMenuItem.Text = "Delete User";
          this.m_DeleteUserMenuItem.Click += new System.EventHandler(this.OnDeleteUser);
          // 
          // m_DeleteAllUsersMenuItem
          // 
          this.m_DeleteAllUsersMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.DeleteAllUsers;
          this.m_DeleteAllUsersMenuItem.Name = "m_DeleteAllUsersMenuItem";
          this.m_DeleteAllUsersMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_DeleteAllUsersMenuItem.Text = "Delete All Users";
          this.m_DeleteAllUsersMenuItem.Click += new System.EventHandler(this.OnDeleteAllUsers);
          // 
          // usersSeparator1
          // 
          usersSeparator1.Name = "usersSeparator1";
          usersSeparator1.Size = new System.Drawing.Size(193, 6);
          // 
          // m_ChangePasswordMenuItem
          // 
          this.m_ChangePasswordMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.ChangePassword;
          this.m_ChangePasswordMenuItem.Name = "m_ChangePasswordMenuItem";
          this.m_ChangePasswordMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_ChangePasswordMenuItem.Text = "Change Password";
          this.m_ChangePasswordMenuItem.Click += new System.EventHandler(this.OnChangePassword);
          // 
          // m_ResetPasswordMenuItem
          // 
          this.m_ResetPasswordMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_ResetPasswordMenuItem.Image")));
          this.m_ResetPasswordMenuItem.Name = "m_ResetPasswordMenuItem";
          this.m_ResetPasswordMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_ResetPasswordMenuItem.Text = "Reset Password";
          this.m_ResetPasswordMenuItem.Click += new System.EventHandler(this.OnResetPassword);
          // 
          // usersSeparator2
          // 
          usersSeparator2.Name = "usersSeparator2";
          usersSeparator2.Size = new System.Drawing.Size(193, 6);
          // 
          // m_RefreshUsersStatusMenuItem
          // 
          this.m_RefreshUsersStatusMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_RefreshUsersStatusMenuItem.Image")));
          this.m_RefreshUsersStatusMenuItem.Name = "m_RefreshUsersStatusMenuItem";
          this.m_RefreshUsersStatusMenuItem.Size = new System.Drawing.Size(196, 22);
          this.m_RefreshUsersStatusMenuItem.Text = "Refresh Users Status";
          this.m_RefreshUsersStatusMenuItem.Click += new System.EventHandler(this.OnUserStatusRefresh);
          // 
          // rolesMenuItem
          // 
          rolesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_CreateRoleMenuItem,
            this.m_DeleteRoleMenuItem,
            this.m_DeleteAllRolesMenuItem,
            rolesSeparator1,
            this.m_AssignUsertoRoleMenuItem,
            this.m_RemoveUserFromRoleMenuItem,
            this.m_RemoveUserFromAllRolesMenuItem});
          rolesMenuItem.Name = "rolesMenuItem";
          rolesMenuItem.Size = new System.Drawing.Size(52, 21);
          rolesMenuItem.Text = "Roles";
          // 
          // m_CreateRoleMenuItem
          // 
          this.m_CreateRoleMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.CreateIRole;
          this.m_CreateRoleMenuItem.Name = "m_CreateRoleMenuItem";
          this.m_CreateRoleMenuItem.Size = new System.Drawing.Size(240, 22);
          this.m_CreateRoleMenuItem.Text = "Create Role";
          this.m_CreateRoleMenuItem.Click += new System.EventHandler(this.OnCreateRole);
          // 
          // m_DeleteRoleMenuItem
          // 
          this.m_DeleteRoleMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.DeleteRole;
          this.m_DeleteRoleMenuItem.Name = "m_DeleteRoleMenuItem";
          this.m_DeleteRoleMenuItem.Size = new System.Drawing.Size(240, 22);
          this.m_DeleteRoleMenuItem.Text = "Delete Role";
          this.m_DeleteRoleMenuItem.Click += new System.EventHandler(this.OnDeleteRole);
          // 
          // m_DeleteAllRolesMenuItem
          // 
          this.m_DeleteAllRolesMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.DeleteAllRoles;
          this.m_DeleteAllRolesMenuItem.Name = "m_DeleteAllRolesMenuItem";
          this.m_DeleteAllRolesMenuItem.Size = new System.Drawing.Size(240, 22);
          this.m_DeleteAllRolesMenuItem.Text = "Delete All Roles";
          this.m_DeleteAllRolesMenuItem.Click += new System.EventHandler(this.OnDeleteAllRoles);
          // 
          // rolesSeparator1
          // 
          rolesSeparator1.Name = "rolesSeparator1";
          rolesSeparator1.Size = new System.Drawing.Size(237, 6);
          // 
          // m_AssignUsertoRoleMenuItem
          // 
          this.m_AssignUsertoRoleMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.Assign;
          this.m_AssignUsertoRoleMenuItem.Name = "m_AssignUsertoRoleMenuItem";
          this.m_AssignUsertoRoleMenuItem.Size = new System.Drawing.Size(240, 22);
          this.m_AssignUsertoRoleMenuItem.Text = "Assign User to Role";
          this.m_AssignUsertoRoleMenuItem.Click += new System.EventHandler(this.OnAssignUserToRole);
          // 
          // m_RemoveUserFromRoleMenuItem
          // 
          this.m_RemoveUserFromRoleMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.Remove;
          this.m_RemoveUserFromRoleMenuItem.Name = "m_RemoveUserFromRoleMenuItem";
          this.m_RemoveUserFromRoleMenuItem.Size = new System.Drawing.Size(240, 22);
          this.m_RemoveUserFromRoleMenuItem.Text = "Remove User from Role";
          this.m_RemoveUserFromRoleMenuItem.Click += new System.EventHandler(this.OnRemoveUserFromRole);
          // 
          // m_RemoveUserFromAllRolesMenuItem
          // 
          this.m_RemoveUserFromAllRolesMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.RemoveAll;
          this.m_RemoveUserFromAllRolesMenuItem.Name = "m_RemoveUserFromAllRolesMenuItem";
          this.m_RemoveUserFromAllRolesMenuItem.Size = new System.Drawing.Size(240, 22);
          this.m_RemoveUserFromAllRolesMenuItem.Text = "Remove User from All Roles";
          this.m_RemoveUserFromAllRolesMenuItem.Click += new System.EventHandler(this.OnRemoveUsersFromAllRoles);
          // 
          // passwordsMenuItem
          // 
          passwordsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_GeneratePasswordMenuItem});
          passwordsMenuItem.Name = "passwordsMenuItem";
          passwordsMenuItem.Size = new System.Drawing.Size(82, 21);
          passwordsMenuItem.Text = "Passwords";
          // 
          // m_GeneratePasswordMenuItem
          // 
          this.m_GeneratePasswordMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.GeneratePassword;
          this.m_GeneratePasswordMenuItem.Name = "m_GeneratePasswordMenuItem";
          this.m_GeneratePasswordMenuItem.Size = new System.Drawing.Size(189, 22);
          this.m_GeneratePasswordMenuItem.Text = "Generate Password";
          this.m_GeneratePasswordMenuItem.Click += new System.EventHandler(this.OnGeneratePassword);
          // 
          // serviceMenuItem
          // 
          serviceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ViewMenuItem,
            this.m_SelectMenuItem});
          serviceMenuItem.Name = "serviceMenuItem";
          serviceMenuItem.Size = new System.Drawing.Size(61, 21);
          serviceMenuItem.Text = "Service";
          serviceMenuItem.Click += new System.EventHandler(this.OnViewService);
          // 
          // m_ViewMenuItem
          // 
          this.m_ViewMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.Service;
          this.m_ViewMenuItem.Name = "m_ViewMenuItem";
          this.m_ViewMenuItem.Size = new System.Drawing.Size(110, 22);
          this.m_ViewMenuItem.Text = "View";
          // 
          // m_SelectMenuItem
          // 
          this.m_SelectMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.SelectService;
          this.m_SelectMenuItem.Name = "m_SelectMenuItem";
          this.m_SelectMenuItem.Size = new System.Drawing.Size(110, 22);
          this.m_SelectMenuItem.Text = "Select";
          // 
          // testMenuItem
          // 
          testMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_LogOnMenuItem,
            this.m_AuthorizeMenuItem});
          testMenuItem.Name = "testMenuItem";
          testMenuItem.Size = new System.Drawing.Size(44, 21);
          testMenuItem.Text = "Test";
          // 
          // m_LogOnMenuItem
          // 
          this.m_LogOnMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.Authenticate;
          this.m_LogOnMenuItem.Name = "m_LogOnMenuItem";
          this.m_LogOnMenuItem.Size = new System.Drawing.Size(147, 22);
          this.m_LogOnMenuItem.Text = "Authenticate";
          this.m_LogOnMenuItem.Click += new System.EventHandler(this.OnAuthenticate);
          // 
          // m_AuthorizeMenuItem
          // 
          this.m_AuthorizeMenuItem.Image = global::CredentialsManagerClient.Properties.Resources.Authorize;
          this.m_AuthorizeMenuItem.Name = "m_AuthorizeMenuItem";
          this.m_AuthorizeMenuItem.Size = new System.Drawing.Size(147, 22);
          this.m_AuthorizeMenuItem.Text = "Authorize";
          this.m_AuthorizeMenuItem.Click += new System.EventHandler(this.OnAuthorize);
          // 
          // helpMenuItem
          // 
          helpMenuItem.Name = "helpMenuItem";
          helpMenuItem.Size = new System.Drawing.Size(47, 21);
          helpMenuItem.Text = "Help";
          // 
          // columnHeader1
          // 
          this.columnHeader1.Text = "";
          this.columnHeader1.Width = 186;
          // 
          // servicePage
          // 
          servicePage.Controls.Add(addressGroupBox);
          servicePage.Controls.Add(this.m_AddressLabel);
          servicePage.Location = new System.Drawing.Point(4, 23);
          servicePage.Name = "servicePage";
          servicePage.Size = new System.Drawing.Size(816, 419);
          servicePage.TabIndex = 4;
          servicePage.Text = "Credentials Service";
          servicePage.UseVisualStyleBackColor = true;
          // 
          // m_AddressLabel
          // 
          this.m_AddressLabel.AutoSize = true;
          this.m_AddressLabel.Location = new System.Drawing.Point(9, 11);
          this.m_AddressLabel.Name = "m_AddressLabel";
          this.m_AddressLabel.Size = new System.Drawing.Size(0, 14);
          this.m_AddressLabel.TabIndex = 2;
          // 
          // addressGroupBox
          // 
          addressGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          addressGroupBox.Controls.Add(this.m_SelectButton);
          addressGroupBox.Controls.Add(this.m_WebBrowser);
          addressGroupBox.Controls.Add(this.m_AddressTextbox);
          addressGroupBox.Controls.Add(this.m_ViewButton);
          addressGroupBox.Location = new System.Drawing.Point(7, 11);
          addressGroupBox.Name = "addressGroupBox";
          addressGroupBox.Size = new System.Drawing.Size(833, 402);
          addressGroupBox.TabIndex = 5;
          addressGroupBox.TabStop = false;
          addressGroupBox.Text = "Credentials Service Base Address:";
          // 
          // m_ViewButton
          // 
          this.m_ViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.m_ViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.m_ViewButton.Location = new System.Drawing.Point(623, 17);
          this.m_ViewButton.Name = "m_ViewButton";
          this.m_ViewButton.Size = new System.Drawing.Size(87, 23);
          this.m_ViewButton.TabIndex = 4;
          this.m_ViewButton.Text = "View";
          this.m_ViewButton.Click += new System.EventHandler(this.OnViewService);
          // 
          // m_AddressTextbox
          // 
          this.m_AddressTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.m_AddressTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
          this.m_AddressTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
          this.m_AddressTextbox.Location = new System.Drawing.Point(7, 20);
          this.m_AddressTextbox.Name = "m_AddressTextbox";
          this.m_AddressTextbox.Size = new System.Drawing.Size(609, 23);
          this.m_AddressTextbox.TabIndex = 3;
          this.m_AddressTextbox.Text = "http://localhost/CredentialsService/AspNetSqlProviderService.svc";
          // 
          // m_WebBrowser
          // 
          this.m_WebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.m_WebBrowser.Location = new System.Drawing.Point(7, 46);
          this.m_WebBrowser.Name = "m_WebBrowser";
          this.m_WebBrowser.Size = new System.Drawing.Size(798, 351);
          this.m_WebBrowser.TabIndex = 6;
          this.m_WebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.OnDownloadCompleted);
          // 
          // m_SelectButton
          // 
          this.m_SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.m_SelectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.m_SelectButton.Location = new System.Drawing.Point(718, 17);
          this.m_SelectButton.Name = "m_SelectButton";
          this.m_SelectButton.Size = new System.Drawing.Size(87, 23);
          this.m_SelectButton.TabIndex = 5;
          this.m_SelectButton.Text = "Select";
          this.m_SelectButton.Click += new System.EventHandler(this.OnSelectService);
          // 
          // passwordsPage
          // 
          passwordsPage.Controls.Add(passwordSetupGroupBox);
          passwordsPage.Controls.Add(generatePassorgGroupBox);
          passwordsPage.Location = new System.Drawing.Point(4, 23);
          passwordsPage.Name = "passwordsPage";
          passwordsPage.Size = new System.Drawing.Size(816, 419);
          passwordsPage.TabIndex = 3;
          passwordsPage.Text = "Passwords";
          passwordsPage.UseVisualStyleBackColor = true;
          // 
          // generatePassorgGroupBox
          // 
          generatePassorgGroupBox.Controls.Add(nonAlphanumericLabel);
          generatePassorgGroupBox.Controls.Add(this.m_LengthTextBox);
          generatePassorgGroupBox.Controls.Add(this.m_NonAlphanumericTextBox);
          generatePassorgGroupBox.Controls.Add(this.m_GeneratePassword);
          generatePassorgGroupBox.Controls.Add(lengthLabel);
          generatePassorgGroupBox.Location = new System.Drawing.Point(315, 11);
          generatePassorgGroupBox.Name = "generatePassorgGroupBox";
          generatePassorgGroupBox.Size = new System.Drawing.Size(301, 368);
          generatePassorgGroupBox.TabIndex = 17;
          generatePassorgGroupBox.TabStop = false;
          generatePassorgGroupBox.Text = "Generate Password";
          // 
          // lengthLabel
          // 
          lengthLabel.AutoSize = true;
          lengthLabel.Location = new System.Drawing.Point(17, 20);
          lengthLabel.Name = "lengthLabel";
          lengthLabel.Size = new System.Drawing.Size(56, 14);
          lengthLabel.TabIndex = 19;
          lengthLabel.Text = "Length:";
          // 
          // m_GeneratePassword
          // 
          this.m_GeneratePassword.Location = new System.Drawing.Point(206, 34);
          this.m_GeneratePassword.Name = "m_GeneratePassword";
          this.m_GeneratePassword.Size = new System.Drawing.Size(87, 23);
          this.m_GeneratePassword.TabIndex = 16;
          this.m_GeneratePassword.Text = "Generate";
          this.m_GeneratePassword.Click += new System.EventHandler(this.OnGeneratePassword);
          // 
          // m_NonAlphanumericTextBox
          // 
          this.m_NonAlphanumericTextBox.Location = new System.Drawing.Point(17, 81);
          this.m_NonAlphanumericTextBox.Name = "m_NonAlphanumericTextBox";
          this.m_NonAlphanumericTextBox.Size = new System.Drawing.Size(116, 23);
          this.m_NonAlphanumericTextBox.TabIndex = 17;
          this.m_NonAlphanumericTextBox.Text = "1";
          // 
          // m_LengthTextBox
          // 
          this.m_LengthTextBox.Location = new System.Drawing.Point(17, 35);
          this.m_LengthTextBox.Name = "m_LengthTextBox";
          this.m_LengthTextBox.Size = new System.Drawing.Size(116, 23);
          this.m_LengthTextBox.TabIndex = 18;
          this.m_LengthTextBox.Text = "6";
          // 
          // nonAlphanumericLabel
          // 
          nonAlphanumericLabel.AutoSize = true;
          nonAlphanumericLabel.Location = new System.Drawing.Point(16, 65);
          nonAlphanumericLabel.Name = "nonAlphanumericLabel";
          nonAlphanumericLabel.Size = new System.Drawing.Size(126, 14);
          nonAlphanumericLabel.TabIndex = 20;
          nonAlphanumericLabel.Text = "Non-alphanumeric:";
          // 
          // passwordSetupGroupBox
          // 
          passwordSetupGroupBox.Controls.Add(passwordResetLabel);
          passwordSetupGroupBox.Controls.Add(this.m_PasswordReset);
          passwordSetupGroupBox.Controls.Add(this.m_RequiresQuestionAndAnswerLabel);
          passwordSetupGroupBox.Controls.Add(passwordRetrievalLabel);
          passwordSetupGroupBox.Controls.Add(requiresQuestionAndAnswerLabel);
          passwordSetupGroupBox.Controls.Add(this.m_PasswordRetrieval);
          passwordSetupGroupBox.Controls.Add(this.m_PasswordRegularExpression);
          passwordSetupGroupBox.Controls.Add(maxInvalidLabel);
          passwordSetupGroupBox.Controls.Add(passwordRegularExpressionLabel);
          passwordSetupGroupBox.Controls.Add(this.m_MaxInvalidAttempts);
          passwordSetupGroupBox.Controls.Add(this.m_AttemptWindow);
          passwordSetupGroupBox.Controls.Add(minNonAlpha);
          passwordSetupGroupBox.Controls.Add(attemptWindowLabel);
          passwordSetupGroupBox.Controls.Add(this.m_MinNonAlphanumeric);
          passwordSetupGroupBox.Controls.Add(this.m_MinLength);
          passwordSetupGroupBox.Controls.Add(minLengthLabel);
          passwordSetupGroupBox.Location = new System.Drawing.Point(7, 11);
          passwordSetupGroupBox.Name = "passwordSetupGroupBox";
          passwordSetupGroupBox.Size = new System.Drawing.Size(301, 368);
          passwordSetupGroupBox.TabIndex = 18;
          passwordSetupGroupBox.TabStop = false;
          passwordSetupGroupBox.Text = "Setup";
          // 
          // minLengthLabel
          // 
          minLengthLabel.AutoSize = true;
          minLengthLabel.Location = new System.Drawing.Point(22, 161);
          minLengthLabel.Name = "minLengthLabel";
          minLengthLabel.Size = new System.Drawing.Size(147, 14);
          minLengthLabel.TabIndex = 8;
          minLengthLabel.Text = "Min required length:";
          // 
          // m_MinLength
          // 
          this.m_MinLength.AutoSize = true;
          this.m_MinLength.Location = new System.Drawing.Point(219, 161);
          this.m_MinLength.Name = "m_MinLength";
          this.m_MinLength.Size = new System.Drawing.Size(14, 14);
          this.m_MinLength.TabIndex = 9;
          this.m_MinLength.Text = "0";
          // 
          // m_MinNonAlphanumeric
          // 
          this.m_MinNonAlphanumeric.AutoSize = true;
          this.m_MinNonAlphanumeric.Location = new System.Drawing.Point(219, 125);
          this.m_MinNonAlphanumeric.Name = "m_MinNonAlphanumeric";
          this.m_MinNonAlphanumeric.Size = new System.Drawing.Size(14, 14);
          this.m_MinNonAlphanumeric.TabIndex = 7;
          this.m_MinNonAlphanumeric.Text = "0";
          // 
          // attemptWindowLabel
          // 
          attemptWindowLabel.AutoSize = true;
          attemptWindowLabel.Location = new System.Drawing.Point(22, 197);
          attemptWindowLabel.Name = "attemptWindowLabel";
          attemptWindowLabel.Size = new System.Drawing.Size(112, 14);
          attemptWindowLabel.TabIndex = 10;
          attemptWindowLabel.Text = "Attempt window:";
          // 
          // minNonAlpha
          // 
          minNonAlpha.AutoSize = true;
          minNonAlpha.Location = new System.Drawing.Point(22, 125);
          minNonAlpha.Name = "minNonAlpha";
          minNonAlpha.Size = new System.Drawing.Size(231, 14);
          minNonAlpha.TabIndex = 6;
          minNonAlpha.Text = "Min non-alphanumeric characters:";
          // 
          // m_AttemptWindow
          // 
          this.m_AttemptWindow.AutoSize = true;
          this.m_AttemptWindow.Location = new System.Drawing.Point(219, 197);
          this.m_AttemptWindow.Name = "m_AttemptWindow";
          this.m_AttemptWindow.Size = new System.Drawing.Size(14, 14);
          this.m_AttemptWindow.TabIndex = 11;
          this.m_AttemptWindow.Text = "0";
          // 
          // m_MaxInvalidAttempts
          // 
          this.m_MaxInvalidAttempts.AutoSize = true;
          this.m_MaxInvalidAttempts.Location = new System.Drawing.Point(226, 89);
          this.m_MaxInvalidAttempts.Name = "m_MaxInvalidAttempts";
          this.m_MaxInvalidAttempts.Size = new System.Drawing.Size(14, 14);
          this.m_MaxInvalidAttempts.TabIndex = 5;
          this.m_MaxInvalidAttempts.Text = "0";
          // 
          // passwordRegularExpressionLabel
          // 
          passwordRegularExpressionLabel.AutoSize = true;
          passwordRegularExpressionLabel.Location = new System.Drawing.Point(22, 232);
          passwordRegularExpressionLabel.Name = "passwordRegularExpressionLabel";
          passwordRegularExpressionLabel.Size = new System.Drawing.Size(203, 14);
          passwordRegularExpressionLabel.TabIndex = 12;
          passwordRegularExpressionLabel.Text = "Password regular expression:";
          // 
          // maxInvalidLabel
          // 
          maxInvalidLabel.AutoSize = true;
          maxInvalidLabel.Location = new System.Drawing.Point(22, 89);
          maxInvalidLabel.Name = "maxInvalidLabel";
          maxInvalidLabel.Size = new System.Drawing.Size(203, 14);
          maxInvalidLabel.TabIndex = 4;
          maxInvalidLabel.Text = "Max invalid attempt allowed:";
          // 
          // m_PasswordRegularExpression
          // 
          this.m_PasswordRegularExpression.AutoSize = true;
          this.m_PasswordRegularExpression.Location = new System.Drawing.Point(229, 232);
          this.m_PasswordRegularExpression.Name = "m_PasswordRegularExpression";
          this.m_PasswordRegularExpression.Size = new System.Drawing.Size(14, 14);
          this.m_PasswordRegularExpression.TabIndex = 13;
          this.m_PasswordRegularExpression.Text = "*";
          // 
          // m_PasswordRetrieval
          // 
          this.m_PasswordRetrieval.AutoSize = true;
          this.m_PasswordRetrieval.Location = new System.Drawing.Point(219, 54);
          this.m_PasswordRetrieval.Name = "m_PasswordRetrieval";
          this.m_PasswordRetrieval.Size = new System.Drawing.Size(28, 14);
          this.m_PasswordRetrieval.TabIndex = 3;
          this.m_PasswordRetrieval.Text = "Yes";
          // 
          // requiresQuestionAndAnswerLabel
          // 
          requiresQuestionAndAnswerLabel.AutoSize = true;
          requiresQuestionAndAnswerLabel.Location = new System.Drawing.Point(22, 269);
          requiresQuestionAndAnswerLabel.Name = "requiresQuestionAndAnswerLabel";
          requiresQuestionAndAnswerLabel.Size = new System.Drawing.Size(210, 14);
          requiresQuestionAndAnswerLabel.TabIndex = 14;
          requiresQuestionAndAnswerLabel.Text = "Requires question and answer:";
          // 
          // passwordRetrievalLabel
          // 
          passwordRetrievalLabel.AutoSize = true;
          passwordRetrievalLabel.Location = new System.Drawing.Point(22, 54);
          passwordRetrievalLabel.Name = "passwordRetrievalLabel";
          passwordRetrievalLabel.Size = new System.Drawing.Size(196, 14);
          passwordRetrievalLabel.TabIndex = 2;
          passwordRetrievalLabel.Text = "Password retrieval enabled:";
          // 
          // m_RequiresQuestionAndAnswerLabel
          // 
          this.m_RequiresQuestionAndAnswerLabel.AutoSize = true;
          this.m_RequiresQuestionAndAnswerLabel.Location = new System.Drawing.Point(238, 269);
          this.m_RequiresQuestionAndAnswerLabel.Name = "m_RequiresQuestionAndAnswerLabel";
          this.m_RequiresQuestionAndAnswerLabel.Size = new System.Drawing.Size(28, 14);
          this.m_RequiresQuestionAndAnswerLabel.TabIndex = 15;
          this.m_RequiresQuestionAndAnswerLabel.Text = "Yes";
          // 
          // m_PasswordReset
          // 
          this.m_PasswordReset.AutoSize = true;
          this.m_PasswordReset.Location = new System.Drawing.Point(219, 21);
          this.m_PasswordReset.Name = "m_PasswordReset";
          this.m_PasswordReset.Size = new System.Drawing.Size(28, 14);
          this.m_PasswordReset.TabIndex = 1;
          this.m_PasswordReset.Text = "Yes";
          // 
          // passwordResetLabel
          // 
          passwordResetLabel.AutoSize = true;
          passwordResetLabel.Location = new System.Drawing.Point(22, 21);
          passwordResetLabel.Name = "passwordResetLabel";
          passwordResetLabel.Size = new System.Drawing.Size(168, 14);
          passwordResetLabel.TabIndex = 0;
          passwordResetLabel.Text = "Password reset enabled:";
          // 
          // rolesPage
          // 
          rolesPage.Controls.Add(usersGroupBox);
          rolesPage.Controls.Add(rolesGroupBox);
          rolesPage.Location = new System.Drawing.Point(4, 23);
          rolesPage.Name = "rolesPage";
          rolesPage.Size = new System.Drawing.Size(816, 419);
          rolesPage.TabIndex = 2;
          rolesPage.Text = "Roles";
          rolesPage.UseVisualStyleBackColor = true;
          // 
          // rolesGroupBox
          // 
          rolesGroupBox.Controls.Add(this.m_UsersInRoleComboBox);
          rolesGroupBox.Controls.Add(this.m_RolesListView);
          rolesGroupBox.Controls.Add(this.m_ThrowIfPopulatedCheckBox);
          rolesGroupBox.Controls.Add(this.m_DeleteAllRolesButton);
          rolesGroupBox.Controls.Add(usersInRoleLabel);
          rolesGroupBox.Controls.Add(this.m_CreateRoleButton);
          rolesGroupBox.Controls.Add(this.m_DeleteRoleButton);
          rolesGroupBox.Controls.Add(this.m_PopulatedLabel);
          rolesGroupBox.Location = new System.Drawing.Point(315, 11);
          rolesGroupBox.Name = "rolesGroupBox";
          rolesGroupBox.Size = new System.Drawing.Size(301, 368);
          rolesGroupBox.TabIndex = 0;
          rolesGroupBox.TabStop = false;
          rolesGroupBox.Text = "Roles";
          // 
          // m_PopulatedLabel
          // 
          this.m_PopulatedLabel.AutoSize = true;
          this.m_PopulatedLabel.Location = new System.Drawing.Point(223, 98);
          this.m_PopulatedLabel.Name = "m_PopulatedLabel";
          this.m_PopulatedLabel.Size = new System.Drawing.Size(70, 14);
          this.m_PopulatedLabel.TabIndex = 7;
          this.m_PopulatedLabel.Text = "Populated";
          // 
          // m_DeleteRoleButton
          // 
          this.m_DeleteRoleButton.Location = new System.Drawing.Point(206, 48);
          this.m_DeleteRoleButton.Name = "m_DeleteRoleButton";
          this.m_DeleteRoleButton.Size = new System.Drawing.Size(87, 23);
          this.m_DeleteRoleButton.TabIndex = 1;
          this.m_DeleteRoleButton.Text = "Delete";
          this.m_DeleteRoleButton.Click += new System.EventHandler(this.OnDeleteRole);
          // 
          // m_CreateRoleButton
          // 
          this.m_CreateRoleButton.Location = new System.Drawing.Point(206, 20);
          this.m_CreateRoleButton.Name = "m_CreateRoleButton";
          this.m_CreateRoleButton.Size = new System.Drawing.Size(87, 23);
          this.m_CreateRoleButton.TabIndex = 2;
          this.m_CreateRoleButton.Text = "Create";
          this.m_CreateRoleButton.Click += new System.EventHandler(this.OnCreateRole);
          // 
          // usersInRoleLabel
          // 
          usersInRoleLabel.AutoSize = true;
          usersInRoleLabel.Location = new System.Drawing.Point(7, 325);
          usersInRoleLabel.Name = "usersInRoleLabel";
          usersInRoleLabel.Size = new System.Drawing.Size(105, 14);
          usersInRoleLabel.TabIndex = 4;
          usersInRoleLabel.Text = "Users in Role:";
          // 
          // m_DeleteAllRolesButton
          // 
          this.m_DeleteAllRolesButton.Location = new System.Drawing.Point(206, 286);
          this.m_DeleteAllRolesButton.Name = "m_DeleteAllRolesButton";
          this.m_DeleteAllRolesButton.Size = new System.Drawing.Size(87, 23);
          this.m_DeleteAllRolesButton.TabIndex = 6;
          this.m_DeleteAllRolesButton.Text = "Delete All";
          this.m_DeleteAllRolesButton.Click += new System.EventHandler(this.OnDeleteAllRoles);
          // 
          // m_ThrowIfPopulatedCheckBox
          // 
          this.m_ThrowIfPopulatedCheckBox.AutoSize = true;
          this.m_ThrowIfPopulatedCheckBox.Location = new System.Drawing.Point(206, 77);
          this.m_ThrowIfPopulatedCheckBox.Name = "m_ThrowIfPopulatedCheckBox";
          this.m_ThrowIfPopulatedCheckBox.Size = new System.Drawing.Size(75, 18);
          this.m_ThrowIfPopulatedCheckBox.TabIndex = 2;
          this.m_ThrowIfPopulatedCheckBox.Text = "Fail if";
          // 
          // m_RolesListView
          // 
          this.m_RolesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            rolesHeader});
          this.m_RolesListView.FullRowSelect = true;
          this.m_RolesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_RolesListView.HideSelection = false;
          this.m_RolesListView.Location = new System.Drawing.Point(7, 20);
          this.m_RolesListView.MultiSelect = false;
          this.m_RolesListView.Name = "m_RolesListView";
          this.m_RolesListView.ShowGroups = false;
          this.m_RolesListView.Size = new System.Drawing.Size(192, 290);
          this.m_RolesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_RolesListView.TabIndex = 6;
          this.m_RolesListView.UseCompatibleStateImageBehavior = false;
          this.m_RolesListView.View = System.Windows.Forms.View.SmallIcon;
          this.m_RolesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSelectedRoleChanged);
          // 
          // rolesHeader
          // 
          rolesHeader.Width = 300;
          // 
          // m_UsersInRoleComboBox
          // 
          this.m_UsersInRoleComboBox.FormattingEnabled = true;
          this.m_UsersInRoleComboBox.ImageList = null;
          this.m_UsersInRoleComboBox.Location = new System.Drawing.Point(7, 341);
          this.m_UsersInRoleComboBox.Name = "m_UsersInRoleComboBox";
          this.m_UsersInRoleComboBox.Size = new System.Drawing.Size(192, 21);
          this.m_UsersInRoleComboBox.TabIndex = 5;
          // 
          // usersGroupBox
          // 
          usersGroupBox.Controls.Add(this.m_RolesForUserComboBox);
          usersGroupBox.Controls.Add(this.m_UsersToAssignListView);
          usersGroupBox.Controls.Add(this.m_RemoveUserFromAllRolesButton);
          usersGroupBox.Controls.Add(rolesForUserLabel);
          usersGroupBox.Controls.Add(this.m_RemoveUserFromRoleButton);
          usersGroupBox.Controls.Add(this.m_AssignButton);
          usersGroupBox.Location = new System.Drawing.Point(7, 11);
          usersGroupBox.Name = "usersGroupBox";
          usersGroupBox.Size = new System.Drawing.Size(301, 368);
          usersGroupBox.TabIndex = 1;
          usersGroupBox.TabStop = false;
          usersGroupBox.Text = "Users";
          // 
          // m_AssignButton
          // 
          this.m_AssignButton.Location = new System.Drawing.Point(206, 20);
          this.m_AssignButton.Name = "m_AssignButton";
          this.m_AssignButton.Size = new System.Drawing.Size(87, 23);
          this.m_AssignButton.TabIndex = 1;
          this.m_AssignButton.Text = "Assign";
          this.m_AssignButton.Click += new System.EventHandler(this.OnAssignUserToRole);
          // 
          // m_RemoveUserFromRoleButton
          // 
          this.m_RemoveUserFromRoleButton.Location = new System.Drawing.Point(206, 48);
          this.m_RemoveUserFromRoleButton.Name = "m_RemoveUserFromRoleButton";
          this.m_RemoveUserFromRoleButton.Size = new System.Drawing.Size(87, 23);
          this.m_RemoveUserFromRoleButton.TabIndex = 3;
          this.m_RemoveUserFromRoleButton.Text = "Remove";
          this.m_RemoveUserFromRoleButton.Click += new System.EventHandler(this.OnRemoveUserFromRole);
          // 
          // rolesForUserLabel
          // 
          rolesForUserLabel.AutoSize = true;
          rolesForUserLabel.Location = new System.Drawing.Point(7, 325);
          rolesForUserLabel.Name = "rolesForUserLabel";
          rolesForUserLabel.Size = new System.Drawing.Size(112, 14);
          rolesForUserLabel.TabIndex = 5;
          rolesForUserLabel.Text = "Roles for User:";
          // 
          // m_RemoveUserFromAllRolesButton
          // 
          this.m_RemoveUserFromAllRolesButton.Location = new System.Drawing.Point(206, 77);
          this.m_RemoveUserFromAllRolesButton.Name = "m_RemoveUserFromAllRolesButton";
          this.m_RemoveUserFromAllRolesButton.Size = new System.Drawing.Size(87, 23);
          this.m_RemoveUserFromAllRolesButton.TabIndex = 2;
          this.m_RemoveUserFromAllRolesButton.Text = "Remove All";
          this.m_RemoveUserFromAllRolesButton.Click += new System.EventHandler(this.OnRemoveUsersFromAllRoles);
          // 
          // m_UsersToAssignListView
          // 
          this.m_UsersToAssignListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            userToassignHeader});
          this.m_UsersToAssignListView.FullRowSelect = true;
          this.m_UsersToAssignListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_UsersToAssignListView.HideSelection = false;
          this.m_UsersToAssignListView.Location = new System.Drawing.Point(8, 20);
          this.m_UsersToAssignListView.MultiSelect = false;
          this.m_UsersToAssignListView.Name = "m_UsersToAssignListView";
          this.m_UsersToAssignListView.ShowGroups = false;
          this.m_UsersToAssignListView.Size = new System.Drawing.Size(192, 290);
          this.m_UsersToAssignListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_UsersToAssignListView.TabIndex = 2;
          this.m_UsersToAssignListView.UseCompatibleStateImageBehavior = false;
          this.m_UsersToAssignListView.View = System.Windows.Forms.View.SmallIcon;
          this.m_UsersToAssignListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSelectedUserAssignChanged);
          // 
          // userToassignHeader
          // 
          userToassignHeader.Width = 300;
          // 
          // m_RolesForUserComboBox
          // 
          this.m_RolesForUserComboBox.FormattingEnabled = true;
          this.m_RolesForUserComboBox.ImageList = null;
          this.m_RolesForUserComboBox.Location = new System.Drawing.Point(7, 341);
          this.m_RolesForUserComboBox.Name = "m_RolesForUserComboBox";
          this.m_RolesForUserComboBox.Size = new System.Drawing.Size(192, 21);
          this.m_RolesForUserComboBox.TabIndex = 4;
          // 
          // usersPage
          // 
          usersPage.Controls.Add(usersStatus);
          usersPage.Controls.Add(usersGoupBox);
          usersPage.Location = new System.Drawing.Point(4, 23);
          usersPage.Name = "usersPage";
          usersPage.Padding = new System.Windows.Forms.Padding(3);
          usersPage.Size = new System.Drawing.Size(816, 419);
          usersPage.TabIndex = 1;
          usersPage.Text = "Users";
          usersPage.UseVisualStyleBackColor = true;
          // 
          // usersGoupBox
          // 
          usersGoupBox.Controls.Add(this.m_UsersListView);
          usersGoupBox.Controls.Add(this.m_ChangePasswordButton);
          usersGoupBox.Controls.Add(this.m_ResetPasswordButton);
          usersGoupBox.Controls.Add(this.m_RelatedDataCheckBox);
          usersGoupBox.Controls.Add(this.m_DeleteAllUsersButton);
          usersGoupBox.Controls.Add(this.m_UpdateUser);
          usersGoupBox.Controls.Add(this.m_DeleteUserButton);
          usersGoupBox.Controls.Add(this.m_CreateUserButton);
          usersGoupBox.Location = new System.Drawing.Point(7, 11);
          usersGoupBox.Name = "usersGoupBox";
          usersGoupBox.Size = new System.Drawing.Size(334, 368);
          usersGoupBox.TabIndex = 4;
          usersGoupBox.TabStop = false;
          usersGoupBox.Text = "Users";
          // 
          // m_CreateUserButton
          // 
          this.m_CreateUserButton.Location = new System.Drawing.Point(206, 20);
          this.m_CreateUserButton.Name = "m_CreateUserButton";
          this.m_CreateUserButton.Size = new System.Drawing.Size(120, 23);
          this.m_CreateUserButton.TabIndex = 4;
          this.m_CreateUserButton.Text = "Create...";
          this.m_CreateUserButton.Click += new System.EventHandler(this.OnCreateUser);
          // 
          // m_DeleteUserButton
          // 
          this.m_DeleteUserButton.Location = new System.Drawing.Point(206, 135);
          this.m_DeleteUserButton.Name = "m_DeleteUserButton";
          this.m_DeleteUserButton.Size = new System.Drawing.Size(120, 23);
          this.m_DeleteUserButton.TabIndex = 4;
          this.m_DeleteUserButton.Text = "Delete";
          this.m_DeleteUserButton.Click += new System.EventHandler(this.OnDeleteUser);
          // 
          // m_UpdateUser
          // 
          this.m_UpdateUser.Location = new System.Drawing.Point(206, 48);
          this.m_UpdateUser.Name = "m_UpdateUser";
          this.m_UpdateUser.Size = new System.Drawing.Size(120, 23);
          this.m_UpdateUser.TabIndex = 7;
          this.m_UpdateUser.Text = "Update";
          this.m_UpdateUser.Click += new System.EventHandler(this.OnUpdateUser);
          // 
          // m_DeleteAllUsersButton
          // 
          this.m_DeleteAllUsersButton.Location = new System.Drawing.Point(206, 338);
          this.m_DeleteAllUsersButton.Name = "m_DeleteAllUsersButton";
          this.m_DeleteAllUsersButton.Size = new System.Drawing.Size(120, 23);
          this.m_DeleteAllUsersButton.TabIndex = 8;
          this.m_DeleteAllUsersButton.Text = "Delete All";
          this.m_DeleteAllUsersButton.Click += new System.EventHandler(this.OnDeleteAllUsers);
          // 
          // m_RelatedDataCheckBox
          // 
          this.m_RelatedDataCheckBox.AutoSize = true;
          this.m_RelatedDataCheckBox.Checked = true;
          this.m_RelatedDataCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
          this.m_RelatedDataCheckBox.Location = new System.Drawing.Point(206, 164);
          this.m_RelatedDataCheckBox.Name = "m_RelatedDataCheckBox";
          this.m_RelatedDataCheckBox.Size = new System.Drawing.Size(82, 18);
          this.m_RelatedDataCheckBox.TabIndex = 9;
          this.m_RelatedDataCheckBox.Text = "All Data";
          // 
          // m_ResetPasswordButton
          // 
          this.m_ResetPasswordButton.Location = new System.Drawing.Point(206, 106);
          this.m_ResetPasswordButton.Name = "m_ResetPasswordButton";
          this.m_ResetPasswordButton.Size = new System.Drawing.Size(120, 23);
          this.m_ResetPasswordButton.TabIndex = 11;
          this.m_ResetPasswordButton.Text = "Reset Password";
          this.m_ResetPasswordButton.Click += new System.EventHandler(this.OnResetPassword);
          // 
          // m_ChangePasswordButton
          // 
          this.m_ChangePasswordButton.Location = new System.Drawing.Point(206, 77);
          this.m_ChangePasswordButton.Name = "m_ChangePasswordButton";
          this.m_ChangePasswordButton.Size = new System.Drawing.Size(120, 23);
          this.m_ChangePasswordButton.TabIndex = 12;
          this.m_ChangePasswordButton.Text = "Change Password";
          this.m_ChangePasswordButton.Click += new System.EventHandler(this.OnChangePassword);
          // 
          // m_UsersListView
          // 
          this.m_UsersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            usersHeader});
          this.m_UsersListView.FullRowSelect = true;
          this.m_UsersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_UsersListView.HideSelection = false;
          this.m_UsersListView.Location = new System.Drawing.Point(7, 20);
          this.m_UsersListView.MultiSelect = false;
          this.m_UsersListView.Name = "m_UsersListView";
          this.m_UsersListView.ShowGroups = false;
          this.m_UsersListView.Size = new System.Drawing.Size(192, 342);
          this.m_UsersListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_UsersListView.TabIndex = 10;
          this.m_UsersListView.UseCompatibleStateImageBehavior = false;
          this.m_UsersListView.View = System.Windows.Forms.View.SmallIcon;
          // 
          // usersHeader
          // 
          usersHeader.Width = 300;
          // 
          // usersStatus
          // 
          usersStatus.Controls.Add(this.m_UsersStatusRefresh);
          usersStatus.Controls.Add(this.m_OnlineTimeWindow);
          usersStatus.Controls.Add(onlineTimeWindowLabel);
          usersStatus.Controls.Add(this.m_UsersOnline);
          usersStatus.Controls.Add(onlineUsersLabel);
          usersStatus.Location = new System.Drawing.Point(348, 11);
          usersStatus.Name = "usersStatus";
          usersStatus.Size = new System.Drawing.Size(268, 368);
          usersStatus.TabIndex = 8;
          usersStatus.TabStop = false;
          usersStatus.Text = "Users Status";
          // 
          // onlineUsersLabel
          // 
          onlineUsersLabel.AutoSize = true;
          onlineUsersLabel.Location = new System.Drawing.Point(14, 33);
          onlineUsersLabel.Name = "onlineUsersLabel";
          onlineUsersLabel.Size = new System.Drawing.Size(168, 14);
          onlineUsersLabel.TabIndex = 9;
          onlineUsersLabel.Text = "Number of users online:";
          // 
          // m_UsersOnline
          // 
          this.m_UsersOnline.AutoSize = true;
          this.m_UsersOnline.Location = new System.Drawing.Point(183, 35);
          this.m_UsersOnline.Name = "m_UsersOnline";
          this.m_UsersOnline.Size = new System.Drawing.Size(14, 14);
          this.m_UsersOnline.TabIndex = 10;
          this.m_UsersOnline.Text = "0";
          this.m_UsersOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // onlineTimeWindowLabel
          // 
          onlineTimeWindowLabel.AutoSize = true;
          onlineTimeWindowLabel.Location = new System.Drawing.Point(14, 62);
          onlineTimeWindowLabel.Name = "onlineTimeWindowLabel";
          onlineTimeWindowLabel.Size = new System.Drawing.Size(140, 14);
          onlineTimeWindowLabel.TabIndex = 11;
          onlineTimeWindowLabel.Text = "Online time window:";
          // 
          // m_OnlineTimeWindow
          // 
          this.m_OnlineTimeWindow.AutoSize = true;
          this.m_OnlineTimeWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.m_OnlineTimeWindow.Location = new System.Drawing.Point(161, 62);
          this.m_OnlineTimeWindow.Name = "m_OnlineTimeWindow";
          this.m_OnlineTimeWindow.Size = new System.Drawing.Size(14, 14);
          this.m_OnlineTimeWindow.TabIndex = 12;
          this.m_OnlineTimeWindow.Text = "0";
          // 
          // m_UsersStatusRefresh
          // 
          this.m_UsersStatusRefresh.Location = new System.Drawing.Point(162, 135);
          this.m_UsersStatusRefresh.Name = "m_UsersStatusRefresh";
          this.m_UsersStatusRefresh.Size = new System.Drawing.Size(87, 23);
          this.m_UsersStatusRefresh.TabIndex = 13;
          this.m_UsersStatusRefresh.Text = "Refresh";
          this.m_UsersStatusRefresh.Click += new System.EventHandler(this.OnUserStatusRefresh);
          // 
          // applicationsTab
          // 
          applicationsTab.Controls.Add(applicationPictureBox);
          applicationsTab.Controls.Add(applicationsGroupBox);
          applicationsTab.Location = new System.Drawing.Point(4, 23);
          applicationsTab.Name = "applicationsTab";
          applicationsTab.Padding = new System.Windows.Forms.Padding(3);
          applicationsTab.Size = new System.Drawing.Size(816, 419);
          applicationsTab.TabIndex = 0;
          applicationsTab.Text = "Applications";
          applicationsTab.UseVisualStyleBackColor = true;
          // 
          // applicationsGroupBox
          // 
          applicationsGroupBox.Controls.Add(this.m_ApplicationListView);
          applicationsGroupBox.Controls.Add(this.m_DeleteAllApplicationsButton);
          applicationsGroupBox.Controls.Add(this.m_CreateApplicationButton);
          applicationsGroupBox.Controls.Add(this.m_DeleteApplicationButton);
          applicationsGroupBox.Location = new System.Drawing.Point(7, 11);
          applicationsGroupBox.Name = "applicationsGroupBox";
          applicationsGroupBox.Size = new System.Drawing.Size(301, 368);
          applicationsGroupBox.TabIndex = 11;
          applicationsGroupBox.TabStop = false;
          applicationsGroupBox.Text = "Applications";
          // 
          // m_DeleteApplicationButton
          // 
          this.m_DeleteApplicationButton.Location = new System.Drawing.Point(206, 48);
          this.m_DeleteApplicationButton.Name = "m_DeleteApplicationButton";
          this.m_DeleteApplicationButton.Size = new System.Drawing.Size(87, 23);
          this.m_DeleteApplicationButton.TabIndex = 7;
          this.m_DeleteApplicationButton.Text = "Delete";
          this.m_DeleteApplicationButton.Visible = false;
          this.m_DeleteApplicationButton.Click += new System.EventHandler(this.OnDeleteApplication);
          // 
          // m_CreateApplicationButton
          // 
          this.m_CreateApplicationButton.Location = new System.Drawing.Point(206, 20);
          this.m_CreateApplicationButton.Name = "m_CreateApplicationButton";
          this.m_CreateApplicationButton.Size = new System.Drawing.Size(87, 23);
          this.m_CreateApplicationButton.TabIndex = 4;
          this.m_CreateApplicationButton.Text = "Create";
          this.m_CreateApplicationButton.Visible = false;
          this.m_CreateApplicationButton.Click += new System.EventHandler(this.OnCreateApplication);
          // 
          // m_DeleteAllApplicationsButton
          // 
          this.m_DeleteAllApplicationsButton.Location = new System.Drawing.Point(206, 338);
          this.m_DeleteAllApplicationsButton.Name = "m_DeleteAllApplicationsButton";
          this.m_DeleteAllApplicationsButton.Size = new System.Drawing.Size(87, 23);
          this.m_DeleteAllApplicationsButton.TabIndex = 11;
          this.m_DeleteAllApplicationsButton.Text = "Delete All";
          this.m_DeleteAllApplicationsButton.Visible = false;
          this.m_DeleteAllApplicationsButton.Click += new System.EventHandler(this.OnDeleteAllApplications);
          // 
          // m_ApplicationListView
          // 
          this.m_ApplicationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            applicationsHeader});
          this.m_ApplicationListView.FullRowSelect = true;
          this.m_ApplicationListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_ApplicationListView.HideSelection = false;
          this.m_ApplicationListView.Location = new System.Drawing.Point(7, 20);
          this.m_ApplicationListView.MultiSelect = false;
          this.m_ApplicationListView.Name = "m_ApplicationListView";
          this.m_ApplicationListView.ShowGroups = false;
          this.m_ApplicationListView.Size = new System.Drawing.Size(192, 342);
          this.m_ApplicationListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_ApplicationListView.TabIndex = 12;
          this.m_ApplicationListView.UseCompatibleStateImageBehavior = false;
          this.m_ApplicationListView.View = System.Windows.Forms.View.SmallIcon;
          this.m_ApplicationListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSelectedApplicationChanged);
          // 
          // applicationsHeader
          // 
          applicationsHeader.Width = 390;
          // 
          // applicationPictureBox
          // 
          applicationPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          applicationPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("applicationPictureBox.Image")));
          applicationPictureBox.Location = new System.Drawing.Point(465, 11);
          applicationPictureBox.Name = "applicationPictureBox";
          applicationPictureBox.Size = new System.Drawing.Size(151, 152);
          applicationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
          applicationPictureBox.TabIndex = 12;
          applicationPictureBox.TabStop = false;
          // 
          // tabControl
          // 
          tabControl.Controls.Add(applicationsTab);
          tabControl.Controls.Add(usersPage);
          tabControl.Controls.Add(rolesPage);
          tabControl.Controls.Add(passwordsPage);
          tabControl.Controls.Add(servicePage);
          tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
          tabControl.Location = new System.Drawing.Point(0, 25);
          tabControl.Name = "tabControl";
          tabControl.SelectedIndex = 0;
          tabControl.Size = new System.Drawing.Size(824, 446);
          tabControl.TabIndex = 0;
          // 
          // CredentialsManagerForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
          this.ClientSize = new System.Drawing.Size(824, 471);
          this.Controls.Add(tabControl);
          this.Controls.Add(mainMenu);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MainMenuStrip = mainMenu;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "CredentialsManagerForm";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        
          this.TabText = " IDesign ASP.NET Credentials Manager";
          this.Text = " IDesign ASP.NET Credentials Manager";
          this.Load += new System.EventHandler(this.OnLoad);
          this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
          mainMenu.ResumeLayout(false);
          mainMenu.PerformLayout();
          servicePage.ResumeLayout(false);
          servicePage.PerformLayout();
          addressGroupBox.ResumeLayout(false);
          addressGroupBox.PerformLayout();
          passwordsPage.ResumeLayout(false);
          generatePassorgGroupBox.ResumeLayout(false);
          generatePassorgGroupBox.PerformLayout();
          passwordSetupGroupBox.ResumeLayout(false);
          passwordSetupGroupBox.PerformLayout();
          rolesPage.ResumeLayout(false);
          rolesGroupBox.ResumeLayout(false);
          rolesGroupBox.PerformLayout();
          usersGroupBox.ResumeLayout(false);
          usersGroupBox.PerformLayout();
          usersPage.ResumeLayout(false);
          usersGoupBox.ResumeLayout(false);
          usersGoupBox.PerformLayout();
          usersStatus.ResumeLayout(false);
          usersStatus.PerformLayout();
          applicationsTab.ResumeLayout(false);
          applicationsTab.PerformLayout();
          applicationsGroupBox.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(applicationPictureBox)).EndInit();
          tabControl.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStripMenuItem m_CreateUserMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_DeleteUserMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_UpdateUserMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_CreateRoleMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_DeleteRoleMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_GeneratePasswordMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_LogOnMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_AuthorizeMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_DeleteAllUsersMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_AssignUsertoRoleMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_RemoveUserFromRoleMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_RemoveUserFromAllRolesMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_RefreshUsersStatusMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_DeleteAllRolesMenuItem;
      private System.Windows.Forms.ToolStripMenuItem m_ViewMenuItem;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private ToolStripMenuItem m_ChangePasswordMenuItem;
      private ToolStripMenuItem m_ResetPasswordMenuItem;
      private ToolStripMenuItem m_SelectMenuItem;
      private Button m_SelectButton;
      private WebBrowser m_WebBrowser;
      private TextBox m_AddressTextbox;
      private Button m_ViewButton;
      private Label m_AddressLabel;
      private Label m_PasswordReset;
      private Label m_RequiresQuestionAndAnswerLabel;
      private Label m_PasswordRetrieval;
      private Label m_PasswordRegularExpression;
      private Label m_MaxInvalidAttempts;
      private Label m_AttemptWindow;
      private Label m_MinNonAlphanumeric;
      private Label m_MinLength;
      private TextBox m_LengthTextBox;
      private TextBox m_NonAlphanumericTextBox;
      private Button m_GeneratePassword;
      private ComboBoxEx m_RolesForUserComboBox;
      private ListViewEx m_UsersToAssignListView;
      private Button m_RemoveUserFromAllRolesButton;
      private Button m_RemoveUserFromRoleButton;
      private Button m_AssignButton;
      private ComboBoxEx m_UsersInRoleComboBox;
      private ListViewEx m_RolesListView;
      private CheckBox m_ThrowIfPopulatedCheckBox;
      private Button m_DeleteAllRolesButton;
      private Button m_CreateRoleButton;
      private Button m_DeleteRoleButton;
      private Label m_PopulatedLabel;
      private Button m_UsersStatusRefresh;
      private Label m_OnlineTimeWindow;
      private Label m_UsersOnline;
      private ListViewEx m_UsersListView;
      private Button m_ChangePasswordButton;
      private Button m_ResetPasswordButton;
      private CheckBox m_RelatedDataCheckBox;
      private Button m_DeleteAllUsersButton;
      private Button m_UpdateUser;
      private Button m_DeleteUserButton;
      private Button m_CreateUserButton;
      private ListViewEx m_ApplicationListView;
      private Button m_DeleteAllApplicationsButton;
      private Button m_CreateApplicationButton;
      private Button m_DeleteApplicationButton;
   }
}

