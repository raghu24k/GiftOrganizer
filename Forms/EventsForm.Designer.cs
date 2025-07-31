namespace GiftOrganizer.Forms
{
    partial class EventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.FlowLayoutPanel flowEvents;
        private System.Windows.Forms.ComboBox cmbPeople;
        private System.Windows.Forms.TextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.flowEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbPeople = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddEvent.Location = new System.Drawing.Point(12, 12);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(120, 35);
            this.btnAddEvent.TabIndex = 0;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // cmbPeople
            // 
            this.cmbPeople.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPeople.Location = new System.Drawing.Point(150, 18);
            this.cmbPeople.Name = "cmbPeople";
            this.cmbPeople.Size = new System.Drawing.Size(200, 25);
            this.cmbPeople.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // flowEvents
            // 
            this.flowEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowEvents.AutoScroll = true;
            this.flowEvents.Location = new System.Drawing.Point(12, 60);
            this.flowEvents.Name = "flowEvents";
            this.flowEvents.Size = new System.Drawing.Size(760, 490);
            this.flowEvents.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(370, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.PlaceholderText = "Search events...";
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.flowEvents);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.cmbPeople);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "EventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Events Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
