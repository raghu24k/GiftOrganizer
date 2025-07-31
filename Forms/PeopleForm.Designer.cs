namespace GiftOrganizer.Forms
{
    partial class PeopleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.FlowLayoutPanel flowPeople;
        private System.Windows.Forms.TextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.flowPeople = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddPerson.Location = new System.Drawing.Point(12, 12);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(120, 35);
            this.btnAddPerson.TabIndex = 0;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // flowPeople
            // 
            this.flowPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPeople.AutoScroll = true;
            this.flowPeople.Location = new System.Drawing.Point(12, 60);
            this.flowPeople.Name = "flowPeople";
            this.flowPeople.Size = new System.Drawing.Size(760, 490);
            this.flowPeople.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(150, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.PlaceholderText = "Search people...";
            // 
            // PeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flowPeople);
            this.Controls.Add(this.btnAddPerson);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "PeopleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "People Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
