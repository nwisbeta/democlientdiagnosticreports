namespace DHEW_DemoFhirClient
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
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
			this.txtNHSno = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFindPatient = new System.Windows.Forms.Button();
			this.btnShowTestResults = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.lstTestResults = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.cboObservations = new System.Windows.Forms.ComboBox();
			this.btnGraph = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblBorn = new System.Windows.Forms.Label();
			this.lblNhsNo = new System.Windows.Forms.Label();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtNHSno
			// 
			this.txtNHSno.Location = new System.Drawing.Point(69, 10);
			this.txtNHSno.Name = "txtNHSno";
			this.txtNHSno.Size = new System.Drawing.Size(203, 20);
			this.txtNHSno.TabIndex = 0;
			this.txtNHSno.Text = "3795624164";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "NHS No:";
			// 
			// btnFindPatient
			// 
			this.btnFindPatient.Location = new System.Drawing.Point(278, 8);
			this.btnFindPatient.Name = "btnFindPatient";
			this.btnFindPatient.Size = new System.Drawing.Size(143, 23);
			this.btnFindPatient.TabIndex = 2;
			this.btnFindPatient.Text = "Find Patient Record";
			this.btnFindPatient.UseVisualStyleBackColor = true;
			this.btnFindPatient.Click += new System.EventHandler(this.btnFindPatient_Click);
			// 
			// btnShowTestResults
			// 
			this.btnShowTestResults.Location = new System.Drawing.Point(427, 8);
			this.btnShowTestResults.Name = "btnShowTestResults";
			this.btnShowTestResults.Size = new System.Drawing.Size(139, 23);
			this.btnShowTestResults.TabIndex = 3;
			this.btnShowTestResults.Text = "Show Test Results";
			this.btnShowTestResults.UseVisualStyleBackColor = true;
			this.btnShowTestResults.Click += new System.EventHandler(this.btnShowTestResults_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(2, 4);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(0, 22);
			this.lblName.TabIndex = 5;
			// 
			// lstTestResults
			// 
			this.lstTestResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lstTestResults.FullRowSelect = true;
			this.lstTestResults.HideSelection = false;
			this.lstTestResults.Location = new System.Drawing.Point(15, 105);
			this.lstTestResults.MultiSelect = false;
			this.lstTestResults.Name = "lstTestResults";
			this.lstTestResults.Size = new System.Drawing.Size(714, 181);
			this.lstTestResults.TabIndex = 6;
			this.lstTestResults.UseCompatibleStateImageBehavior = false;
			this.lstTestResults.View = System.Windows.Forms.View.Details;
			this.lstTestResults.SelectedIndexChanged += new System.EventHandler(this.lstTestResults_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "DiagnosticReportId";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Test(s)";
			this.columnHeader2.Width = 358;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(16, 299);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(712, 303);
			this.panel1.TabIndex = 8;
			// 
			// cboObservations
			// 
			this.cboObservations.Location = new System.Drawing.Point(16, 609);
			this.cboObservations.Name = "cboObservations";
			this.cboObservations.Size = new System.Drawing.Size(256, 21);
			this.cboObservations.TabIndex = 9;
			// 
			// btnGraph
			// 
			this.btnGraph.Location = new System.Drawing.Point(278, 607);
			this.btnGraph.Name = "btnGraph";
			this.btnGraph.Size = new System.Drawing.Size(75, 23);
			this.btnGraph.TabIndex = 10;
			this.btnGraph.Text = "Draw Graph";
			this.btnGraph.UseVisualStyleBackColor = true;
			this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.lblNhsNo);
			this.panel2.Controls.Add(this.lblBorn);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.lblName);
			this.panel2.Location = new System.Drawing.Point(15, 43);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(712, 56);
			this.panel2.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Born";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(239, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "NHS No.";
			// 
			// lblBorn
			// 
			this.lblBorn.AutoSize = true;
			this.lblBorn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBorn.Location = new System.Drawing.Point(39, 33);
			this.lblBorn.Name = "lblBorn";
			this.lblBorn.Size = new System.Drawing.Size(0, 18);
			this.lblBorn.TabIndex = 8;
			// 
			// lblNhsNo
			// 
			this.lblNhsNo.AutoSize = true;
			this.lblNhsNo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNhsNo.Location = new System.Drawing.Point(295, 33);
			this.lblNhsNo.Name = "lblNhsNo";
			this.lblNhsNo.Size = new System.Drawing.Size(0, 18);
			this.lblNhsNo.TabIndex = 9;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Date";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 119;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Organisation";
			this.columnHeader4.Width = 189;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(741, 676);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnGraph);
			this.Controls.Add(this.cboObservations);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lstTestResults);
			this.Controls.Add(this.btnShowTestResults);
			this.Controls.Add(this.btnFindPatient);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNHSno);
			this.Name = "Form1";
			this.Text = "DHEW Demo FHIR client";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtNHSno;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFindPatient;
		private System.Windows.Forms.Button btnShowTestResults;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ListView lstTestResults;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ComboBox cboObservations;
		private System.Windows.Forms.Button btnGraph;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblNhsNo;
		private System.Windows.Forms.Label lblBorn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
	}
}

