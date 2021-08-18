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
	[SerializeField] private float _gamepadSensitivity;

	public float MouseSensitivity
	{
		get { return _mouseSensitivity; }
		private set { _mouseSensitivity = value; }
	}
	public float GamepadSensitivity
	{
		get { return _gamepadSensitivity; }
		private set { _gamepadSensitivity = value; }
	}
}
