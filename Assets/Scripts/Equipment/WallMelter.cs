using UnityEngine;

public class WallMelter : Gun
{
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float projectileSpeed;
	[SerializeField] float bulletDropForce;
	[SerializeField] float meltRadius;

	public override void Use()
	{
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
		if (target != Vector3.zero)
		{
			var projectile = Instantiate(projectilePrefab, ShootPoint);
			var projectileScript = projectile.GetComponent<WallMelter_ProjectileBehaviour>();
			projectileScript.Initialize(meltRadius);
			var dir = target - projectile.transform.position;
			projectileScript.RB.AddForce(dir.normalized * projectileSpeed, ForceMode.Impulse);
			projectileScript.BulletDrop = bulletDropForce;
			projectile.transform.SetParent(null);
			Destroy(projectile, 10);
		}
		else
		{
			var projectile = Instantiate(projectilePrefab, ShootPoint);
			var projectileScript = projectile.GetComponent<WallMelter_ProjectileBehaviour>();
			projectileScript.Initialize(meltRadius);
			projectileScript.RB.AddRelativeForce(projectileSpeed, 0, 0, ForceMode.Impulse);
			projectileScript.BulletDrop = bulletDropForce;
			projectile.transform.SetParent(null);
			Destroy(projectile, 10);
		}
	}
}
