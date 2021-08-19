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

	[Header("Tags")]
	[SerializeField] private string _destructableTag_Wall;
	[Header("Layers")]
	[SerializeField] private LayerMask _groundLayer;
	[SerializeField] private LayerMask _playerLayer;
	[SerializeField] private LayerMask _enemyLayer;

	public string DestructableTag_Wall
	{
		get { return _destructableTag_Wall; }
	}
	public LayerMask GroundLayer
	{
		get { return _groundLayer; }
	}
	public LayerMask PlayerLayer
	{
		get { return _playerLayer; }
	}
	public LayerMask EnemyLayer
	{
		get { return _enemyLayer; }
	}
}
