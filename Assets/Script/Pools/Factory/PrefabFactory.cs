using UnityEngine;

namespace Script.Pools.Factory {
	public class PrefabFactory<T> : IFactory<T> where T : MonoBehaviour {

		private readonly GameObject _prefab;
		private readonly string _name;
		private int _index;
		private readonly GameObject _parent;

		public PrefabFactory(GameObject prefab) : this(prefab, prefab.name) { }

		private PrefabFactory(GameObject prefab, string name) {
			this._prefab = prefab;
			this._name = name;
			_parent = new GameObject
			{
				name = $"{this._prefab.name}Pool"
			};
		}

		public T Create() {
			GameObject tempGameObject = GameObject.Instantiate(_prefab, _parent.transform, true);
			tempGameObject.name = _name + _index.ToString();
			T objectOfType = tempGameObject.GetComponent<T>();
			_index++;
			return objectOfType;
		}
	}
}