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
      components = new System.ComponentModel.Container();
      GridPb = new PictureBox();
      RefreshButton = new Button();
      RunStopButton = new Button();
      GridTimer = new System.Windows.Forms.Timer(components);
      DrawingModeGroupBox = new GroupBox();
      SmoothRadioButton = new RadioButton();
      RawRadioButton = new RadioButton();
      ((System.ComponentModel.ISupportInitialize)GridPb).BeginInit();
      DrawingModeGroupBox.SuspendLayout();
      SuspendLayout();
      // 
      // GridPb
      // 
      GridPb.Location = new Point(77, 79);
      GridPb.Name = "GridPb";
      GridPb.Size = new Size(800, 800);
      GridPb.TabIndex = 0;
      GridPb.TabStop = false;
      GridPb.Paint += GridPb_Paint;
      // 
      // RefreshButton
      // 
      RefreshButton.Location = new Point(312, 895);
      RefreshButton.Name = "RefreshButton";
      RefreshButton.Size = new Size(75, 23);
      RefreshButton.TabIndex = 1;
      RefreshButton.Text = "Refresh";
      RefreshButton.UseVisualStyleBackColor = true;
      RefreshButton.Click += RefreshButton_Click;
      // 
      // RunStopButton
      // 
      RunStopButton.Location = new Point(442, 895);
      RunStopButton.Name = "RunStopButton";
      RunStopButton.Size = new Size(75, 23);
      RunStopButton.TabIndex = 2;
      RunStopButton.Text = "Run";
      RunStopButton.UseVisualStyleBackColor = true;
      RunStopButton.Click += RunStopButton_Click;
      // 
      // GridTimer
      // 
      GridTimer.Tick += GridTimer_Tick;
      // 
      // DrawingModeGroupBox
      // 
      DrawingModeGroupBox.Controls.Add(SmoothRadioButton);
      DrawingModeGroupBox.Controls.Add(RawRadioButton);
      DrawingModeGroupBox.Location = new Point(564, 885);
      DrawingModeGroupBox.Name = "DrawingModeGroupBox";
      DrawingModeGroupBox.Size = new Size(171, 64);
      DrawingModeGroupBox.TabIndex = 3;
      DrawingModeGroupBox.TabStop = false;
      DrawingModeGroupBox.Text = "Mode";
      // 
      // SmoothRadioButton
      // 
      SmoothRadioButton.AutoSize = true;
      SmoothRadioButton.Location = new Point(72, 23);
      SmoothRadioButton.Name = "SmoothRadioButton";
      SmoothRadioButton.Size = new Size(67, 19);
      SmoothRadioButton.TabIndex = 1;
      SmoothRadioButton.TabStop = true;
      SmoothRadioButton.Text = "Smooth";
      SmoothRadioButton.UseVisualStyleBackColor = true;
      // 
      // RawRadioButton
      // 
      RawRadioButton.AutoSize = true;
      RawRadioButton.Checked = true;
      RawRadioButton.Location = new Point(19, 23);
      RawRadioButton.Name = "RawRadioButton";
      RawRadioButton.Size = new Size(47, 19);
      RawRadioButton.TabIndex = 0;
      RawRadioButton.TabStop = true;
      RawRadioButton.Text = "Raw";
      RawRadioButton.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(984, 961);
      Controls.Add(DrawingModeGroupBox);
      Controls.Add(RunStopButton);
      Controls.Add(RefreshButton);
      Controls.Add(GridPb);
      Name = "Form1";
      Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)GridPb).EndInit();
      DrawingModeGroupBox.ResumeLayout(false);
      DrawingModeGroupBox.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private PictureBox GridPb;
    private Button RefreshButton;
    private Button RunStopButton;
    private System.Windows.Forms.Timer GridTimer;
    private GroupBox DrawingModeGroupBox;
    private RadioButton RawRadioButton;
    private RadioButton SmoothRadioButton;
  }
}
