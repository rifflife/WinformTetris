using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum GameKey
{
	None,

	// Moving
	MoveLeft,
	MoveRight,

	// Rotating
	RotateLeft,
	RotateRight,

	// Dropping
	SoftDrop,
	HardDrop,

	// Holding
	Hold,
}

public class InputData
{
	public event Action? OnPressed;
	public event Action? OnReleased;
	public bool IsPressed;
	public int Interval;
	private int mIntervalDelay;

	public void Update()
	{
		if (IsPressed && Interval != 0)
		{
			if (mIntervalDelay > 0)
			{
				mIntervalDelay--;
				return;
			}

			OnPressed?.Invoke();

			mIntervalDelay = Interval;
		}
	}

	public void OnInputPressed()
	{
		if (!IsPressed)
		{
			OnPressed?.Invoke();
		}

		IsPressed = true;
	}

	public void OnInputReleased()
	{
		OnReleased?.Invoke();
		IsPressed = false;
		mIntervalDelay = Interval;
	}
}

public class InputManager
{
	private Dictionary<GameKey, Keys> mInputByGameKey = new()
	{
		// Moving
		{ GameKey.MoveLeft, Keys.Left },
		{ GameKey.MoveRight, Keys.Right },
		
		// Rotating
		{ GameKey.RotateLeft, Keys.Z },
		{ GameKey.RotateRight, Keys.X },

		// Dropping
		{ GameKey.SoftDrop, Keys.Down },
		{ GameKey.HardDrop, Keys.Space },

		// Holding
		{ GameKey.Hold, Keys.ShiftKey },
	};

	private Dictionary<Keys, InputData> mInputTable = new()
	{
		// Moving
		{ Keys.Left, new InputData() },
		{ Keys.Right, new InputData() },

		// Rotating
		{ Keys.Z, new InputData() },
		{ Keys.X, new InputData() },

		// Dropping
		{ Keys.Down, new InputData() },
		{ Keys.Space, new InputData() },

		// Holding
		{ Keys.ShiftKey, new InputData() },
	};

	public InputData GetInputData(GameKey gameKey)
	{
		return mInputTable[mInputByGameKey[gameKey]];
	}

	public void SetInput(Keys key, bool isPressed)
	{
		if (!mInputTable.ContainsKey(key))
		{
			return;
		}

		if (isPressed)
		{
			mInputTable[key].OnInputPressed();
		}
		else
		{
			mInputTable[key].OnInputReleased();
		}
	}

	public void Update()
	{
		foreach (var inputData in mInputTable.Values)
		{
			inputData.Update();
		}
	}
}
