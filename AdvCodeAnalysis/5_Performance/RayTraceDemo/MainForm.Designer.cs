namespace RayTraceDemo
{
  partial class MainForm
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
      this.myRunButton = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.myAntiAliasCheckBox = new System.Windows.Forms.CheckBox();
      this.myTimeLabel = new System.Windows.Forms.Label();
      this.myHintLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // myRunButton
      // 
      this.myRunButton.Location = new System.Drawing.Point(12, 37);
      this.myRunButton.Name = "myRunButton";
      this.myRunButton.Size = new System.Drawing.Size(75, 23);
      this.myRunButton.TabIndex = 0;
      this.myRunButton.Text = "Run";
      this.myRunButton.UseVisualStyleBackColor = true;
      this.myRunButton.Click += new System.EventHandler(this.myRunButton_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.Location = new System.Drawing.Point(12, 66);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(640, 370);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // myAntiAliasCheckBox
      // 
      this.myAntiAliasCheckBox.AutoSize = true;
      this.myAntiAliasCheckBox.Location = new System.Drawing.Point(93, 41);
      this.myAntiAliasCheckBox.Name = "myAntiAliasCheckBox";
      this.myAntiAliasCheckBox.Size = new System.Drawing.Size(68, 17);
      this.myAntiAliasCheckBox.TabIndex = 4;
      this.myAntiAliasCheckBox.Text = "Anti alias";
      this.myAntiAliasCheckBox.UseVisualStyleBackColor = true;
      this.myAntiAliasCheckBox.CheckedChanged += new System.EventHandler(this.myAntiAliasCheckBox_CheckedChanged);
      // 
      // myTimeLabel
      // 
      this.myTimeLabel.AutoSize = true;
      this.myTimeLabel.Location = new System.Drawing.Point(167, 42);
      this.myTimeLabel.Name = "myTimeLabel";
      this.myTimeLabel.Size = new System.Drawing.Size(0, 13);
      this.myTimeLabel.TabIndex = 5;
      // 
      // myHintLabel
      // 
      this.myHintLabel.AutoSize = true;
      this.myHintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.myHintLabel.Location = new System.Drawing.Point(12, 9);
      this.myHintLabel.Name = "myHintLabel";
      this.myHintLabel.Size = new System.Drawing.Size(318, 25);
      this.myHintLabel.TabIndex = 6;
      this.myHintLabel.Text = "Step 1: Click the \'Run\' button below";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(664, 448);
      this.Controls.Add(this.myHintLabel);
      this.Controls.Add(this.myTimeLabel);
      this.Controls.Add(this.myAntiAliasCheckBox);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.myRunButton);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Text = "Ray Trace";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button myRunButton;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.CheckBox myAntiAliasCheckBox;
    private System.Windows.Forms.Label myTimeLabel;
    private System.Windows.Forms.Label myHintLabel;
  }
}

