using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Handler : MonoBehaviour
{
	public static UI_Handler Instance { get; private set; }

	[Header("Cross Hair")]
	[SerializeField] Image[] crosshairElements;

	[Header("Hack Mode")]
	[SerializeField] GameObject hackModeIndicator;
	[SerializeField] [TextArea(2, 3)] string hackModeOnText, hackModeOffText;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	private void Start()
	{
		ChangeCrosshair();
	}

	public void HackModeOn()
	{
		var txt = hackModeIndicator.GetComponentInChildren<TextMeshProUGUI>();
		txt.text = hackModeOnText;
	}

	public void HackModeOff()
	{
		var txt = hackModeIndicator.GetComponentInChildren<TextMeshProUGUI>();
		txt.text = hackModeOffText;
	}

	public void ChangeCrosshair()
	{
		foreach (var item in crosshairElements)
		{
			item.color = PlayerSettings.Instance.CrosshairColor;
		}
	}
}
