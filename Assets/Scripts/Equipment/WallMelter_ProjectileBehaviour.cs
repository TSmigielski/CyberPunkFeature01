using UnityEngine;

public class WallMelter_ProjectileBehaviour : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	public Rigidbody RB
	{
		get { return _rb; }
		private set { _rb = value; }
	}

	public float BulletDrop { get; set; }

	float meltRadius;

	public void Initialize(float _meltRadius)
	{
		meltRadius = _meltRadius;
		RB.useGravity = false;
	}

	private void Update()
	{
		if (RB != null)
			RB.AddForce(0, BulletDrop * Time.deltaTime, 0, ForceMode.VelocityChange);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(RB);
		var colliders = Physics.OverlapSphere(transform.position, meltRadius);

		foreach (var cl in colliders)
		{
			if (cl.CompareTag(StaticData.Instance.DestructableTag_Wall))
				Destroy(cl.gameObject);
		}
		Destroy(gameObject);
	}
}
