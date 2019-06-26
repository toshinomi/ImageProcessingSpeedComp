using System;
using System.Windows.Forms;

namespace ImageProcessingSpeedComp
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFilterStartNormal = new System.Windows.Forms.Button();
            this.btnAllClear = new System.Windows.Forms.Button();
            this.btnFilterStartUnsafe = new System.Windows.Forms.Button();
            this.groupBoxImageOutput = new System.Windows.Forms.GroupBox();
            this.checkBoxView = new System.Windows.Forms.CheckBox();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelFilterImage = new System.Windows.Forms.Label();
            this.pictureBoxFilter = new System.Windows.Forms.PictureBox();
            this.labelOriginalImage = new System.Windows.Forms.Label();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.toolTipBtnFileSelect = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBtnAllClear = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBtnFilterStartUnsafe = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBtnFilterStartNormal = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxProcessingInfo = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeUnit = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.toolTipBtnStop = new System.Windows.Forms.ToolTip(this.components);
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.groupBoxOperation.SuspendLayout();
            this.groupBoxImageOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            this.groupBoxProcessingInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.BackColor = System.Drawing.Color.White;
            this.btnFileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFileSelect.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFileSelect.Location = new System.Drawing.Point(41, 36);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(154, 68);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "File Select...";
            this.btnFileSelect.UseVisualStyleBackColor = false;
            this.btnFileSelect.Click += new System.EventHandler(this.OnClickBtnFileSelect);
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.btnStop);
            this.groupBoxOperation.Controls.Add(this.btnFilterStartNormal);
            this.groupBoxOperation.Controls.Add(this.btnAllClear);
            this.groupBoxOperation.Controls.Add(this.btnFilterStartUnsafe);
            this.groupBoxOperation.Controls.Add(this.btnFileSelect);
            this.groupBoxOperation.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxOperation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(249, 462);
            this.groupBoxOperation.TabIndex = 0;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "Operation";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStop.Location = new System.Drawing.Point(41, 372);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(154, 68);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.OnClickBtnStop);
            // 
            // btnFilterStartNormal
            // 
            this.btnFilterStartNormal.BackColor = System.Drawing.Color.White;
            this.btnFilterStartNormal.Enabled = false;
            this.btnFilterStartNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilterStartNormal.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFilterStartNormal.Location = new System.Drawing.Point(41, 286);
            this.btnFilterStartNormal.Name = "btnFilterStartNormal";
            this.btnFilterStartNormal.Size = new System.Drawing.Size(154, 68);
            this.btnFilterStartNormal.TabIndex = 3;
            this.btnFilterStartNormal.Text = "Filter Start\r\n(Normal)";
            this.btnFilterStartNormal.UseVisualStyleBackColor = false;
            this.btnFilterStartNormal.Click += new System.EventHandler(this.OnClickBtnFilterStartNormal);
            // 
            // btnAllClear
            // 
            this.btnAllClear.BackColor = System.Drawing.Color.White;
            this.btnAllClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAllClear.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAllClear.Location = new System.Drawing.Point(41, 120);
            this.btnAllClear.Name = "btnAllClear";
            this.btnAllClear.Size = new System.Drawing.Size(154, 68);
            this.btnAllClear.TabIndex = 1;
            this.btnAllClear.Text = "All Clear";
            this.btnAllClear.UseVisualStyleBackColor = false;
            this.btnAllClear.Click += new System.EventHandler(this.OnClickBtnAllClear);
            // 
            // btnFilterStartUnsafe
            // 
            this.btnFilterStartUnsafe.BackColor = System.Drawing.Color.White;
            this.btnFilterStartUnsafe.Enabled = false;
            this.btnFilterStartUnsafe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilterStartUnsafe.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFilterStartUnsafe.Location = new System.Drawing.Point(41, 202);
            this.btnFilterStartUnsafe.Name = "btnFilterStartUnsafe";
            this.btnFilterStartUnsafe.Size = new System.Drawing.Size(154, 68);
            this.btnFilterStartUnsafe.TabIndex = 2;
            this.btnFilterStartUnsafe.Text = "Filter Start\r\n(Unsafe)";
            this.btnFilterStartUnsafe.UseVisualStyleBackColor = false;
            this.btnFilterStartUnsafe.Click += new System.EventHandler(this.OnClickBtnFilterStartUnsafe);
            // 
            // groupBoxImageOutput
            // 
            this.groupBoxImageOutput.Controls.Add(this.labelEnd);
            this.groupBoxImageOutput.Controls.Add(this.labelStart);
            this.groupBoxImageOutput.Controls.Add(this.checkBoxView);
            this.groupBoxImageOutput.Controls.Add(this.pictureBoxStatus);
            this.groupBoxImageOutput.Controls.Add(this.progressBar);
            this.groupBoxImageOutput.Controls.Add(this.labelStatus);
            this.groupBoxImageOutput.Controls.Add(this.labelFilterImage);
            this.groupBoxImageOutput.Controls.Add(this.pictureBoxFilter);
            this.groupBoxImageOutput.Controls.Add(this.labelOriginalImage);
            this.groupBoxImageOutput.Controls.Add(this.pictureBoxOriginal);
            this.groupBoxImageOutput.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxImageOutput.Location = new System.Drawing.Point(267, 12);
            this.groupBoxImageOutput.Name = "groupBoxImageOutput";
            this.groupBoxImageOutput.Size = new System.Drawing.Size(1065, 581);
            this.groupBoxImageOutput.TabIndex = 2;
            this.groupBoxImageOutput.TabStop = false;
            this.groupBoxImageOutput.Text = "Image Output";
            // 
            // checkBoxView
            // 
            this.checkBoxView.AutoSize = true;
            this.checkBoxView.Location = new System.Drawing.Point(295, 51);
            this.checkBoxView.Name = "checkBoxView";
            this.checkBoxView.Size = new System.Drawing.Size(71, 25);
            this.checkBoxView.TabIndex = 2;
            this.checkBoxView.Text = "View";
            this.checkBoxView.UseVisualStyleBackColor = true;
            this.checkBoxView.CheckedChanged += new System.EventHandler(this.OnCheckedChangedCheckBoxShow);
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.Image")));
            this.pictureBoxStatus.Location = new System.Drawing.Point(704, 243);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(202, 200);
            this.pictureBoxStatus.TabIndex = 7;
            this.pictureBoxStatus.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(93, 52);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(196, 23);
            this.progressBar.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(19, 52);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(68, 21);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Status";
            // 
            // labelFilterImage
            // 
            this.labelFilterImage.AutoSize = true;
            this.labelFilterImage.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFilterImage.Location = new System.Drawing.Point(536, 83);
            this.labelFilterImage.Name = "labelFilterImage";
            this.labelFilterImage.Size = new System.Drawing.Size(112, 21);
            this.labelFilterImage.TabIndex = 1;
            this.labelFilterImage.Text = "Filter Image";
            // 
            // pictureBoxFilter
            // 
            this.pictureBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFilter.Location = new System.Drawing.Point(540, 111);
            this.pictureBoxFilter.Name = "pictureBoxFilter";
            this.pictureBoxFilter.Size = new System.Drawing.Size(498, 456);
            this.pictureBoxFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFilter.TabIndex = 6;
            this.pictureBoxFilter.TabStop = false;
            // 
            // labelOriginalImage
            // 
            this.labelOriginalImage.AutoSize = true;
            this.labelOriginalImage.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOriginalImage.Location = new System.Drawing.Point(19, 83);
            this.labelOriginalImage.Name = "labelOriginalImage";
            this.labelOriginalImage.Size = new System.Drawing.Size(132, 21);
            this.labelOriginalImage.TabIndex = 0;
            this.labelOriginalImage.Text = "Original Image";
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(23, 111);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(498, 456);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 4;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // groupBoxProcessingInfo
            // 
            this.groupBoxProcessingInfo.Controls.Add(this.labelTime);
            this.groupBoxProcessingInfo.Controls.Add(this.labelTimeUnit);
            this.groupBoxProcessingInfo.Controls.Add(this.textBoxTime);
            this.groupBoxProcessingInfo.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxProcessingInfo.Location = new System.Drawing.Point(12, 480);
            this.groupBoxProcessingInfo.Name = "groupBoxProcessingInfo";
            this.groupBoxProcessingInfo.Size = new System.Drawing.Size(249, 113);
            this.groupBoxProcessingInfo.TabIndex = 1;
            this.groupBoxProcessingInfo.TabStop = false;
            this.groupBoxProcessingInfo.Text = "Processing Infomation";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(37, 32);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(52, 21);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Time";
            // 
            // labelTimeUnit
            // 
            this.labelTimeUnit.AutoSize = true;
            this.labelTimeUnit.Location = new System.Drawing.Point(208, 63);
            this.labelTimeUnit.Name = "labelTimeUnit";
            this.labelTimeUnit.Size = new System.Drawing.Size(35, 21);
            this.labelTimeUnit.TabIndex = 5;
            this.labelTimeUnit.Text = "ms";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(41, 56);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(154, 28);
            this.textBoxTime.TabIndex = 4;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelStart
            // 
            this.labelStart.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStart.Location = new System.Drawing.Point(69, 27);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(34, 23);
            this.labelStart.TabIndex = 8;
            this.labelStart.Text = "0";
            this.labelStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEnd
            // 
            this.labelEnd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEnd.Location = new System.Drawing.Point(135, 27);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(154, 23);
            this.labelEnd.TabIndex = 9;
            this.labelEnd.Text = "0";
            this.labelEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1344, 603);
            this.Controls.Add(this.groupBoxProcessingInfo);
            this.Controls.Add(this.groupBoxImageOutput);
            this.Controls.Add(this.groupBoxOperation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Image Processing Speed Comparison";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosingFormMain);
            this.groupBoxOperation.ResumeLayout(false);
            this.groupBoxImageOutput.ResumeLayout(false);
            this.groupBoxImageOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            this.groupBoxProcessingInfo.ResumeLayout(false);
            this.groupBoxProcessingInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect;
        private GroupBox groupBoxOperation;
        private GroupBox groupBoxImageOutput;
        private Label labelFilterImage;
        private PictureBox pictureBoxFilter;
        private Label labelOriginalImage;
        private PictureBox pictureBoxOriginal;
        private ToolTip toolTipBtnFileSelect;
        private Button btnFilterStartUnsafe;
        private Button btnAllClear;
        private ToolTip toolTipBtnAllClear;
        private Button btnFilterStartNormal;
        private ToolTip toolTipBtnFilterStartUnsafe;
        private ToolTip toolTipBtnFilterStartNormal;
        private GroupBox groupBoxProcessingInfo;
        private TextBox textBoxTime;
        private Label labelTimeUnit;
        private Label labelTime;
        private ProgressBar progressBar;
        private Label labelStatus;
        private CheckBox checkBoxView;
        private PictureBox pictureBoxStatus;
        private Button btnStop;
        private ToolTip toolTipBtnStop;
        private Label labelStart;
        private Label labelEnd;
    }
}

