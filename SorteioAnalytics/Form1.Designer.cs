
namespace SorteioAnalytics
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.ckbFiltroExt = new System.Windows.Forms.CheckBox();
            this.cbExtracoes = new System.Windows.Forms.ComboBox();
            this.calendarInicio = new System.Windows.Forms.DateTimePicker();
            this.calendarFim = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gerar Relatório";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckbFiltroExt
            // 
            this.ckbFiltroExt.AutoSize = true;
            this.ckbFiltroExt.Checked = true;
            this.ckbFiltroExt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFiltroExt.Location = new System.Drawing.Point(144, 12);
            this.ckbFiltroExt.Name = "ckbFiltroExt";
            this.ckbFiltroExt.Size = new System.Drawing.Size(127, 17);
            this.ckbFiltroExt.TabIndex = 5;
            this.ckbFiltroExt.Text = "Utilizar Filtro Extração";
            this.ckbFiltroExt.UseVisualStyleBackColor = true;
            // 
            // cbExtracoes
            // 
            this.cbExtracoes.FormattingEnabled = true;
            this.cbExtracoes.Location = new System.Drawing.Point(12, 9);
            this.cbExtracoes.Name = "cbExtracoes";
            this.cbExtracoes.Size = new System.Drawing.Size(121, 21);
            this.cbExtracoes.TabIndex = 6;
            this.cbExtracoes.SelectedIndexChanged += new System.EventHandler(this.cbExtracoes_SelectedIndexChanged);
            // 
            // calendarInicio
            // 
            this.calendarInicio.Location = new System.Drawing.Point(12, 45);
            this.calendarInicio.Name = "calendarInicio";
            this.calendarInicio.Size = new System.Drawing.Size(245, 20);
            this.calendarInicio.TabIndex = 9;
            // 
            // calendarFim
            // 
            this.calendarFim.Location = new System.Drawing.Point(12, 80);
            this.calendarFim.Name = "calendarFim";
            this.calendarFim.Size = new System.Drawing.Size(245, 20);
            this.calendarFim.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 118);
            this.Controls.Add(this.calendarFim);
            this.Controls.Add(this.calendarInicio);
            this.Controls.Add(this.cbExtracoes);
            this.Controls.Add(this.ckbFiltroExt);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Relatório Extrações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckbFiltroExt;
        private System.Windows.Forms.ComboBox cbExtracoes;
        private System.Windows.Forms.DateTimePicker calendarInicio;
        private System.Windows.Forms.DateTimePicker calendarFim;
    }
}

