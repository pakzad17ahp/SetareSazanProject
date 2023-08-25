using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.SqlServer;

namespace SetareSazanProject
{
    partial class TextBoxPro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextBoxPro
            // 
            this.EnabledChanged += new System.EventHandler(this.TextBoxPro_EnabledChanged);
            this.TextChanged += new System.EventHandler(this.TextBoxPro_TextChanged);
            this.Enter += new System.EventHandler(this.TextBoxPro_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPro_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPro_KeyPress);
            this.Leave += new System.EventHandler(this.TextBoxPro_Leave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBoxPro_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.TextBoxPro_MouseWheel);
            this.ResumeLayout(false);

        }

        #endregion





    }
}
