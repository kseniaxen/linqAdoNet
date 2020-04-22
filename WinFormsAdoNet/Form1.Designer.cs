namespace WinFormsAdoNet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.buttonLazyLoad = new System.Windows.Forms.Button();
            this.buttonEagerLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(988, 436);
            this.dataGridView1.TabIndex = 0;
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(862, 4);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(107, 49);
            this.btFind.TabIndex = 1;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(695, 22);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(137, 22);
            this.tbFind.TabIndex = 2;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // buttonLazyLoad
            // 
            this.buttonLazyLoad.Location = new System.Drawing.Point(35, 9);
            this.buttonLazyLoad.Name = "buttonLazyLoad";
            this.buttonLazyLoad.Size = new System.Drawing.Size(98, 39);
            this.buttonLazyLoad.TabIndex = 3;
            this.buttonLazyLoad.Text = "Lazy loading";
            this.buttonLazyLoad.UseVisualStyleBackColor = true;
            this.buttonLazyLoad.Click += new System.EventHandler(this.buttonLazyLoad_Click);
            // 
            // buttonEagerLoad
            // 
            this.buttonEagerLoad.Location = new System.Drawing.Point(174, 9);
            this.buttonEagerLoad.Name = "buttonEagerLoad";
            this.buttonEagerLoad.Size = new System.Drawing.Size(111, 39);
            this.buttonEagerLoad.TabIndex = 4;
            this.buttonEagerLoad.Text = "Eager loading";
            this.buttonEagerLoad.UseVisualStyleBackColor = true;
            this.buttonEagerLoad.Click += new System.EventHandler(this.buttonEagerLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Время (в миллисекундах):";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(494, 20);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(16, 17);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 526);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEagerLoad);
            this.Controls.Add(this.buttonLazyLoad);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button buttonLazyLoad;
        private System.Windows.Forms.Button buttonEagerLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTime;
    }
}

