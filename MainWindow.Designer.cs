namespace WeatherMonitoring
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.TextBox();
            this.StopMetiostationButton = new System.Windows.Forms.Button();
            this.addMeteostation = new System.Windows.Forms.Button();
            this.placeholerForTextBox = new System.Windows.Forms.Label();
            this.nameMeteostation = new System.Windows.Forms.TextBox();
            this.periodSendingData = new System.Windows.Forms.ComboBox();
            this.locationMeteostation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.meteostationType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteMeteostationButton = new System.Windows.Forms.Button();
            this.restartMeteostationButton = new System.Windows.Forms.Button();
            this.meteostaionCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.watchAllMeteostations = new System.Windows.Forms.Button();
            this.chooseMeteostation = new System.Windows.Forms.Button();
            this.meteostationType2 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 1;
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(439, 20);
            this.data.Multiline = true;
            this.data.Name = "data";
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data.Size = new System.Drawing.Size(407, 494);
            this.data.TabIndex = 2;
            this.data.TextChanged += new System.EventHandler(this.data_TextChanged);
            // 
            // StopMetiostationButton
            // 
            this.StopMetiostationButton.Location = new System.Drawing.Point(17, 176);
            this.StopMetiostationButton.Name = "StopMetiostationButton";
            this.StopMetiostationButton.Size = new System.Drawing.Size(402, 31);
            this.StopMetiostationButton.TabIndex = 3;
            this.StopMetiostationButton.Text = "Приостоновить метеостанцию";
            this.StopMetiostationButton.UseVisualStyleBackColor = true;
            this.StopMetiostationButton.Click += new System.EventHandler(this.StopMetiostationButton_Click);
            // 
            // addMeteostation
            // 
            this.addMeteostation.Location = new System.Drawing.Point(18, 360);
            this.addMeteostation.Name = "addMeteostation";
            this.addMeteostation.Size = new System.Drawing.Size(260, 34);
            this.addMeteostation.TabIndex = 19;
            this.addMeteostation.Text = "Создать метеостанцию";
            this.addMeteostation.UseVisualStyleBackColor = true;
            this.addMeteostation.Click += new System.EventHandler(this.addMeteostation_Click);
            // 
            // placeholerForTextBox
            // 
            this.placeholerForTextBox.AutoSize = true;
            this.placeholerForTextBox.Location = new System.Drawing.Point(21, 164);
            this.placeholerForTextBox.Name = "placeholerForTextBox";
            this.placeholerForTextBox.Size = new System.Drawing.Size(173, 16);
            this.placeholerForTextBox.TabIndex = 18;
            this.placeholerForTextBox.Text = "Название метеостанции:";
            // 
            // nameMeteostation
            // 
            this.nameMeteostation.Location = new System.Drawing.Point(18, 194);
            this.nameMeteostation.Name = "nameMeteostation";
            this.nameMeteostation.Size = new System.Drawing.Size(260, 22);
            this.nameMeteostation.TabIndex = 17;
            // 
            // periodSendingData
            // 
            this.periodSendingData.FormattingEnabled = true;
            this.periodSendingData.Location = new System.Drawing.Point(18, 316);
            this.periodSendingData.Name = "periodSendingData";
            this.periodSendingData.Size = new System.Drawing.Size(260, 24);
            this.periodSendingData.TabIndex = 16;
            this.periodSendingData.Tag = "";
            this.periodSendingData.Text = "Выберите период выборки данных";
            // 
            // locationMeteostation
            // 
            this.locationMeteostation.FormattingEnabled = true;
            this.locationMeteostation.Location = new System.Drawing.Point(18, 275);
            this.locationMeteostation.Name = "locationMeteostation";
            this.locationMeteostation.Size = new System.Drawing.Size(260, 24);
            this.locationMeteostation.TabIndex = 15;
            this.locationMeteostation.Tag = "";
            this.locationMeteostation.Text = "Выберите локацию метеостанции";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 14;
            // 
            // meteostationType
            // 
            this.meteostationType.FormattingEnabled = true;
            this.meteostationType.Location = new System.Drawing.Point(18, 232);
            this.meteostationType.Name = "meteostationType";
            this.meteostationType.Size = new System.Drawing.Size(260, 24);
            this.meteostationType.TabIndex = 13;
            this.meteostationType.Tag = "";
            this.meteostationType.Text = "Выберите вид метеостанции";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addMeteostation);
            this.groupBox1.Controls.Add(this.placeholerForTextBox);
            this.groupBox1.Controls.Add(this.meteostationType);
            this.groupBox1.Controls.Add(this.nameMeteostation);
            this.groupBox1.Controls.Add(this.locationMeteostation);
            this.groupBox1.Controls.Add(this.periodSendingData);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 531);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создать метеостанцию";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteMeteostationButton);
            this.groupBox2.Controls.Add(this.restartMeteostationButton);
            this.groupBox2.Controls.Add(this.meteostaionCombobox);
            this.groupBox2.Controls.Add(this.data);
            this.groupBox2.Controls.Add(this.StopMetiostationButton);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(337, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(863, 531);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа метеостанций";
            // 
            // deleteMeteostationButton
            // 
            this.deleteMeteostationButton.Location = new System.Drawing.Point(17, 250);
            this.deleteMeteostationButton.Name = "deleteMeteostationButton";
            this.deleteMeteostationButton.Size = new System.Drawing.Size(402, 31);
            this.deleteMeteostationButton.TabIndex = 24;
            this.deleteMeteostationButton.Text = "Удалить метоостанцию";
            this.deleteMeteostationButton.UseVisualStyleBackColor = true;
            this.deleteMeteostationButton.Click += new System.EventHandler(this.deleteMeteostationButton_Click);
            // 
            // restartMeteostationButton
            // 
            this.restartMeteostationButton.Location = new System.Drawing.Point(19, 213);
            this.restartMeteostationButton.Name = "restartMeteostationButton";
            this.restartMeteostationButton.Size = new System.Drawing.Size(402, 31);
            this.restartMeteostationButton.TabIndex = 23;
            this.restartMeteostationButton.Text = "Возобновить работу метеостанции";
            this.restartMeteostationButton.UseVisualStyleBackColor = true;
            this.restartMeteostationButton.Click += new System.EventHandler(this.restartMeteostationButton_Click);
            // 
            // meteostaionCombobox
            // 
            this.meteostaionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.meteostaionCombobox.FormattingEnabled = true;
            this.meteostaionCombobox.Location = new System.Drawing.Point(17, 28);
            this.meteostaionCombobox.Name = "meteostaionCombobox";
            this.meteostaionCombobox.Size = new System.Drawing.Size(402, 152);
            this.meteostaionCombobox.TabIndex = 22;
            this.meteostaionCombobox.Tag = "";
            this.meteostaionCombobox.Text = "Выберите вид метеостанции";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.watchAllMeteostations);
            this.groupBox3.Controls.Add(this.chooseMeteostation);
            this.groupBox3.Controls.Add(this.meteostationType2);
            this.groupBox3.Location = new System.Drawing.Point(19, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 158);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Создать метеостанцию";
            // 
            // watchAllMeteostations
            // 
            this.watchAllMeteostations.Location = new System.Drawing.Point(6, 105);
            this.watchAllMeteostations.Name = "watchAllMeteostations";
            this.watchAllMeteostations.Size = new System.Drawing.Size(388, 35);
            this.watchAllMeteostations.TabIndex = 28;
            this.watchAllMeteostations.Text = "Показывать все метеостанции";
            this.watchAllMeteostations.UseVisualStyleBackColor = true;
            this.watchAllMeteostations.Click += new System.EventHandler(this.watchAllMeteostations_Click);
            // 
            // chooseMeteostation
            // 
            this.chooseMeteostation.Location = new System.Drawing.Point(6, 64);
            this.chooseMeteostation.Name = "chooseMeteostation";
            this.chooseMeteostation.Size = new System.Drawing.Size(388, 35);
            this.chooseMeteostation.TabIndex = 27;
            this.chooseMeteostation.Text = "Показывать только выбранную метеостанцию";
            this.chooseMeteostation.UseVisualStyleBackColor = true;
            this.chooseMeteostation.Click += new System.EventHandler(this.chooseMeteostation_Click);
            // 
            // meteostationType2
            // 
            this.meteostationType2.FormattingEnabled = true;
            this.meteostationType2.Location = new System.Drawing.Point(6, 34);
            this.meteostationType2.Name = "meteostationType2";
            this.meteostationType2.Size = new System.Drawing.Size(388, 24);
            this.meteostationType2.TabIndex = 22;
            this.meteostationType2.Tag = "";
            this.meteostationType2.Text = "Выберите вид метеостанции";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 563);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainWindow";
            this.Text = "WheatherMonitoring";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Button StopMetiostationButton;
        private System.Windows.Forms.Button addMeteostation;
        private System.Windows.Forms.Label placeholerForTextBox;
        private System.Windows.Forms.TextBox nameMeteostation;
        private System.Windows.Forms.ComboBox periodSendingData;
        private System.Windows.Forms.ComboBox locationMeteostation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox meteostationType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox meteostaionCombobox;
        private System.Windows.Forms.Button restartMeteostationButton;
        private System.Windows.Forms.Button deleteMeteostationButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button watchAllMeteostations;
        private System.Windows.Forms.Button chooseMeteostation;
        private System.Windows.Forms.ComboBox meteostationType2;
    }
}

