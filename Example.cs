using System;
using TDEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestRun
{
	public class Example
	{
		static void Main()
		{
			Vector2[] list = {new Vector2(0, 0), new Vector2(0, 4), new Vector2(2, 2)};
			Track line = new Track(list);
			Console.WriteLine(line.Contact(0, 2));
			Console.WriteLine(line.Contact(0, 3));
			Console.WriteLine(line.Contact(1, 4));
			Console.WriteLine(line.Len());
			
			// End
			Console.ReadKey(true);
		}
	}
}
