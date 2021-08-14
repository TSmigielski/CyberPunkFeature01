using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
	public static PlayerSettings Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	[SerializeField] private float _mouseSensitivity;

	public float MouseSensitivity
	{
		get { return _mouseSensitivity; }
		set { _mouseSensitivity = value; }
	}
}
