namespace CredentialsManagerClient
{
   partial class CreateApplicationDialog
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
          System.Windows.Forms.Label applicationLabel;
          System.Windows.Forms.Button createApplicationButton;
          System.Windows.Forms.Button closeButton;
          System.Windows.Forms.ColumnHeader createdUsersHeader;
          System.Windows.Forms.GroupBox createdGroup;
          this.m_CreatedApplicationsListView = new CredentialsManagerClient.ListViewEx();
          this.m_Validator = new System.Windows.Forms.ErrorProvider(this.components);
          this.m_ApplicationTextBox = new System.Windows.Forms.TextBox();
          this.createApplicationGroup = new System.Windows.Forms.GroupBox();
          applicationLabel = new System.Windows.Forms.Label();
          createApplicationButton = new System.Windows.Forms.Button();
          closeButton = new System.Windows.Forms.Button();
          createdUsersHeader = new System.Windows.Forms.ColumnHeader();
          createdGroup = new System.Windows.Forms.GroupBox();
          createdGroup.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_Validator)).BeginInit();
          this.createApplicationGroup.SuspendLayout();
          this.SuspendLayout();
          // 
          // applicationLabel
          // 
          applicationLabel.AutoSize = true;
          applicationLabel.Location = new System.Drawing.Point(10, 18);
          applicationLabel.Name = "applicationLabel";
          applicationLabel.Size = new System.Drawing.Size(77, 12);
          applicationLabel.TabIndex = 0;
          applicationLabel.Text = "Application:";
          // 
          // createApplicationButton
          // 
          createApplicationButton.Location = new System.Drawing.Point(154, 32);
          createApplicationButton.Name = "createApplicationButton";
          createApplicationButton.Size = new System.Drawing.Size(75, 21);
          createApplicationButton.TabIndex = 4;
          createApplicationButton.Text = "Create";
          createApplicationButton.Click += new System.EventHandler(this.OnCreateApplication);
          // 
          // closeButton
          // 
          closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          closeButton.Location = new System.Drawing.Point(163, 229);
          closeButton.Name = "closeButton";
          closeButton.Size = new System.Drawing.Size(75, 21);
          closeButton.TabIndex = 5;
          closeButton.Text = "Close";
          closeButton.Click += new System.EventHandler(this.OnClose);
          // 
          // createdUsersHeader
          // 
          createdUsersHeader.Width = 300;
          // 
          // createdGroup
          // 
          createdGroup.Controls.Add(this.m_CreatedApplicationsListView);
          createdGroup.Location = new System.Drawing.Point(6, 78);
          createdGroup.Name = "createdGroup";
          createdGroup.Size = new System.Drawing.Size(141, 173);
          createdGroup.TabIndex = 16;
          createdGroup.TabStop = false;
          createdGroup.Text = "Created Applications";
          // 
          // m_CreatedApplicationsListView
          // 
          this.m_CreatedApplicationsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            createdUsersHeader});
          this.m_CreatedApplicationsListView.FullRowSelect = true;
          this.m_CreatedApplicationsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.m_CreatedApplicationsListView.Location = new System.Drawing.Point(7, 15);
          this.m_CreatedApplicationsListView.MultiSelect = false;
          this.m_CreatedApplicationsListView.Name = "m_CreatedApplicationsListView";
          this.m_CreatedApplicationsListView.ShowGroups = false;
          this.m_CreatedApplicationsListView.Size = new System.Drawing.Size(125, 153);
          this.m_CreatedApplicationsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
          this.m_CreatedApplicationsListView.TabIndex = 0;
          this.m_CreatedApplicationsListView.UseCompatibleStateImageBehavior = false;
          this.m_CreatedApplicationsListView.View = System.Windows.Forms.View.SmallIcon;
          // 
          // m_Validator
          // 
          this.m_Validator.ContainerControl = this;
          // 
          // m_ApplicationTextBox
          // 
          this.m_ApplicationTextBox.Location = new System.Drawing.Point(11, 33);
          this.m_ApplicationTextBox.Name = "m_ApplicationTextBox";
          this.m_ApplicationTextBox.Size = new System.Drawing.Size(121, 21);
          this.m_ApplicationTextBox.TabIndex = 1;
          // 
          // createApplicationGroup
          // 
          this.createApplicationGroup.Controls.Add(createApplicationButton);
          this.createApplicationGroup.Controls.Add(this.m_ApplicationTextBox);
          this.createApplicationGroup.Controls.Add(applicationLabel);
          this.createApplicationGroup.Location = new System.Drawing.Point(6, 10);
          this.createApplicationGroup.Name = "createApplicationGroup";
          this.createApplicationGroup.Size = new System.Drawing.Size(237, 62);
          this.createApplicationGroup.TabIndex = 17;
          this.createApplicationGroup.TabStop = false;
          this.createApplicationGroup.Text = "New Application:";
          // 
          // CreateApplicationDialog
          // 
          this.AcceptButton = createApplicationButton;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = closeButton;
          this.ClientSize = new System.Drawing.Size(246, 257);
          this.Controls.Add(this.createApplicationGroup);
          this.Controls.Add(createdGroup);
          this.Controls.Add(closeButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "CreateApplicationDialog";
          this.ShowIcon = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "New Application Dialog";
          createdGroup.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.m_Validator)).EndInit();
          this.createApplicationGroup.ResumeLayout(false);
          this.createApplicationGroup.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ErrorProvider m_Validator;
      private System.Windows.Forms.TextBox m_ApplicationTextBox;
      private ListViewEx m_CreatedApplicationsListView;
      private System.Windows.Forms.GroupBox createApplicationGroup;
   }
}