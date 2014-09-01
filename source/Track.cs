using System;
using Microsoft.Xna.Framework;

namespace TDEngine
{
	public class Line
	{
		public Vector2 p1;		// The first Point
		public Vector2 p2;		// The seond Point
		public float m;			// The Gradient
		public float b;			// The y intercept
		public float len;		// The length
		public bool IsVertical; // Whether the line is vertical (Needed to check collisions)
		public Line(Vector2 p1, Vector2 p2)
		{
			this.p1 = p1;
			this.p2 = p2;
			m = (p1.Y - p2.Y) / (p1.X - p2.X);
			b = p1.Y - m * p1.X;
			len = Dist(p1, p2);
			if (Math.Abs(m) == 1 / (float)0)
				IsVertical = false;
			else
				IsVertical = true;
		}
		public bool IsWithin(Vector2 point)
		{
			// Detects if point is within the rectangle formed by the two points (Is actually touching it)
			if((point.X >= p1.X && point.X <= p2.X) || (point.X <= p1.X && point.X >= p2.X))
				if ((point.Y >=p1.Y && point.Y <= p2.Y) || (point.Y <= p1.Y && point.Y >= p2.Y))
					return true;
			return false;
		} 
		public bool Contact(Vector2 point)
		{
			// Detects if point is on line
			if (IsVertical)
			{
				if (point.X == p1.X)
					if(this.IsWithin(point))
					   return true;
			}
			else 
			{
				if (point.Y == m * point.X + b)
					if (this.IsWithin(point))
						return true;
			}
			return false;
			
		}
		static float Dist(Vector2 p1, Vector2 p2)
		{
			return Vector2.Distance(p1, p2);
		}
		static float Dist(float x1, float y1, float x2, float y2)
		{
			return Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2));
		}
	}
	public class Track
	{
		public Line[] lines; 				// Lines
		private float tlen;  				// Total length 
		System.Random rand = new Random();
		int n;								// Number of lines
		public Track(Line[] lines)
		{
			n = lines.Length;
			this.lines = lines;
			for (int i = 0; i < n; i++) {
				tlen += lines[i].len;
			}
		}
		public Track(Vector2[] points) : this(PointsToLines(points)){}
		public static Line[] PointsToLines(Vector2[] points)
		{
			Line[] JoinedPoints = new Line[points.Length - 1];
			for (int i = 0; i < points.Length - 1; i++) {
				JoinedPoints[i] = new Line(points[i], points[i+1]);
			}
			return JoinedPoints;
		}
		public float Len(){
			return tlen;
		}
		public bool Contact(Vector2 point)
		{
			foreach (Line segment in lines) {
				if (segment.Contact(point))
					return true;
			}
			return false;
		}
		public bool Contact(float x, float y)
		{
			// During testing: #Laziness_is_a_virtue
			return this.Contact(new Vector2(x, y));
		}
		public float[] RandPos(int n)
		{
			float bit = tlen / n;
			float[] temp = new float[n];
			for (int i = 0; i < n; i++) {
				temp[i] = (float)rand.NextDouble() * bit;
			}
			return temp;
		}
	}
}
