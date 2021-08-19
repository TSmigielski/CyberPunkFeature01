using UnityEngine;

public class Equipment : MonoBehaviour
{
	[SerializeField] private EquipmentData _eqData;

	public EquipmentData EQData
	{
		get { return _eqData; }
		private set { _eqData = value; }
	}

	public virtual void Use()
	{
		
	}
}
