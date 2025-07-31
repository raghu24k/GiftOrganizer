namespace GiftOrganizer.Forms
{
    partial class AddGiftForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbPeople;
        private System.Windows.Forms.ComboBox cmbEvents;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbPeople = new System.Windows.Forms.ComboBox();
            this.cmbEvents = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Add/Edit Gift";
            this.lblTitle.AutoSize = true;
            // 
            // cmbPeople
            // 
            this.cmbPeople.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPeople.Location = new System.Drawing.Point(30, 60);
            this.cmbPeople.Name = "cmbPeople";
            this.cmbPeople.Size = new System.Drawing.Size(280, 25);
            this.cmbPeople.DropDownWidth = 320;
            this.cmbPeople.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPeople.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            // 
            // cmbEvents
            // 
            this.cmbEvents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEvents.Location = new System.Drawing.Point(30, 100);
            this.cmbEvents.Name = "cmbEvents";
            this.cmbEvents.Size = new System.Drawing.Size(280, 25);
            this.cmbEvents.DropDownWidth = 320;
            this.cmbEvents.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEvents.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(30, 140);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Gift name";
            this.txtName.Size = new System.Drawing.Size(280, 25);
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.Location = new System.Drawing.Point(30, 180);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(280, 25);
            this.cmbType.Items.AddRange(new object[] { "Given", "Planned", "Received" });
            // 
            // txtCost
            // 
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCost.Location = new System.Drawing.Point(30, 220);
            this.txtCost.Name = "txtCost";
            this.txtCost.PlaceholderText = "Cost (₹)";
            this.txtCost.Size = new System.Drawing.Size(280, 25);
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(30, 260);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "Notes (optional)";
            this.txtNotes.Size = new System.Drawing.Size(280, 60);
            // 
            // txtImage
            // 
            this.txtImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImage.Location = new System.Drawing.Point(30, 330);
            this.txtImage.Name = "txtImage";
            this.txtImage.PlaceholderText = "Image path (optional)";
            this.txtImage.Size = new System.Drawing.Size(200, 25);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(240, 330);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(70, 25);
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(30, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(280, 35);
            this.btnSave.Text = "Save Gift";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddGiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(350, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbEvents);
            this.Controls.Add(this.cmbPeople);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddGiftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Gift";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
