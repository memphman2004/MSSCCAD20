using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace CarCrudWinForms
{
    // 1. Car class - our model
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }

    // 2. DbContext class for EF Core
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=cars.db");
        }
    }

    public partial class Form1 : Form
    {
        // UI controls
        private DataGridView dataGridView1;
        private TextBox txtVIN, txtMake, txtModel, txtYear, txtPrice;
        private Button btnAdd, btnUpdate, btnDelete, btnRefresh;
        private Label lblVIN, lblMake, lblModel, lblYear, lblPrice;

        // DB context
        private CarContext db = new CarContext();

        public Form1()
        {
            InitializeComponent();
            db.Database.EnsureCreated(); // Creates DB if not exists
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Cars CRUD Example - Beginner";
            this.Width = 750;
            this.Height = 400;

            // Initialize controls
            dataGridView1 = new DataGridView() { Left = 10, Top = 10, Width = 700, Height = 180 };
            lblVIN = new Label() { Left = 10, Top = 200, Text = "VIN", Width = 40 };
            txtVIN = new TextBox() { Left = 50, Top = 200, Width = 100 };
            lblMake = new Label() { Left = 170, Top = 200, Text = "Make", Width = 40 };
            txtMake = new TextBox() { Left = 210, Top = 200, Width = 100 };
            lblModel = new Label() { Left = 330, Top = 200, Text = "Model", Width = 45 };
            txtModel = new TextBox() { Left = 375, Top = 200, Width = 100 };
            lblYear = new Label() { Left = 495, Top = 200, Text = "Year", Width = 40 };
            txtYear = new TextBox() { Left = 535, Top = 200, Width = 60 };
            lblPrice = new Label() { Left = 610, Top = 200, Text = "Price", Width = 40 };
            txtPrice = new TextBox() { Left = 650, Top = 200, Width = 60 };

            btnAdd = new Button() { Left = 50, Top = 240, Text = "Add", Width = 80 };
            btnUpdate = new Button() { Left = 160, Top = 240, Text = "Update", Width = 80 };
            btnDelete = new Button() { Left = 270, Top = 240, Text = "Delete", Width = 80 };
            btnRefresh = new Button() { Left = 380, Top = 240, Text = "Refresh", Width = 80 };

            // Events
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // Add controls to Form
            this.Controls.Add(dataGridView1);
            this.Controls.Add(lblVIN);   this.Controls.Add(txtVIN);
            this.Controls.Add(lblMake);  this.Controls.Add(txtMake);
            this.Controls.Add(lblModel); this.Controls.Add(txtModel);
            this.Controls.Add(lblYear);  this.Controls.Add(txtYear);
            this.Controls.Add(lblPrice); this.Controls.Add(txtPrice);
            this.Controls.Add(btnAdd); this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete); this.Controls.Add(btnRefresh);
        }

        // Load all cars into the grid
        private void LoadData()
        {
            dataGridView1.DataSource = db.Cars.ToList();
            dataGridView1.Columns["Id"].Visible = false;
        }

        // Add a new car
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car()
                {
                    VIN = txtVIN.Text,
                    Make = txtMake.Text,
                    Model = txtModel.Text,
                    Year = int.Parse(txtYear.Text),
                    Price = decimal.Parse(txtPrice.Text)
                };
                db.Cars.Add(car);
                db.SaveChanges();
                LoadData();
                ClearFields();
            }
            catch
            {
                MessageBox.Show("Check your input fields.");
            }
        }

        // Update selected car
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                var car = db.Cars.Find(id);
                if (car != null)
                {
                    try
                    {
                        car.VIN = txtVIN.Text;
                        car.Make = txtMake.Text;
                        car.Model = txtModel.Text;
                        car.Year = int.Parse(txtYear.Text);
                        car.Price = decimal.Parse(txtPrice.Text);
                        db.SaveChanges();
                        LoadData();
                        ClearFields();
                    }
                    catch
                    {
                        MessageBox.Show("Check your input fields.");
                    }
                }
            }
        }

        // Delete selected car
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                var car = db.Cars.Find(id);
                if (car != null)
                {
                    db.Cars.Remove(car);
                    db.SaveChanges();
                    LoadData();
                    ClearFields();
                }
            }
        }

        // Refresh grid
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Fill fields when a grid row is selected
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                txtVIN.Text = dataGridView1.CurrentRow.Cells["VIN"].Value?.ToString();
                txtMake.Text = dataGridView1.CurrentRow.Cells["Make"].Value?.ToString();
                txtModel.Text = dataGridView1.CurrentRow.Cells["Model"].Value?.ToString();
                txtYear.Text = dataGridView1.CurrentRow.Cells["Year"].Value?.ToString();
                txtPrice.Text = dataGridView1.CurrentRow.Cells["Price"].Value?.ToString();
            }
        }

        // Helper to clear text boxes
        private void ClearFields()
        {
            txtVIN.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtYear.Text = "";
            txtPrice.Text = "";
        }
    }

    // Entry point for the application
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
