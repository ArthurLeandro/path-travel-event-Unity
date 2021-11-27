using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Examples;

namespace Travel
{
	public class TravelSystem : MonoBehaviour
	{
		[SerializeField] Graph graph;
		[SerializeField] GameObject m_prefabFollower;
		[SerializeField] GameObject m_prefabPath;

		[SerializeField] int o = -1;
		[SerializeField] int t = -1;

		PathFollower m_follower;
		GeneratePathExample m_generated;
		PathCreator m_creator;
		GameObject followerObj;
		private void Start()
		{
			CreateLink();
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}

		void Awake()
		{
			Instantiate(m_prefabPath, Vector3.zero, Quaternion.identity);
			followerObj = Instantiate(m_prefabFollower, Vector3.zero, Quaternion.identity);
			m_follower = m_prefabFollower.GetComponent<PathFollower>();
			m_generated = m_prefabPath.GetComponent<GeneratePathExample>();
			m_creator = m_prefabPath.GetComponent<PathCreator>();
			m_generated.waypoints = new Transform[0];
			TravelSystemEvents.OnFinishingLinks += (() => Travel());
		}

		public void CreateLink()
		{
			TravelSystemEvents.CallOnCreateLinks();
			graph.CreateLink();
			TravelSystemEvents.CallOnFinishingLinks();
		}

		private void Travel()
		{
			if (o < 0)
				o = UnityEngine.Random.Range(0, 38);
			if (t < 0)
				t = UnityEngine.Random.Range(0, 38);
			if (o != t)
				SearchPath(graph.vertices[o], graph.vertices[t]);
			// List<Vertex> vertex = SearchPath(graph.vertices[o], graph.vertices[t]);
			// m_follower.pathCreator = m_creator;
			// Transform[] tarr = vertex.Select(v => v.Transform).ToArray();
			// followerObj.transform.position = tarr[0].position;
			// m_generated.waypoints = tarr;
			// BezierPath bezierPath = new BezierPath(tarr, false, PathSpace.xyz);
			// m_creator.bezierPath = bezierPath;
		}

		public List<Vertex> SearchPath(Vertex p_origin, Vertex p_destination)
		{
			return graph.Search(p_origin, p_destination);
		}
	}
}