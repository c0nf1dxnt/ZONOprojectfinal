namespace ZONOproject.Forms
{
    partial class NewProductCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProductCreationForm));
            productNameTextBox = new TextBox();
            productPhotoPictureBox = new PictureBox();
            changePhotoButton = new Button();
            productDescriptionTextBox = new TextBox();
            productManufacturerComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            productTypeComboBox = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            productColorComboBox = new ComboBox();
            label5 = new Label();
            productPriceTextBox = new TextBox();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button4 = new Button();
            button5 = new Button();
            productYearOfProductionTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // productNameTextBox
            // 
            productNameTextBox.Location = new Point(83, 12);
            productNameTextBox.Name = "productNameTextBox";
            productNameTextBox.PlaceholderText = "Название товара";
            productNameTextBox.Size = new Size(253, 23);
            productNameTextBox.TabIndex = 0;
            // 
            // productPhotoPictureBox
            // 
            productPhotoPictureBox.Location = new Point(83, 53);
            productPhotoPictureBox.Name = "productPhotoPictureBox";
            productPhotoPictureBox.Size = new Size(253, 168);
            productPhotoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            productPhotoPictureBox.TabIndex = 1;
            productPhotoPictureBox.TabStop = false;
            // 
            // changePhotoButton
            // 
            changePhotoButton.BackColor = Color.DeepSkyBlue;
            changePhotoButton.ForeColor = SystemColors.ButtonHighlight;
            changePhotoButton.Location = new Point(145, 227);
            changePhotoButton.Name = "changePhotoButton";
            changePhotoButton.Size = new Size(108, 32);
            changePhotoButton.TabIndex = 2;
            changePhotoButton.Text = "Изменить фото";
            changePhotoButton.UseVisualStyleBackColor = false;
            changePhotoButton.Click += EditProductPhotoDialog;
            // 
            // productDescriptionTextBox
            // 
            productDescriptionTextBox.Location = new Point(103, 278);
            productDescriptionTextBox.Multiline = true;
            productDescriptionTextBox.Name = "productDescriptionTextBox";
            productDescriptionTextBox.PlaceholderText = "Описание товара";
            productDescriptionTextBox.Size = new Size(352, 58);
            productDescriptionTextBox.TabIndex = 3;
            // 
            // productManufacturerComboBox
            // 
            productManufacturerComboBox.FormattingEnabled = true;
            productManufacturerComboBox.Location = new Point(334, 356);
            productManufacturerComboBox.Name = "productManufacturerComboBox";
            productManufacturerComboBox.Size = new Size(121, 23);
            productManufacturerComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(103, 359);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 5;
            label1.Text = "Производитель";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 446);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 6;
            label2.Text = "Год производства";
            // 
            // productTypeComboBox
            // 
            productTypeComboBox.FormattingEnabled = true;
            productTypeComboBox.Location = new Point(334, 385);
            productTypeComboBox.Name = "productTypeComboBox";
            productTypeComboBox.Size = new Size(121, 23);
            productTypeComboBox.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 388);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 8;
            label3.Text = "Тип товара";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 475);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 10;
            label4.Text = "Цена";
            // 
            // productColorComboBox
            // 
            productColorComboBox.FormattingEnabled = true;
            productColorComboBox.Location = new Point(334, 414);
            productColorComboBox.Name = "productColorComboBox";
            productColorComboBox.Size = new Size(121, 23);
            productColorComboBox.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(103, 417);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 12;
            label5.Text = "Цвет";
            // 
            // productPriceTextBox
            // 
            productPriceTextBox.Location = new Point(334, 472);
            productPriceTextBox.Name = "productPriceTextBox";
            productPriceTextBox.Size = new Size(121, 23);
            productPriceTextBox.TabIndex = 14;
            productPriceTextBox.KeyPress += BlockingIncorrectInput;
            // 
            // button2
            // 
            button2.BackColor = Color.DeepSkyBlue;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(193, 525);
            button2.Name = "button2";
            button2.Size = new Size(145, 37);
            button2.TabIndex = 15;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += SaveNewProductInDatabase;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(355, 99);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Производитель";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(355, 128);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Тип товара";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 23;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(355, 157);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Цвет";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 24;
            // 
            // button1
            // 
            button1.Location = new Point(471, 99);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 26;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(471, 128);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 28;
            button4.Text = "Добавить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(471, 157);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 29;
            button5.Text = "Добавить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // productYearOfProductionTextBox
            // 
            productYearOfProductionTextBox.Location = new Point(334, 443);
            productYearOfProductionTextBox.Name = "productYearOfProductionTextBox";
            productYearOfProductionTextBox.Size = new Size(121, 23);
            productYearOfProductionTextBox.TabIndex = 30;
            productYearOfProductionTextBox.KeyPress += BlockingIncorrectInput;
            // 
            // NewProductCreationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 588);
            Controls.Add(productYearOfProductionTextBox);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(productPriceTextBox);
            Controls.Add(productColorComboBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(productTypeComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(productManufacturerComboBox);
            Controls.Add(productDescriptionTextBox);
            Controls.Add(changePhotoButton);
            Controls.Add(productPhotoPictureBox);
            Controls.Add(productNameTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "NewProductCreationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление нового товара";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox productNameTextBox;
        private PictureBox productPhotoPictureBox;
        private Button changePhotoButton;
        private TextBox productDescriptionTextBox;
        private ComboBox productManufacturerComboBox;
        private Label label1;
        private Label label2;
        private ComboBox productTypeComboBox;
        private Label label3;
        private Label label4;
        private ComboBox productColorComboBox;
        private Label label5;
        private TextBox productPriceTextBox;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button4;
        private Button button5;
        private TextBox productYearOfProductionTextBox;
    }
}