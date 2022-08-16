using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class InputManager
{
	private Dictionary<Keys, bool> mInputTable = new();

	public InputManager()
	{
		mInputTable.Add(Keys.Left, false);
		mInputTable.Add(Keys.Right, false);
		mInputTable.Add(Keys.Down, false);
		mInputTable.Add(Keys.Space, false);
		mInputTable.Add(Keys.Shift, false);
	}

	public void SetInput(Keys key, bool isPressed)
	{
		if (!mInputTable.ContainsKey(key))
		{
			return;
		}

		mInputTable[key] = isPressed;
	}
	
}
