using UnityEngine;

public class StaticData : MonoBehaviour
{
	public static StaticData Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	[SerializeField] private LayerMask _groundLayer;
	[SerializeField] private LayerMask _enemyLayer;

	public LayerMask GroundLayer
	{
		get { return _groundLayer; }
	}
	public LayerMask EnemyLayer
	{
		get { return _enemyLayer; }
	}
}
