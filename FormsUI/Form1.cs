using static FormsUI.DataManager.DataFormat;

namespace FormsUI;

public partial class Form1 : Form
{
  private readonly GridPlot _grid;
  private readonly DataManager _dm;

  public Form1()
  {
    InitializeComponent();
    _grid = new(GridPb, []);
    _dm = new();
  }

  private void GridPb_Paint(object sender, PaintEventArgs e)
  {
    _grid.Paint(sender, e);
  }

  private void RefreshButton_Click(object sender, EventArgs e) => FetchAndDraw();

  private void RunStopButton_Click(object sender, EventArgs e)
  {
    RunStopButton.Text = RunStopButton.Text == "Run" ? "Stop" : "Run";
    if (RunStopButton.Text == "Stop")
      GridTimer.Start();
    else
      GridTimer.Stop();
  }

  /// <summary>
  /// Fetches data from the UDP, treats them and draws them on the grid.
  /// </summary>
  private void FetchAndDraw()
  {
    var mode = SmoothRadioButton.Checked ? Smoothed : Raw;
    _dm.SmoothingPeriod = (int)SmoothingPeriodUpDown.Value;
    var points = _dm.FetchData(mode);
    _grid.DrawGrid(points);
  }

  private void GridTimer_Tick(object sender, EventArgs e)
  {
    try
    {
      FetchAndDraw();
    }
    catch (Exception ex)
    {
      GridTimer.Stop();
      RunStopButton.Text = "Run";
      MessageBox.Show("Error: " + ex.Message);
    }
  }

  private void SmoothRadioButton_CheckedChanged(object sender, EventArgs e) => SmoothingPeriodGroupBox.Visible = true;
  private void RawRadioButton_CheckedChanged(object sender, EventArgs e) => SmoothingPeriodGroupBox.Visible = false;
}
