using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum GameResult
{
	None = 0,
	Win = 1,
	Lose = 2,
}

public struct Block
{
	public bool IsFilled;
	public Color BlockColor;

	public Block(bool isFilled, Color blockColor)
	{
		IsFilled = isFilled;
		BlockColor = blockColor;
	}

	public Block(bool isFilled)
	{
		IsFilled = isFilled;
		BlockColor = TetrisGame.ThemeColor;
	}
}

public class TetrisGame
{
	public event Action<GameResult>? OnGameFinished = null;
	public event Action<int>? OnScoreChanged = null;

	// Map Data
	private TileGrid mGameMap;

	// Mino Data
	private List<Mino> mBaseMinos;
	private List<Mino> mMinoQueue = new List<Mino>(10);

	// Gameplay Data
	private Mino? mHold = null;
	private Mino? mCurrentMino = null;

	private TileCoord mMinoPos;

	public int Score { get; private set; }

	// Muse
	private Random mRandom = new();

	// Drawing
	public static readonly Color ThemeColor = Color.DarkGray;
	private int mCellSize = 20;

	private bool mIsHoldedOnce;

	public TetrisGame()
	{
		mGameMap = new TileGrid(10, 20);

		mBaseMinos = new List<Mino>(7);

		mBaseMinos.Add(Mino.LMino);
		mBaseMinos.Add(Mino.JMino);
		mBaseMinos.Add(Mino.OMino);
		mBaseMinos.Add(Mino.ZMino);
		mBaseMinos.Add(Mino.SMino);
		mBaseMinos.Add(Mino.IMino);
		mBaseMinos.Add(Mino.TMino);
	}

	public void Initialize()
	{
		mGameMap.Clear();

		Score = 0;
		mHold = null;
		mIsHoldedOnce = false;
		mCurrentMino = null;
		mMinoQueue.Clear();
		fillRandomMino();
		popMino();
	}

	public void Tick()
	{
		if (mCurrentMino != null)
		{
			if (mGameMap.IsCollideWith(mCurrentMino, mMinoPos, TileCoord.Down))
			{
				mGameMap.AddArea(mCurrentMino, mMinoPos);
				int removedLineCount = mGameMap.GetMatchLinesAndShift();
				Score += removedLineCount * 100;
				OnScoreChanged?.Invoke(Score);

				if (mMinoPos.Y == 0)
				{
					OnGameFinished?.Invoke(GameResult.Lose);
				}

				popMino();
				mIsHoldedOnce = false;
			}
			else
			{
				mMinoPos += TileCoord.Down;
			}
		}
	}

	// Input

	public void Hold()
	{
		if (mIsHoldedOnce)
		{
			return;
		}

		mIsHoldedOnce = true;

		if (mHold == null)
		{
			mHold = mCurrentMino;
			popMino();
		}
		else
		{
			var temp = mCurrentMino;
			mCurrentMino = mHold;
			mHold = temp;
		}

		resetMinoPosition();
	}

	public bool TryMove(TileCoord direction)
	{
		if (mCurrentMino == null)
		{
			return false;
		}

		if (mGameMap.IsCollideWith(mCurrentMino, mMinoPos, direction))
		{
			return false;
		}

		mMinoPos += direction;
		return true;
	}

	public bool TryRotate(bool isRightAngle)
	{
		if (mCurrentMino == null)
		{
			return false;
		}

		mCurrentMino.Rotate(isRightAngle);

		if (mGameMap.IsCollideWith(mCurrentMino, mMinoPos, TileCoord.Zero))
		{
			mCurrentMino.Rotate(!isRightAngle);
			return false;
		}

		return true;
	}

	// Logic

	private void popMino()
	{
		mCurrentMino = mMinoQueue[0];

		mMinoQueue.RemoveAt(0);

		if (mMinoQueue.Count < 3)
		{
			fillRandomMino();
		}

		resetMinoPosition();

		if (mGameMap.IsCollideWith(mCurrentMino, mMinoPos, TileCoord.Zero))
		{
			OnGameFinished?.Invoke(GameResult.Lose);
		}
	}

	private void fillRandomMino()
	{
		int n = mBaseMinos.Count;
		while (n > 1)
		{
			n--;
			int k = mRandom.Next(n + 1);
			Mino temp = mBaseMinos[k];
			mBaseMinos[k] = mBaseMinos[n];
			mBaseMinos[n] = temp;
		}

		foreach (Mino m in mBaseMinos)
		{
			mMinoQueue.Add(m.Clone());
		}
	}

	private void resetMinoPosition()
	{
		mMinoPos = new TileCoord(3, 0);
	}

	// Drawing

	public void DrawMap(Graphics g)
	{
		g.Clear(ThemeColor);
		
		mGameMap.Draw(g, mCellSize, TileCoord.Zero);
		mCurrentMino?.Draw(g, mCellSize, mMinoPos);
	}

	public void DrawQueue(Graphics g)
	{
		g.Clear(ThemeColor);

		if (mMinoQueue.Count < 3)
		{
			return;
		}

		for (int i = 0; i < 3; i++)
		{
			mMinoQueue[i].Draw(g, mCellSize, (TileCoord.Down * 4 + TileCoord.Down) * i);
		}
	}

	public void DrawHold(Graphics g)
	{
		g.Clear(ThemeColor);

		if (mHold == null)
		{
			return;
		}

		mHold.Draw(g, mCellSize, TileCoord.Zero);
	}
}