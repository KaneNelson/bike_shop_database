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


// This is the front end to used by the employees to do things such as add customers, or make orders
namespace DatabaseFrontEnd
{

    public partial class Form1 : Form

    {
        string connectionString = "Data Source=I\\SQLEXPRESS;Initial Catalog=BikeShop;Integrated Security=True";

        // Stores all the productIDs and their respective quantities in an order.
        List<int[]> order_list = new List<int[]>();
        public Form1()
        {
            InitializeComponent();

            // Allows the dropdowns to be updated when clicked on
            LookupStoresComboBox.DropDown += new System.EventHandler(LookupStoresComboBox_DropDown);
            LookupProductsComboBox.DropDown += new System.EventHandler(LookupProductsComboBox_DropDown);
            OrderStoreComboBox.DropDown += new System.EventHandler(OrderStoreComboBox_DropDown);
            OrderStaffComboBox.DropDown += new System.EventHandler(OrderStaffComboBox_DropDown);
            OrderProductComboBox.DropDown += new System.EventHandler(OrderProductComboBox_DropDown);
            OrderQtyComboBox.DropDown += new System.EventHandler(OrderQtyComboBox_DropDown);
        }


        private void AddCustButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Customer VALUES (@Firstname, @Lastname, @Phone, @Email, " +
                "@Street, @City, @State, @Zip)");

            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = AddCustFirstNameTextbox.Text;
            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = AddCustLastNameTextbox.Text;
            command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = AddCustPhoneTextbox.Text;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = AddCustEmailTextbox.Text;
            command.Parameters.Add("@Street", SqlDbType.VarChar).Value = AddCustAddressTextbox.Text;
            command.Parameters.Add("@City", SqlDbType.VarChar).Value = AddCustCityTextbox.Text;
            command.Parameters.Add("@State", SqlDbType.VarChar).Value = AddCustStateTextbox.Text;
            command.Parameters.Add("@Zip", SqlDbType.VarChar).Value = AddCustZipTextbox.Text;

            command.Connection = conn;
            command.ExecuteReader();

            conn.Close();
            AddCustFirstNameTextbox.Text = "";
            AddCustLastNameTextbox.Text = "";
            AddCustPhoneTextbox.Text = "";
            AddCustEmailTextbox.Text = "";
            AddCustAddressTextbox.Text = "";
            AddCustCityTextbox.Text = "";
            AddCustStateTextbox.Text = "";
            AddCustZipTextbox.Text = "";
        }



        private void LookupStoresComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select StoreName from Store", conn);
            command.Connection = conn;

