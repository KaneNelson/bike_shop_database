using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace DBFrontEndStockSide
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=I\\SQLEXPRESS;Initial Catalog=BikeShop;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();

            //Allows for updating dropdowns on click
            ProductBrandComboBox.DropDown += new System.EventHandler(ProductBrandComboBox_DropDown);
            ProductCategoryDropBox.DropDown += new System.EventHandler(ProductCategoryDropBox_DropDown);
            ProductNameComboBox.DropDown += new System.EventHandler(ProductNameComboBox_DropDown);
            StoreComboBox.DropDown += new System.EventHandler(StoreComboBox_DropDown);
            
            StaffSalesChart.Series.Clear();
            StaffSalesChart.Legends.Clear();
        }

        private void AddBrandButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("INSERT INTO BikeBrand VALUES(@BikeBrand)", conn);

            command.Parameters.Add("@BikeBrand", SqlDbType.NChar).Value = BrandTextBox.Text;
            
            command.ExecuteReader();
            conn.Close();
            
            BrandTextBox.Text = "";
        }

        private void ProductBrandComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select BrandId, BrandName from BikeBrand", conn);

            List<string> brands = new List<string>();
            List<Int32> ids = new List<Int32>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        ids.Add(reader.GetInt32(0));
                        brands.Add(reader.GetString(1));
                    }
                }
            }


            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < ids.Count(); i++)
            {
                dict.Add(brands[i], ids[i]);
            }

            ProductBrandComboBox.DataSource = new BindingSource(dict, null);
            ProductBrandComboBox.DisplayMember = "Key";
            ProductBrandComboBox.ValueMember = "Value";
            
            conn.Close();
        }

        private void ProductCategoryDropBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select TypeId, Type from BikeCategory", conn);

            List<string> cats = new List<string>();
            List<Int32> ids = new List<Int32>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        ids.Add(reader.GetInt32(0));
                        cats.Add(reader.GetString(1));
                    }

                }
            }

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < ids.Count(); i++)
            {
                dict.Add(cats[i], ids[i]);
            }

            ProductCategoryDropBox.DataSource = new BindingSource(dict, null);
            ProductCategoryDropBox.DisplayMember = "Key";
            ProductCategoryDropBox.ValueMember = "Value";

            conn.Close();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Product VALUES(@ProductName, " +
                "@BrandID, @TypeID, @ModelYear, @ListPrice) ", conn);

            command.Parameters.Add("@ProductName", SqlDbType.NChar).Value = ProductNameTextBox.Text;
            command.Parameters.Add("@BrandId", SqlDbType.Int).Value = ProductBrandComboBox.SelectedValue;
            command.Parameters.Add("@TypeId", SqlDbType.Int).Value = ProductCategoryDropBox.SelectedValue;
            command.Parameters.Add("@ModelYear", SqlDbType.Int).Value = Int32.Parse(ProductYearTextBox.Text);
            command.Parameters.Add("@ListPrice", SqlDbType.Decimal).Value = float.Parse(ProductPriceTextBox.Text);

            command.ExecuteReader();
            conn.Close();

            ProductNameTextBox.Text = "";
            ProductYearTextBox.Text = "";
            ProductPriceTextBox.Text = "";
        }

        private void ProductNameComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select ProductId, ProductName from Product", conn);

            List<string> prods = new List<string>();
            List<Int32> ids = new List<Int32>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        ids.Add(reader.GetInt32(0));
                        prods.Add(reader.GetString(1));
                    }
                }
            }


            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < ids.Count(); i++)
            {
                dict.Add(prods[i], ids[i]);
            }
            ProductNameComboBox.DataSource = new BindingSource(dict, null);
            ProductNameComboBox.DisplayMember = "Key";
            ProductNameComboBox.ValueMember = "Value";

            conn.Close();
        }

        private void StoreComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select StoreId, StoreName from Store", conn);

            List<string> stores = new List<string>();
            List<Int32> ids = new List<Int32>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        ids.Add(reader.GetInt32(0));
                        stores.Add(reader.GetString(1));
                    }
                }
            }


            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < ids.Count(); i++)
            {
                dict.Add(stores[i], ids[i]);
            }

            StoreComboBox.DataSource = new BindingSource(dict, null);
            StoreComboBox.DisplayMember = "Key";
            StoreComboBox.ValueMember = "Value";

            conn.Close();
        }

        private void IncreaseQtyButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("UPDATE Inventory SET StoreQuantity = StoreQuantity + @AddedQty " +
                "WHERE Inventory.ProductID = @productID AND Inventory.StoreID = @StoreID", conn);

            command.Parameters.Add("@AddedQty", SqlDbType.Int).Value = Int32.Parse(QtyTextBox.Text);
            command.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductNameComboBox.SelectedValue;
            command.Parameters.Add("@StoreID", SqlDbType.Int).Value = StoreComboBox.SelectedValue;

            command.ExecuteReader();
            conn.Close();

            QtyTextBox.Text = "";
        }


        private void ShowCustPurchasesButton_Click(object sender, EventArgs e)
        {
            CustomerPurchasesTextBox.Text = "";

            // To connections needed since 2 sql queries are being ran
            SqlConnection conn = new SqlConnection(connectionString);
            SqlConnection conn2 = new SqlConnection(connectionString);
            conn.Open();
            conn2.Open();

            SqlCommand command = new SqlCommand("SELECT Orders.CustomerID, Customer.FirstName, Customer.LastName, " +
                "Store.StoreID, Store.StoreName, Orders.OrderID, Customer.Phone, Customer.Street, Customer.City" +
                " FROM Orders JOIN Customer on Orders.CustomerID = " +
                "Customer.CustomerID JOIN Staff_Store on Orders.StaffStoreID = Staff_Store.StaffStoreID " +
                "JOIN Store on Staff_Store.StoreID = Store.StoreID ORDER BY Customer.LastName, Customer.FirstName", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    decimal OrderSum = 0;
                    if (!reader.IsDBNull(0))
                    {
                        CustomerPurchasesTextBox.Text += reader.GetString(2) + ", " + reader.GetString(1) + Environment.NewLine;
                        CustomerPurchasesTextBox.Text += "Phone: " + reader.GetString(6) + Environment.NewLine;
                        CustomerPurchasesTextBox.Text += reader.GetString(7) + ", " + reader.GetString(8) + Environment.NewLine;
                        CustomerPurchasesTextBox.Text += "OrderID:  " + reader.GetInt32(5).ToString() + Environment.NewLine;
                        CustomerPurchasesTextBox.Text += "Store: " + reader.GetString(4) + Environment.NewLine + Environment.NewLine;

                        SqlCommand command2 = new SqlCommand("SELECT Product.ProductName, OrderLines.Quantity, " +
                            "(OrderLines.Quantity * Product.ListPrice), (1 - Orders.Discount) From OrderLines JOIN Product on " +
                            "OrderLines.ProductID = Product.ProductID" +
                            " Join Orders on OrderLines.OrderID = Orders.OrderID WHERE Orders.OrderID = @OrderID", conn2);

                        command2.Parameters.Add("@OrderID", SqlDbType.Int).Value = reader.GetInt32(5);
                        
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                if (!reader2.IsDBNull(0))
                                {
                                    CustomerPurchasesTextBox.Text += "\t" + reader2.GetString(0) + " Qty: " + reader2.GetInt32(1).ToString() + Environment.NewLine;
                                    CustomerPurchasesTextBox.Text += "\tTotal: $" + reader2.GetDecimal(2).ToString() + Environment.NewLine;
                                    OrderSum += reader2.GetDecimal(2) * reader2.GetDecimal(3);
                                }
                            }
                        }

                        CustomerPurchasesTextBox.Text += Environment.NewLine + "Order Total (Discount Included): $" +
                            Math.Round(OrderSum, 2).ToString() + Environment.NewLine + Environment.NewLine;
                    }

                }
            }

            conn.Close();
            conn2.Close();
        }
        private void ShowStaffTotalSalesButton_Click(object sender, EventArgs e)
        {
            StaffOrdersTextBox.Text = "";
            StaffSalesChart.Series.Clear();
            StaffSalesChart.Legends.Clear();

            //Add a new Legend(if needed) and do some formating


            //Add a new chart-series
            string seriesname = "MySeriesName";
            StaffSalesChart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            StaffSalesChart.Series[seriesname].ChartType = SeriesChartType.Pie;

            //Add some datapoints so the series. in this case you can pass the values to this method


            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT Staff.FirstName, Staff.LastName, SUM(Product.ListPrice * OrderLines.Quantity * (1-Orders.Discount))" +
                " as 'Total Sales' FROM Orders JOIN OrderLines on Orders.OrderID = OrderLines.OrderID " +
                "JOIN Product on OrderLines.ProductID = Product.ProductID JOIN Staff_Store on Orders.StaffStoreID = " +
                "Staff_Store.StaffStoreID JOIN Staff on Staff_Store.StaffID = Staff.StaffID JOIN Store on Staff_Store.StoreID = Store.StoreID " +
                "GROUP BY Staff.FirstName, Staff.LastName ORDER BY Staff.LastName, Staff.FirstName", conn);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        StaffOrdersTextBox.Text += reader.GetString(1) + ", " + reader.GetString(0) + Environment.NewLine;
                        StaffOrdersTextBox.Text += "Employee Total Sales: $" + Math.Round(reader.GetDecimal(2), 2).ToString() + Environment.NewLine + Environment.NewLine;
                        StaffSalesChart.Series[seriesname].Points.AddXY(reader.GetString(1) + ", " + reader.GetString(0), Math.Round(reader.GetDecimal(2), 2));
                    }

                }
            }
            foreach (DataPoint p in StaffSalesChart.Series[seriesname].Points)
            {
                p.Label = "#PERCENT\n#VALX";
            }


        }

        private void ShowStaffOrdersButton_Click(object sender, EventArgs e)
        {
            StaffOrdersTextBox.Text = "";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlConnection conn2 = new SqlConnection(connectionString);
            conn.Open();
            conn2.Open();

            SqlCommand command = new SqlCommand("SELECT Staff.FirstName, Staff.LastName, Store.StoreName, Orders.OrderID, Staff_Store.StaffStoreID " +
                "FROM Orders JOIN Staff_Store on Orders.StaffStoreID = Staff_Store.StaffStoreID " +
                "JOIN Staff on Staff_Store.StaffID = Staff.StaffID JOIN Store on Staff_Store.StoreID = Store.StoreID " +
                "ORDER BY Staff.LastName, Staff.FirstName", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    decimal OrderSum = 0;
                    if (!reader.IsDBNull(0))
                    {
                        StaffOrdersTextBox.Text += reader.GetString(1) + ", " + reader.GetString(0) + Environment.NewLine;
                        StaffOrdersTextBox.Text += "OrderID:  " + reader.GetInt32(3).ToString() + Environment.NewLine;
                        StaffOrdersTextBox.Text += "Store: " + reader.GetString(2) + Environment.NewLine + Environment.NewLine;

                        SqlCommand command2 = new SqlCommand("SELECT Product.ProductName,  OrderLines.Quantity, " +
                            "(OrderLines.Quantity * Product.ListPrice), (1-Orders.Discount) FROM OrderLines JOIN Product on OrderLines.ProductID =" +
                            " Product.ProductID JOIN Orders on Orders.OrderID = OrderLines.OrderID " +
                            "JOIN Staff_Store on Orders.StaffStoreID = Staff_Store.StaffStoreID WHERE " +
                            "Staff_Store.StaffStoreID = @StaffStoreID and Orders.OrderID = @OrderID", conn2);

                        command2.Parameters.Add("@StaffStoreID", SqlDbType.Int).Value = reader.GetInt32(4);
                        command2.Parameters.Add("@OrderID", SqlDbType.Int).Value = reader.GetInt32(3);
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                if (!reader2.IsDBNull(0))
                                {
                                    StaffOrdersTextBox.Text += "\t" + reader2.GetString(0) + " Qty: " + reader2.GetInt32(1).ToString() + Environment.NewLine;
                                    StaffOrdersTextBox.Text += "\tTotal: $" + reader2.GetDecimal(2).ToString() + Environment.NewLine;
                                    OrderSum += reader2.GetDecimal(2) * reader2.GetDecimal(3);
                                }
                            }
                        }
                        StaffOrdersTextBox.Text += Environment.NewLine + "Order Total (Discount Included): $" + Math.Round(OrderSum, 2).ToString() + Environment.NewLine + Environment.NewLine;
                    }

                }
            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
