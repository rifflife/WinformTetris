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
			this.components = new System.ComponentModel.Container();
			this.label2 = new System.Windows.Forms.Label();
			this.Canvas_Queue = new System.Windows.Forms.PictureBox();
			this.Canvas_Hold = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Label_Score = new System.Windows.Forms.Label();
			this.Canvas_GamePlayArea = new System.Windows.Forms.PictureBox();
			this.UpdateTick = new System.Windows.Forms.Timer(this.components);
			this.Label_Info = new System.Windows.Forms.Label();
			this.Label_State = new System.Windows.Forms.Label();
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
			this.Canvas_Queue.Size = new System.Drawing.Size(80, 300);
			this.Canvas_Queue.TabIndex = 12;
			this.Canvas_Queue.TabStop = false;
			this.Canvas_Queue.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Queue_Paint);
			// 
			// Canvas_Hold
			// 
			this.Canvas_Hold.BackColor = System.Drawing.SystemColors.Window;
			this.Canvas_Hold.Location = new System.Drawing.Point(10, 30);
			this.Canvas_Hold.Name = "Canvas_Hold";
			this.Canvas_Hold.Size = new System.Drawing.Size(80, 80);
			this.Canvas_Hold.TabIndex = 11;
			this.Canvas_Hold.TabStop = false;
			this.Canvas_Hold.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Hold_Paint);
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
			// Label_Score
			// 
			this.Label_Score.AutoSize = true;
			this.Label_Score.Location = new System.Drawing.Point(12, 397);
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
			this.Canvas_GamePlayArea.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_GamePlayArea_Paint);
			// 
			// UpdateTick
			// 
			this.UpdateTick.Enabled = true;
			this.UpdateTick.Interval = 16;
			this.UpdateTick.Tick += new System.EventHandler(this.UpdateTick_Tick);
			// 
			// Label_Info
			// 
			this.Label_Info.AutoSize = true;
			this.Label_Info.Location = new System.Drawing.Point(10, 127);
			this.Label_Info.Name = "Label_Info";
			this.Label_Info.Size = new System.Drawing.Size(65, 180);
			this.Label_Info.TabIndex = 14;
			this.Label_Info.Text = "# 컨트롤\r\n* 방향키\r\n이동\r\n\r\n* Z, X\r\n회전\r\n\r\n* Space\r\n하드 드랍\r\n\r\n* Left Shift\r\n홀드";
			// 
			// Label_State
			// 
			this.Label_State.AutoSize = true;
			this.Label_State.Location = new System.Drawing.Point(302, 358);
			this.Label_State.Name = "Label_State";
			this.Label_State.Size = new System.Drawing.Size(79, 30);
			this.Label_State.TabIndex = 15;
			this.Label_State.Text = "스페이스바로\r\n게임 시작";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 423);
			this.Controls.Add(this.Label_State);
			this.Controls.Add(this.Label_Info);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Canvas_Queue);
			this.Controls.Add(this.Canvas_Hold);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Label_Score);
			this.Controls.Add(this.Canvas_GamePlayArea);
			this.Name = "MainForm";
			this.Text = "The Tetris";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
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
		private System.Windows.Forms.Label Label_Score;
		private System.Windows.Forms.PictureBox Canvas_GamePlayArea;
		private System.Windows.Forms.Timer UpdateTick;
		private System.Windows.Forms.Label Label_Info;
		private System.Windows.Forms.Label Label_State;
	}
}
