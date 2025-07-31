namespace GiftOrganizer.Forms
{
    partial class AddEventForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbPeople;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbPeople = new ComboBox();
            txtName = new TextBox();
            dtpDate = new DateTimePicker();
            chkReminder = new CheckBox();
            btnSave = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // cmbPeople
            // 
            cmbPeople.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPeople.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPeople.DropDownWidth = 320;
            cmbPeople.Font = new Font("Segoe UI", 10F);
            cmbPeople.Location = new Point(34, 80);
            cmbPeople.Margin = new Padding(3, 4, 3, 4);
            cmbPeople.Name = "cmbPeople";
            cmbPeople.Size = new Size(320, 31);
            cmbPeople.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(34, 133);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Event name";
            txtName.Size = new Size(319, 30);
            txtName.TabIndex = 4;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Location = new Point(34, 187);
            dtpDate.Margin = new Padding(3, 4, 3, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(319, 30);
            dtpDate.TabIndex = 3;
            // 
            // chkReminder
            // 
            chkReminder.AutoSize = true;
            chkReminder.Font = new Font("Segoe UI", 10F);
            chkReminder.Location = new Point(34, 240);
            chkReminder.Margin = new Padding(3, 4, 3, 4);
            chkReminder.Name = "chkReminder";
            chkReminder.Size = new Size(134, 27);
            chkReminder.TabIndex = 2;
            chkReminder.Text = "Set Reminder";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Location = new Point(34, 293);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(320, 47);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save Event";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(34, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(155, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add/Edit Event";
            // 
            // AddEventForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(400, 373);
            Controls.Add(lblTitle);
            Controls.Add(btnSave);
            Controls.Add(chkReminder);
            Controls.Add(dtpDate);
            Controls.Add(txtName);
            Controls.Add(cmbPeople);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddEventForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Event";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
