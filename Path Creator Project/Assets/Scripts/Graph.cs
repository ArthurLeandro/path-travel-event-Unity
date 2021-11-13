using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Travel
{
	[Serializable]
	public class Graph
	{
		public List<Vertex> vertices;
		private List<Vertex> hidePath;


		public List<Vertex> Search(Vertex p_origin, Vertex p_destination)
		{
			List<List<Vertex>> path = new List<List<Vertex>>();
			foreach (Vertex n in p_origin.Vertices)
			{
				List<Vertex> list = Search(n, p_destination, new List<Vertex>(), new List<Vertex>());
				if (list != null)
					path.Add(list);
			}
#if UNITY_EDITOR
			// foreach (var p in path)
			// {
			// 	foreach (var n in p)
			// 	{
			// 		Debug.Log($"Node: {n.Name}");
			// 	}
			// 	Debug.Log($"Tamanho {p.Count}");
			// }
#endif
			Debug.Log($"ORIGIN: {p_origin.Name}");
			Debug.Log($"DESTINY: {p_destination.Name}");
			return path.Last();
			// return path.Where(p => p.Count > 0).OrderBy(p => p.Count).First();
		}

		public List<Vertex> Search(Vertex p_origin, Vertex p_destination, List<Vertex> p_visited, List<Vertex> p_path)
		{
			if (p_origin != null)
			{
				if (!p_visited.Contains(p_origin))
				{
					p_visited.Add(p_origin);
					p_path.Add(p_origin);
					if (p_origin == p_destination)
					{
						return p_path;
					}
					else
					{
						foreach (Vertex v in p_origin.Vertices)
						{
							Search(v, p_destination, p_visited, p_path);
						}
					}
				}
				else
				{
					return null;
				}
			}
			return null;
		}


		private int NumberCalculated() => UnityEngine.Random.Range(0, 101);

		private void OccurEvent()
		{
			// para cada no do tipo Random
			//ver se ocorrera o evento
			//se ocorrer rodar a visualização ate este evento
			//senao apenas rodar o algoritmo puro mesmo

		}
		public void CreateLink()
		{
			foreach (var v in vertices)
			{
				v.Vertices = new List<Vertex>(v.places.Count());
				for (int i = 0; i < v.places.Count; i++)
				{
					try
					{
						if (!v.places[i].name.Equals(""))
							foreach (var vi in vertices.Where(vert => vert.Name.Equals(v.places[i].name)))
								v.Vertices.Add(vi);
					}
					catch (Exception e)
					{
						Debug.Log($"GRAPH CreateLink - Name {v.Name} Error{e}");
					}
				}
			}
		}

		public IEnumerator CreateLinkCoroutine()
		{
			foreach (var v in vertices)
			{
				v.Vertices = new List<Vertex>(v.places.Count());
				for (int i = 0; i < v.places.Count; i++)
				{
					try
					{
						if (!v.places[i].name.Equals(""))
							foreach (var vi in vertices.Where(vert => vert.Name.Equals(v.places[i].name)))
								v.Vertices.Add(vi);
					}
					catch (Exception e)
					{
						Debug.Log($"GRAPH CreateLink - Name {v.Name} Error{e}");
					}
				}
				yield return null;
			}
		}
	}
}