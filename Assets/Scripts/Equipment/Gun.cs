using UnityEngine;
using UnityEngine.VFX;

public class Gun : Equipment
{
	protected GunData gunData;

	[SerializeField] private VisualEffect _shootPoint;

	static protected Transform mainCam;

	public int Magazine { get; protected set; }
	public int Reserves { get; protected set; }

	private void Awake()
	{
		gunData = EQData as GunData;

		if (mainCam == null)
			mainCam = Camera.main.transform;

		Magazine = gunData.magazineSize;
		Reserves = gunData.reserveAmmo;
	}

	private void OnEnable()
	{
		UI_Handler.Instance.UpdateAmmo(Magazine, Reserves);
	}

	public VisualEffect ShootPoint
	{
		get { return _shootPoint; }
		private set { _shootPoint = value; }
	}

	public override void Use()
	{
		if (!IsReady)
			return;

		Shoot();
	}

	private void Shoot()
	{
		if (Magazine > 0)
		{
			Magazine--;
			ShootPoint.Play();
			Animator.SetTrigger("Fired");
			UI_Handler.Instance.UpdateAmmo(Magazine, Reserves);
		}
	}

	public virtual void Reload()
	{
		if (Magazine < gunData.magazineSize)
			Animator.SetTrigger("Reload"); //Animation handles readiness
	}

	protected virtual void MagazineIn() //Animation calls this method
	{
		if (Reserves >= gunData.magazineSize)
		{
			Magazine = gunData.magazineSize;
			Reserves -= gunData.magazineSize;
		}
		else if (Reserves > 0)
		{
			Magazine = Reserves;
			Reserves = 0;
		}
		else
		{
			//todo you're out of ammo
		}
		UI_Handler.Instance.UpdateAmmo(Magazine, Reserves);
	}

	public void ResetReloadTrigger()
	{
		Animator.ResetTrigger("Reload");
	}
}