            List<string> stores = new List<string>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        stores.Add(reader.GetString(0));
                    }
                }
            }

            LookupStoresComboBox.Items.Clear();
            LookupStoresComboBox.Items.AddRange(stores.ToArray());
            
            conn.Close();
        }

        private void LookupProductsComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select ProductName from Product", conn);
            List<string> stores = new List<string>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        stores.Add(reader.GetString(0));
                    }
                }
            }


            LookupProductsComboBox.Items.Clear();
            LookupProductsComboBox.Items.AddRange(stores.ToArray());
            conn.Close();

        }

        // Finds if product is available at selected store and if not then shows stores product is available at
        private void LookupButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("select StoreInventoryID from Inventory inv" +
                " join Product pr on pr.productID = Inv.productID join Store sto on sto.StoreID = Inv.StoreID" +
                " where productName = @productName and StoreName = @StoreName and StoreQuantity > 0", conn);

            command.Parameters.Add("@ProductName", SqlDbType.NChar).Value = LookupProductsComboBox.SelectedItem;
            command.Parameters.Add("@StoreName", SqlDbType.NChar).Value = LookupStoresComboBox.SelectedItem;
            List<string> stores = new List<string>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    stores.Add(reader.GetInt32(0).ToString());
                }
            }

            LookupTextbox.Text = "";

            if (stores.Count > 0)
            {
                LookupTextbox.Text += "PRODUCT IN STOCK!!! " + Environment.NewLine;

            }
            else
            {
                command = new SqlCommand("select st.StoreName, st.Phone, st.Street, st.City from inventory inv" +
                    " join Product pr on pr.productID = inv.productID join Store st on st.StoreID = inv.StoreID" +
                    " where productName = @productName and StoreQuantity > 0", conn);
               
                command.Parameters.Add("@productName", SqlDbType.NChar).Value = LookupProductsComboBox.SelectedItem;
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        stores.Add(reader.GetString(0));
                    }
                }
                
                if (stores.Count > 0)
                {
                    LookupTextbox.Text = "Product NOT available at this location!!!" + Environment.NewLine + Environment.NewLine;
                    LookupTextbox.Text += "Product is available at these locations: " + Environment.NewLine;
                    command = new SqlCommand("select st.StoreName, st.Phone, st.Street, st.City, inv.StoreQuantity from inventory inv" +
                        " join Product pr on pr.productID = inv.productID join Store st on st.StoreID = inv.StoreID" +
                        " where productName = @productName and StoreQuantity > 0", conn);
                    command.Parameters.Add("@productName", SqlDbType.NChar).Value = LookupProductsComboBox.SelectedItem;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LookupTextbox.Text += reader.GetString(0) + " " + reader.GetString(2) + ", " + reader.GetString(3);
                            LookupTextbox.Text += Environment.NewLine;
                            LookupTextbox.Text += reader.GetString(1) + Environment.NewLine;
                            LookupTextbox.Text += "Qty: " + reader.GetInt32(4).ToString() + Environment.NewLine;

                        }
                    }
                }
                else
                {
                    LookupTextbox.Text += "Product is NOT available at any of our locations";
                }
            }
            
            conn.Close();
        }




        private void OrderStoreComboBox_DropDown(object sender, System.EventArgs e)
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

            // dict contains the store and its corresponding id
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < stores.Count(); i++)
            {
                dict.Add(stores[i], ids[i]);
            }
            // Gets the combobox to display the storename, but gets the storeID when getting selected item
            OrderStoreComboBox.DataSource = new BindingSource(dict, null);
            OrderStoreComboBox.DisplayMember = "Key";
            OrderStoreComboBox.ValueMember = "Value";

            conn.Close();

        }

        private void OrderStaffComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select Staff.StaffID, Firstname, Lastname from Staff join Staff_Store ss" +
                " on ss.StaffID = Staff.StaffID where StoreID = @StoreID", conn);

            command.Parameters.Add("@StoreID", SqlDbType.Int).Value = OrderStoreComboBox.SelectedValue;
            
            List<string> staffname = new List<string>();
            List<Int32> ids = new List<Int32>();
           
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        ids.Add(reader.GetInt32(0));
                        staffname.Add(reader.GetString(1) + " " + reader.GetString(2));
                    }
                }
            }
           
            // dict contains the staff member name and their corresponding id
            Dictionary<string, int> dict = new Dictionary<string, int>();
           
            for (int i = 0; i < ids.Count(); i++)
            {
                dict.Add(staffname[i], ids[i]);
            }
            
            // Gets the combobox to display the staff member, but gets their id when getting selected combobox item
            OrderStaffComboBox.DataSource = new BindingSource(dict, null);
            OrderStaffComboBox.DisplayMember = "Key";
            OrderStaffComboBox.ValueMember = "Value";

            conn.Close();
        }

        private void OrderProductComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select ProductName, BrandName, Type," +
                " ModelYear, ListPrice, pr.productId" +
                " from Product pr join BikeBrand br on pr.BrandID = br.BrandId join BikeCategory ca" +
                " on ca.TypeId = pr.typeID join Inventory inv on inv.productID = pr.ProductId " +
                "where StoreID = @StoreID and StoreQuantity > 0", conn);

            command.Parameters.Add("@StoreId", SqlDbType.Int).Value = OrderStoreComboBox.SelectedValue;

            List<string> products = new List<string>();
            List<int> ids = new List<int>();
          
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        products.Add(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) +
                            ", " + reader.GetInt32(3).ToString() + ", " + reader.GetDecimal(4).ToString());
                        ids.Add(reader.GetInt32(5));
                    }
                }
            }
            
            // dict contains the product and the corresponding id
            Dictionary<string, int> dict = new Dictionary<string, int>();
            
            for (int i = 0; i < ids.Count(); i++)
            {
                dict.Add(products[i], ids[i]);
            }

            // Gets the combobox to display the product, but gets the productId when getting selected item
            OrderProductComboBox.DataSource = new BindingSource(dict, null);
            OrderProductComboBox.DisplayMember = "Key";
            OrderProductComboBox.ValueMember = "Value";
          
            conn.Close();
        }

        private void OrderQtyComboBox_DropDown(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select StoreQuantity from Inventory " +
                "where productId = @prodID and StoreID = @StoreID", conn);
