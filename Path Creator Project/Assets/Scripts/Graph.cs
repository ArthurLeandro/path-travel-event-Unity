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
			List<List<Vertex>> paths = new List<List<Vertex>>();
			foreach (Vertex v in p_origin.Vertices)
			{
				List<Vertex> path = new List<Vertex>();
				path.Add(p_origin);
				DFS(v, p_destination, new List<Vertex>(), path, paths);
			}
			// foreach (List<Vertex> path in paths)
			// 	PrintListOfPaths(path, p_origin, p_destination);
			return paths.Where(p => p.Count > 0).OrderByDescending(p => p.Count).First();
		}

		public void DFS(Vertex p_origin, Vertex p_destination, List<Vertex> p_visited, List<Vertex> p_path, List<List<Vertex>> p_paths)
		{
			if (p_origin.Name.Equals(p_destination.Name))
			{
				p_path.Add(p_destination);
				p_paths.Add(p_path);
			}
			else
			{
				foreach (Vertex v in p_origin.Vertices)
				{
					if (!p_visited.Contains(p_origin))
					{
						p_path.Add(v);
						p_visited.Add(p_origin);
						DFS(v, p_destination, p_visited, p_path, p_paths);
					}
				}
			}
		}

		private void PrintListOfPaths(List<Vertex> p_path, Vertex p_origin, Vertex p_destination)
		{
#if UNITY_EDITOR
			Debug.Log("---------- Path	found ---------- ");
			Debug.Log($"Origin:{p_origin.Name}\nDestination:{p_destination.Name}");
			foreach (Vertex v in p_path)
				Debug.Log($"{v.Name}");
			Debug.Log("\n\n\n");
#endif
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