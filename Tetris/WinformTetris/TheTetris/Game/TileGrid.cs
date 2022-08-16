using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TileGrid
{
	public int Width { get; protected set; }
	public int Height { get; protected set; }
	public Block[,] Area { get; protected set; }

	public bool this[int y, int x] => Area[y, x].IsFilled;

	public TileGrid(int width, int height)
	{
		Width = width;
		Height = height;
		Area = new Block[Height, Width];
	}

	public void Clear()
	{
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				Area[y, x] = new Block(false);
			}
		}
	}

	public void Draw(Graphics g, int cellSize)
	{
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				using (SolidBrush sb = new SolidBrush(Area[y, x].BlockColor))
				{
					g.FillRectangle(sb, x * cellSize, y * cellSize, cellSize, cellSize);
				}
			}
		}
	}

	public void IsCollideWith(TileGrid other, TileCoord direction)
	{

	}
}
