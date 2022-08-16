namespace TheTetris
{
	partial class MainForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.Canvas_Queue = new System.Windows.Forms.PictureBox();
			this.Canvas_Hold = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Btn_Start = new System.Windows.Forms.Button();
			this.Label_Score = new System.Windows.Forms.Label();
			this.Canvas_GamePlayArea = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.Canvas_Queue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Canvas_Hold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Canvas_GamePlayArea)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(302, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 15);
			this.label2.TabIndex = 13;
			this.label2.Text = "Next";
			// 
			// Canvas_Queue
			// 
			this.Canvas_Queue.BackColor = System.Drawing.SystemColors.Window;
			this.Canvas_Queue.Location = new System.Drawing.Point(302, 30);
			this.Canvas_Queue.Name = "Canvas_Queue";
			this.Canvas_Queue.Size = new System.Drawing.Size(80, 240);
			this.Canvas_Queue.TabIndex = 12;
			this.Canvas_Queue.TabStop = false;
			// 
			// Canvas_Hold
			// 
			this.Canvas_Hold.BackColor = System.Drawing.SystemColors.Window;
			this.Canvas_Hold.Location = new System.Drawing.Point(10, 30);
			this.Canvas_Hold.Name = "Canvas_Hold";
			this.Canvas_Hold.Size = new System.Drawing.Size(80, 80);
			this.Canvas_Hold.TabIndex = 11;
			this.Canvas_Hold.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 15);
			this.label1.TabIndex = 10;
			this.label1.Text = "Hold";
			// 
			// Btn_Start
			// 
			this.Btn_Start.Location = new System.Drawing.Point(302, 363);
			this.Btn_Start.Name = "Btn_Start";
			this.Btn_Start.Size = new System.Drawing.Size(80, 48);
			this.Btn_Start.TabIndex = 9;
			this.Btn_Start.Text = "시작하기";
			this.Btn_Start.UseVisualStyleBackColor = true;
			// 
			// Label_Score
			// 
			this.Label_Score.AutoSize = true;
			this.Label_Score.Location = new System.Drawing.Point(302, 335);
			this.Label_Score.Name = "Label_Score";
			this.Label_Score.Size = new System.Drawing.Size(49, 15);
			this.Label_Score.TabIndex = 8;
			this.Label_Score.Text = "점수 : 0";
			// 
			// Canvas_GamePlayArea
			// 
			this.Canvas_GamePlayArea.BackColor = System.Drawing.SystemColors.Window;
			this.Canvas_GamePlayArea.Location = new System.Drawing.Point(96, 12);
			this.Canvas_GamePlayArea.Name = "Canvas_GamePlayArea";
			this.Canvas_GamePlayArea.Size = new System.Drawing.Size(200, 400);
			this.Canvas_GamePlayArea.TabIndex = 7;
			this.Canvas_GamePlayArea.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 423);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Canvas_Queue);
			this.Controls.Add(this.Canvas_Hold);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Btn_Start);
			this.Controls.Add(this.Label_Score);
			this.Controls.Add(this.Canvas_GamePlayArea);
			this.Name = "MainForm";
			this.Text = "The Tetris";
			((System.ComponentModel.ISupportInitialize)(this.Canvas_Queue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Canvas_Hold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Canvas_GamePlayArea)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox Canvas_Queue;
		private System.Windows.Forms.PictureBox Canvas_Hold;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Btn_Start;
		private System.Windows.Forms.Label Label_Score;
		private System.Windows.Forms.PictureBox Canvas_GamePlayArea;
	}
}
