using UnityEngine;
using UnityEngine.SceneManagement;

namespace Travel
{
	public class EventHandlerSceneLoad : MonoBehaviour, IHandler
	{
		string m_nameOfScene;
		public void ActUponEvent()
		{
			SceneManager.LoadScene(m_nameOfScene, LoadSceneMode.Additive);
		}
	}
}