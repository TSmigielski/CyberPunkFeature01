using UnityEngine;

public class Gun : Equipment
{
	[SerializeField] private Transform _shootPoint;

	static protected Transform mainCam;

	private void Awake()
	{
		if (mainCam == null)
			mainCam = Camera.main.transform;
	}

	public Transform ShootPoint
	{
		get { return _shootPoint; }
		private set { _shootPoint = value; }
	}

	public override void Use()
	{
		base.Use();
	}

	protected virtual void Shoot()
	{

	}
}
