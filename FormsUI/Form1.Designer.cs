namespace FormsUI
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      GridPb = new PictureBox();
      ((System.ComponentModel.ISupportInitialize)GridPb).BeginInit();
      SuspendLayout();
      // 
      // GridPb
      // 
      GridPb.Location = new Point(169, 67);
      GridPb.Name = "GridPb";
      GridPb.Size = new Size(430, 296);
      GridPb.TabIndex = 0;
      GridPb.TabStop = false;
      GridPb.Paint += GridPb_Paint;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(GridPb);
      Name = "Form1";
      Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)GridPb).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private PictureBox GridPb;
  }
}
