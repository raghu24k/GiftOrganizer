namespace GiftOrganizer.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowEvents;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.FlowLayoutPanel flowPlannedGifts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peopleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giftsMenuItem;
        private System.Windows.Forms.Label lblEventsSection;
        private System.Windows.Forms.Label lblPlannedGiftsSection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.flowPlannedGifts = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.peopleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giftsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEventsSection = new System.Windows.Forms.Label();
            this.lblPlannedGiftsSection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowEvents
            // 
            this.flowEvents.Location = new System.Drawing.Point(20, 56);
            this.flowEvents.Name = "flowEvents";
            this.flowEvents.Size = new System.Drawing.Size(350, 200);
            this.flowEvents.TabIndex = 0;
            // 
            // lblTotalSpent
            // 
            this.lblTotalSpent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalSpent.Location = new System.Drawing.Point(400, 56);
            this.lblTotalSpent.Name = "lblTotalSpent";
            this.lblTotalSpent.Size = new System.Drawing.Size(350, 40);
            this.lblTotalSpent.TabIndex = 1;
            this.lblTotalSpent.Text = "Total Spent This Month: ?0.00";
            // 
            // flowPlannedGifts
            // 
            this.flowPlannedGifts.Location = new System.Drawing.Point(20, 276);
            this.flowPlannedGifts.Name = "flowPlannedGifts";
            this.flowPlannedGifts.Size = new System.Drawing.Size(730, 200);
            this.flowPlannedGifts.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleMenuItem,
            this.eventsMenuItem,
            this.giftsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // peopleMenuItem
            // 
            this.peopleMenuItem.Name = "peopleMenuItem";
            this.peopleMenuItem.Size = new System.Drawing.Size(65, 24);
            this.peopleMenuItem.Text = "People";
            // 
            // eventsMenuItem
            // 
            this.eventsMenuItem.Name = "eventsMenuItem";
            this.eventsMenuItem.Size = new System.Drawing.Size(62, 24);
            this.eventsMenuItem.Text = "Events";
            // 
            // giftsMenuItem
            // 
            this.giftsMenuItem.Name = "giftsMenuItem";
            this.giftsMenuItem.Size = new System.Drawing.Size(52, 24);
            this.giftsMenuItem.Text = "Gifts";
            // 
            // lblEventsSection
            // 
            this.lblEventsSection.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEventsSection.Location = new System.Drawing.Point(20, 36);
            this.lblEventsSection.Name = "lblEventsSection";
            this.lblEventsSection.Size = new System.Drawing.Size(350, 20);
            this.lblEventsSection.Text = "Upcoming Events";
            // 
            // lblPlannedGiftsSection
            // 
            this.lblPlannedGiftsSection.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPlannedGiftsSection.Location = new System.Drawing.Point(20, 256);
            this.lblPlannedGiftsSection.Name = "lblPlannedGiftsSection";
            this.lblPlannedGiftsSection.Size = new System.Drawing.Size(350, 20);
            this.lblPlannedGiftsSection.Text = "Planned Gifts";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.lblPlannedGiftsSection);
            this.Controls.Add(this.lblEventsSection);
            this.Controls.Add(this.flowPlannedGifts);
            this.Controls.Add(this.lblTotalSpent);
            this.Controls.Add(this.flowEvents);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Organizer Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
