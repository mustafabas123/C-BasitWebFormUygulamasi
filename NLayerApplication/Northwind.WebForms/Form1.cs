using Northwind.Bussiness.Abstract;
using Northwind.Bussiness.Concerete;
using Northwind.Bussiness.DependencyReselvors.Ninject;
using Northwind.Entities.Concerete;
using Nothwind.DataAccess.Concerete.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService= InstanceFactory.GetInstance<ICategoryService>();
        }

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProduct();
            GetCategory();
        }
        private void GetProduct()
        {
            dataGridView1.DataSource = _productService.GetAll();

        }
        private void GetCategory()
        {
            cmbKategori.DataSource = _categoryService.GetAll();
            cmbKategori.DisplayMember = "CategoryName";
            cmbKategori.ValueMember = "CategoryID";

            cmbKategoriAdi.DataSource = _categoryService.GetAll();
            cmbKategoriAdi.DisplayMember = "CategoryName";
            cmbKategoriAdi.ValueMember = "CategoryID";
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _productService.GetProductByCategory(Convert.ToInt32(cmbKategori.SelectedValue));
            }
            catch 
            {

                
            }
        }

        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtUrunAdi.Text))
            {
                GetProduct();
            }
            else
            {
                dataGridView1.DataSource = _productService.GetProductByProductName(txtUrunAdi.Text);
            }
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryID = Convert.ToInt32(cmbKategoriAdi.SelectedValue),
                    ProductName = txtUrunAdi2.Text,
                    QuantityPerUnit = txtBirimAdedi.Text,
                    UnitPrice = Convert.ToDecimal(txtFiyat.Text),
                    UnitsInStock = Convert.ToInt16(txtStockAdedi.Text)
                });
                GetProduct();
                MessageBox.Show("Ürün eklendi");
            }
            catch (Exception excetion)
            {
                MessageBox.Show(excetion.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductID = Convert.ToInt32(txtId.Text),
                CategoryID = Convert.ToInt32(cmbKategoriAdi.SelectedValue),
                ProductName = txtUrunAdi2.Text,
                QuantityPerUnit = txtBirimAdedi.Text,
                UnitPrice = Convert.ToDecimal(txtFiyat.Text),
                UnitsInStock = Convert.ToInt16(txtStockAdedi.Text)
            });
            GetProduct();
            MessageBox.Show("Ürün güncellendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            txtId.Text= row.Cells[0].Value.ToString();
            txtUrunAdi2.Text = row.Cells[2].Value.ToString();
            cmbKategoriAdi.SelectedValue = row.Cells[1].Value;
            txtFiyat.Text = row.Cells[4].Value.ToString();
            txtStockAdedi.Text = row.Cells[5].Value.ToString();
            txtBirimAdedi.Text = row.Cells[3].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text != null || txtId.Text == "")
            {

                try
                {
                    _productService.Delete(new Product
                    {
                        ProductID = Convert.ToInt32(txtId.Text),
                    });
                    GetProduct();
                    MessageBox.Show("Ürün Silindi");
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.InnerException.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("Bir değer seçmeniz lazım paşam");
            }

        }
    }
}
