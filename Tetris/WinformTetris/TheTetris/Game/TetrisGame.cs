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
		BlockColor = Color.White;
	}
}

public class TetrisGame
{
	public event Action<GameResult>? OnGameFinished = null;

	// Map Data
	private TileGrid mGameMap;

	// Mino Data
	private List<Mino> mMinos;
	private Queue<Mino> mMinoQueue = new Queue<Mino>(10);

	// Gameplay Data
	private Mino? mHold = null;
	private Mino? mCurrentMino = null;

	private int mCurrentMinoX = 0;
	private int mCurrentMinoY = 0;

	private int mScore = 0;

	// Muse
	private Random mRandom = new();

	public TetrisGame()
	{
		mGameMap = new TileGrid(10, 20);

		mMinos = new List<Mino>(7);

		mMinos.Add(Mino.LMino);
		mMinos.Add(Mino.JMino);
		mMinos.Add(Mino.OMino);
		mMinos.Add(Mino.ZMino);
		mMinos.Add(Mino.SMino);
		mMinos.Add(Mino.IMino);
		mMinos.Add(Mino.TMino);
	}

	public void Initialize()
	{
		mGameMap.Clear();

		mHold = null;
		mCurrentMino = null;
		mMinoQueue.Clear();
		FillRandomMino();
	}

	private void rotateCurrentMino(bool isRightAngle)
	{

	}

	private void holdMino()
	{
		if (mHold == null)
		{
			mHold = mCurrentMino;
			PopMino();
		}
		else
		{
			var temp = mCurrentMino;
			mCurrentMino = mHold;
			mHold = temp;
		}

		resetMinoPosition();
	}

	private void PopMino()
	{
		mCurrentMino = mMinoQueue.Dequeue();
		if (mMinoQueue.Count < 3)
		{
			FillRandomMino();
		}

		resetMinoPosition();
	}

	private void resetMinoPosition()
	{
		mCurrentMinoX = 3;
		mCurrentMinoY = 20;
	}

	public void Start()
	{

	}

	private void tick()
	{
		mCurrentMinoY++;
	}

	private void checkLines()
	{

	}

	public void Draw()
	{

	}

	private void FillRandomMino()
	{
		int n = mMinos.Count;
		while (n > 1)
		{
			n--;
			int k = mRandom.Next(n + 1);
			Mino temp = mMinos[k];
			mMinos[k] = mMinos[n];
			mMinos[n] = temp;
		}

		foreach (Mino m in mMinos)
		{
			mMinoQueue.Enqueue(m.Clone());
		}
	}

	//private bool isCurrentMinoCollideBy(TileCoord direction)
	//{
	//	if (mCurrentMino == null)
	//	{
	//		return false;
	//	}

	//	var minoArea = mCurrentMino.Area;

	//	for (int y = 0; y < mCurrentMino.Height; y++)
	//	{
	//		for (int x = 0; x < mCurrentMino.Width; x++)
	//		{
	//			if (!mCurrentMino[y, x])
	//			{
	//				continue;
	//			}

	//			// 영역을 벗어난 경우 충돌한 것으로 간주
	//			if (!isValidPosition(new TileCoord(x, y) + direction))
	//			{
	//				return true;
	//			}

				
	//		}
	//	}


	//}

	//private bool isValidPosition(TileCoord position)
	//{
	//	return isValidPosition(position.X, position.Y);
	//}

	//private bool isValidPosition(int x, int y)
	//{
	//	return !(x < 0 || x >= mWidth || y < 0 || y >= mHeight);
	//}

}