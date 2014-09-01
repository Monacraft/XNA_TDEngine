using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TDEngine
{
	public class Map
	{
		private Texture2D[] layers;
		public Texture2D mLayer;
		public Map(params Texture2D[] layers)
		{
			this.layers = layers;
			mLayer = this.layers[0];
		}
		public void addTrack(Track track)
		{
			
		}
	}
}
