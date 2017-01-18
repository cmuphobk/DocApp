namespace ReportsApplication
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Очистка всех занятых ресурсов.
        /// </summary>
        /// <param name="disposing">Значение true, если следует освободить управляемые ресурсы, в противном случае значение false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, формируемый конструктором Windows Form Designer 

        /// <summary>
        /// Обязательный метод для поддержки конструктора Designer, не изменяйте
        /// его содержимое в редакторе кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DocAppDataSet = new ReportsApplication.DocAppDataSet();
            this.WeightsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.WeightsTableAdapter = new ReportsApplication.DocAppDataSetTableAdapters.WeightsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DocAppDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "WeightDataSet";
            reportDataSource1.Value = this.WeightsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // DocAppDataSet
            // 
            this.DocAppDataSet.DataSetName = "DocAppDataSet";
            this.DocAppDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // WeightsBindingSource
            // 
            this.WeightsBindingSource.DataMember = "Weights";
            this.WeightsBindingSource.DataSource = this.DocAppDataSet;
            // 
            // WeightsTableAdapter
            // 
            this.WeightsTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DocAppDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource WeightsBindingSource;
        private DocAppDataSet DocAppDataSet;
        private DocAppDataSetTableAdapters.WeightsTableAdapter WeightsTableAdapter;
    }
}

