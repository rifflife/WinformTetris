using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTetris
{
	public partial class MainForm : Form
	{
		private GameManager mGameManager;
		private InputManager mInputManager;

		public MainForm()
		{
			InitializeComponent();

			mInputManager = new InputManager();
			mGameManager = new GameManager(mInputManager);

			mGameManager.OnStateChanged += (message) =>
			{
				Label_State.Text = message;
			};
			mGameManager.OnScoreChanged += (score) =>
			{
				Label_Score.Text = $"점수 : {score}";
			};
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			mInputManager.SetInput(e.KeyCode, true);
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			mInputManager.SetInput(e.KeyCode, false);
		}

		private void UpdateTick_Tick(object sender, EventArgs e)
		{
			mInputManager.Update();
			mGameManager.Update();

			Canvas_Hold.Invalidate();
			Canvas_Queue.Invalidate();
			Canvas_GamePlayArea.Invalidate();
		}

		private void Canvas_Queue_Paint(object sender, PaintEventArgs e)
		{
			mGameManager.DrawQueue(e.Graphics);
		}

		private void Canvas_GamePlayArea_Paint(object sender, PaintEventArgs e)
		{
			mGameManager.DrawMap(e.Graphics);
		}

		private void Canvas_Hold_Paint(object sender, PaintEventArgs e)
		{
			mGameManager.DrawHold(e.Graphics);
		}

		private void Btn_Start_Click(object sender, EventArgs e)
		{
			mGameManager.StartGame();
		}
	}
}
