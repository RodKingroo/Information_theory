using System.ComponentModel;

namespace Huffman
{
    partial class FHuffman
    {
        private IContainer container = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (container != null)) container.Dispose();
            base.Dispose(disposing);

        }

        private void InitializeComponent()
        {
            this.CodeBtn = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CodeBtn
            // 
            this.CodeBtn.Location = new System.Drawing.Point(668, 14);
            this.CodeBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CodeBtn.Name = "CodeBtn";
            this.CodeBtn.Size = new System.Drawing.Size(88, 27);
            this.CodeBtn.TabIndex = 0;
            this.CodeBtn.Text = "Code";
            this.CodeBtn.UseVisualStyleBackColor = true;
            this.CodeBtn.Click += new System.EventHandler(this.CodeBtn_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(14, 14);
            this.OutputTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(647, 259);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.Text = "";
            // 
            // FHuffman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 285);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.CodeBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FHuffman";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private Button CodeBtn;
        private RichTextBox OutputTextBox;

    }
}
