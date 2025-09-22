namespace PianoReader;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using OpenCvSharp;
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

public sealed partial class FrmMain : Form
{
    #region Types

    private enum COLOR_PICKER
    {
        NONE,
        WHITE, WHITE_LEFT_PRESSED, WHITE_RIGHT_PRESSED,
        BLACK, BLACK_LEFT_PRESSED, BLACK_RIGHT_PRESSED
    };

    public record MidiEventData(string Type, int Note, int Frame, int Track);

    #endregion

    #region Fields

    private readonly ITaskbarList3 taskbar = (ITaskbarList3)new CTaskbarList();
    private COLOR_PICKER color_picker = COLOR_PICKER.NONE;
    private double fps = 30;
    private Dictionary<int, RectangleF> keys = [];
    private int width = 0, height = 0;
    private Image overlay = new Bitmap(1, 1);
    private MidiFile? midi_file;
    private List<MidiEventData> midi_events = [];
    private bool midi_playing = false, midi_converting = false;
    private bool video_loading = false;

    #endregion

    #region Methods

    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out Point lpPoint);

    [GeneratedRegex("\\d+")]
    public static partial Regex re_number();

    [GeneratedRegex("[A-G]")]
    public static partial Regex re_note();

    private void SavePreset(string filePath)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine($"[PianoReaderPreset]");
        sw.WriteLine($"KeyTop={tbrKeyTop.Value}");
        sw.WriteLine($"KeyNumber={tbrKeyNumber.Value}");
        sw.WriteLine($"StartKey={tbrStartKey.Value}");
        sw.WriteLine($"BlackKeyHeight={tbrBlackKeyHeight.Value}");
        sw.WriteLine($"BlackKeyWidth={tbrBlackKeyWidth.Value}");
        sw.WriteLine($"KeyHeight={tbrKeyHeight.Value}");
        sw.WriteLine($"White={ColorTranslator.ToHtml(btnWhite.BackColor)}");
        sw.WriteLine($"WhitePressedLeft={ColorTranslator.ToHtml(btnWhitePressedLeft.BackColor)}");
        sw.WriteLine($"WhitePressedRight={ColorTranslator.ToHtml(btnWhitePressedRight.BackColor)}");
        sw.WriteLine($"Black={ColorTranslator.ToHtml(btnBlack.BackColor)}");
        sw.WriteLine($"BlackPressedLeft={ColorTranslator.ToHtml(btnBlackPressedLeft.BackColor)}");
        sw.WriteLine($"BlackPressedRight={ColorTranslator.ToHtml(btnBlackPressedRight.BackColor)}");
        sw.WriteLine($"ColorDeviation={tbrColorDeviation.Value}");
        sw.WriteLine($"BPM={tbrBPM.Value}");
        sw.WriteLine($"Transpose={tbrTranspose.Value}");
    }

    private void LoadPreset(string filePath)
    {
        if (!File.Exists(filePath))
        {
            MessageBox.Show("Preset file not found!", "Preset load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var line in File.ReadAllLines(filePath))
        {
            var xline = line.Trim();
            if (string.IsNullOrWhiteSpace(xline) || xline.StartsWith(';') || xline.StartsWith('['))
                continue;

            var parts = xline.Split(['=', ';'], 3);
            if (parts.Length >= 2)
                dict[parts[0].Trim()] = parts[1].Trim();
        }

        try
        {
            // validate số nguyên
            var KeyTop = ValidateInt(dict["KeyTop"], tbrKeyTop.Minimum, tbrKeyTop.Maximum);
            var KeyNumber = ValidateInt(dict["KeyNumber"], tbrKeyNumber.Minimum, tbrKeyNumber.Maximum);
            var StartKey = ValidateInt(dict["StartKey"], tbrStartKey.Minimum, tbrStartKey.Maximum);
            var BlackKeyHeight = ValidateInt(dict["BlackKeyHeight"], tbrBlackKeyHeight.Minimum, tbrBlackKeyHeight.Maximum);
            var BlackKeyWidth = ValidateInt(dict["BlackKeyWidth"], tbrBlackKeyWidth.Minimum, tbrBlackKeyWidth.Maximum);
            var KeyHeight = ValidateInt(dict["KeyHeight"], tbrKeyHeight.Minimum, tbrKeyHeight.Maximum);
            var ColorDeviation = ValidateInt(dict["ColorDeviation"], tbrColorDeviation.Minimum, tbrColorDeviation.Maximum);
            var BPM = ValidateInt(dict["BPM"], tbrBPM.Minimum, tbrBPM.Maximum);
            var Transpose = ValidateInt(dict["Transpose"], tbrTranspose.Minimum, tbrTranspose.Maximum);

            // validate màu
            var White = ValidateColor(dict["White"]);
            var WhitePressedLeft = ValidateColor(dict["WhitePressedLeft"]);
            var WhitePressedRight = ValidateColor(dict["WhitePressedRight"]);
            var Black = ValidateColor(dict["Black"]);
            var BlackPressedLeft = ValidateColor(dict["BlackPressedLeft"]);
            var BlackPressedRight = ValidateColor(dict["BlackPressedRight"]);

            // tất cả hợp lệ -> gán vào control
            tbrKeyTop.Value = KeyTop;
            tbrKeyNumber.Value = KeyNumber;
            tbrStartKey.Value = StartKey;
            tbrBlackKeyHeight.Value = BlackKeyHeight;
            tbrBlackKeyWidth.Value = BlackKeyWidth;
            tbrKeyHeight.Value = KeyHeight;
            tbrColorDeviation.Value = ColorDeviation;
            tbrBPM.Value = BPM;
            tbrTranspose.Value = Transpose;

            btnWhite.BackColor = White;
            btnWhitePressedLeft.BackColor = WhitePressedLeft;
            btnWhitePressedRight.BackColor = WhitePressedRight;
            btnBlack.BackColor = Black;
            btnBlackPressedLeft.BackColor = BlackPressedLeft;
            btnBlackPressedRight.BackColor = BlackPressedRight;

            MessageBox.Show("Preset loaded success!", "Preset load", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Preset load", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static int ValidateInt(string value, int min, int max)
    {
        if (!int.TryParse(value, out int v))
            throw new Exception($"Invalid integer: {value}");
        if (v < min || v > max)
            throw new Exception($"Value {v} out of range [{min}, {max}]");
        return v;
    }

    private static Color ValidateColor(string value)
    {
        try
        {
            return ColorTranslator.FromHtml(value);
        }
        catch
        {
            throw new Exception($"Invalid color: {value}");
        }
    }

    private string FrameToTime(int frameIndex)
    {
        int totalSeconds = (int)(frameIndex / fps);
        int hours = totalSeconds / 3600;
        int minutes = totalSeconds % 3600 / 60;
        int seconds = totalSeconds % 60;
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    public void BuildKeys(int startIndex, int keyNumber, float blackKeyWidth, float blackKeyHeight, float keyWidth, float keyHeight, float keyTop)
    {
        int[] black_positions = [0, 1, 3, 4, 5];
        int whiteCount = 0;
        for (int i = 0; i < keyNumber; i++)
            if (black_positions.Contains((startIndex + whiteCount++) % 7) && i + 1 < keyNumber)
                i++;

        float whiteWidth = keyWidth / whiteCount;
        float sep = whiteWidth - blackKeyWidth * 5.0f / 7.0f;
        float[] blackSeps = [
            0,
            blackKeyWidth / 2,
            blackKeyWidth / 2,
            0,
            blackKeyWidth / 2,
            blackKeyWidth / 2,
            blackKeyWidth / 2
        ];
        float x1 = 0, x2 = blackSeps[startIndex % 7];

        keys.Clear();
        for (int i = 0, wC = 0; i < keyNumber; i++, wC++)
        {
            keys[i + 1] = new RectangleF(
                x1,
                keyTop + blackKeyHeight,
                whiteWidth,
                keyHeight - blackKeyHeight
            );
            x1 += whiteWidth;

            x2 += sep;
            if (black_positions.Contains((startIndex + wC) % 7) && i + 1 < keyNumber)
            {
                keys[++i + 1] = new RectangleF(
                    x2,
                    keyTop,
                    blackKeyWidth,
                    blackKeyHeight
                );
                x2 += blackKeyWidth;
            }
        }
    }

    private void CreateOverlay()
    {
        var g = Graphics.FromImage(overlay);
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        g.Clear(Color.Transparent);

        var keyTop = tbrKeyTop.Value;
        var keyWidth = width;
        var keyHeight = tbrKeyHeight.Value;

        BuildKeys(
            tbrStartKey.Value,
            tbrKeyNumber.Value,
            tbrBlackKeyWidth.Value,
            tbrBlackKeyHeight.Value,
            width,
            tbrKeyHeight.Value,
            tbrKeyTop.Value
        );

        foreach (var key in keys)
        {
            var br = Brushes.Black;
            var pe = Pens.Orange;
            if (key.Value.Height == tbrBlackKeyHeight.Value)
            {
                br = Brushes.White;
                pe = Pens.Yellow;
            }

            g.DrawString(key.Key.ToString(), Font, br, key.Value, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            g.DrawRectangle(pe, new RectangleF(key.Value.X, key.Value.Y, key.Value.Width - 1, key.Value.Height - 1));
        }

        // Bound
        g.DrawRectangle(Pens.Red, keys[0] = new RectangleF(0, keyTop, keyWidth - 1, keyHeight - 1)); // Bound

        // Redraw frame
        tbrSeek_Scroll(this, EventArgs.Empty);
    }

    private void WriteMidi()
    {
        var transpose = tbrTranspose.Value;
        short ticksPerBeat = 480;
        int bpm = tbrBPM.Value;
        int tempo = 60_000_000 / bpm;
        int FrameToTick(int frame) => (int)(frame / fps * ticksPerBeat * (1_000_000.0 / tempo));

        midi_file = new MidiFile
        {
            TimeDivision = new TicksPerQuarterNoteTimeDivision(ticksPerBeat)
        };
        var trackGroups = midi_events.GroupBy(e => e.Track);

        foreach (var group in trackGroups)
        {
            var trackChunk = new TrackChunk();
            midi_file.Chunks.Add(trackChunk);
            var trackEvents = trackChunk.Events;

            var sorted = group.OrderBy(e => e.Frame).ToList();

            int lastTick = 0;
            foreach (var ev in sorted)
            {
                var tick = FrameToTick(ev.Frame);
                var delta = tick - lastTick;
                lastTick = tick;

                if (ev.Type == "on")
                    trackEvents.Add(new NoteOnEvent((SevenBitNumber)(transpose + ev.Note), (SevenBitNumber)96) { DeltaTime = delta });
                else
                    trackEvents.Add(new NoteOffEvent((SevenBitNumber)(transpose + ev.Note), (SevenBitNumber)96) { DeltaTime = delta });
            }
        }

        if (midi_events.Count > 0)
        {
            var tempoEvent = new SetTempoEvent(tempo);
            ((TrackChunk)midi_file.Chunks[0]).Events.Insert(0, tempoEvent);
        }
    }

    #endregion

    public FrmMain()
    {
        InitializeComponent();
        DoubleBuffered = true;
        taskbar.HrInit();
    }

    private void ptbVideoPreview_Click(object sender, EventArgs e)
    {
        if (color_picker == COLOR_PICKER.NONE)
            ofdLoadVideo.ShowDialog(this);
        else
        {
            GetCursorPos(out Point cursorPos);

            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);
            g.CopyFromScreen(cursorPos, Point.Empty, new Size(1, 1));
            Color color = bmp.GetPixel(0, 0);

            switch (color_picker)
            {
                case COLOR_PICKER.WHITE:
                    btnWhite.BackColor = color;
                    break;
                case COLOR_PICKER.WHITE_LEFT_PRESSED:
                    btnWhitePressedLeft.BackColor = color;
                    break;
                case COLOR_PICKER.WHITE_RIGHT_PRESSED:
                    btnWhitePressedRight.BackColor = color;
                    break;
                case COLOR_PICKER.BLACK:
                    btnBlack.BackColor = color;
                    break;
                case COLOR_PICKER.BLACK_LEFT_PRESSED:
                    btnBlackPressedLeft.BackColor = color;
                    break;
                case COLOR_PICKER.BLACK_RIGHT_PRESSED:
                    btnBlackPressedRight.BackColor = color;
                    break;
            }
            color_picker = COLOR_PICKER.NONE;
            ptbVideoPreview.Cursor = Cursors.Default;
            tbrSeek_Scroll(sender, e);
        }
    }

    private async void ofdLoadVideo_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        using var capture = new VideoCapture(ofdLoadVideo.FileName);

        try
        {
            if (!Directory.Exists("temp"))
                Directory.CreateDirectory("temp");

            btnStopMidi.PerformClick();

            video_loading = true;

            taskbar.SetProgressState(Handle, TBPFLAG.TBPF_NORMAL);
            taskbar.SetProgressValue(Handle, 0, 1);

            width = capture.FrameWidth;
            height = capture.FrameHeight;
            fps = capture.Fps;

            lblTitle.Text = $"{Path.GetFileName(ofdLoadVideo.FileName)} ({(int)Math.Round(fps)} fps)";

            btnLoadPreset.Enabled = true;
            btnSavePreset.Enabled = true;

            btnPlayMidi.Enabled = false;
            btnStopMidi.Enabled = true;
            btnSaveMidi.Enabled = false;

            tbrSeek.Value = 0;
            tbrSeek.Maximum = 1;
            lblMaxTime.Text = "00:00:01";
            lblTime.Text = "00:00:00";
            tlpTool.Enabled = true;

            overlay = new Bitmap(width, height);
            CreateOverlay();

            Application.DoEvents();

            await Task.Run(() =>
            {
                var frame = new Mat();
                for (var i = 0; video_loading && capture.Read(frame); i++)
                {
                    frame.SaveImage("temp\\" + i + ".jpg");
                    if (i % 100 == 0)
                        Invoke(() =>
                        {
                            lblLoading.Visible = !lblLoading.Visible;
                            lblLoadProgress.Text = (i * 100.0 / capture.FrameCount).ToString("0") + "%";

                            lblMaxFrame.Text = i.ToString();
                            lblMaxTime.Text = FrameToTime(i);
                            tbrSeek.Maximum = i;

                            tbrSeek_Scroll(sender, e);
                            taskbar.SetProgressValue(Handle, (ulong)i, (ulong)capture.FrameCount);
                        });
                }
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        btnStopMidi.Enabled = false;
        lblLoading.Visible = false;
        lblLoadProgress.Visible = false;

        if (video_loading)
        {
            tbrSeek.Maximum = capture.FrameCount - 1;
            lblMaxTime.Text = FrameToTime(capture.FrameCount);
            lblMaxFrame.Text = capture.FrameCount.ToString();
            taskbar.SetProgressState(Handle, TBPFLAG.TBPF_NOPROGRESS);

            btnConvert.Enabled = true;

            MessageBox.Show("Load done !", "Load video", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
            taskbar.SetProgressState(Handle, TBPFLAG.TBPF_ERROR);

        video_loading = false;
    }

    private void tbrSeek_Scroll(object sender, EventArgs e)
    {
        var deviation = tbrColorDeviation.Value;
        lblFrame.Text = tbrSeek.Value.ToString();
        lblTime.Text = FrameToTime(tbrSeek.Value);

        var i = tbrSeek.Value;

        if (midi_playing)
            ptbVideoPreview.ImageLocation = $"temp\\{i}.jpg";
        else
        {
            var keyNum = tbrKeyNumber.Value;

            var whiteNote = new[] {
                    Scalar.FromRgb(btnWhite.BackColor.R, btnWhite.BackColor.G, btnWhite.BackColor.B),
                    Scalar.FromRgb(btnWhitePressedLeft.BackColor.R, btnWhitePressedLeft.BackColor.G, btnWhitePressedLeft.BackColor.B),
                    Scalar.FromRgb(btnWhitePressedRight.BackColor.R, btnWhitePressedRight.BackColor.G, btnWhitePressedRight.BackColor.B)
                };
            var blackNote = new[] {
                    Scalar.FromRgb(btnBlack.BackColor.R, btnBlack.BackColor.G, btnBlack.BackColor.B),
                    Scalar.FromRgb(btnBlackPressedLeft.BackColor.R, btnBlackPressedLeft.BackColor.G, btnBlackPressedLeft.BackColor.B),
                    Scalar.FromRgb(btnBlackPressedRight.BackColor.R, btnBlackPressedRight.BackColor.G, btnBlackPressedRight.BackColor.B)
                };

            var bmp = Image.FromFile($"temp\\{i}.jpg");
            var gra = Graphics.FromImage(bmp);

            try
            {
                var image = Cv2.ImRead($"temp\\{i}.jpg");

                for (var note = 1; note <= keyNum; note++)
                {
                    var mean = Cv2.Mean(
                        new Mat(
                            image,
                            new Rect(
                                (int)keys[note].X,
                                (int)keys[note].Y,
                                (int)keys[note].Width,
                                (int)keys[note].Height
                            )
                        )
                    );

                    for (var key = 1; key < 3; key++)
                    {
                        var c = blackNote[key];
                        var r = c.Val0 - mean.Val0;
                        var g = c.Val1 - mean.Val1;
                        var b = c.Val2 - mean.Val2;
                        var d = Math.Sqrt(r * r + g * g + b * b);

                        if (d < deviation)
                        {
                            switch (key)
                            {
                                case 1: // Black Left Pressed
                                    gra.FillRectangle(Brushes.Blue, keys[note]);
                                    break;
                                case 2: // Black Right Pressed
                                    gra.FillRectangle(Brushes.Green, keys[note]);
                                    break;
                            }
                            goto end;
                        }
                    }

                    for (var key = 1; key < 3; key++)
                    {
                        var c = whiteNote[key];
                        var r = c.Val0 - mean.Val0;
                        var g = c.Val1 - mean.Val1;
                        var b = c.Val2 - mean.Val2;
                        var d = Math.Sqrt(r * r + g * g + b * b);

                        if (d < deviation)
                        {
                            switch (key)
                            {
                                case 1: // White Left Pressed
                                    gra.FillRectangle(Brushes.Blue, keys[note]);
                                    break;
                                case 2: // White Right Pressed
                                    gra.FillRectangle(Brushes.Green, keys[note]);
                                    break;
                            }
                            goto end;
                        }
                    }

                end:
                    ;
                }
            }
            catch
            {
            }

            gra.CompositingMode = CompositingMode.SourceOver;
            gra.DrawImage(overlay, 0, 0);
            ptbVideoPreview.Image = bmp;
        }
    }

    private void tbrStartKey_Scroll(object sender, EventArgs e)
    {
        lblStartKey.Text = re_note().Replace(lblStartKey.Text, "CDEFGAB"[tbrStartKey.Value].ToString());
        CreateOverlay();
    }

    private void tbrKeyNumber_Scroll(object sender, EventArgs e)
    {
        lblKeyNumber.Text = re_number().Replace(lblKeyNumber.Text, tbrKeyNumber.Value.ToString());
        CreateOverlay();
    }

    private void tbrKeyTop_Scroll(object sender, EventArgs e)
    {
        lblKeyTop.Text = Regex.Replace(lblKeyTop.Text, "\\d+", tbrKeyTop.Value.ToString());
        CreateOverlay();
    }

    private void tbrKeyHeight_Scroll(object sender, EventArgs e)
    {
        lblKeyHeight.Text = re_number().Replace(lblKeyHeight.Text, tbrKeyHeight.Value.ToString());
        CreateOverlay();
    }

    private void tbrBlackKeyWidth_Scroll(object sender, EventArgs e)
    {
        lblBlackKeyWidth.Text = re_number().Replace(lblBlackKeyWidth.Text, tbrBlackKeyWidth.Value.ToString());
        CreateOverlay();
    }

    private void tbrBlackKeyHeight_Scroll(object sender, EventArgs e)
    {
        lblBlackKeyHeight.Text = re_number().Replace(lblBlackKeyHeight.Text, tbrBlackKeyHeight.Value.ToString());
        CreateOverlay();
    }

    private void tbrBPM_Scroll(object sender, EventArgs e)
    {
        lblBPM.Text = re_number().Replace(lblBPM.Text, tbrBPM.Value.ToString());
        if (midi_events.Count != 0)
        {
            btnStopMidi.PerformClick();
            WriteMidi();
        }
    }

    private void tbrTranspose_Scroll(object sender, EventArgs e)
    {
        lblTranspose.Text = re_number().Replace(lblTranspose.Text, tbrTranspose.Value.ToString());
        if (midi_events.Count != 0)
        {
            btnStopMidi.PerformClick();
            WriteMidi();
        }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        lblStart.Text = re_number().Replace(lblStart.Text, tbrSeek.Value.ToString());
        pgbConvert.Minimum = tbrSeek.Value;
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        lblStop.Text = re_number().Replace(lblStop.Text, tbrSeek.Value.ToString());
        pgbConvert.Maximum = tbrSeek.Value;
    }

    private void tbrColorDeviation_Scroll(object sender, EventArgs e)
    {
        lblColorDeviation.Text = re_number().Replace(lblColorDeviation.Text, tbrColorDeviation.Value.ToString());
        tbrSeek_Scroll(sender, e);
    }

    private void btnWhite_Click(object sender, EventArgs e)
    {
        ptbVideoPreview.Cursor = Cursors.Cross;
        color_picker = COLOR_PICKER.WHITE;
    }

    private void btnWhitePressedLeft_Click(object sender, EventArgs e)
    {
        ptbVideoPreview.Cursor = Cursors.Cross;
        color_picker = COLOR_PICKER.WHITE_LEFT_PRESSED;
    }

    private void btnWhitePressedRight_Click(object sender, EventArgs e)
    {
        ptbVideoPreview.Cursor = Cursors.Cross;
        color_picker = COLOR_PICKER.WHITE_RIGHT_PRESSED;
    }

    private void btnBlack_Click(object sender, EventArgs e)
    {
        ptbVideoPreview.Cursor = Cursors.Cross;
        color_picker = COLOR_PICKER.BLACK;
    }

    private void btnBlackPressedLeft_Click(object sender, EventArgs e)
    {
        ptbVideoPreview.Cursor = Cursors.Cross;
        color_picker = COLOR_PICKER.BLACK_LEFT_PRESSED;
    }

    private void btnBlackPressedRight_Click(object sender, EventArgs e)
    {
        ptbVideoPreview.Cursor = Cursors.Cross;
        color_picker = COLOR_PICKER.BLACK_RIGHT_PRESSED;
    }

    private async void btnConvert_Click(object sender, EventArgs e)
    {
        var start = pgbConvert.Minimum;
        var stop = pgbConvert.Maximum;

        if (start == 0 || stop <= start)
        {
            MessageBox.Show("Start / Stop frame not set or be invalid!", "Convert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var deviation = tbrColorDeviation.Value;
        var keyNum = tbrKeyNumber.Value;

        var whiteNote = new[] {
            Scalar.FromRgb(btnWhite.BackColor.R, btnWhite.BackColor.G, btnWhite.BackColor.B),
            Scalar.FromRgb(btnWhitePressedLeft.BackColor.R, btnWhitePressedLeft.BackColor.G, btnWhitePressedLeft.BackColor.B),
            Scalar.FromRgb(btnWhitePressedRight.BackColor.R, btnWhitePressedRight.BackColor.G, btnWhitePressedRight.BackColor.B)
        };
        var blackNote = new[] {
            Scalar.FromRgb(btnBlack.BackColor.R, btnBlack.BackColor.G, btnBlack.BackColor.B),
            Scalar.FromRgb(btnBlackPressedLeft.BackColor.R, btnBlackPressedLeft.BackColor.G, btnBlackPressedLeft.BackColor.B),
            Scalar.FromRgb(btnBlackPressedRight.BackColor.R, btnBlackPressedRight.BackColor.G, btnBlackPressedRight.BackColor.B)
        };

        pgbConvert.Visible = true;
        btnConvert.Enabled = false;
        btnStopMidi.Enabled = true;
        btnPlayMidi.Enabled = false;
        btnSaveMidi.Enabled = false;
        pgbConvert.Value = start;
        taskbar.SetProgressState(Handle, TBPFLAG.TBPF_NORMAL);

        midi_converting = true;
        midi_events = [];

        var notes = new byte[keyNum + 1];
        for (var note = 1; note <= keyNum; note++)
            notes[note] = 0;

        await Task.Run(() =>
        {
            for (var frame = start; frame <= stop && midi_converting; frame++)
            {
                var image = Cv2.ImRead($"temp\\{frame}.jpg");

                for (var note = 1; note <= keyNum; note++)
                {
                    var mean = Cv2.Mean(
                        new Mat(
                            image,
                            new Rect(
                                (int)keys[note].X,
                                (int)keys[note].Y,
                                (int)keys[note].Width,
                                (int)keys[note].Height
                            )
                        )
                    );

                    for (byte key = 0; key < 3; key++)
                    {
                        var c = blackNote[key];
                        var r = c.Val0 - mean.Val0;
                        var g = c.Val1 - mean.Val1;
                        var b = c.Val2 - mean.Val2;
                        var d = Math.Sqrt(r * r + g * g + b * b);

                        if (d < deviation)
                        {
                            if (notes[note] != key)
                            {
                                switch (key)
                                {
                                    case 0: // Black
                                        if (notes[note] == 1)
                                            midi_events.Add(new("off", note, frame - start, 0));
                                        else if (notes[note] == 2)
                                            midi_events.Add(new("off", note, frame - start, 1));
                                        break;
                                    case 1: // Black Left Pressed
                                        midi_events.Add(new("on", note, frame - start, 0));
                                        break;
                                    case 2: // Black Right Pressed
                                        midi_events.Add(new("on", note, frame - start, 1));
                                        break;
                                }
                                notes[note] = key;
                            }
                            goto end;
                        }
                    }

                    for (byte key = 0; key < 3; key++)
                    {
                        var c = whiteNote[key];
                        var r = c.Val0 - mean.Val0;
                        var g = c.Val1 - mean.Val1;
                        var b = c.Val2 - mean.Val2;
                        var d = Math.Sqrt(r * r + g * g + b * b);

                        if (d < deviation)
                        {
                            if (notes[note] != key)
                            {
                                switch (key)
                                {
                                    case 0: // White
                                        if (notes[note] == 1)
                                            midi_events.Add(new("off", note, frame - start, 0));
                                        else if (notes[note] == 2)
                                            midi_events.Add(new("off", note, frame - start, 1));
                                        break;
                                    case 1: // White Left Pressed
                                        midi_events.Add(new("on", note, frame - start, 0));
                                        break;
                                    case 2: // White Right Pressed
                                        midi_events.Add(new("on", note, frame - start, 1));
                                        break;
                                }
                                notes[note] = key;
                            }
                            goto end;
                        }
                    }

                end:
                    ;
                }

                if (frame % 100 == 0)
                    Invoke(() =>
                    {
                        pgbConvert.Value = frame;
                        taskbar.SetProgressValue(Handle, (uint)(frame - start), (uint)(stop - start));
                    });
            }
        });

        pgbConvert.Visible = false;
        btnConvert.Enabled = true;
        btnStopMidi.Enabled = false;

        if (midi_converting)
        {
            WriteMidi();
            taskbar.SetProgressState(Handle, TBPFLAG.TBPF_NOPROGRESS);
            btnPlayMidi.Enabled = true;
            btnSaveMidi.Enabled = true;

            MessageBox.Show("Convert done !", "Convert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
            taskbar.SetProgressState(Handle, TBPFLAG.TBPF_ERROR);

        midi_converting = false;
        tbrSeek_Scroll(sender, e);
    }

    private async void btnPlayMidi_Click(object sender, EventArgs e)
    {
        if (OutputDevice.GetDevicesCount() == 0)
            MessageBox.Show("No MIDI output device found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
        {
            midi_playing = true;
            btnPlayMidi.Enabled = false;
            btnStopMidi.Enabled = true;

            var start = pgbConvert.Minimum;
            var stop = pgbConvert.Maximum;

            try
            {
                using var outputDevice = OutputDevice.GetByIndex(0);
                using var playBack = midi_file.GetPlayback(outputDevice);
                playBack.Start();

                await Task.Run(() =>
                {
                    while (playBack.IsRunning && midi_playing)
                    {
                        var time = playBack.GetCurrentTime<MetricTimeSpan>();
                        var frame = (int)Math.Round(time.TotalMicroseconds / 1000000.0f * fps) + start;

                        Invoke(() =>
                        {
                            tbrSeek.Value = Math.Max(start, Math.Min(frame, stop));
                            tbrSeek_Scroll(sender, e);
                        });

                        Thread.Sleep((int)(1000 / fps));
                    }
                });
            }
            catch
            {
            }

            btnPlayMidi.Enabled = true;
            btnStopMidi.Enabled = false;
        }
    }

    private void btnSaveMidi_Click(object sender, EventArgs e)
    {
        sfdSaveMIDI.ShowDialog(this);
    }

    private void sfdSaveMIDI_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        midi_file!.Write(sfdSaveMIDI.FileName);
        MessageBox.Show("Write MIDI file success!", "Save MIDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnStopMidi_Click(object sender, EventArgs e)
    {
        if (midi_playing)
            midi_playing = false;
        if (midi_converting)
            midi_converting = false;
        if (video_loading)
            video_loading = false;
        btnStopMidi.Enabled = false;
    }

    private void lblCredits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("explorer.exe", "https://github.com/manh9011");
    }

    private void ofdLoadPreset_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        LoadPreset(ofdLoadPreset.FileName);
    }

    private void sfdSavePreset_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        SavePreset(sfdSavePreset.FileName);
    }

    private void btnSavePreset_Click(object sender, EventArgs e)
    {
        sfdSavePreset.ShowDialog(this);
    }

    private void btnLoadPreset_Click(object sender, EventArgs e)
    {
        ofdLoadPreset.ShowDialog(this);
    }
}
