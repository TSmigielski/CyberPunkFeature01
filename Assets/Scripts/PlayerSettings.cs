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

	[SerializeField] float _mouseSensitivity;
	[SerializeField] float _gamepadSensitivity;
	[SerializeField] Color _crosshairColor;

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
	public Color CrosshairColor
	{
		get { return _crosshairColor; }
		private set { _crosshairColor = value; }
	}
}