;
            command.Parameters.Add("@prodId", SqlDbType.Int).Value = OrderProductComboBox.SelectedValue;
            command.Parameters.Add("@StoreId", SqlDbType.Int).Value = OrderStoreComboBox.SelectedValue;

            int quantity = 0;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    quantity = reader.GetInt32(0);
                }
            }

            OrderQtyComboBox.Items.Clear();

            if (quantity > 0)
            {
                for (int i = 1; i <= quantity; i++)
                {
                    OrderQtyComboBox.Items.Add(i);
                }
            }

            conn.Close();
        }

        private void AddToOrderButton_Click(object sender, EventArgs e)
        {
            CurrentOrderTextbox.Text += OrderProductComboBox.Text + Environment.NewLine;
            CurrentOrderTextbox.Text += "Quantity: " + OrderQtyComboBox.SelectedItem + Environment.NewLine;

            int[] arr = new int[2] { (int)OrderProductComboBox.SelectedValue, (int)OrderQtyComboBox.SelectedItem };
            
            order_list.Add(arr);
        }

        // Puts all the items in the order_list into one order then places that order
        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            CurrentOrderTextbox.Text = "";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Gets staff and store info from dropdowns to add to order information
            SqlCommand command = new SqlCommand("select StaffStoreID from Staff_Store where " +
                "StaffID = @StaffID and StoreID = @StoreID", conn);
            
            command.Parameters.Add("@StaffId", SqlDbType.Int).Value = OrderStaffComboBox.SelectedValue;
            command.Parameters.Add("@StoreId", SqlDbType.Int).Value = OrderStoreComboBox.SelectedValue;

            int staff_storeID = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    staff_storeID = reader.GetInt32(0);

                }
            }

            int customerID = 0;

            // Gets customerID from the customer's email in the email textbox
            command = new SqlCommand("select CustomerID from Customer where Email = @Email", conn);
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = OrderEmailTextbox.Text;
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        customerID = reader.GetInt32(0);
                    }
                }
            }

            // Adds order and order info to database
            command = new SqlCommand("Insert into Orders values(GETDATE(), @CustomerID," +
                " @StaffStoreID, @Discount) Select SCOPE_IDENTITY()", conn);
            command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
            command.Parameters.Add("@StaffStoreID", SqlDbType.Int).Value = staff_storeID;
            command.Parameters.Add("Discount", SqlDbType.Decimal).Value = float.Parse(OrderDiscountTextbox.Text);

            int orderID = 0;
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        orderID = Convert.ToInt32(reader.GetDecimal(0)); 
                    }
                }
            }
            
            for(int i = 0; i < order_list.Count; i++)
            {
                // Updates the inventory by subtracting product qty from qty in order
                command = new SqlCommand("Update Inventory set StoreQuantity = (StoreQuantity - @NewQuantity) " +
                    "where StoreID = @StoreID and ProductID = @ProductID", conn);
                command.Parameters.Add("StoreId", SqlDbType.Int).Value = OrderStoreComboBox.SelectedValue;
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = order_list[i][0];
                command.Parameters.Add("@NewQuantity", SqlDbType.Int).Value = order_list[i][1];

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                }

                // Adds products from the order to the database
                command = new SqlCommand("Insert into OrderLines Values(@OrderID, @ProductID, @Quantity)", conn);
                
                command.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = order_list[i][0];
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = order_list[i][1];

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                }
            }
           
            conn.Close();            
        }
    }
}
