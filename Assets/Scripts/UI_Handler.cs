using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Handler : MonoBehaviour
{
	public static UI_Handler Instance { get; private set; }

	[Header("Inventory")]
	[SerializeField] GameObject slotPrefab;
	[SerializeField] Transform slotsParent;
	List<UI_EQSlot> currentSlots;
	[SerializeField] TextMeshProUGUI ammo;

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

	public void InitializeEquipment(Equipment[] playerEquipment)
	{
		if (currentSlots != null)
			foreach (var slot in currentSlots)
				Destroy(slot.gameObject);

		currentSlots = new List<UI_EQSlot>();

		for (int i = 0; i < playerEquipment.Length; i++)
		{
			var slot = Instantiate(slotPrefab, slotsParent);
			var script = slot.GetComponent<UI_EQSlot>();
			script.mainText.text = playerEquipment[i].EQData.itemName;
			script.index.text = (i + 1).ToString();
			currentSlots.Add(script);
		}
	}

	public void SelectEquipment(int index)
	{
		foreach (var slot in currentSlots)
			slot.image.color = slot.normalColor;

		if (index == 0)
		{
			ammo.gameObject.SetActive(false);
			return;
		}

		ammo.gameObject.SetActive(true);

		currentSlots[index - 1].image.color = currentSlots[index - 1].selectedColor;
	}

	public void UpdateAmmo(int magazine, int reserve)
	{
		ammo.text = $"{magazine} / {reserve}";
	}
}
