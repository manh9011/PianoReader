namespace PianoReader;

partial class FrmMain
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
        ptbVideoPreview = new PictureBox();
        spcLayout = new SplitContainer();
        tlpVideo = new TableLayoutPanel();
        lblFrame = new Label();
        lblMaxFrame = new Label();
        lblTime = new Label();
        lblMaxTime = new Label();
        tbrSeek = new TrackBar();
        lblLoading = new Label();
        lblLoadProgress = new Label();
        lblTitle = new Label();
        tlpTool = new TableLayoutPanel();
        btnLoadPreset = new Button();
        btnSavePreset = new Button();
        tbrKeyHeight = new TrackBar();
        lblKeyHeightRange = new Label();
        btnStop = new Button();
        lblKeyHeight = new Label();
        btnStart = new Button();
        lblBlackKeyWidth = new Label();
        tbrBlackKeyWidth = new TrackBar();
        lblBlackKeyWidthRange = new Label();
        lblStop = new Label();
        tbrBlackKeyHeight = new TrackBar();
        lblBlackKeyHeightRange = new Label();
        lblStart = new Label();
        lblBlackKeyHeight = new Label();
        tbrColorDeviation = new TrackBar();
        pgbConvert = new ProgressBar();
        tbrTranspose = new TrackBar();
        lblColorDeviationRange = new Label();
        lblTransposeRange = new Label();
        lblTranspose = new Label();
        lblColorDeviation = new Label();
        tbrBPM = new TrackBar();
        lblBPMRange = new Label();
        lblBPM = new Label();
        lblWhiteKeyColor = new Label();
        lblBlackKeyPressedColors = new Label();
        btnBlackPressedRight = new Button();
        btnBlackPressedLeft = new Button();
        lblBlackKeyColor = new Label();
        btnBlack = new Button();
        lblWhiteKeyPressedColors = new Label();
        btnWhitePressedLeft = new Button();
        tbrStartKey = new TrackBar();
        btnWhitePressedRight = new Button();
        btnWhite = new Button();
        lblStartKeyRange = new Label();
        lblStartKey = new Label();
        tbrKeyNumber = new TrackBar();
        tbrKeyTop = new TrackBar();
        lblKeyNumberRange = new Label();
        lblKeyNumber = new Label();
        lblKeyTop = new Label();
        btnConvert = new Button();
        lblKeyTopRange = new Label();
        btnPlayMidi = new Button();
        btnStopMidi = new Button();
        btnSaveMidi = new Button();
        lblCredits = new LinkLabel();
        ofdLoadVideo = new OpenFileDialog();
        sfdSaveMIDI = new SaveFileDialog();
        ofdLoadPreset = new OpenFileDialog();
        sfdSavePreset = new SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)ptbVideoPreview).BeginInit();
        ((System.ComponentModel.ISupportInitialize)spcLayout).BeginInit();
        spcLayout.Panel1.SuspendLayout();
        spcLayout.Panel2.SuspendLayout();
        spcLayout.SuspendLayout();
        tlpVideo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tbrSeek).BeginInit();
        tlpTool.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tbrKeyHeight).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrBlackKeyWidth).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrBlackKeyHeight).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrColorDeviation).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrTranspose).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrBPM).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrStartKey).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrKeyNumber).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbrKeyTop).BeginInit();
        SuspendLayout();
        // 
        // ptbVideoPreview
        // 
        ptbVideoPreview.BackgroundImage = (Image)resources.GetObject("ptbVideoPreview.BackgroundImage");
        ptbVideoPreview.BackgroundImageLayout = ImageLayout.Center;
        tlpVideo.SetColumnSpan(ptbVideoPreview, 3);
        ptbVideoPreview.Dock = DockStyle.Fill;
        ptbVideoPreview.Location = new Point(0, 20);
        ptbVideoPreview.Margin = new Padding(0);
        ptbVideoPreview.Name = "ptbVideoPreview";
        ptbVideoPreview.Size = new Size(921, 735);
        ptbVideoPreview.SizeMode = PictureBoxSizeMode.Zoom;
        ptbVideoPreview.TabIndex = 0;
        ptbVideoPreview.TabStop = false;
        ptbVideoPreview.Click += ptbVideoPreview_Click;
        // 
        // spcLayout
        // 
        spcLayout.BackColor = Color.White;
        spcLayout.Dock = DockStyle.Fill;
        spcLayout.FixedPanel = FixedPanel.Panel2;
        spcLayout.ForeColor = Color.Black;
        spcLayout.Location = new Point(0, 0);
        spcLayout.Name = "spcLayout";
        // 
        // spcLayout.Panel1
        // 
        spcLayout.Panel1.BackColor = Color.Black;
        spcLayout.Panel1.Controls.Add(tlpVideo);
        // 
        // spcLayout.Panel2
        // 
        spcLayout.Panel2.BackColor = Color.White;
        spcLayout.Panel2.Controls.Add(tlpTool);
        spcLayout.Panel2.Controls.Add(lblCredits);
        spcLayout.Size = new Size(1151, 795);
        spcLayout.SplitterDistance = 921;
        spcLayout.TabIndex = 1;
        // 
        // tlpVideo
        // 
        tlpVideo.ColumnCount = 3;
        tlpVideo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        tlpVideo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpVideo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        tlpVideo.Controls.Add(lblFrame, 0, 2);
        tlpVideo.Controls.Add(lblMaxFrame, 0, 3);
        tlpVideo.Controls.Add(lblTime, 2, 2);
        tlpVideo.Controls.Add(lblMaxTime, 2, 3);
        tlpVideo.Controls.Add(tbrSeek, 1, 2);
        tlpVideo.Controls.Add(lblLoading, 0, 0);
        tlpVideo.Controls.Add(lblLoadProgress, 2, 0);
        tlpVideo.Controls.Add(ptbVideoPreview, 0, 1);
        tlpVideo.Controls.Add(lblTitle, 1, 0);
        tlpVideo.Dock = DockStyle.Fill;
        tlpVideo.Location = new Point(0, 0);
        tlpVideo.Name = "tlpVideo";
        tlpVideo.RowCount = 4;
        tlpVideo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpVideo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpVideo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpVideo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpVideo.Size = new Size(921, 795);
        tlpVideo.TabIndex = 2;
        // 
        // lblFrame
        // 
        lblFrame.BackColor = Color.Transparent;
        lblFrame.Dock = DockStyle.Fill;
        lblFrame.ForeColor = Color.White;
        lblFrame.Location = new Point(3, 755);
        lblFrame.Name = "lblFrame";
        lblFrame.Size = new Size(74, 20);
        lblFrame.TabIndex = 5;
        lblFrame.Text = "0";
        lblFrame.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMaxFrame
        // 
        lblMaxFrame.BackColor = Color.Transparent;
        lblMaxFrame.Dock = DockStyle.Fill;
        lblMaxFrame.ForeColor = Color.White;
        lblMaxFrame.Location = new Point(3, 775);
        lblMaxFrame.Name = "lblMaxFrame";
        lblMaxFrame.Size = new Size(74, 20);
        lblMaxFrame.TabIndex = 6;
        lblMaxFrame.Text = "0";
        lblMaxFrame.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTime
        // 
        lblTime.BackColor = Color.Transparent;
        lblTime.Dock = DockStyle.Fill;
        lblTime.ForeColor = Color.White;
        lblTime.Location = new Point(844, 755);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(74, 20);
        lblTime.TabIndex = 3;
        lblTime.Text = "00:00:00";
        lblTime.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMaxTime
        // 
        lblMaxTime.BackColor = Color.Transparent;
        lblMaxTime.Dock = DockStyle.Fill;
        lblMaxTime.ForeColor = Color.White;
        lblMaxTime.Location = new Point(844, 775);
        lblMaxTime.Name = "lblMaxTime";
        lblMaxTime.Size = new Size(74, 20);
        lblMaxTime.TabIndex = 4;
        lblMaxTime.Text = "00:00:00";
        lblMaxTime.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tbrSeek
        // 
        tbrSeek.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tbrSeek.BackColor = Color.Black;
        tbrSeek.Location = new Point(80, 755);
        tbrSeek.Margin = new Padding(0);
        tbrSeek.Maximum = 100;
        tbrSeek.Name = "tbrSeek";
        tlpVideo.SetRowSpan(tbrSeek, 2);
        tbrSeek.Size = new Size(761, 40);
        tbrSeek.TabIndex = 2;
        tbrSeek.TickStyle = TickStyle.None;
        tbrSeek.Scroll += tbrSeek_Scroll;
        // 
        // lblLoading
        // 
        lblLoading.BackColor = Color.Transparent;
        lblLoading.Dock = DockStyle.Fill;
        lblLoading.ForeColor = Color.White;
        lblLoading.Location = new Point(3, 0);
        lblLoading.Name = "lblLoading";
        lblLoading.Size = new Size(74, 20);
        lblLoading.TabIndex = 8;
        lblLoading.Text = "Loading...";
        lblLoading.TextAlign = ContentAlignment.MiddleLeft;
        lblLoading.Visible = false;
        // 
        // lblLoadProgress
        // 
        lblLoadProgress.BackColor = Color.Transparent;
        lblLoadProgress.Dock = DockStyle.Fill;
        lblLoadProgress.ForeColor = Color.White;
        lblLoadProgress.Location = new Point(844, 0);
        lblLoadProgress.Name = "lblLoadProgress";
        lblLoadProgress.Size = new Size(74, 20);
        lblLoadProgress.TabIndex = 7;
        lblLoadProgress.Text = "0%";
        lblLoadProgress.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(83, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(755, 20);
        lblTitle.TabIndex = 9;
        lblTitle.Text = "Press [ ⯈ ] to load video";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tlpTool
        // 
        tlpTool.ColumnCount = 3;
        tlpTool.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpTool.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 41F));
        tlpTool.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
        tlpTool.Controls.Add(btnLoadPreset, 0, 27);
        tlpTool.Controls.Add(btnSavePreset, 0, 26);
        tlpTool.Controls.Add(tbrKeyHeight, 0, 11);
        tlpTool.Controls.Add(lblKeyHeightRange, 1, 10);
        tlpTool.Controls.Add(btnStop, 1, 19);
        tlpTool.Controls.Add(lblKeyHeight, 0, 10);
        tlpTool.Controls.Add(btnStart, 1, 18);
        tlpTool.Controls.Add(lblBlackKeyWidth, 0, 8);
        tlpTool.Controls.Add(tbrBlackKeyWidth, 0, 9);
        tlpTool.Controls.Add(lblBlackKeyWidthRange, 1, 8);
        tlpTool.Controls.Add(lblStop, 0, 19);
        tlpTool.Controls.Add(tbrBlackKeyHeight, 0, 7);
        tlpTool.Controls.Add(lblBlackKeyHeightRange, 1, 6);
        tlpTool.Controls.Add(lblStart, 0, 18);
        tlpTool.Controls.Add(lblBlackKeyHeight, 0, 6);
        tlpTool.Controls.Add(tbrColorDeviation, 0, 17);
        tlpTool.Controls.Add(pgbConvert, 0, 24);
        tlpTool.Controls.Add(tbrTranspose, 0, 23);
        tlpTool.Controls.Add(lblColorDeviationRange, 1, 16);
        tlpTool.Controls.Add(lblTransposeRange, 1, 22);
        tlpTool.Controls.Add(lblTranspose, 0, 22);
        tlpTool.Controls.Add(lblColorDeviation, 0, 16);
        tlpTool.Controls.Add(tbrBPM, 0, 21);
        tlpTool.Controls.Add(lblBPMRange, 1, 20);
        tlpTool.Controls.Add(lblBPM, 0, 20);
        tlpTool.Controls.Add(lblWhiteKeyColor, 0, 12);
        tlpTool.Controls.Add(lblBlackKeyPressedColors, 0, 15);
        tlpTool.Controls.Add(btnBlackPressedRight, 2, 15);
        tlpTool.Controls.Add(btnBlackPressedLeft, 1, 15);
        tlpTool.Controls.Add(lblBlackKeyColor, 0, 14);
        tlpTool.Controls.Add(btnBlack, 1, 14);
        tlpTool.Controls.Add(lblWhiteKeyPressedColors, 0, 13);
        tlpTool.Controls.Add(btnWhitePressedLeft, 1, 13);
        tlpTool.Controls.Add(tbrStartKey, 0, 5);
        tlpTool.Controls.Add(btnWhitePressedRight, 2, 13);
        tlpTool.Controls.Add(btnWhite, 1, 12);
        tlpTool.Controls.Add(lblStartKeyRange, 1, 4);
        tlpTool.Controls.Add(lblStartKey, 0, 4);
        tlpTool.Controls.Add(tbrKeyNumber, 0, 3);
        tlpTool.Controls.Add(tbrKeyTop, 0, 1);
        tlpTool.Controls.Add(lblKeyNumberRange, 1, 2);
        tlpTool.Controls.Add(lblKeyNumber, 0, 2);
        tlpTool.Controls.Add(lblKeyTop, 0, 0);
        tlpTool.Controls.Add(btnConvert, 0, 25);
        tlpTool.Controls.Add(lblKeyTopRange, 1, 0);
        tlpTool.Controls.Add(btnPlayMidi, 1, 25);
        tlpTool.Controls.Add(btnStopMidi, 1, 26);
        tlpTool.Controls.Add(btnSaveMidi, 1, 27);
        tlpTool.Dock = DockStyle.Fill;
        tlpTool.Enabled = false;
        tlpTool.Location = new Point(0, 0);
        tlpTool.Name = "tlpTool";
        tlpTool.RowCount = 29;
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        tlpTool.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpTool.Size = new Size(226, 758);
        tlpTool.TabIndex = 1;
        // 
        // btnLoadPreset
        // 
        btnLoadPreset.Dock = DockStyle.Fill;
        btnLoadPreset.Enabled = false;
        btnLoadPreset.FlatAppearance.BorderSize = 0;
        btnLoadPreset.Location = new Point(3, 621);
        btnLoadPreset.Name = "btnLoadPreset";
        btnLoadPreset.Size = new Size(140, 20);
        btnLoadPreset.TabIndex = 53;
        btnLoadPreset.Text = "LOAD PRESET";
        btnLoadPreset.UseVisualStyleBackColor = true;
        btnLoadPreset.Click += btnLoadPreset_Click;
        // 
        // btnSavePreset
        // 
        btnSavePreset.Dock = DockStyle.Fill;
        btnSavePreset.Enabled = false;
        btnSavePreset.FlatAppearance.BorderSize = 0;
        btnSavePreset.Location = new Point(3, 595);
        btnSavePreset.Name = "btnSavePreset";
        btnSavePreset.Size = new Size(140, 20);
        btnSavePreset.TabIndex = 52;
        btnSavePreset.Text = "SAVE PRESET";
        btnSavePreset.UseVisualStyleBackColor = true;
        btnSavePreset.Click += btnSavePreset_Click;
        // 
        // tbrKeyHeight
        // 
        tlpTool.SetColumnSpan(tbrKeyHeight, 3);
        tbrKeyHeight.Dock = DockStyle.Fill;
        tbrKeyHeight.LargeChange = 50;
        tbrKeyHeight.Location = new Point(3, 253);
        tbrKeyHeight.Maximum = 300;
        tbrKeyHeight.Minimum = 1;
        tbrKeyHeight.Name = "tbrKeyHeight";
        tbrKeyHeight.Size = new Size(220, 20);
        tbrKeyHeight.TabIndex = 2;
        tbrKeyHeight.TickFrequency = 10;
        tbrKeyHeight.Value = 190;
        tbrKeyHeight.Scroll += tbrKeyHeight_Scroll;
        // 
        // lblKeyHeightRange
        // 
        lblKeyHeightRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblKeyHeightRange, 2);
        lblKeyHeightRange.Dock = DockStyle.Fill;
        lblKeyHeightRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblKeyHeightRange.Location = new Point(146, 230);
        lblKeyHeightRange.Margin = new Padding(0);
        lblKeyHeightRange.Name = "lblKeyHeightRange";
        lblKeyHeightRange.Size = new Size(80, 20);
        lblKeyHeightRange.TabIndex = 11;
        lblKeyHeightRange.Text = "(1 - 300)";
        lblKeyHeightRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnStop
        // 
        tlpTool.SetColumnSpan(btnStop, 2);
        btnStop.Dock = DockStyle.Fill;
        btnStop.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
        btnStop.Location = new Point(146, 434);
        btnStop.Margin = new Padding(0);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(80, 20);
        btnStop.TabIndex = 37;
        btnStop.Text = "SET";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // lblKeyHeight
        // 
        lblKeyHeight.AutoSize = true;
        lblKeyHeight.Dock = DockStyle.Fill;
        lblKeyHeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblKeyHeight.Location = new Point(0, 230);
        lblKeyHeight.Margin = new Padding(0);
        lblKeyHeight.Name = "lblKeyHeight";
        lblKeyHeight.Size = new Size(146, 20);
        lblKeyHeight.TabIndex = 2;
        lblKeyHeight.Text = "Keyboard Height: 190";
        lblKeyHeight.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnStart
        // 
        tlpTool.SetColumnSpan(btnStart, 2);
        btnStart.Dock = DockStyle.Fill;
        btnStart.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
        btnStart.Location = new Point(146, 414);
        btnStart.Margin = new Padding(0);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(80, 20);
        btnStart.TabIndex = 36;
        btnStart.Text = "SET";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += btnStart_Click;
        // 
        // lblBlackKeyWidth
        // 
        lblBlackKeyWidth.AutoSize = true;
        lblBlackKeyWidth.Dock = DockStyle.Fill;
        lblBlackKeyWidth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBlackKeyWidth.Location = new Point(0, 184);
        lblBlackKeyWidth.Margin = new Padding(0);
        lblBlackKeyWidth.Name = "lblBlackKeyWidth";
        lblBlackKeyWidth.Size = new Size(146, 20);
        lblBlackKeyWidth.TabIndex = 3;
        lblBlackKeyWidth.Text = "Black Key Width: 19";
        lblBlackKeyWidth.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tbrBlackKeyWidth
        // 
        tlpTool.SetColumnSpan(tbrBlackKeyWidth, 3);
        tbrBlackKeyWidth.Dock = DockStyle.Fill;
        tbrBlackKeyWidth.LargeChange = 50;
        tbrBlackKeyWidth.Location = new Point(3, 207);
        tbrBlackKeyWidth.Maximum = 100;
        tbrBlackKeyWidth.Minimum = 1;
        tbrBlackKeyWidth.Name = "tbrBlackKeyWidth";
        tbrBlackKeyWidth.Size = new Size(220, 20);
        tbrBlackKeyWidth.TabIndex = 3;
        tbrBlackKeyWidth.TickFrequency = 10;
        tbrBlackKeyWidth.Value = 19;
        tbrBlackKeyWidth.Scroll += tbrBlackKeyWidth_Scroll;
        // 
        // lblBlackKeyWidthRange
        // 
        lblBlackKeyWidthRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblBlackKeyWidthRange, 2);
        lblBlackKeyWidthRange.Dock = DockStyle.Fill;
        lblBlackKeyWidthRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBlackKeyWidthRange.Location = new Point(146, 184);
        lblBlackKeyWidthRange.Margin = new Padding(0);
        lblBlackKeyWidthRange.Name = "lblBlackKeyWidthRange";
        lblBlackKeyWidthRange.Size = new Size(80, 20);
        lblBlackKeyWidthRange.TabIndex = 12;
        lblBlackKeyWidthRange.Text = "(1 - 100)";
        lblBlackKeyWidthRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStop
        // 
        lblStop.AutoSize = true;
        lblStop.Dock = DockStyle.Fill;
        lblStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStop.Location = new Point(0, 434);
        lblStop.Margin = new Padding(0);
        lblStop.Name = "lblStop";
        lblStop.Size = new Size(146, 20);
        lblStop.TabIndex = 33;
        lblStop.Text = "Stop frame: 0";
        lblStop.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tbrBlackKeyHeight
        // 
        tlpTool.SetColumnSpan(tbrBlackKeyHeight, 3);
        tbrBlackKeyHeight.Dock = DockStyle.Fill;
        tbrBlackKeyHeight.LargeChange = 50;
        tbrBlackKeyHeight.Location = new Point(3, 161);
        tbrBlackKeyHeight.Maximum = 300;
        tbrBlackKeyHeight.Minimum = 1;
        tbrBlackKeyHeight.Name = "tbrBlackKeyHeight";
        tbrBlackKeyHeight.Size = new Size(220, 20);
        tbrBlackKeyHeight.TabIndex = 4;
        tbrBlackKeyHeight.TickFrequency = 10;
        tbrBlackKeyHeight.Value = 125;
        tbrBlackKeyHeight.Scroll += tbrBlackKeyHeight_Scroll;
        // 
        // lblBlackKeyHeightRange
        // 
        lblBlackKeyHeightRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblBlackKeyHeightRange, 2);
        lblBlackKeyHeightRange.Dock = DockStyle.Fill;
        lblBlackKeyHeightRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBlackKeyHeightRange.Location = new Point(146, 138);
        lblBlackKeyHeightRange.Margin = new Padding(0);
        lblBlackKeyHeightRange.Name = "lblBlackKeyHeightRange";
        lblBlackKeyHeightRange.Size = new Size(80, 20);
        lblBlackKeyHeightRange.TabIndex = 13;
        lblBlackKeyHeightRange.Text = "(1 - 300)";
        lblBlackKeyHeightRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStart
        // 
        lblStart.AutoSize = true;
        lblStart.Dock = DockStyle.Fill;
        lblStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStart.Location = new Point(0, 414);
        lblStart.Margin = new Padding(0);
        lblStart.Name = "lblStart";
        lblStart.Size = new Size(146, 20);
        lblStart.TabIndex = 32;
        lblStart.Text = "Start frame: 0";
        lblStart.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblBlackKeyHeight
        // 
        lblBlackKeyHeight.AutoSize = true;
        lblBlackKeyHeight.Dock = DockStyle.Fill;
        lblBlackKeyHeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBlackKeyHeight.Location = new Point(0, 138);
        lblBlackKeyHeight.Margin = new Padding(0);
        lblBlackKeyHeight.Name = "lblBlackKeyHeight";
        lblBlackKeyHeight.Size = new Size(146, 20);
        lblBlackKeyHeight.TabIndex = 4;
        lblBlackKeyHeight.Text = "Black Key Height: 125";
        lblBlackKeyHeight.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tbrColorDeviation
        // 
        tlpTool.SetColumnSpan(tbrColorDeviation, 3);
        tbrColorDeviation.Dock = DockStyle.Fill;
        tbrColorDeviation.LargeChange = 10;
        tbrColorDeviation.Location = new Point(3, 391);
        tbrColorDeviation.Maximum = 100;
        tbrColorDeviation.Minimum = 10;
        tbrColorDeviation.Name = "tbrColorDeviation";
        tbrColorDeviation.Size = new Size(220, 20);
        tbrColorDeviation.TabIndex = 50;
        tbrColorDeviation.TickFrequency = 10;
        tbrColorDeviation.Value = 30;
        tbrColorDeviation.Scroll += tbrColorDeviation_Scroll;
        // 
        // pgbConvert
        // 
        tlpTool.SetColumnSpan(pgbConvert, 3);
        pgbConvert.Dock = DockStyle.Fill;
        pgbConvert.Location = new Point(3, 549);
        pgbConvert.Name = "pgbConvert";
        pgbConvert.Size = new Size(220, 14);
        pgbConvert.TabIndex = 39;
        pgbConvert.Visible = false;
        // 
        // tbrTranspose
        // 
        tlpTool.SetColumnSpan(tbrTranspose, 3);
        tbrTranspose.Dock = DockStyle.Fill;
        tbrTranspose.LargeChange = 8;
        tbrTranspose.Location = new Point(3, 523);
        tbrTranspose.Maximum = 64;
        tbrTranspose.Name = "tbrTranspose";
        tbrTranspose.Size = new Size(220, 20);
        tbrTranspose.TabIndex = 47;
        tbrTranspose.TickFrequency = 2;
        tbrTranspose.Value = 23;
        tbrTranspose.Scroll += tbrTranspose_Scroll;
        // 
        // lblColorDeviationRange
        // 
        lblColorDeviationRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblColorDeviationRange, 2);
        lblColorDeviationRange.Dock = DockStyle.Fill;
        lblColorDeviationRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblColorDeviationRange.Location = new Point(146, 368);
        lblColorDeviationRange.Margin = new Padding(0);
        lblColorDeviationRange.Name = "lblColorDeviationRange";
        lblColorDeviationRange.Size = new Size(80, 20);
        lblColorDeviationRange.TabIndex = 49;
        lblColorDeviationRange.Text = "(10 - 100)";
        lblColorDeviationRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTransposeRange
        // 
        lblTransposeRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblTransposeRange, 2);
        lblTransposeRange.Dock = DockStyle.Fill;
        lblTransposeRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTransposeRange.Location = new Point(146, 500);
        lblTransposeRange.Margin = new Padding(0);
        lblTransposeRange.Name = "lblTransposeRange";
        lblTransposeRange.Size = new Size(80, 20);
        lblTransposeRange.TabIndex = 46;
        lblTransposeRange.Text = "(0 - 64)";
        lblTransposeRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTranspose
        // 
        lblTranspose.AutoSize = true;
        lblTranspose.Dock = DockStyle.Fill;
        lblTranspose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTranspose.Location = new Point(0, 500);
        lblTranspose.Margin = new Padding(0);
        lblTranspose.Name = "lblTranspose";
        lblTranspose.Size = new Size(146, 20);
        lblTranspose.TabIndex = 45;
        lblTranspose.Text = "Transpose: 23";
        lblTranspose.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblColorDeviation
        // 
        lblColorDeviation.AutoSize = true;
        lblColorDeviation.Dock = DockStyle.Fill;
        lblColorDeviation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblColorDeviation.Location = new Point(0, 368);
        lblColorDeviation.Margin = new Padding(0);
        lblColorDeviation.Name = "lblColorDeviation";
        lblColorDeviation.Size = new Size(146, 20);
        lblColorDeviation.TabIndex = 48;
        lblColorDeviation.Text = "Color Deviation: 30";
        lblColorDeviation.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tbrBPM
        // 
        tlpTool.SetColumnSpan(tbrBPM, 3);
        tbrBPM.Dock = DockStyle.Fill;
        tbrBPM.LargeChange = 20;
        tbrBPM.Location = new Point(3, 477);
        tbrBPM.Maximum = 220;
        tbrBPM.Minimum = 1;
        tbrBPM.Name = "tbrBPM";
        tbrBPM.Size = new Size(220, 20);
        tbrBPM.TabIndex = 18;
        tbrBPM.TickFrequency = 10;
        tbrBPM.Value = 70;
        tbrBPM.Scroll += tbrBPM_Scroll;
        // 
        // lblBPMRange
        // 
        lblBPMRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblBPMRange, 2);
        lblBPMRange.Dock = DockStyle.Fill;
        lblBPMRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBPMRange.Location = new Point(146, 454);
        lblBPMRange.Margin = new Padding(0);
        lblBPMRange.Name = "lblBPMRange";
        lblBPMRange.Size = new Size(80, 20);
        lblBPMRange.TabIndex = 14;
        lblBPMRange.Text = "(40 - 220)";
        lblBPMRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblBPM
        // 
        lblBPM.AutoSize = true;
        lblBPM.Dock = DockStyle.Fill;
        lblBPM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBPM.Location = new Point(0, 454);
        lblBPM.Margin = new Padding(0);
        lblBPM.Name = "lblBPM";
        lblBPM.Size = new Size(146, 20);
        lblBPM.TabIndex = 7;
        lblBPM.Text = "BPM: 70";
        lblBPM.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblWhiteKeyColor
        // 
        lblWhiteKeyColor.AutoSize = true;
        lblWhiteKeyColor.Dock = DockStyle.Fill;
        lblWhiteKeyColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblWhiteKeyColor.Location = new Point(0, 276);
        lblWhiteKeyColor.Margin = new Padding(0);
        lblWhiteKeyColor.Name = "lblWhiteKeyColor";
        lblWhiteKeyColor.Size = new Size(146, 20);
        lblWhiteKeyColor.TabIndex = 8;
        lblWhiteKeyColor.Text = "White Key Color";
        lblWhiteKeyColor.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblBlackKeyPressedColors
        // 
        lblBlackKeyPressedColors.AutoSize = true;
        lblBlackKeyPressedColors.Dock = DockStyle.Fill;
        lblBlackKeyPressedColors.Font = new Font("Segoe UI", 9F);
        lblBlackKeyPressedColors.Location = new Point(0, 342);
        lblBlackKeyPressedColors.Margin = new Padding(0);
        lblBlackKeyPressedColors.Name = "lblBlackKeyPressedColors";
        lblBlackKeyPressedColors.Size = new Size(146, 26);
        lblBlackKeyPressedColors.TabIndex = 21;
        lblBlackKeyPressedColors.Text = "  Pressed";
        lblBlackKeyPressedColors.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnBlackPressedRight
        // 
        btnBlackPressedRight.BackColor = Color.FromArgb(210, 151, 1);
        btnBlackPressedRight.Dock = DockStyle.Fill;
        btnBlackPressedRight.FlatStyle = FlatStyle.Flat;
        btnBlackPressedRight.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
        btnBlackPressedRight.Location = new Point(190, 345);
        btnBlackPressedRight.Name = "btnBlackPressedRight";
        btnBlackPressedRight.Size = new Size(33, 20);
        btnBlackPressedRight.TabIndex = 29;
        btnBlackPressedRight.Text = "R";
        btnBlackPressedRight.UseVisualStyleBackColor = false;
        btnBlackPressedRight.Click += btnBlackPressedRight_Click;
        // 
        // btnBlackPressedLeft
        // 
        btnBlackPressedLeft.BackColor = Color.FromArgb(151, 75, 2);
        btnBlackPressedLeft.Dock = DockStyle.Fill;
        btnBlackPressedLeft.FlatStyle = FlatStyle.Flat;
        btnBlackPressedLeft.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
        btnBlackPressedLeft.Location = new Point(149, 345);
        btnBlackPressedLeft.Name = "btnBlackPressedLeft";
        btnBlackPressedLeft.Size = new Size(35, 20);
        btnBlackPressedLeft.TabIndex = 25;
        btnBlackPressedLeft.Text = "L";
        btnBlackPressedLeft.UseVisualStyleBackColor = false;
        btnBlackPressedLeft.Click += btnBlackPressedLeft_Click;
        // 
        // lblBlackKeyColor
        // 
        lblBlackKeyColor.AutoSize = true;
        lblBlackKeyColor.Dock = DockStyle.Fill;
        lblBlackKeyColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBlackKeyColor.Location = new Point(0, 322);
        lblBlackKeyColor.Margin = new Padding(0);
        lblBlackKeyColor.Name = "lblBlackKeyColor";
        lblBlackKeyColor.Size = new Size(146, 20);
        lblBlackKeyColor.TabIndex = 20;
        lblBlackKeyColor.Text = "Black Key Color";
        lblBlackKeyColor.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnBlack
        // 
        btnBlack.BackColor = Color.FromArgb(53, 0, 13);
        tlpTool.SetColumnSpan(btnBlack, 2);
        btnBlack.Dock = DockStyle.Fill;
        btnBlack.FlatStyle = FlatStyle.Flat;
        btnBlack.Location = new Point(149, 325);
        btnBlack.Name = "btnBlack";
        btnBlack.Size = new Size(74, 14);
        btnBlack.TabIndex = 24;
        btnBlack.UseVisualStyleBackColor = false;
        btnBlack.Click += btnBlack_Click;
        // 
        // lblWhiteKeyPressedColors
        // 
        lblWhiteKeyPressedColors.AutoSize = true;
        lblWhiteKeyPressedColors.Dock = DockStyle.Fill;
        lblWhiteKeyPressedColors.Font = new Font("Segoe UI", 9F);
        lblWhiteKeyPressedColors.Location = new Point(0, 296);
        lblWhiteKeyPressedColors.Margin = new Padding(0);
        lblWhiteKeyPressedColors.Name = "lblWhiteKeyPressedColors";
        lblWhiteKeyPressedColors.Size = new Size(146, 26);
        lblWhiteKeyPressedColors.TabIndex = 19;
        lblWhiteKeyPressedColors.Text = "  Pressed";
        lblWhiteKeyPressedColors.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnWhitePressedLeft
        // 
        btnWhitePressedLeft.BackColor = Color.FromArgb(227, 113, 3);
        btnWhitePressedLeft.Dock = DockStyle.Fill;
        btnWhitePressedLeft.FlatStyle = FlatStyle.Flat;
        btnWhitePressedLeft.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
        btnWhitePressedLeft.Location = new Point(149, 299);
        btnWhitePressedLeft.Name = "btnWhitePressedLeft";
        btnWhitePressedLeft.Size = new Size(35, 20);
        btnWhitePressedLeft.TabIndex = 23;
        btnWhitePressedLeft.Text = "L";
        btnWhitePressedLeft.UseVisualStyleBackColor = false;
        btnWhitePressedLeft.Click += btnWhitePressedLeft_Click;
        // 
        // tbrStartKey
        // 
        tlpTool.SetColumnSpan(tbrStartKey, 3);
        tbrStartKey.Dock = DockStyle.Fill;
        tbrStartKey.LargeChange = 1;
        tbrStartKey.Location = new Point(3, 115);
        tbrStartKey.Maximum = 6;
        tbrStartKey.Name = "tbrStartKey";
        tbrStartKey.Size = new Size(220, 20);
        tbrStartKey.TabIndex = 41;
        tbrStartKey.Scroll += tbrStartKey_Scroll;
        // 
        // btnWhitePressedRight
        // 
        btnWhitePressedRight.BackColor = Color.FromArgb(216, 197, 15);
        btnWhitePressedRight.Dock = DockStyle.Fill;
        btnWhitePressedRight.FlatStyle = FlatStyle.Flat;
        btnWhitePressedRight.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
        btnWhitePressedRight.Location = new Point(190, 299);
        btnWhitePressedRight.Name = "btnWhitePressedRight";
        btnWhitePressedRight.Size = new Size(33, 20);
        btnWhitePressedRight.TabIndex = 27;
        btnWhitePressedRight.Text = "R";
        btnWhitePressedRight.UseVisualStyleBackColor = false;
        btnWhitePressedRight.Click += btnWhitePressedRight_Click;
        // 
        // btnWhite
        // 
        btnWhite.BackColor = Color.FromArgb(247, 253, 227);
        tlpTool.SetColumnSpan(btnWhite, 2);
        btnWhite.Dock = DockStyle.Fill;
        btnWhite.FlatStyle = FlatStyle.Flat;
        btnWhite.Location = new Point(149, 279);
        btnWhite.Name = "btnWhite";
        btnWhite.Size = new Size(74, 14);
        btnWhite.TabIndex = 22;
        btnWhite.UseVisualStyleBackColor = false;
        btnWhite.Click += btnWhite_Click;
        // 
        // lblStartKeyRange
        // 
        lblStartKeyRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblStartKeyRange, 2);
        lblStartKeyRange.Dock = DockStyle.Fill;
        lblStartKeyRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStartKeyRange.Location = new Point(146, 92);
        lblStartKeyRange.Margin = new Padding(0);
        lblStartKeyRange.Name = "lblStartKeyRange";
        lblStartKeyRange.Size = new Size(80, 20);
        lblStartKeyRange.TabIndex = 42;
        lblStartKeyRange.Text = "(C - B)";
        lblStartKeyRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStartKey
        // 
        lblStartKey.AutoSize = true;
        lblStartKey.Dock = DockStyle.Fill;
        lblStartKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStartKey.Location = new Point(0, 92);
        lblStartKey.Margin = new Padding(0);
        lblStartKey.Name = "lblStartKey";
        lblStartKey.Size = new Size(146, 20);
        lblStartKey.TabIndex = 40;
        lblStartKey.Text = "Start Key: C";
        lblStartKey.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tbrKeyNumber
        // 
        tlpTool.SetColumnSpan(tbrKeyNumber, 3);
        tbrKeyNumber.Dock = DockStyle.Fill;
        tbrKeyNumber.LargeChange = 16;
        tbrKeyNumber.Location = new Point(3, 69);
        tbrKeyNumber.Maximum = 88;
        tbrKeyNumber.Minimum = 8;
        tbrKeyNumber.Name = "tbrKeyNumber";
        tbrKeyNumber.Size = new Size(220, 20);
        tbrKeyNumber.TabIndex = 0;
        tbrKeyNumber.TickFrequency = 8;
        tbrKeyNumber.Value = 65;
        tbrKeyNumber.Scroll += tbrKeyNumber_Scroll;
        // 
        // tbrKeyTop
        // 
        tlpTool.SetColumnSpan(tbrKeyTop, 3);
        tbrKeyTop.Dock = DockStyle.Fill;
        tbrKeyTop.LargeChange = 100;
        tbrKeyTop.Location = new Point(3, 23);
        tbrKeyTop.Maximum = 1000;
        tbrKeyTop.Name = "tbrKeyTop";
        tbrKeyTop.Size = new Size(220, 20);
        tbrKeyTop.TabIndex = 1;
        tbrKeyTop.TickFrequency = 50;
        tbrKeyTop.Value = 475;
        tbrKeyTop.Scroll += tbrKeyTop_Scroll;
        // 
        // lblKeyNumberRange
        // 
        lblKeyNumberRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblKeyNumberRange, 2);
        lblKeyNumberRange.Dock = DockStyle.Fill;
        lblKeyNumberRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblKeyNumberRange.Location = new Point(146, 46);
        lblKeyNumberRange.Margin = new Padding(0);
        lblKeyNumberRange.Name = "lblKeyNumberRange";
        lblKeyNumberRange.Size = new Size(80, 20);
        lblKeyNumberRange.TabIndex = 9;
        lblKeyNumberRange.Text = "(8 - 88)";
        lblKeyNumberRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblKeyNumber
        // 
        lblKeyNumber.AutoSize = true;
        lblKeyNumber.Dock = DockStyle.Fill;
        lblKeyNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblKeyNumber.Location = new Point(0, 46);
        lblKeyNumber.Margin = new Padding(0);
        lblKeyNumber.Name = "lblKeyNumber";
        lblKeyNumber.Size = new Size(146, 20);
        lblKeyNumber.TabIndex = 5;
        lblKeyNumber.Text = "Key Number: 65";
        lblKeyNumber.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblKeyTop
        // 
        lblKeyTop.AutoSize = true;
        lblKeyTop.Dock = DockStyle.Fill;
        lblKeyTop.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblKeyTop.Location = new Point(0, 0);
        lblKeyTop.Margin = new Padding(0);
        lblKeyTop.Name = "lblKeyTop";
        lblKeyTop.Size = new Size(146, 20);
        lblKeyTop.TabIndex = 1;
        lblKeyTop.Text = "Keyboard Top: 475";
        lblKeyTop.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnConvert
        // 
        btnConvert.Dock = DockStyle.Fill;
        btnConvert.Enabled = false;
        btnConvert.FlatAppearance.BorderSize = 0;
        btnConvert.Location = new Point(3, 569);
        btnConvert.Name = "btnConvert";
        btnConvert.Size = new Size(140, 20);
        btnConvert.TabIndex = 6;
        btnConvert.Text = "CONVERT";
        btnConvert.UseVisualStyleBackColor = true;
        btnConvert.Click += btnConvert_Click;
        // 
        // lblKeyTopRange
        // 
        lblKeyTopRange.AutoSize = true;
        tlpTool.SetColumnSpan(lblKeyTopRange, 2);
        lblKeyTopRange.Dock = DockStyle.Fill;
        lblKeyTopRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblKeyTopRange.Location = new Point(146, 0);
        lblKeyTopRange.Margin = new Padding(0);
        lblKeyTopRange.Name = "lblKeyTopRange";
        lblKeyTopRange.Size = new Size(80, 20);
        lblKeyTopRange.TabIndex = 10;
        lblKeyTopRange.Text = "(0 - 1000)";
        lblKeyTopRange.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnPlayMidi
        // 
        tlpTool.SetColumnSpan(btnPlayMidi, 2);
        btnPlayMidi.Dock = DockStyle.Fill;
        btnPlayMidi.Enabled = false;
        btnPlayMidi.FlatAppearance.BorderSize = 0;
        btnPlayMidi.Location = new Point(149, 569);
        btnPlayMidi.Name = "btnPlayMidi";
        btnPlayMidi.Size = new Size(74, 20);
        btnPlayMidi.TabIndex = 38;
        btnPlayMidi.Text = "PLAY";
        btnPlayMidi.UseVisualStyleBackColor = true;
        btnPlayMidi.Click += btnPlayMidi_Click;
        // 
        // btnStopMidi
        // 
        tlpTool.SetColumnSpan(btnStopMidi, 2);
        btnStopMidi.Dock = DockStyle.Fill;
        btnStopMidi.Enabled = false;
        btnStopMidi.FlatAppearance.BorderSize = 0;
        btnStopMidi.Location = new Point(149, 595);
        btnStopMidi.Name = "btnStopMidi";
        btnStopMidi.Size = new Size(74, 20);
        btnStopMidi.TabIndex = 44;
        btnStopMidi.Text = "STOP";
        btnStopMidi.UseVisualStyleBackColor = true;
        btnStopMidi.Click += btnStopMidi_Click;
        // 
        // btnSaveMidi
        // 
        tlpTool.SetColumnSpan(btnSaveMidi, 2);
        btnSaveMidi.Dock = DockStyle.Fill;
        btnSaveMidi.Enabled = false;
        btnSaveMidi.FlatAppearance.BorderSize = 0;
        btnSaveMidi.Location = new Point(149, 621);
        btnSaveMidi.Name = "btnSaveMidi";
        btnSaveMidi.Size = new Size(74, 20);
        btnSaveMidi.TabIndex = 43;
        btnSaveMidi.Text = "SAVE";
        btnSaveMidi.UseVisualStyleBackColor = true;
        btnSaveMidi.Click += btnSaveMidi_Click;
        // 
        // lblCredits
        // 
        lblCredits.Dock = DockStyle.Bottom;
        lblCredits.LinkArea = new LinkArea(17, 44);
        lblCredits.Location = new Point(0, 758);
        lblCredits.Name = "lblCredits";
        lblCredits.Size = new Size(226, 37);
        lblCredits.TabIndex = 51;
        lblCredits.TabStop = true;
        lblCredits.Text = "Piano Reader 1.0\r\nhttps://github.com/manh9011";
        lblCredits.TextAlign = ContentAlignment.MiddleCenter;
        lblCredits.UseCompatibleTextRendering = true;
        lblCredits.LinkClicked += lblCredits_LinkClicked;
        // 
        // ofdLoadVideo
        // 
        ofdLoadVideo.DefaultExt = "mp4";
        ofdLoadVideo.Filter = "Video (*.mp4)|*.mp4";
        ofdLoadVideo.Title = "Load Video";
        ofdLoadVideo.FileOk += ofdLoadVideo_FileOk;
        // 
        // sfdSaveMIDI
        // 
        sfdSaveMIDI.DefaultExt = "mid";
        sfdSaveMIDI.Filter = "Midi File (*.mid)|*.mid";
        sfdSaveMIDI.Title = "Save MIDI";
        sfdSaveMIDI.FileOk += sfdSaveMIDI_FileOk;
        // 
        // ofdLoadPreset
        // 
        ofdLoadPreset.DefaultExt = "ini";
        ofdLoadPreset.Filter = "Piano Reader Preset (*.ini)|*.ini";
        ofdLoadPreset.Title = "Load Preset";
        ofdLoadPreset.FileOk += ofdLoadPreset_FileOk;
        // 
        // sfdSavePreset
        // 
        sfdSavePreset.DefaultExt = "ini";
        sfdSavePreset.Filter = "Piano Reader Preset (*.ini)|*.ini";
        sfdSavePreset.Title = "Save Preset";
        sfdSavePreset.FileOk += sfdSavePreset_FileOk;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1151, 795);
        Controls.Add(spcLayout);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Piano Reader";
        WindowState = FormWindowState.Maximized;
        ((System.ComponentModel.ISupportInitialize)ptbVideoPreview).EndInit();
        spcLayout.Panel1.ResumeLayout(false);
        spcLayout.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)spcLayout).EndInit();
        spcLayout.ResumeLayout(false);
        tlpVideo.ResumeLayout(false);
        tlpVideo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tbrSeek).EndInit();
        tlpTool.ResumeLayout(false);
        tlpTool.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tbrKeyHeight).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrBlackKeyWidth).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrBlackKeyHeight).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrColorDeviation).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrTranspose).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrBPM).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrStartKey).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrKeyNumber).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbrKeyTop).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox ptbVideoPreview;
    private SplitContainer spcLayout;
    private TableLayoutPanel tlpTool;
    private TrackBar tbrKeyNumber;
    private TrackBar tbrKeyTop;
    private TrackBar tbrKeyHeight;
    private TrackBar tbrBlackKeyWidth;
    private TrackBar tbrBlackKeyHeight;
    private Label lblKeyNumber;
    private Label lblKeyTop;
    private Label lblKeyHeight;
    private Label lblBlackKeyWidth;
    private Label lblBlackKeyHeight;
    private Button btnConvert;
    private OpenFileDialog ofdLoadVideo;
    private TrackBar tbrSeek;
    private Label lblTime;
    private Label lblMaxTime;
    private Label lblMaxFrame;
    private Label lblFrame;
    private Label lblLoadProgress;
    private Label lblLoading;
    private TableLayoutPanel tlpVideo;
    private TrackBar tbrBPM;
    private Label lblBPMRange;
    private Label lblBlackKeyHeightRange;
    private Label lblBlackKeyWidthRange;
    private Label lblKeyHeightRange;
    private Label lblKeyTopRange;
    private Label lblKeyNumberRange;
    private Label lblWhiteKeyColor;
    private Label lblBPM;
    private Label lblBlackKeyPressedColors;
    private Label lblBlackKeyColor;
    private Label lblWhiteKeyPressedColors;
    private Button btnBlackPressedLeft;
    private Button btnBlack;
    private Button btnWhitePressedLeft;
    private Button btnWhite;
    private Button btnBlackPressedRight;
    private Button btnWhitePressedRight;
    private Button btnStop;
    private Label lblStop;
    private Label lblStart;
    private Button btnStart;
    private Label lblTitle;
    private Button btnPlayMidi;
    private ProgressBar pgbConvert;
    private Label lblStartKeyRange;
    private TrackBar tbrStartKey;
    private Label lblStartKey;
    private SaveFileDialog sfdSaveMIDI;
    private Button btnSaveMidi;
    private Button btnStopMidi;
    private Label lblTranspose;
    private TrackBar tbrTranspose;
    private Label lblTransposeRange;
    private TrackBar tbrColorDeviation;
    private Label lblColorDeviationRange;
    private Label lblColorDeviation;
    private LinkLabel lblCredits;
    private Button btnLoadPreset;
    private Button btnSavePreset;
    private OpenFileDialog ofdLoadPreset;
    private SaveFileDialog sfdSavePreset;
}
