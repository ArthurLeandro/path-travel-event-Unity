using UnityEngine;
using UnityEngine.Events;

namespace Travel
{
	[CreateAssetMenu(menuName = "Travel/Events")]
	public class Event : ScriptableObject
	{
		[SerializeField] UnityEvent m_event;
		[SerializeField] float m_probability;
	}
}