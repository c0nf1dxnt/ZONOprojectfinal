using ZONOproject.Database;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOproject
{
    /// <summary>
    /// Класс формы авторизации пользователя в системе
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Поля
        bool isEntrance = true;
        bool isPasswordVisible = false;
        TextBox repeatPasswordTextBox = new TextBox();
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        ResourceManager languageResources = new ResourceManager("ZONOproject.Localization.LoginFormRU", typeof(LoginForm).Assembly);
        ResourceManager localizationResources = new ResourceManager("ZONOproject.Localization.Languages", typeof(LoginForm).Assembly);  
        #endregion

        #region События
        private void EntryButtonClick(object sender, EventArgs e)
        {
            if ((loginFieldTextBox.Text == String.Empty) || (passwordFieldTextBox.Text == String.Empty))
            {
                logger.Info("Пользователь нажал на кнопку входа/регистрации, не указав данные," +
                    "необходимые для входа/регистрации");

                MessageBox.Show(languageResources.GetString("errorMessageContent"), languageResources
                    .GetString("errorMessageTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!isEntrance)
            {
                logger.Info("Пользователь нажал на кнопку регистрации");

                var repeatPasswordTextBox = loginFormTableLayoutPanel.Controls["repeatPasswordTextBox"];

                if (repeatPasswordTextBox == null)
                {
                    logger.Error("При регистрации поле для повтора введенного пароля не появилось." +
                        "Регистрация невозможна!");

                    return;
                }

                if (repeatPasswordTextBox.Text != passwordFieldTextBox.Text)
                {
                    logger.Info("Пользователь не зарегистрирован, т.к. было введено два разных пароля");

                    MessageBox.Show(languageResources.GetString("passwordMismatchContent"), languageResources
                    .GetString("passwordMismatchTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    repeatPasswordTextBox.Text = String.Empty;
                    passwordFieldTextBox.Text = String.Empty;

                    return;
                }

                var registrationResult = DatabaseInteraction.RegisterNewUser(loginFieldTextBox.Text,
                    passwordFieldTextBox.Text);

                if (!registrationResult)
                {
                    logger.Warn($"Пользователь не зарегистрирован, т.к. логин {loginFieldTextBox.Text}" +
                        $"уже существует в БД");

                    MessageBox.Show(languageResources.GetString("errorRegistrationContent"), languageResources
                    .GetString("errorRegistrationTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    loginFieldTextBox.Text = String.Empty;
                }
                else
                {
                    logger.Debug($"Пользователь зарегистрирован. В БД добавлен новый логин {loginFieldTextBox.Text}");

                    MessageBox.Show(languageResources.GetString("successfulRegistrationContent"), languageResources
                    .GetString("successfulRegistrationTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    enterButton.Text = languageResources.GetString($"{enterButton.Name}EnterValue");
                    messageLabel.Text = languageResources.GetString($"{messageLabel.Name}EnterValue");
                    registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}EnterValue");

                    repeatPasswordTextBox.Dispose();
                    loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);

                    loginFieldTextBox.Text = String.Empty;
                    passwordFieldTextBox.Text = String.Empty;
                    isEntrance = true;
                }
            }
            else if (isEntrance)
            {
                logger.Info("Пользователь нажал на кнопку входа в приложение");

                var loginResult = DatabaseInteraction.CheckLoginData(loginFieldTextBox.Text,
                    passwordFieldTextBox.Text);

                if (loginResult)
                {
                    logger.Info($"Пользователь с логином {loginFieldTextBox} успешно вошел в приложение");

                    Program.SetLanguageInformation(selectLanguageComboBox.SelectedItem, languageResources);
                    Close();
                }

                logger.Warn($"Пользователь не вошел в приложение, т.к. логина {loginFieldTextBox.Text}" +
                    $"не существует в БД");

                MessageBox.Show(languageResources.GetString("loginFailedContent"), languageResources
                .GetString("loginFailedTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClickOnRegistrationLabel(object sender, EventArgs e)
        {
            if (isEntrance)
            {
                logger.Info("Пользователь нажал на кнопку для начала регистрации");

                loginFormTableLayoutPanel.Controls.Add(registrationLabel, 0, 4);

                repeatPasswordTextBox.Dock = DockStyle.Fill;
                repeatPasswordTextBox.Font = new Font(fontCollection.Families[0], 14);
                repeatPasswordTextBox.BackColor = Color.FromArgb(240, 240, 240);
                repeatPasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
                repeatPasswordTextBox.Cursor = Cursors.IBeam;
                repeatPasswordTextBox.Margin = new Padding(10, 4, 10, 11);
                repeatPasswordTextBox.MaxLength = 30;
                repeatPasswordTextBox.Name = "repeatPasswordTextBox";
                repeatPasswordTextBox.TabIndex = 0;
                repeatPasswordTextBox.UseSystemPasswordChar = true;
                repeatPasswordTextBox.Visible = true;
                repeatPasswordTextBox.PlaceholderText = languageResources.GetString(repeatPasswordTextBox.Name);
                loginFormTableLayoutPanel.Controls.Add(repeatPasswordTextBox, 1, 4);

                showPasswordPictureBox.Visible = true;
                passwordFieldTextBox.Margin = new Padding(10, 8, 10, 11);
                loginFieldTextBox.Text = string.Empty;
                passwordFieldTextBox.Text = string.Empty;
                repeatPasswordTextBox.Text = string.Empty;
                repeatPasswordTextBox.Visible = true;

                messageLabel.Text = languageResources.GetString($"{messageLabel.Name}RegistrationValue");
                enterButton.Text = languageResources.GetString($"{enterButton.Name}RegistrationValue");
                registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}RegistrationValue");
                isEntrance = false;
            }
            else
            {
                logger.Info("Пользователь нажал на кнопку для возвращения ко входу");

                var repeatPasswordTextBox = loginFormTableLayoutPanel.Controls["repeatPasswordTextBox"];

                if (repeatPasswordTextBox == null)
                {
                    logger.Error("При регистрации поле для повтора введенного пароля не появилось");

                    return;
                }

                repeatPasswordTextBox.Dispose();
                repeatPasswordTextBox.Visible = false;
                loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);

                showPasswordPictureBox.Visible = true;
                passwordFieldTextBox.Margin = new Padding(10, 11, 10, 11);

                messageLabel.Text = languageResources.GetString($"{messageLabel.Name}EnterValue");
                enterButton.Text = languageResources.GetString($"{enterButton.Name}EnterValue");
                registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}EnterValue");

                loginFieldTextBox.Text = String.Empty;
                passwordFieldTextBox.Text = String.Empty;
                isEntrance = true;
            }
        }

        private void ShowPasswordPictureBox(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                logger.Info("Пользователь нажал на иконку для скрытия пароля");

                isPasswordVisible = false;
                passwordFieldTextBox.UseSystemPasswordChar = true;
                repeatPasswordTextBox.UseSystemPasswordChar = true;
                showPasswordPictureBox.Image = Properties.Resources.eyeHidden;
            }
            else
            {
                logger.Info("Пользователь нажал на иконку для просмотра пароля");

                isPasswordVisible = true;
                passwordFieldTextBox.UseSystemPasswordChar = false;
                repeatPasswordTextBox.UseSystemPasswordChar = false;
                showPasswordPictureBox.Image = Properties.Resources.eyeVisible;
            }
        }

        private void SelectLanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Пользователь сменил язык на {selectLanguageComboBox.SelectedText}");

            switch (selectLanguageComboBox.SelectedIndex)
            {
                case 0:
                    languageResources = new ResourceManager("ZONOproject.Localization.LoginFormRU",
                        typeof(LoginForm).Assembly);
                    break;
                case 1:
                    languageResources = new ResourceManager("ZONOproject.Localization.LoginFormEN",
                        typeof(LoginForm).Assembly);
                    break;
            }

            if (isEntrance)
            {
                enterButton.Text = languageResources.GetString($"{enterButton.Name}EnterValue");
                registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}EnterValue");
                messageLabel.Text = languageResources.GetString($"{messageLabel.Name}EnterValue");
            }
            else
            {
                enterButton.Text = languageResources.GetString($"{enterButton.Name}RegistrationValue");
                registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}RegistrationValue");
                messageLabel.Text = languageResources.GetString($"{messageLabel.Name}RegistrationValue");

                var repeatPasswordTextBox = loginFormTableLayoutPanel.Controls["repeatPasswordTextBox"] as TextBox;

                if (repeatPasswordTextBox == null)
                {
                    logger.Error("При регистрации поле для повтора введенного пароля не появилось");

                    return;
                }

                repeatPasswordTextBox.PlaceholderText = languageResources.GetString(repeatPasswordTextBox.Name);
            }

            passwordFieldTextBox.PlaceholderText = languageResources.GetString(passwordFieldTextBox.Name);
            loginFieldTextBox.PlaceholderText = languageResources.GetString(loginFieldTextBox.Name);
            Text = languageResources.GetString(Name);
            flagPictureBox.Image = (Image)languageResources.GetObject("flag");

            logger.Info("Все элементы управления поменяли язык");
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EntryButtonClick(sender, e);
            }
        }
        #endregion

        #region Конструкторы
        public LoginForm()
        {
            logger.Info("Запустилось приложение. Открылась форма входа в приложение");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");

            InitializeComponent();

            TextBox repeatPasswordTextBox;

            messageLabel.Font = new Font(fontCollection.Families[0], 16);
            loginFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            passwordFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            registrationLabel.Font = new Font(fontCollection.Families[0], 12);
            selectLanguageComboBox.Font = new Font(fontCollection.Families[0], 12);

            selectLanguageComboBox.Items.AddRange(new string[] { localizationResources.GetString("RU"),
                localizationResources.GetString("EN") });
            selectLanguageComboBox.SelectedItem = localizationResources.GetString("RU");
        }
        #endregion
    }
}