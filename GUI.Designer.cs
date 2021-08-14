
namespace Vegas_Oscillator_Randomizer
{
    partial class GUI
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
            this.applyBtn = new System.Windows.Forms.Button();
            this.effectDropdown = new System.Windows.Forms.ComboBox();
            this.parameterDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.oscHeightBox = new System.Windows.Forms.TextBox();
            this.oscAmplitudeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.oscWaveformDropdown = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.randMaxBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.randMinBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.randSeedBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.wavelengthSecondsBox = new System.Windows.Forms.TextBox();
            this.wavelengthLabel2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bpmBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.hzBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wavelengthFramesBox = new System.Windows.Forms.TextBox();
            this.wavelengthLabel1 = new System.Windows.Forms.Label();
            this.firstRadiobtn = new System.Windows.Forms.RadioButton();
            this.secondRadiobtn = new System.Windows.Forms.RadioButton();
            this.thirdRadiobtn = new System.Windows.Forms.RadioButton();
            this.interpolationDropdown = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.fourthRadiobtn = new System.Windows.Forms.RadioButton();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(10, 331);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(194, 61);
            this.applyBtn.TabIndex = 0;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // effectDropdown
            // 
            this.effectDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectDropdown.FormattingEnabled = true;
            this.effectDropdown.Location = new System.Drawing.Point(12, 34);
            this.effectDropdown.Name = "effectDropdown";
            this.effectDropdown.Size = new System.Drawing.Size(193, 21);
            this.effectDropdown.TabIndex = 1;
            this.effectDropdown.SelectedIndexChanged += new System.EventHandler(this.effectDropdown_SelectedIndexChanged);
            // 
            // parameterDropdown
            // 
            this.parameterDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parameterDropdown.FormattingEnabled = true;
            this.parameterDropdown.Location = new System.Drawing.Point(12, 97);
            this.parameterDropdown.Name = "parameterDropdown";
            this.parameterDropdown.Size = new System.Drawing.Size(193, 21);
            this.parameterDropdown.TabIndex = 2;
            this.parameterDropdown.SelectedIndexChanged += new System.EventHandler(this.parameterDropdown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Effect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parameter";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(234, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(267, 204);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.oscHeightBox);
            this.tabPage1.Controls.Add(this.oscAmplitudeBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.oscWaveformDropdown);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(259, 178);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Oscillator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Height";
            // 
            // oscHeightBox
            // 
            this.oscHeightBox.Location = new System.Drawing.Point(97, 75);
            this.oscHeightBox.Name = "oscHeightBox";
            this.oscHeightBox.Size = new System.Drawing.Size(100, 20);
            this.oscHeightBox.TabIndex = 4;
            // 
            // oscAmplitudeBox
            // 
            this.oscAmplitudeBox.Location = new System.Drawing.Point(97, 49);
            this.oscAmplitudeBox.Name = "oscAmplitudeBox";
            this.oscAmplitudeBox.Size = new System.Drawing.Size(100, 20);
            this.oscAmplitudeBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amplitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Waveform";
            // 
            // oscWaveformDropdown
            // 
            this.oscWaveformDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oscWaveformDropdown.FormattingEnabled = true;
            this.oscWaveformDropdown.Location = new System.Drawing.Point(97, 13);
            this.oscWaveformDropdown.Name = "oscWaveformDropdown";
            this.oscWaveformDropdown.Size = new System.Drawing.Size(100, 21);
            this.oscWaveformDropdown.TabIndex = 0;
            this.oscWaveformDropdown.SelectedIndexChanged += new System.EventHandler(this.oscWaveformDropdown_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.randMaxBox);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.randMinBox);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.randSeedBox);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(259, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Randomizer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // randMaxBox
            // 
            this.randMaxBox.Location = new System.Drawing.Point(97, 78);
            this.randMaxBox.Name = "randMaxBox";
            this.randMaxBox.Size = new System.Drawing.Size(100, 20);
            this.randMaxBox.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Max (Exclusive)";
            // 
            // randMinBox
            // 
            this.randMinBox.Location = new System.Drawing.Point(97, 52);
            this.randMinBox.Name = "randMinBox";
            this.randMinBox.Size = new System.Drawing.Size(100, 20);
            this.randMinBox.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Min (Inclusive)";
            // 
            // randSeedBox
            // 
            this.randSeedBox.Location = new System.Drawing.Point(97, 15);
            this.randSeedBox.Name = "randSeedBox";
            this.randSeedBox.Size = new System.Drawing.Size(100, 20);
            this.randSeedBox.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Seed";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.comboBox4);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.textBox17);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.textBox18);
            this.tabPage3.Controls.Add(this.label27);
            this.tabPage3.Controls.Add(this.textBox19);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(259, 178);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Noise";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(238, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "\"Speed\" = change in noise position per keyframe";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "\"Speed\"";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(97, 15);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 21);
            this.comboBox4.TabIndex = 15;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(60, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(31, 13);
            this.label29.TabIndex = 14;
            this.label29.Text = "Type";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(97, 102);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 20);
            this.textBox17.TabIndex = 12;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 105);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 13);
            this.label26.TabIndex = 11;
            this.label26.Text = "Max (Exclusive)";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(97, 76);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 20);
            this.textBox18.TabIndex = 10;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(75, 13);
            this.label27.TabIndex = 9;
            this.label27.Text = "Min (Inclusive)";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(97, 42);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 20);
            this.textBox19.TabIndex = 8;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(59, 45);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 13);
            this.label28.TabIndex = 7;
            this.label28.Text = "Seed";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.wavelengthSecondsBox);
            this.groupBox1.Controls.Add(this.wavelengthLabel2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.bpmBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.hzBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.wavelengthFramesBox);
            this.groupBox1.Controls.Add(this.wavelengthLabel1);
            this.groupBox1.Location = new System.Drawing.Point(234, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 170);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequency";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(199, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "(Press ENTER to confirm after changing)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "seconds";
            // 
            // wavelengthSecondsBox
            // 
            this.wavelengthSecondsBox.Location = new System.Drawing.Point(97, 55);
            this.wavelengthSecondsBox.Name = "wavelengthSecondsBox";
            this.wavelengthSecondsBox.Size = new System.Drawing.Size(100, 20);
            this.wavelengthSecondsBox.TabIndex = 8;
            this.wavelengthSecondsBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wavelengthSecondsBox_KeyDown);
            // 
            // wavelengthLabel2
            // 
            this.wavelengthLabel2.AutoSize = true;
            this.wavelengthLabel2.Location = new System.Drawing.Point(7, 58);
            this.wavelengthLabel2.Name = "wavelengthLabel2";
            this.wavelengthLabel2.Size = new System.Drawing.Size(84, 13);
            this.wavelengthLabel2.TabIndex = 7;
            this.wavelengthLabel2.Text = "One cycle every";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Beats per minute";
            // 
            // bpmBox
            // 
            this.bpmBox.Location = new System.Drawing.Point(12, 111);
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(100, 20);
            this.bpmBox.TabIndex = 5;
            this.bpmBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bpmBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Hz";
            // 
            // hzBox
            // 
            this.hzBox.Location = new System.Drawing.Point(12, 83);
            this.hzBox.Name = "hzBox";
            this.hzBox.Size = new System.Drawing.Size(100, 20);
            this.hzBox.TabIndex = 3;
            this.hzBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hzBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "frames";
            // 
            // wavelengthFramesBox
            // 
            this.wavelengthFramesBox.Location = new System.Drawing.Point(97, 26);
            this.wavelengthFramesBox.Name = "wavelengthFramesBox";
            this.wavelengthFramesBox.Size = new System.Drawing.Size(100, 20);
            this.wavelengthFramesBox.TabIndex = 1;
            this.wavelengthFramesBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wavelengthFramesBox_KeyDown);
            // 
            // wavelengthLabel1
            // 
            this.wavelengthLabel1.AutoSize = true;
            this.wavelengthLabel1.Location = new System.Drawing.Point(7, 29);
            this.wavelengthLabel1.Name = "wavelengthLabel1";
            this.wavelengthLabel1.Size = new System.Drawing.Size(84, 13);
            this.wavelengthLabel1.TabIndex = 0;
            this.wavelengthLabel1.Text = "One cycle every";
            // 
            // firstRadiobtn
            // 
            this.firstRadiobtn.AutoSize = true;
            this.firstRadiobtn.Checked = true;
            this.firstRadiobtn.Location = new System.Drawing.Point(12, 133);
            this.firstRadiobtn.Name = "firstRadiobtn";
            this.firstRadiobtn.Size = new System.Drawing.Size(32, 17);
            this.firstRadiobtn.TabIndex = 7;
            this.firstRadiobtn.TabStop = true;
            this.firstRadiobtn.Text = "X";
            this.firstRadiobtn.UseVisualStyleBackColor = true;
            // 
            // secondRadiobtn
            // 
            this.secondRadiobtn.AutoSize = true;
            this.secondRadiobtn.Location = new System.Drawing.Point(50, 133);
            this.secondRadiobtn.Name = "secondRadiobtn";
            this.secondRadiobtn.Size = new System.Drawing.Size(32, 17);
            this.secondRadiobtn.TabIndex = 8;
            this.secondRadiobtn.TabStop = true;
            this.secondRadiobtn.Text = "Y";
            this.secondRadiobtn.UseVisualStyleBackColor = true;
            // 
            // thirdRadiobtn
            // 
            this.thirdRadiobtn.AutoSize = true;
            this.thirdRadiobtn.Enabled = false;
            this.thirdRadiobtn.Location = new System.Drawing.Point(88, 133);
            this.thirdRadiobtn.Name = "thirdRadiobtn";
            this.thirdRadiobtn.Size = new System.Drawing.Size(32, 17);
            this.thirdRadiobtn.TabIndex = 9;
            this.thirdRadiobtn.TabStop = true;
            this.thirdRadiobtn.Text = "Z";
            this.thirdRadiobtn.UseVisualStyleBackColor = true;
            // 
            // interpolationDropdown
            // 
            this.interpolationDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationDropdown.FormattingEnabled = true;
            this.interpolationDropdown.Location = new System.Drawing.Point(11, 206);
            this.interpolationDropdown.Name = "interpolationDropdown";
            this.interpolationDropdown.Size = new System.Drawing.Size(193, 21);
            this.interpolationDropdown.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Interpolation";
            // 
            // fourthRadiobtn
            // 
            this.fourthRadiobtn.AutoSize = true;
            this.fourthRadiobtn.Enabled = false;
            this.fourthRadiobtn.Location = new System.Drawing.Point(126, 133);
            this.fourthRadiobtn.Name = "fourthRadiobtn";
            this.fourthRadiobtn.Size = new System.Drawing.Size(32, 17);
            this.fourthRadiobtn.TabIndex = 12;
            this.fourthRadiobtn.TabStop = true;
            this.fourthRadiobtn.Text = "A";
            this.fourthRadiobtn.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 404);
            this.Controls.Add(this.fourthRadiobtn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.interpolationDropdown);
            this.Controls.Add(this.thirdRadiobtn);
            this.Controls.Add(this.secondRadiobtn);
            this.Controls.Add(this.firstRadiobtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parameterDropdown);
            this.Controls.Add(this.effectDropdown);
            this.Controls.Add(this.applyBtn);
            this.Name = "GUI";
            this.Text = "NitroGuy\'s Oscillator/Randomizer";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.ComboBox effectDropdown;
        private System.Windows.Forms.ComboBox parameterDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox oscAmplitudeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox oscWaveformDropdown;
        private System.Windows.Forms.TextBox randMaxBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox randMinBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox randSeedBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox wavelengthSecondsBox;
        private System.Windows.Forms.Label wavelengthLabel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox bpmBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox hzBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox wavelengthFramesBox;
        private System.Windows.Forms.Label wavelengthLabel1;
        private System.Windows.Forms.RadioButton firstRadiobtn;
        private System.Windows.Forms.RadioButton secondRadiobtn;
        private System.Windows.Forms.RadioButton thirdRadiobtn;
        private System.Windows.Forms.ComboBox interpolationDropdown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton fourthRadiobtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox oscHeightBox;
        private System.Windows.Forms.Label label16;
    }
}

