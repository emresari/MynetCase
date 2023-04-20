using UnityEngine;

namespace Script.Pools.Factory {
	public class MonoBehaviourFactory<T> : IFactory<T> where T : MonoBehaviour {

		private GameObject _prefab;
		private readonly string _name;
		private int _index;

		public MonoBehaviourFactory() : this("GameObject") { }

		public MonoBehaviourFactory(string name) {
			this._name = name;
		}

		public T Create() {
			GameObject tempGameObject = GameObject.Instantiate(new GameObject()) as GameObject;
			tempGameObject.name = _name + _index.ToString();
			tempGameObject.AddComponent<T>();
			T objectOfType = tempGameObject.GetComponent<T>();
			_index++;
			return objectOfType;
		}
	}
}