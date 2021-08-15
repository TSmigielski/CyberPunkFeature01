using TMPro;
using UnityEngine;

public class UI_Handler : MonoBehaviour
{
	public static UI_Handler Instance { get; private set; }

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
}
