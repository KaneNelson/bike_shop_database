
namespace DBFrontEndStockSide
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BrandTextBox = new System.Windows.Forms.TextBox();
            this.AddBrandButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerPurchasesTextBox = new System.Windows.Forms.TextBox();
            this.ShowStaffTotalSalesButton = new System.Windows.Forms.Button();
            this.StaffOrdersTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.ProductBrandComboBox = new System.Windows.Forms.ComboBox();
            this.ProductCategoryDropBox = new System.Windows.Forms.ComboBox();
            this.ProductYearTextBox = new System.Windows.Forms.TextBox();
            this.ProductPriceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ProductNameComboBox = new System.Windows.Forms.ComboBox();
            this.StoreComboBox = new System.Windows.Forms.ComboBox();
            this.QtyTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.IncreaseQtyButton = new System.Windows.Forms.Button();
            this.ShowCustPurchasesButton = new System.Windows.Forms.Button();
            this.ShowStaffOrdersButton = new System.Windows.Forms.Button();
            this.StaffSalesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.StaffSalesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // BrandTextBox
            // 
            this.BrandTextBox.Location = new System.Drawing.Point(83, 29);
            this.BrandTextBox.Name = "BrandTextBox";
            this.BrandTextBox.Size = new System.Drawing.Size(129, 22);
            this.BrandTextBox.TabIndex = 0;
            this.BrandTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AddBrandButton
            // 
            this.AddBrandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AddBrandButton.Location = new System.Drawing.Point(42, 57);
            this.AddBrandButton.Name = "AddBrandButton";
            this.AddBrandButton.Size = new System.Drawing.Size(120, 29);
            this.AddBrandButton.TabIndex = 1;
            this.AddBrandButton.Text = "Add Brand";
            this.AddBrandButton.UseVisualStyleBackColor = true;
            this.AddBrandButton.Click += new System.EventHandler(this.AddBrandButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brand:";
            // 
            // CustomerPurchasesTextBox
            // 
            this.CustomerPurchasesTextBox.Location = new System.Drawing.Point(802, 26);
            this.CustomerPurchasesTextBox.Multiline = true;
            this.CustomerPurchasesTextBox.Name = "CustomerPurchasesTextBox";
            this.CustomerPurchasesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CustomerPurchasesTextBox.Size = new System.Drawing.Size(331, 265);
            this.CustomerPurchasesTextBox.TabIndex = 4;
            this.CustomerPurchasesTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // ShowStaffTotalSalesButton
            // 
            this.ShowStaffTotalSalesButton.Location = new System.Drawing.Point(672, 373);
            this.ShowStaffTotalSalesButton.Name = "ShowStaffTotalSalesButton";
            this.ShowStaffTotalSalesButton.Size = new System.Drawing.Size(123, 45);
            this.ShowStaffTotalSalesButton.TabIndex = 5;
            this.ShowStaffTotalSalesButton.Text = "Show Staff\'s Total Sales";
            this.ShowStaffTotalSalesButton.UseVisualStyleBackColor = true;
            this.ShowStaffTotalSalesButton.Click += new System.EventHandler(this.ShowStaffTotalSalesButton_Click);
            // 
            // StaffOrdersTextBox
            // 
            this.StaffOrdersTextBox.Location = new System.Drawing.Point(802, 319);
            this.StaffOrdersTextBox.Multiline = true;
            this.StaffOrdersTextBox.Name = "StaffOrdersTextBox";
            this.StaffOrdersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.StaffOrdersTextBox.Size = new System.Drawing.Size(331, 286);
            this.StaffOrdersTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(183, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Add New Product:";
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Location = new System.Drawing.Point(10, 212);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.ProductNameTextBox.TabIndex = 8;
            // 
            // ProductBrandComboBox
            // 
            this.ProductBrandComboBox.FormattingEnabled = true;
            this.ProductBrandComboBox.Location = new System.Drawing.Point(128, 212);
            this.ProductBrandComboBox.Name = "ProductBrandComboBox";
            this.ProductBrandComboBox.Size = new System.Drawing.Size(121, 24);
            this.ProductBrandComboBox.TabIndex = 9;
            // 
            // ProductCategoryDropBox
            // 
            this.ProductCategoryDropBox.FormattingEnabled = true;
            this.ProductCategoryDropBox.Location = new System.Drawing.Point(255, 212);
            this.ProductCategoryDropBox.Name = "ProductCategoryDropBox";
            this.ProductCategoryDropBox.Size = new System.Drawing.Size(121, 24);
            this.ProductCategoryDropBox.TabIndex = 10;
            // 
            // ProductYearTextBox
            // 
            this.ProductYearTextBox.Location = new System.Drawing.Point(382, 212);
            this.ProductYearTextBox.Name = "ProductYearTextBox";
            this.ProductYearTextBox.Size = new System.Drawing.Size(66, 22);
            this.ProductYearTextBox.TabIndex = 11;
            // 
            // ProductPriceTextBox
            // 
            this.ProductPriceTextBox.Location = new System.Drawing.Point(454, 212);
            this.ProductPriceTextBox.Name = "ProductPriceTextBox";
            this.ProductPriceTextBox.Size = new System.Drawing.Size(100, 22);
            this.ProductPriceTextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(6, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Product Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(128, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Brand";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(251, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(378, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(450, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Price";
            // 
            // AddProductButton
            // 
            this.AddProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AddProductButton.Location = new System.Drawing.Point(209, 260);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(100, 31);
            this.AddProductButton.TabIndex = 18;
            this.AddProductButton.Text = "Add Product";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(170, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Increase Qty:";
            // 
            // ProductNameComboBox
            // 
            this.ProductNameComboBox.FormattingEnabled = true;
            this.ProductNameComboBox.Location = new System.Drawing.Point(22, 396);
            this.ProductNameComboBox.Name = "ProductNameComboBox";
            this.ProductNameComboBox.Size = new System.Drawing.Size(121, 24);
            this.ProductNameComboBox.TabIndex = 20;
            // 
            // StoreComboBox
            // 
            this.StoreComboBox.FormattingEnabled = true;
            this.StoreComboBox.Location = new System.Drawing.Point(158, 396);
            this.StoreComboBox.Name = "StoreComboBox";
            this.StoreComboBox.Size = new System.Drawing.Size(121, 24);
            this.StoreComboBox.TabIndex = 21;
            // 
            // QtyTextBox
            // 
            this.QtyTextBox.Location = new System.Drawing.Point(301, 396);
            this.QtyTextBox.Name = "QtyTextBox";
            this.QtyTextBox.Size = new System.Drawing.Size(47, 22);
            this.QtyTextBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(18, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Product Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(154, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Store";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(297, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Qty";
            // 
            // IncreaseQtyButton
            // 
            this.IncreaseQtyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.IncreaseQtyButton.Location = new System.Drawing.Point(174, 450);
            this.IncreaseQtyButton.Name = "IncreaseQtyButton";
            this.IncreaseQtyButton.Size = new System.Drawing.Size(104, 28);
            this.IncreaseQtyButton.TabIndex = 26;
            this.IncreaseQtyButton.Text = "Increase Qty";
            this.IncreaseQtyButton.UseVisualStyleBackColor = true;
            this.IncreaseQtyButton.Click += new System.EventHandler(this.IncreaseQtyButton_Click);
            // 
            // ShowCustPurchasesButton
            // 
            this.ShowCustPurchasesButton.Location = new System.Drawing.Point(672, 29);
            this.ShowCustPurchasesButton.Name = "ShowCustPurchasesButton";
            this.ShowCustPurchasesButton.Size = new System.Drawing.Size(123, 49);
            this.ShowCustPurchasesButton.TabIndex = 27;
            this.ShowCustPurchasesButton.Text = "Show Customer Purchases";
            this.ShowCustPurchasesButton.UseVisualStyleBackColor = true;
            this.ShowCustPurchasesButton.Click += new System.EventHandler(this.ShowCustPurchasesButton_Click);
            // 
            // ShowStaffOrdersButton
            // 
            this.ShowStaffOrdersButton.Location = new System.Drawing.Point(672, 319);
            this.ShowStaffOrdersButton.Name = "ShowStaffOrdersButton";
            this.ShowStaffOrdersButton.Size = new System.Drawing.Size(123, 45);
            this.ShowStaffOrdersButton.TabIndex = 28;
            this.ShowStaffOrdersButton.Text = "Show Staff\'s Orders";
            this.ShowStaffOrdersButton.UseVisualStyleBackColor = true;
            this.ShowStaffOrdersButton.Click += new System.EventHandler(this.ShowStaffOrdersButton_Click);
            // 
            // StaffSalesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.StaffSalesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.StaffSalesChart.Legends.Add(legend1);
            this.StaffSalesChart.Location = new System.Drawing.Point(357, 443);
            this.StaffSalesChart.Name = "StaffSalesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.StaffSalesChart.Series.Add(series1);
            this.StaffSalesChart.Size = new System.Drawing.Size(374, 322);
            this.StaffSalesChart.TabIndex = 29;
            this.StaffSalesChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 823);
            this.Controls.Add(this.StaffSalesChart);
            this.Controls.Add(this.ShowStaffOrdersButton);
            this.Controls.Add(this.ShowCustPurchasesButton);
            this.Controls.Add(this.IncreaseQtyButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.QtyTextBox);
            this.Controls.Add(this.StoreComboBox);
            this.Controls.Add(this.ProductNameComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductPriceTextBox);
            this.Controls.Add(this.ProductYearTextBox);
            this.Controls.Add(this.ProductCategoryDropBox);
            this.Controls.Add(this.ProductBrandComboBox);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StaffOrdersTextBox);
            this.Controls.Add(this.ShowStaffTotalSalesButton);
            this.Controls.Add(this.CustomerPurchasesTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddBrandButton);
            this.Controls.Add(this.BrandTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.StaffSalesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BrandTextBox;
        private System.Windows.Forms.Button AddBrandButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CustomerPurchasesTextBox;
        private System.Windows.Forms.Button ShowStaffTotalSalesButton;
        private System.Windows.Forms.TextBox StaffOrdersTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.ComboBox ProductBrandComboBox;
        private System.Windows.Forms.ComboBox ProductCategoryDropBox;
        private System.Windows.Forms.TextBox ProductYearTextBox;
        private System.Windows.Forms.TextBox ProductPriceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ProductNameComboBox;
        private System.Windows.Forms.ComboBox StoreComboBox;
        private System.Windows.Forms.TextBox QtyTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button IncreaseQtyButton;
        private System.Windows.Forms.Button ShowCustPurchasesButton;
        private System.Windows.Forms.Button ShowStaffOrdersButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart StaffSalesChart;
    }
}

