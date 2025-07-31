namespace GiftOrganizer.Forms
{
    partial class GiftsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddGift;
        private System.Windows.Forms.FlowLayoutPanel flowGifts;
        private System.Windows.Forms.ComboBox cmbPeople;
        private System.Windows.Forms.ComboBox cmbEvents;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkThisMonth;
        private System.Windows.Forms.TextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddGift = new System.Windows.Forms.Button();
            this.flowGifts = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbPeople = new System.Windows.Forms.ComboBox();
            this.cmbEvents = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkThisMonth = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddGift
            // 
            this.btnAddGift.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddGift.Location = new System.Drawing.Point(12, 48);
            this.btnAddGift.Name = "btnAddGift";
            this.btnAddGift.Size = new System.Drawing.Size(120, 35);
            this.btnAddGift.TabIndex = 0;
            this.btnAddGift.Text = "Add Gift";
            this.btnAddGift.UseVisualStyleBackColor = true;
            this.btnAddGift.Click += new System.EventHandler(this.btnAddGift_Click);
            // 
            // cmbPeople
            // 
            this.cmbPeople.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPeople.Location = new System.Drawing.Point(150, 54);
            this.cmbPeople.Name = "cmbPeople";
            this.cmbPeople.Size = new System.Drawing.Size(120, 25);
            this.cmbPeople.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // cmbEvents
            // 
            this.cmbEvents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEvents.Location = new System.Drawing.Point(280, 54);
            this.cmbEvents.Name = "cmbEvents";
            this.cmbEvents.Size = new System.Drawing.Size(120, 25);
            this.cmbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.Location = new System.Drawing.Point(410, 54);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(100, 25);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Items.AddRange(new object[] { "All", "Given", "Planned", "Received" });
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(520, 54);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 25);
            this.txtSearch.PlaceholderText = "Search gifts...";
            // 
            // chkThisMonth
            // 
            this.chkThisMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkThisMonth.Location = new System.Drawing.Point(710, 56);
            this.chkThisMonth.Name = "chkThisMonth";
            this.chkThisMonth.Text = "This Month";
            this.chkThisMonth.AutoSize = true;
            // 
            // flowGifts
            // 
            this.flowGifts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowGifts.AutoScroll = true;
            this.flowGifts.Location = new System.Drawing.Point(12, 90);
            this.flowGifts.Name = "flowGifts";
            this.flowGifts.Size = new System.Drawing.Size(760, 460);
            this.flowGifts.TabIndex = 1;
            // 
            // GiftsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.flowGifts);
            this.Controls.Add(this.btnAddGift);
            this.Controls.Add(this.cmbPeople);
            this.Controls.Add(this.cmbEvents);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkThisMonth);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "GiftsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gifts Manager";
            this.ResumeLayout(false);
        }
    }
}
