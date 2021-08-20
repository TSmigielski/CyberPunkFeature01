using UnityEngine;

public class Equipment : MonoBehaviour
{
	[SerializeField] private EquipmentData _eqData;
	[SerializeField] private Animator _animator;

	public EquipmentData EQData
	{
		get { return _eqData; }
		private set { _eqData = value; }
	}

	public Animator Animator
	{
		get { return _animator; }
		private set { _animator = value; }
	}

	public bool IsReady { get; protected set; } = true;

	public virtual void Use()
	{
		if (!IsReady)
			return;
	}

	public virtual void MakeReady()
	{
		IsReady = true;
	}

	public virtual void MakeNotReady()
	{
		IsReady = false;
	}
}
