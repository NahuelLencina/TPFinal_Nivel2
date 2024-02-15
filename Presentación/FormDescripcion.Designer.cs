
namespace Presentación
{
    partial class FormDescripcion
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
            this.ltbDescripcion = new System.Windows.Forms.RichTextBox();
            this.pboxArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // ltbDescripcion
            // 
            this.ltbDescripcion.Location = new System.Drawing.Point(12, 12);
            this.ltbDescripcion.Name = "ltbDescripcion";
            this.ltbDescripcion.Size = new System.Drawing.Size(200, 148);
            this.ltbDescripcion.TabIndex = 0;
            this.ltbDescripcion.Text = "";
          
            // 
            // pboxArticulo
            // 
            this.pboxArticulo.Location = new System.Drawing.Point(218, 12);
            this.pboxArticulo.Name = "pboxArticulo";
            this.pboxArticulo.Size = new System.Drawing.Size(232, 288);
            this.pboxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxArticulo.TabIndex = 1;
            this.pboxArticulo.TabStop = false;
            // 
            // FormDescripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 337);
            this.Controls.Add(this.pboxArticulo);
            this.Controls.Add(this.ltbDescripcion);
            this.Name = "FormDescripcion";
            this.Text = "descripcion";
            this.Load += new System.EventHandler(this.FormDescripcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ltbDescripcion;
        private System.Windows.Forms.PictureBox pboxArticulo;
    }
}