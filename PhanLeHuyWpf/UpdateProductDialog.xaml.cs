using System;
using System.Windows;
using BusinessObjects;
using Services;

namespace PhanLeHuyWpf
{
    /// <summary>
    /// Interaction logic for UpdateProductDialog.xaml
    /// </summary>
    public partial class UpdateProductDialog : Window
    {
        private ProductService ps = new ProductService();
        private InputValidator iv = new InputValidator();
        public UpdateProductDialog(Product existingProduct)
        {
            InitializeComponent();

            txtProductId.Text = existingProduct.ProductId.ToString();
            txtProductName.Text = existingProduct.ProductName;
            txtSupplierId.Text = existingProduct.SupplierId.ToString();
            txtCategoryId.Text = existingProduct.CategoryId.ToString();
            txtQuantityPerUnit.Text = existingProduct.QuantityPerUnit.ToString();
            txtUnitPrice.Text = existingProduct.UnitPrice.ToString();
            txtUnitsInStock.Text = existingProduct.UnitsInStock.ToString();
            txtUnitsOnOrder.Text = existingProduct.UnitsOnOrder.ToString();
            txtReorderLevel.Text = existingProduct.ReorderLevel.ToString();
            chkDiscontinued.IsChecked = existingProduct.Discontinued;

            txtProductId.IsReadOnly = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!iv.IsCategoryIdExist(int.Parse(txtCategoryId.Text)))
            {
                MessageBox.Show("Id khong ton tai");
                return;
            }
            try
            {
                Product product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    SupplierId = int.Parse(txtSupplierId.Text),
                    CategoryId = int.Parse(txtCategoryId.Text),
                    QuantityPerUnit = txtQuantityPerUnit.Text.Trim(),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    UnitsOnOrder = int.Parse(txtUnitsOnOrder.Text),
                    ReorderLevel = int.Parse(txtReorderLevel.Text),
                    Discontinued = chkDiscontinued.IsChecked ?? false
                };

                if (ps.UpdateProduct(product))
                {
                    DialogResult = true;
                    Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
