using UnityEngine;

public class WallMelter : Gun
{
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float projectileSpeed;
	[SerializeField] float bulletDropForce;
	[SerializeField] float meltRadius;

	public override void Use()
	{
		if (!IsReady)
			return;

		RaycastHit hit;
		if (Physics.Raycast(mainCam.position, mainCam.transform.forward, out hit))
		{
			CustomShoot(hit.point);
		}
		else
			CustomShoot(Vector3.zero);
	}

	private void CustomShoot(Vector3 target)
	{
		if (Magazine <= 0)
			return;

		Magazine--;
		ShootPoint.Play();
		Animator.SetTrigger("Fired");
		UI_Handler.Instance.UpdateAmmo(Magazine, Reserves);

		var projectile = Instantiate(projectilePrefab, ShootPoint.transform);
		var projectileScript = projectile.GetComponent<WallMelter_ProjectileBehaviour>();
		projectileScript.Initialize(meltRadius);

		if (target != Vector3.zero)
		{
			var dir = target - projectile.transform.position;
			projectileScript.RB.AddForce(dir.normalized * projectileSpeed, ForceMode.Impulse);
		}
		else
			projectileScript.RB.AddRelativeForce(projectileSpeed, 0, 0, ForceMode.Impulse);

		projectileScript.BulletDrop = bulletDropForce;
		projectile.transform.SetParent(null);
		Destroy(projectile, 10);
	}
}
