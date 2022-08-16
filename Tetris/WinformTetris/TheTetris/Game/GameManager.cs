using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameManager
{
	public event Action<string>? OnStateChanged = null;
	public event Action<int>? OnScoreChanged = null;

	private TetrisGame mTetrisGame;
	private InputManager mInputManager;
	private bool mIsStarted;
	private const int DROP_TICK_INIT = 20;
	private int mDropTick;

	public GameManager(InputManager inputManager)
	{
		// Initialize game
		mTetrisGame = new TetrisGame();
		mTetrisGame.OnGameFinished += OnGameFinished;
		mTetrisGame.OnScoreChanged += (score) => { OnScoreChanged?.Invoke(score); };

		// Initialize input
		mInputManager = inputManager;

		var rightInput = mInputManager.GetInputData(GameKey.MoveRight);
		rightInput.Interval = 5;
		rightInput.OnPressed += () => { tryMove(TileCoord.Right); };

		var leftInput = mInputManager.GetInputData(GameKey.MoveLeft);
		leftInput.Interval = 5;
		leftInput.OnPressed += () => { tryMove(TileCoord.Left); };

		var softDropInput = mInputManager.GetInputData(GameKey.SoftDrop);
		softDropInput.Interval = 5;
		softDropInput.OnPressed += () => { tryMove(TileCoord.Down); };

		var rightRotateInput = mInputManager.GetInputData(GameKey.RotateRight);
		rightRotateInput.OnPressed += () => { tryRotate(true); };

		var leftRotateInput = mInputManager.GetInputData(GameKey.RotateLeft);
		leftRotateInput.OnPressed += () => { tryRotate(false); };

		var holdInput = mInputManager.GetInputData(GameKey.Hold);
		holdInput.OnPressed += () => { hold(); };

		var hardDropInput = mInputManager.GetInputData(GameKey.HardDrop);
		hardDropInput.OnPressed += () =>
		{
			if (!mIsStarted)
			{
				StartGame();
				return;
			}

			while (tryMove(TileCoord.Down)) {}
			mTetrisGame.Tick();
			// hard drop
		};
	}

	private bool tryMove(TileCoord direction)
	{
		if (mIsStarted)
		{
			return mTetrisGame.TryMove(direction);
		}
		
		return false;
	}

	private bool tryRotate(bool isRightAngle)
	{
		if (mIsStarted)
		{
			return mTetrisGame.TryRotate(isRightAngle);
		}

		return false;
	}

	private void hold()
	{
		if (mIsStarted)
		{
			mTetrisGame.Hold();
		}
	}

	public void StartGame()
	{
		mTetrisGame.Initialize();
		mIsStarted = true;
		mDropTick = DROP_TICK_INIT;
		OnStateChanged?.Invoke("게임 시작!");
	}

	public void Update()
	{
		if (!mIsStarted)
		{
			return;
		}

		mDropTick--;
		if (mDropTick <= 0)
		{
			mTetrisGame.Tick();
			mDropTick = DROP_TICK_INIT;
		}
	}

	private void OnGameFinished(GameResult gameResult)
	{
		mIsStarted = false;

		switch (gameResult)
		{
			case GameResult.Win:
				OnStateChanged?.Invoke("게임 승리 !");
				break;

			case GameResult.Lose:
				OnStateChanged?.Invoke("게임 패배 !");
				break;

			default:
				OnStateChanged?.Invoke("알수 없는 오류 발생");
				break;
		}
	}

	public void DrawMap(Graphics g) => mTetrisGame.DrawMap(g);

	public void DrawHold(Graphics g) => mTetrisGame.DrawHold(g);

	public void DrawQueue(Graphics g) => mTetrisGame.DrawQueue(g);
}
