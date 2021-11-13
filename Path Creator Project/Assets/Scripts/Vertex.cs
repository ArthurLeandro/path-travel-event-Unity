using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Travel
{

	[Serializable]
	public class Vertex
	{
		[SerializeField] Transform transform;
		[SerializeField] List<Vertex> vertices;
		public List<GameObject> places;
		[SerializeField] int m_weigth;
		[SerializeField] bool m_visited;
		[SerializeField] string name;

		public Transform Transform { get => transform; set => transform = value; }
		public int Weigth { get => m_weigth; set => m_weigth = value; }
		public bool Visited { get => m_visited; set => m_visited = value; }
		public List<Vertex> Vertices { get => vertices; set => vertices = value; }
		public string Name { get => name; set => name = value; }
	}
}