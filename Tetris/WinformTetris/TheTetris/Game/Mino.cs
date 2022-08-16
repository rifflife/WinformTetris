using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mino : TileGrid
{
	public const int AREA_SIZE = 4;

	private Mino(Color blockColor, bool[,] area) : base(blockColor, area)
	{
		if (Height != Width)
		{
			throw new ArgumentException("Mino의 영역 크기는 반드시 정사각형이어야 합니다.");
		}
	}

	public Mino(Mino copy)
	{
		this.Width = copy.Width;
		this.Height = copy.Height;
		this.Area = new Block[this.Height, this.Width];

		for (int y = 0; y < this.Width; y++)
		{
			for (int x = 0; x < this.Height; x++)
			{
				this.Area[y, x] = copy.Area[y, x];
			}
		}
	}

	public Mino Clone()
	{
		return new Mino(this);
	}

	public void Rotate(bool isRight)
	{
		Block[,] rotateArea = new Block[Height, Width];

		if (isRight)
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					rotateArea[x, Height - 1 - y] = Area[y, x];
				}
			}
		}
		else
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					rotateArea[Width - 1 - x, y] = Area[y, x];
				}
			}
		}

		Area = rotateArea;
	}

	public static Mino LMino => new Mino(Color.Orange, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, false, false, false },
			{ false, true, false, false },
			{ false, true, false, false },
			{ false, true, true, false },
		});

	public static Mino JMino => new Mino(Color.Blue, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, false, false, false },
			{ false, false, true, false },
			{ false, false, true, false },
			{ false, true, true, false },
		});

	public static Mino OMino => new Mino(Color.Yellow, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, false, false, false },
			{ false, true, true, false },
			{ false, true, true, false },
			{ false, false, false, false },
		});

	public static Mino ZMino => new Mino(Color.Red, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, false, false, false },
			{ true, true, false, false },
			{ false, true, true, false },
			{ false, false, false, false },
		});

	public static Mino SMino => new Mino(Color.Green, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, false, false, false },
			{ false, false, true, true },
			{ false, true, true, false },
			{ false, false, false, false },
		});

	public static Mino IMino => new Mino(Color.Cyan, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, true, false, false },
			{ false, true, false, false },
			{ false, true, false, false },
			{ false, true, false, false },
		});

	public static Mino TMino => new Mino(Color.Magenta, new bool[AREA_SIZE, AREA_SIZE]
		{
			{ false, false, false, false },
			{ true, true, true, false },
			{ false, true, false, false },
			{ false, false, false, false },
		});
}
