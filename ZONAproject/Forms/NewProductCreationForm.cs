using System.Drawing.Imaging;
using ZONOproject.Database;
using ZONOproject.EntityClasses;

namespace ZONOproject.Forms
{
    /// <summary>
    /// Форма добавления нового товара
    /// </summary>
    public partial class NewProductCreationForm : Form
    {
        #region Поля
        User currentUser;
        #endregion

        #region Методы
        /// <summary>
        /// Метод загрузки данных из таблиц баз данных в comboBox'ы
        /// </summary>
        public void LoadComboBoxesData()
        {
            using (var database = new DatabaseContext())
            {
                var manufacturerNames = database.Manufacturers.AsEnumerable().Select(x => x.ManufacturerName).ToList();
                var typeNames = database.ProductTypes.AsEnumerable().Select(x => x.ProductTypeName).ToList();
                var colorNames = database.Colors.AsEnumerable().Select(x => x.ColorName).ToList();

                productManufacturerComboBox.Items.AddRange(manufacturerNames.ToArray());
                productTypeComboBox.Items.AddRange(typeNames.ToArray());
                productColorComboBox.Items.AddRange(colorNames.ToArray());
            }
        }
        #endregion

        #region События
        private void BlockingIncorrectInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EditProductPhotoDialog(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите изображение товара";
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    productPhotoPictureBox.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }
        private void SaveNewProductInDatabase(object sender, EventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                var manufacturerIDs = database.Manufacturers.AsEnumerable().Select(x => x.ManufacturerID).ToList();
                var typeIDs = database.ProductTypes.AsEnumerable().Select(x => x.ProductTypeID).ToList();
                var colorIDs = database.Colors.AsEnumerable().Select(x => x.ColorID).ToList();

                var product = new Recommendation();

                product.ID = currentUser.ID;
                product.RecommendationName = productNameTextBox.Text;
                product.RecommendationDescription = productDescriptionTextBox.Text;
                product.RecommendationMark = 5;
                product.ProductPriceFrom = int.Parse(productPriceTextBox.Text);
                product.RecommendationId = Guid.NewGuid();
                using (var ms = new MemoryStream())
                {
                    productPhotoPictureBox.Image.Save(ms, ImageFormat.Jpeg);
                    product.ProductPhoto = ms.ToArray();
                }
                var colorselected = productColorComboBox.SelectedIndex;
                var manufacturerselected = productManufacturerComboBox.SelectedIndex;
                var producttypeselected = productTypeComboBox.SelectedIndex;


                product.ColorID = colorIDs[colorselected];
                product.ManufacturerID = manufacturerIDs[manufacturerselected];
                product.ProductTypeID = typeIDs[producttypeselected];
                
                if (int.TryParse(productYearOfProductionTextBox.Text, out int result))
                {
                    product.YearOfProduction = result;
                }

                database.Recommendations.Add(product);
                database.SaveChanges();

                MessageBox.Show("Товар успешно добавлен!", "Внимаение!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
        }
        #endregion

        #region Конструкторы
        public NewProductCreationForm(User currentUser)
        {
            InitializeComponent();
            LoadComboBoxesData();
            this.currentUser = currentUser;
        }
        #endregion

        #region Временные методы, удалить до релиза
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                var manufacturer = new Manufacturer();

                manufacturer.ManufacturerName = textBox1.Text;

                database.Manufacturers.Add(manufacturer);
                database.SaveChanges();

                LoadComboBoxesData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                var productType = new ProductType();

                productType.ProductTypeName = textBox3.Text;

                database.ProductTypes.Add(productType);
                database.SaveChanges();

                LoadComboBoxesData();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                var color = new EntityClasses.Color();

                color.ColorName = textBox4.Text;

                database.Colors.Add(color);
                database.SaveChanges();

                LoadComboBoxesData();
            }
        }
        #endregion

    }
}
