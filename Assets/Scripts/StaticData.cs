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

	[SerializeField] private LayerMask layerMask;
	public LayerMask GroundLayer
	{
		get { return layerMask; }
	}

}
