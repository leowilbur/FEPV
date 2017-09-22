namespace CredentialsManagerClient
{
   partial class CreateUserDialog
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
          this.components = new System.ComponentModel.Container();
          System.Windows.Forms.GroupBox createdGroup;
          System.Windows.Forms.ColumnHeader createdUsersHeader;
          System.Windows.Forms.GroupBox userGroup;
          System.Windows.Forms.Button createUserButton;
          System.Windows.Forms.Label securityAnswerLabel;
          System.Windows.Forms.Label securityQuestionLabel;
          System.Windows.Forms.Label emailLabel;
          System.Windows.Forms.Label confirmedPasswordLabel;
          System.Windows.Forms.Label passwordLabel;
          System.Windows.Forms.Label userNameLabel;
          System.Windows.Forms.Button closeButton;
          this.m_CreatedUsersListView = new CredentialsManagerClient.ListViewEx();
          this.m_ActiveUserCheckBox = new System.Windows.Forms.CheckBox();
          this.m_SecurityAnswerTextbox = new System.Windows.Forms.TextBox();
          this.m_SecurityQuestionTextBox = new System.Windows.Forms.TextBox();
          this.m_EmailTextBox = new System.Windows.Forms.TextBox();
          this.m_ConfirmedPasswordTextBox = new System.Windows.Forms.TextBox();
          this.m_PasswordTextbox = new System.Windows.Forms.TextBox();
          this.m_UserNameTextBox = new System.Windows.Forms.TextBox();
          this.m_GeneratePasswordCheckBox = new System.Windows.Forms.CheckBox();
          this.m_Validator = new System.Windows.Forms.ErrorProvider(this.components);
          createdGroup = new System.Windows.Forms.GroupBox();
          createdUsersHeader = new System.Windows.Forms.ColumnHeader();
          userGroup = new System.Windows.Forms.GroupBox();
          createUserButton = new System.Windows.Forms.Button();
          securityAnswerLabel = new System.Windows.Forms.Label();
          securityQuestionLabel = new System.Windows.Forms.Label();
          emailLabel = new System.Windows.Forms.Label();
          confirmedPasswordLabel = new System.Windows.Forms.Label();
          passwordLabel = new System.Windows.Forms.Label();
          userNameLabel = new System.Windows.Forms.Label();
          closeButton = new System.Windows.Forms.Button();
          createdGroup.SuspendLayout();
          userGroup.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_Validator)).BeginInit();
          this.SuspendLayout();
          // 
          // createdGroup
          // 
          createdGroup.Controls.Add(this.m_CreatedUsersListView);
          createdGroup.Location = new System.Drawing.Point(6, 271);
          createdGroup.Name = "createdGroup";
          createdGroup.Size = new System.Drawing.Size(141, 173);
          createdGroup.TabIndex = 15;
          createdGroup.TabStop = false;
          createdGroup.Text = "Created Users";
          // 
          // m_CreatedUsersListView
          // 
          this.m_CreatedUsersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            createdUsersHeader});
          this.m_CreatedUsersListView.FullRowSelect = true;
          this.m_CreatedUsersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_CreatedUsersListView.Location = new System.Drawing.Point(6, 18);
          this.m_CreatedUsersListView.MultiSelect = false;
          this.m_CreatedUsersListView.Name = "m_CreatedUsersListView";
          this.m_CreatedUsersListView.ShowGroups = false;
          this.m_CreatedUsersListView.Size = new System.Drawing.Size(129, 153);
          this.m_CreatedUsersListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_CreatedUsersListView.TabIndex = 0;
          this.m_CreatedUsersListView.UseCompatibleStateImageBehavior = false;
          this.m_CreatedUsersListView.View = System.Windows.Forms.View.SmallIcon;
          // 
          // createdUsersHeader
          // 
          createdUsersHeader.Width = 300;
          // 
          // userGroup
          // 
          userGroup.Controls.Add(createUserButton);
          userGroup.Controls.Add(this.m_ActiveUserCheckBox);
          userGroup.Controls.Add(this.m_SecurityAnswerTextbox);
          userGroup.Controls.Add(securityAnswerLabel);
          userGroup.Controls.Add(this.m_SecurityQuestionTextBox);
          userGroup.Controls.Add(securityQuestionLabel);
          userGroup.Controls.Add(this.m_EmailTextBox);
          userGroup.Controls.Add(emailLabel);
          userGroup.Controls.Add(this.m_ConfirmedPasswordTextBox);
          userGroup.Controls.Add(confirmedPasswordLabel);
          userGroup.Controls.Add(this.m_PasswordTextbox);
          userGroup.Controls.Add(passwordLabel);
          userGroup.Controls.Add(this.m_UserNameTextBox);
          userGroup.Controls.Add(userNameLabel);
          userGroup.Controls.Add(this.m_GeneratePasswordCheckBox);
          userGroup.Location = new System.Drawing.Point(6, 10);
          userGroup.Name = "userGroup";
          userGroup.Size = new System.Drawing.Size(309, 256);
          userGroup.TabIndex = 1;
          userGroup.TabStop = false;
          userGroup.Text = "User Account:";
          // 
          // createUserButton
          // 
          createUserButton.Location = new System.Drawing.Point(177, 69);
          createUserButton.Name = "createUserButton";
          createUserButton.Size = new System.Drawing.Size(75, 21);
          createUserButton.TabIndex = 4;
          createUserButton.Text = "Create User";
          createUserButton.Click += new System.EventHandler(this.OnCreateUser);
          // 
          // m_ActiveUserCheckBox
          // 
          this.m_ActiveUserCheckBox.AutoSize = true;
          this.m_ActiveUserCheckBox.Checked = true;
          this.m_ActiveUserCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
          this.m_ActiveUserCheckBox.Location = new System.Drawing.Point(177, 27);
          this.m_ActiveUserCheckBox.Name = "m_ActiveUserCheckBox";
          this.m_ActiveUserCheckBox.Size = new System.Drawing.Size(90, 16);
          this.m_ActiveUserCheckBox.TabIndex = 12;
          this.m_ActiveUserCheckBox.Text = "Active User";
          // 
          // m_SecurityAnswerTextbox
          // 
          this.m_SecurityAnswerTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
          this.m_SecurityAnswerTextbox.Location = new System.Drawing.Point(6, 227);
          this.m_SecurityAnswerTextbox.Name = "m_SecurityAnswerTextbox";
          this.m_SecurityAnswerTextbox.Size = new System.Drawing.Size(135, 21);
          this.m_SecurityAnswerTextbox.TabIndex = 11;
          // 
          // securityAnswerLabel
          // 
          securityAnswerLabel.AutoSize = true;
          securityAnswerLabel.Location = new System.Drawing.Point(5, 212);
          securityAnswerLabel.Name = "securityAnswerLabel";
          securityAnswerLabel.Size = new System.Drawing.Size(71, 12);
          securityAnswerLabel.TabIndex = 10;
          securityAnswerLabel.Text = "Department:";
          // 
          // m_SecurityQuestionTextBox
          // 
          this.m_SecurityQuestionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
          this.m_SecurityQuestionTextBox.Location = new System.Drawing.Point(6, 187);
          this.m_SecurityQuestionTextBox.Name = "m_SecurityQuestionTextBox";
          this.m_SecurityQuestionTextBox.Size = new System.Drawing.Size(135, 21);
          this.m_SecurityQuestionTextBox.TabIndex = 9;
          // 
          // securityQuestionLabel
          // 
          securityQuestionLabel.AutoSize = true;
          securityQuestionLabel.Location = new System.Drawing.Point(8, 173);
          securityQuestionLabel.Name = "securityQuestionLabel";
          securityQuestionLabel.Size = new System.Drawing.Size(83, 12);
          securityQuestionLabel.TabIndex = 8;
          securityQuestionLabel.Text = "Chinese Name:";
          // 
          // m_EmailTextBox
          // 
          this.m_EmailTextBox.Location = new System.Drawing.Point(6, 145);
          this.m_EmailTextBox.Name = "m_EmailTextBox";
          this.m_EmailTextBox.Size = new System.Drawing.Size(246, 21);
          this.m_EmailTextBox.TabIndex = 7;
          // 
          // emailLabel
          // 
          emailLabel.AutoSize = true;
          emailLabel.Location = new System.Drawing.Point(5, 130);
          emailLabel.Name = "emailLabel";
          emailLabel.Size = new System.Drawing.Size(47, 12);
          emailLabel.TabIndex = 6;
          emailLabel.Text = "E-mail:";
          // 
          // m_ConfirmedPasswordTextBox
          // 
          this.m_ConfirmedPasswordTextBox.Location = new System.Drawing.Point(6, 105);
          this.m_ConfirmedPasswordTextBox.Name = "m_ConfirmedPasswordTextBox";
          this.m_ConfirmedPasswordTextBox.PasswordChar = '*';
          this.m_ConfirmedPasswordTextBox.Size = new System.Drawing.Size(135, 21);
          this.m_ConfirmedPasswordTextBox.TabIndex = 5;
          // 
          // confirmedPasswordLabel
          // 
          confirmedPasswordLabel.AutoSize = true;
          confirmedPasswordLabel.Location = new System.Drawing.Point(5, 90);
          confirmedPasswordLabel.Name = "confirmedPasswordLabel";
          confirmedPasswordLabel.Size = new System.Drawing.Size(107, 12);
          confirmedPasswordLabel.TabIndex = 4;
          confirmedPasswordLabel.Text = "Confirm Password:";
          // 
          // m_PasswordTextbox
          // 
          this.m_PasswordTextbox.Location = new System.Drawing.Point(6, 66);
          this.m_PasswordTextbox.Name = "m_PasswordTextbox";
          this.m_PasswordTextbox.PasswordChar = '*';
          this.m_PasswordTextbox.Size = new System.Drawing.Size(135, 21);
          this.m_PasswordTextbox.TabIndex = 3;
          // 
          // passwordLabel
          // 
          passwordLabel.AutoSize = true;
          passwordLabel.Location = new System.Drawing.Point(5, 52);
          passwordLabel.Name = "passwordLabel";
          passwordLabel.Size = new System.Drawing.Size(59, 12);
          passwordLabel.TabIndex = 2;
          passwordLabel.Text = "Password:";
          // 
          // m_UserNameTextBox
          // 
          this.m_UserNameTextBox.Location = new System.Drawing.Point(6, 28);
          this.m_UserNameTextBox.Name = "m_UserNameTextBox";
          this.m_UserNameTextBox.Size = new System.Drawing.Size(135, 21);
          this.m_UserNameTextBox.TabIndex = 1;
          // 
          // userNameLabel
          // 
          userNameLabel.AutoSize = true;
          userNameLabel.Location = new System.Drawing.Point(5, 13);
          userNameLabel.Name = "userNameLabel";
          userNameLabel.Size = new System.Drawing.Size(53, 12);
          userNameLabel.TabIndex = 0;
          userNameLabel.Text = "User ID:";
          // 
          // m_GeneratePasswordCheckBox
          // 
          this.m_GeneratePasswordCheckBox.AutoSize = true;
          this.m_GeneratePasswordCheckBox.Location = new System.Drawing.Point(177, 48);
          this.m_GeneratePasswordCheckBox.Name = "m_GeneratePasswordCheckBox";
          this.m_GeneratePasswordCheckBox.Size = new System.Drawing.Size(126, 16);
          this.m_GeneratePasswordCheckBox.TabIndex = 14;
          this.m_GeneratePasswordCheckBox.Text = "Generate Password";
          this.m_GeneratePasswordCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
          // 
          // closeButton
          // 
          closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          closeButton.Location = new System.Drawing.Point(201, 423);
          closeButton.Name = "closeButton";
          closeButton.Size = new System.Drawing.Size(75, 21);
          closeButton.TabIndex = 13;
          closeButton.Text = "Close";
          closeButton.Click += new System.EventHandler(this.OnClose);
          // 
          // m_Validator
          // 
          this.m_Validator.ContainerControl = this;
          // 
          // CreateUserDialog
          // 
          this.AcceptButton = createUserButton;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = closeButton;
          this.ClientSize = new System.Drawing.Size(327, 447);
          this.Controls.Add(createdGroup);
          this.Controls.Add(userGroup);
          this.Controls.Add(closeButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "CreateUserDialog";
          this.ShowIcon = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "New User Dialog";
          this.Load += new System.EventHandler(this.CreateUserDialog_Load);
          createdGroup.ResumeLayout(false);
          userGroup.ResumeLayout(false);
          userGroup.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_Validator)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox m_ActiveUserCheckBox;
      private System.Windows.Forms.TextBox m_SecurityAnswerTextbox;
      private System.Windows.Forms.TextBox m_SecurityQuestionTextBox;
      private System.Windows.Forms.TextBox m_EmailTextBox;
      private System.Windows.Forms.TextBox m_ConfirmedPasswordTextBox;
      private System.Windows.Forms.TextBox m_PasswordTextbox;
      private System.Windows.Forms.TextBox m_UserNameTextBox;
      private System.Windows.Forms.ErrorProvider m_Validator;
      private System.Windows.Forms.CheckBox m_GeneratePasswordCheckBox;
      ListViewEx m_CreatedUsersListView;
   }
}