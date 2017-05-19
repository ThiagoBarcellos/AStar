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

		while (q.Count > 0) 
		{
			var p = q.Dequeue ();
			if (p.position.x == toPosition.x && p.position.y == toPosition.y) 
			{
				Debug.Log ("ACHEI");
				break;
			}
			else 
			{
				q.Enqueue (new Caminho (p.position.x, p.position.y + 1, p));
				q.Enqueue (new Caminho (p.position.x, p.position.y - 1, p));
				q.Enqueue (new Caminho (p.position.x + 1 , p.position.y, p));
				q.Enqueue (new Caminho (p.position.x - 1, p.position.y, p));
			}
		}

		var path = new List<Grid.Position>();
		//path.Add( fromPosition.x && fromPosition.y );
		//path.Add( toPosition );

		return path;
	}
}