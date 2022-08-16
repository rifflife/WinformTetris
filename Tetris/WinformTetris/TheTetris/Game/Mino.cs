using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mino : TileGrid
{
	public const int AREA_SIZE = 4;
	public Color MinoColor { get; private set;}

	private Mino(Color blockColor, bool[,] area)
		: base(area.GetLength(1), area.GetLength(0))
	{
		MinoColor = blockColor;

		if (Height != Width)
		{
			throw new ArgumentException("Mino의 영역 크기는 반드시 정사각형이어야 합니다.");
		}

		Area = new Block[Height, Width];

		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				Area[y, x] = new Block(false, blockColor);
			}
		}
	}

	public Mino Clone()
	{
		bool[,] newArea = new bool[Height, Width];
		Array.Copy(this.Area, newArea, this.Area.Length);

		return new Mino(MinoColor, newArea);
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
					rotateArea[x, Width - 1 - y] = Area[y, x];
				}
			}
		}
		else
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					rotateArea[Height - 1 - x, y] = Area[y, x];
				}
			}
		}
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

	public static Mino IMino => new Mino(Color.Green, new bool[AREA_SIZE, AREA_SIZE]
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
