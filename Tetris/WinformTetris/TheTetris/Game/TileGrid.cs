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

	public TileGrid() { }

	public TileGrid(int width, int height)
	{
		Width = width;
		Height = height;
		Area = new Block[Height, Width];
	}

	public TileGrid(Color blockColor, bool[,] area)
		: this(area.GetLength(1), area.GetLength(0))
	{
		Area = new Block[Height, Width];

		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				Area[y, x] = new Block(area[y, x], blockColor);
			}
		}
	}

	public TileGrid(TileGrid copy)
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

	public void AddArea(TileGrid other, TileCoord offset)
	{
		for (int otherY = 0; otherY < other.Height; otherY++)
		{
			for (int otherX = 0; otherX < other.Width; otherX++)
			{
				var block = other.Area[otherY, otherX];

				if (block.IsFilled)
				{
					int targetX = otherX + offset.X;
					int targetY = otherY + offset.Y;
					this.Area[targetY, targetX] = block;
				}
			}
		}
	}
	
	public int GetMatchLinesAndShift()
	{
		int matchCount = 0;

		for (int y = Height - 1; y >= 0; y--)
		{
			bool isLineMatched = true;

			for (int x = 0; x < Width; x++)
			{
				if (!this[y, x])
				{
					isLineMatched = false;
					break;
				}
			}

			if (isLineMatched)
			{
				shiftDown(y);
				matchCount++;
				y++;
			}
		}

		return matchCount;
	}

	private void shiftDown(int baseLine)
	{
		for (int y = baseLine; y > 0; y--)
		{
			for (int x = 0; x < Width; x++)
			{
				Area[y, x] = Area[y - 1, x];
			}
		}
	}

	public void Draw(Graphics g, int cellSize, TileCoord offset)
	{
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				var block = Area[y, x];

				if (block.IsFilled)
				{
					using SolidBrush sb = new SolidBrush(Area[y, x].BlockColor);
					int drawX = (x + offset.X) * cellSize;
					int drawY = (y + offset.Y) * cellSize;
					g.FillRectangle(sb, drawX, drawY, cellSize, cellSize);
				}
			}
		}
	}

	public bool IsCollideWith(TileGrid other, TileCoord position, TileCoord direction)
	{
		if (other == null)
		{
			return false;
		}

		for (int otherY = 0; otherY < other.Height; otherY++)
		{
			for (int otherX = 0; otherX < other.Width; otherX++)
			{
				if (other[otherY, otherX])
				{
					TileCoord checkPos = new TileCoord(otherX, otherY) + position + direction;

					// 영역을 벗어난 경우 충돌한 것으로 간주
					if (!isValidPosition(checkPos))
					{
						return true;
					}

					if (this[checkPos.Y, checkPos.X])
					{
						return true;
					}
				}
			}
		}

		return false;
	}

	private bool isValidPosition(TileCoord position)
	{
		return isValidPosition(position.X, position.Y);
	}

	private bool isValidPosition(int x, int y)
	{
		return !(x < 0 || x >= Width || y < 0 || y >= Height);
	}
}
