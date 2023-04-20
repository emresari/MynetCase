namespace Script.Pools.Factory {
	public interface IFactory<T> {
		T Create();
	}
}