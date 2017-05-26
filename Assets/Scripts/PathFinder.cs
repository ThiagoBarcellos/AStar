using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
	public class Caminho
	{
		public Grid.Position position;
		public Caminho next = null;

		public Caminho(int x, int y, Caminho next){
			position.x = x;
			position.y = y;
			this.next = next;
		}
	}

	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		Queue<Caminho> q = new Queue<Caminho> ();
		q.Enqueue (new Caminho(fromPosition.x, fromPosition.y, null));

		var path = new List<Grid.Position>();

		while (q.Count > 0) 
		{
			var p = q.Dequeue ();
			if (p.position.x == toPosition.x && p.position.y == toPosition.y) 
			{
				while (p != null) {
					path.Add (p.position);
					p = p.next;
					//Debug.Log (p.position.x + " " + p.position.y);
				}
				Debug.Log ("ACHEI");
				break;
			}
			else 
			{
				tiles.GetLength (0);
				tiles.GetLength(1);

				if(p.position.y + 1 < tiles.GetLength(1) && !tiles[p.position.x, p.position.y + 1 ].isWall)
					q.Enqueue (new Caminho (p.position.x, p.position.y + 1, p));
				if(p.position.y - 1 >= 0 && p.position.y < tiles.GetLength(1) && !tiles[p.position.x, p.position.y - 1 ].isWall)
					q.Enqueue (new Caminho (p.position.x, p.position.y - 1, p));
				if(p.position.x + 1 < tiles.GetLength(0) && !tiles[p.position.x + 1, p.position.y].isWall)
					q.Enqueue (new Caminho (p.position.x + 1 , p.position.y, p));
				if(p.position.x - 1 >= 0 && p.position.x < tiles.GetLength(0) && !tiles[p.position.x - 1, p.position.y].isWall)
					q.Enqueue (new Caminho (p.position.x - 1, p.position.y, p));
			}
		}
		return path;
	}
}