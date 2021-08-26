using System.Collections;
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
	public bool IsUsing { get; set; } = false;

	protected bool coIsRunning = false;

	private void Update()
	{
		if (IsUsing && !coIsRunning)
		{
			StartCoroutine(Use(0f));
		}
	}

	public virtual IEnumerator Use(float autoPause = 0f)
	{
		coIsRunning = true;
		while (IsUsing)
		{
			if (!IsReady)
			{
				coIsRunning = false;
				yield break;
			}

			yield return new WaitForSeconds(autoPause);
		}
		coIsRunning = false;
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
