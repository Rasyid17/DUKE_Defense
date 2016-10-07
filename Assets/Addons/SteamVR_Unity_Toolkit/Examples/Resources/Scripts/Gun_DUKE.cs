using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class Gun_DUKE : VRTK_InteractableObject
{
	private GameObject bullet;
	public GameObject shot;
	public float bulletCount = 60;
	public TextMesh bulletNum;
	private AudioSource gunSFX;
	public float counter;
	public float reloadTime;
	public GameObject reloadBar;
    private float bulletSpeed = 3000f;
    private float bulletLife = 5f;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        FireBullet();
    }

    protected override void Start()
	{
		base.Start ();
		bullet = transform.Find ("Bullet").gameObject;
		bullet.SetActive (false);
		gunSFX = gameObject.GetComponent<AudioSource> ();

	}

	void Update()
	{
		bulletNum.text = bulletCount.ToString ();

		if(bulletCount <= 0)
		{
			//			bulletCount = 60;
			reloadBar.SetActive (true);

			if (Mathf.FloorToInt(counter) < reloadTime)
			{
				counter += 4 * Time.deltaTime;
				reloadBar.GetComponent<Scrollbar>().size = counter / reloadTime;

				if(reloadBar.GetComponent<Scrollbar>().size == 1)
				{
					reloadBar.SetActive (false);
					bulletCount = 60;
				}
			}
		}
	}

    private void FireBullet()
    {
		if(bulletCount  >= 1)
		{
			GameObject bulletClone = Instantiate(shot, bullet.transform.position, bullet.transform.rotation) as GameObject;
			bulletClone.SetActive(true);
			//        Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
			//        rb.AddForce(-bullet.transform.forward * bulletSpeed);
			Destroy(bulletClone, bulletLife);
			gunSFX.Play ();
			bulletCount--;
		}
			
    }
}