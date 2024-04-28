namespace ZONOproject
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            passwordFieldTextBox = new TextBox();
            messageLabel = new Label();
            enterButton = new Button();
            logoPictureBox = new PictureBox();
            showPasswordPictureBox = new PictureBox();
            loginFormTableLayoutPanel = new TableLayoutPanel();
            loginFieldTextBox = new TextBox();
            registrationLabel = new Label();
            selectLanguageTableLayoutPanel = new TableLayoutPanel();
            selectLanguageComboBox = new ComboBox();
            flagPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showPasswordPictureBox).BeginInit();
            loginFormTableLayoutPanel.SuspendLayout();
            selectLanguageTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).BeginInit();
            SuspendLayout();
            // 
            // passwordFieldTextBox
            // 
            passwordFieldTextBox.BackColor = Color.FromArgb(240, 240, 240);
            passwordFieldTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordFieldTextBox.Cursor = Cursors.IBeam;
            passwordFieldTextBox.Dock = DockStyle.Fill;
            passwordFieldTextBox.Location = new Point(270, 510);
            passwordFieldTextBox.Margin = new Padding(10, 11, 10, 11);
            passwordFieldTextBox.MaxLength = 30;
            passwordFieldTextBox.Name = "passwordFieldTextBox";
            passwordFieldTextBox.Size = new Size(391, 23);
            passwordFieldTextBox.TabIndex = 0;
            passwordFieldTextBox.TabStop = false;
            passwordFieldTextBox.UseSystemPasswordChar = true;
            // 
            // messageLabel
            // 
            messageLabel.Dock = DockStyle.Fill;
            messageLabel.Location = new Point(268, 377);
            messageLabel.Margin = new Padding(8, 0, 8, 8);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(395, 53);
            messageLabel.TabIndex = 0;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // enterButton
            // 
            enterButton.BackColor = Color.FromArgb(0, 166, 253);
            enterButton.Cursor = Cursors.Hand;
            enterButton.Dock = DockStyle.Fill;
            enterButton.FlatAppearance.BorderSize = 0;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Location = new Point(340, 614);
            enterButton.Margin = new Padding(80, 0, 80, 16);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(251, 57);
            enterButton.TabIndex = 0;
            enterButton.TabStop = false;
            enterButton.UseVisualStyleBackColor = false;
            enterButton.MouseDown += EntryButtonClick;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(260, 0);
            logoPictureBox.Margin = new Padding(0);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(411, 377);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // showPasswordPictureBox
            // 
            showPasswordPictureBox.Cursor = Cursors.Hand;
            showPasswordPictureBox.Dock = DockStyle.Left;
            showPasswordPictureBox.Image = Properties.Resources.eyeHidden;
            showPasswordPictureBox.Location = new Point(671, 504);
            showPasswordPictureBox.Margin = new Padding(0, 5, 5, 5);
            showPasswordPictureBox.Name = "showPasswordPictureBox";
            showPasswordPictureBox.Size = new Size(58, 51);
            showPasswordPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            showPasswordPictureBox.TabIndex = 0;
            showPasswordPictureBox.TabStop = false;
            showPasswordPictureBox.MouseDown += ShowPasswordPictureBox;
            // 
            // loginFormTableLayoutPanel
            // 
            loginFormTableLayoutPanel.ColumnCount = 3;
            loginFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.94118F));
            loginFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.1176453F));
            loginFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.9411774F));
            loginFormTableLayoutPanel.Controls.Add(loginFieldTextBox, 1, 2);
            loginFormTableLayoutPanel.Controls.Add(logoPictureBox, 1, 0);
            loginFormTableLayoutPanel.Controls.Add(messageLabel, 1, 1);
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 5);
            loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);
            loginFormTableLayoutPanel.Controls.Add(selectLanguageTableLayoutPanel, 0, 0);
            loginFormTableLayoutPanel.Controls.Add(passwordFieldTextBox, 1, 3);
            loginFormTableLayoutPanel.Controls.Add(showPasswordPictureBox, 2, 3);
            loginFormTableLayoutPanel.Dock = DockStyle.Fill;
            loginFormTableLayoutPanel.Location = new Point(0, 0);
            loginFormTableLayoutPanel.Margin = new Padding(0);
            loginFormTableLayoutPanel.Name = "loginFormTableLayoutPanel";
            loginFormTableLayoutPanel.RowCount = 6;
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            loginFormTableLayoutPanel.Size = new Size(932, 687);
            loginFormTableLayoutPanel.TabIndex = 0;
            // 
            // loginFieldTextBox
            // 
            loginFieldTextBox.BackColor = Color.FromArgb(240, 240, 240);
            loginFieldTextBox.BorderStyle = BorderStyle.FixedSingle;
            loginFieldTextBox.Cursor = Cursors.IBeam;
            loginFieldTextBox.Dock = DockStyle.Fill;
            loginFieldTextBox.Location = new Point(270, 449);
            loginFieldTextBox.Margin = new Padding(10, 11, 10, 11);
            loginFieldTextBox.MaxLength = 30;
            loginFieldTextBox.Name = "loginFieldTextBox";
            loginFieldTextBox.Size = new Size(391, 23);
            loginFieldTextBox.TabIndex = 0;
            loginFieldTextBox.TabStop = false;
            // 
            // registrationLabel
            // 
            registrationLabel.Cursor = Cursors.Hand;
            registrationLabel.Dock = DockStyle.Fill;
            registrationLabel.ForeColor = Color.FromArgb(0, 166, 253);
            registrationLabel.Location = new Point(270, 565);
            registrationLabel.Margin = new Padding(10, 5, 10, 21);
            registrationLabel.Name = "registrationLabel";
            registrationLabel.Size = new Size(391, 28);
            registrationLabel.TabIndex = 0;
            registrationLabel.TextAlign = ContentAlignment.MiddleCenter;
            registrationLabel.Click += ClickOnRegistrationLabel;
            // 
            // selectLanguageTableLayoutPanel
            // 
            selectLanguageTableLayoutPanel.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            selectLanguageTableLayoutPanel.ColumnCount = 2;
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2990646F));
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.7009354F));
            selectLanguageTableLayoutPanel.Controls.Add(selectLanguageComboBox, 1, 0);
            selectLanguageTableLayoutPanel.Controls.Add(flagPictureBox, 0, 0);
            selectLanguageTableLayoutPanel.Dock = DockStyle.Top;
            selectLanguageTableLayoutPanel.Location = new Point(15, 27);
            selectLanguageTableLayoutPanel.Margin = new Padding(15, 27, 24, 0);
            selectLanguageTableLayoutPanel.Name = "selectLanguageTableLayoutPanel";
            selectLanguageTableLayoutPanel.RowCount = 1;
            selectLanguageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            selectLanguageTableLayoutPanel.Size = new Size(221, 39);
            selectLanguageTableLayoutPanel.TabIndex = 0;
            // 
            // selectLanguageComboBox
            // 
            selectLanguageComboBox.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageComboBox.Cursor = Cursors.Hand;
            selectLanguageComboBox.Dock = DockStyle.Fill;
            selectLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectLanguageComboBox.FlatStyle = FlatStyle.Popup;
            selectLanguageComboBox.FormattingEnabled = true;
            selectLanguageComboBox.Location = new Point(58, 5);
            selectLanguageComboBox.Margin = new Padding(4, 4, 4, 0);
            selectLanguageComboBox.Name = "selectLanguageComboBox";
            selectLanguageComboBox.Size = new Size(158, 23);
            selectLanguageComboBox.TabIndex = 0;
            selectLanguageComboBox.TabStop = false;
            selectLanguageComboBox.SelectedIndexChanged += SelectLanguageComboBoxSelectedIndexChanged;
            // 
            // flagPictureBox
            // 
            flagPictureBox.Dock = DockStyle.Fill;
            flagPictureBox.Location = new Point(4, 4);
            flagPictureBox.Name = "flagPictureBox";
            flagPictureBox.Size = new Size(46, 31);
            flagPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            flagPictureBox.TabIndex = 0;
            flagPictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(178, 242, 196);
            ClientSize = new Size(932, 687);
            Controls.Add(loginFormTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.logoIcon;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            KeyDown += FormKeyDown;
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)showPasswordPictureBox).EndInit();
            loginFormTableLayoutPanel.ResumeLayout(false);
            loginFormTableLayoutPanel.PerformLayout();
            selectLanguageTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private TextBox passwordFieldTextBox;
        private Label messageLabel;
        private Button enterButton;
        private PictureBox logoPictureBox;
        private PictureBox showPasswordPictureBox;
        private TableLayoutPanel loginFormTableLayoutPanel;
        private TextBox loginFieldTextBox;
        private Label registrationLabel;
        private ComboBox selectLanguageComboBox;
        private TableLayoutPanel selectLanguageTableLayoutPanel;
        private PictureBox flagPictureBox;
    }
}