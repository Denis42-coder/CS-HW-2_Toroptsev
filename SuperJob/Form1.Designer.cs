namespace SuperJob
{
    partial class Form1
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbRateHour = new System.Windows.Forms.RadioButton();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rbRateFix = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(56, 61);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(153, 20);
            this.tbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ф.И.О.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Должность";
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(56, 124);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(153, 20);
            this.tbPosition.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ставка";
            // 
            // rbRateHour
            // 
            this.rbRateHour.AutoSize = true;
            this.rbRateHour.Location = new System.Drawing.Point(86, 172);
            this.rbRateHour.Name = "rbRateHour";
            this.rbRateHour.Size = new System.Drawing.Size(118, 17);
            this.rbRateHour.TabIndex = 5;
            this.rbRateHour.TabStop = true;
            this.rbRateHour.Text = "Почасовая оплата";
            this.rbRateHour.UseVisualStyleBackColor = true;
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(58, 270);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(151, 20);
            this.tbRate.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(58, 338);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rbRateFix
            // 
            this.rbRateFix.AutoSize = true;
            this.rbRateFix.Location = new System.Drawing.Point(86, 205);
            this.rbRateFix.Name = "rbRateFix";
            this.rbRateFix.Size = new System.Drawing.Size(140, 17);
            this.rbRateFix.TabIndex = 8;
            this.rbRateFix.TabStop = true;
            this.rbRateFix.Text = "Фиксированая оплата";
            this.rbRateFix.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbRateFix);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.rbRateHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbRateHour;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rbRateFix;
    }
}

