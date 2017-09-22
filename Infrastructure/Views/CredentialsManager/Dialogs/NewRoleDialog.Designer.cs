namespace CredentialsManagerClient
{
   partial class CreateRoleDialog
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
          System.Windows.Forms.Label roleLabel;
          System.Windows.Forms.Button createRoleButton;
          System.Windows.Forms.Button closeButton;
          System.Windows.Forms.GroupBox newRoleGroup;
          System.Windows.Forms.GroupBox createdGroup;
          System.Windows.Forms.ColumnHeader createdUsersHeader;
          this.m_RoleTextBox = new System.Windows.Forms.TextBox();
          this.m_CreatedRolesListView = new CredentialsManagerClient.ListViewEx();
          this.m_RoleValidator = new System.Windows.Forms.ErrorProvider(this.components);
          roleLabel = new System.Windows.Forms.Label();
          createRoleButton = new System.Windows.Forms.Button();
          closeButton = new System.Windows.Forms.Button();
          newRoleGroup = new System.Windows.Forms.GroupBox();
          createdGroup = new System.Windows.Forms.GroupBox();
          createdUsersHeader = new System.Windows.Forms.ColumnHeader();
          newRoleGroup.SuspendLayout();
          createdGroup.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_RoleValidator)).BeginInit();
          this.SuspendLayout();
          // 
          // roleLabel
          // 
          roleLabel.AutoSize = true;
          roleLabel.Location = new System.Drawing.Point(10, 17);
          roleLabel.Name = "roleLabel";
          roleLabel.Size = new System.Drawing.Size(35, 12);
          roleLabel.TabIndex = 0;
          roleLabel.Text = "Role:";
          // 
          // createRoleButton
          // 
          createRoleButton.Location = new System.Drawing.Point(154, 31);
          createRoleButton.Name = "createRoleButton";
          createRoleButton.Size = new System.Drawing.Size(75, 21);
          createRoleButton.TabIndex = 4;
          createRoleButton.Text = "Create Role";
          createRoleButton.Click += new System.EventHandler(this.OnCreateRole);
          // 
          // closeButton
          // 
          closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          closeButton.Location = new System.Drawing.Point(160, 229);
          closeButton.Name = "closeButton";
          closeButton.Size = new System.Drawing.Size(75, 21);
          closeButton.TabIndex = 5;
          closeButton.Text = "Close";
          closeButton.Click += new System.EventHandler(this.OnClosed);
          // 
          // newRoleGroup
          // 
          newRoleGroup.Controls.Add(createRoleButton);
          newRoleGroup.Controls.Add(roleLabel);
          newRoleGroup.Controls.Add(this.m_RoleTextBox);
          newRoleGroup.Location = new System.Drawing.Point(6, 10);
          newRoleGroup.Name = "newRoleGroup";
          newRoleGroup.Size = new System.Drawing.Size(237, 62);
          newRoleGroup.TabIndex = 6;
          newRoleGroup.TabStop = false;
          newRoleGroup.Text = "New Role:";
          // 
          // m_RoleTextBox
          // 
          this.m_RoleTextBox.Location = new System.Drawing.Point(11, 33);
          this.m_RoleTextBox.Name = "m_RoleTextBox";
          this.m_RoleTextBox.Size = new System.Drawing.Size(121, 21);
          this.m_RoleTextBox.TabIndex = 1;
          // 
          // createdGroup
          // 
          createdGroup.Controls.Add(this.m_CreatedRolesListView);
          createdGroup.Location = new System.Drawing.Point(6, 78);
          createdGroup.Name = "createdGroup";
          createdGroup.Size = new System.Drawing.Size(141, 173);
          createdGroup.TabIndex = 17;
          createdGroup.TabStop = false;
          createdGroup.Text = "Created Roles";
          // 
          // m_CreatedRolesListView
          // 
          this.m_CreatedRolesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            createdUsersHeader});
          this.m_CreatedRolesListView.FullRowSelect = true;
          this.m_CreatedRolesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_CreatedRolesListView.Location = new System.Drawing.Point(7, 15);
          this.m_CreatedRolesListView.MultiSelect = false;
          this.m_CreatedRolesListView.Name = "m_CreatedRolesListView";
          this.m_CreatedRolesListView.ShowGroups = false;
          this.m_CreatedRolesListView.Size = new System.Drawing.Size(125, 153);
          this.m_CreatedRolesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_CreatedRolesListView.TabIndex = 0;
          this.m_CreatedRolesListView.UseCompatibleStateImageBehavior = false;
          this.m_CreatedRolesListView.View = System.Windows.Forms.View.SmallIcon;
          // 
          // createdUsersHeader
          // 
          createdUsersHeader.Width = 300;
          // 
          // m_RoleValidator
          // 
          this.m_RoleValidator.ContainerControl = this;
          // 
          // CreateRoleDialog
          // 
          this.AcceptButton = createRoleButton;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = closeButton;
          this.ClientSize = new System.Drawing.Size(248, 258);
          this.Controls.Add(createdGroup);
          this.Controls.Add(newRoleGroup);
          this.Controls.Add(closeButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "CreateRoleDialog";
          this.ShowIcon = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "New Role Dialog";
          newRoleGroup.ResumeLayout(false);
          newRoleGroup.PerformLayout();
          createdGroup.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.m_RoleValidator)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ErrorProvider m_RoleValidator;
      private System.Windows.Forms.TextBox m_RoleTextBox;
      private ListViewEx m_CreatedRolesListView;
   }
}