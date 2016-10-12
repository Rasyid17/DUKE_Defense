using UnityEngine;
using System.Collections;
using VRTK;
using UnityEngine.UI;

public class Gun_DUKE : VRTK_InteractableObject
{
	private GameObject bullet;
	public GameObject shot;
	public float bulletCount;
	public TextMesh bulletNum;
	private AudioSource gunSFX;
	public float counter;
	public float reloadTime;
	public GameObject reloadBar;
    private float bulletSpeed = 3000f;
    private float bulletLife = 5f;

	[SerializeField]
	GameObject resetObject, muzzleF;

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

				if(reloadBar.GetComponent<Scrollbar>().size >= 1)
				{
					reloadBar.SetActive (false);
					bulletCount = 10;
					counter = 0;
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
			muzzleF.SetActive (true);
			bulletCount--;
			StartCoroutine(FlashCooldown());
		}
			
    }

	IEnumerator FlashCooldown()
	{
		yield return new WaitForSeconds (0.4f);
		muzzleF.SetActive (false);
	}

	public override void Ungrabbed(GameObject currentTouchingObject) {
		base.Ungrabbed (currentTouchingObject);

		gameObject.transform.position = resetObject.GetComponent<Transform> ().position;
		gameObject.transform.rotation = resetObject.GetComponent<Transform> ().rotation;
	}

//	void OnTriggerEnter(Collider hit)
//	{
//		if(hit.gameObject.tag == "Untagged")
//		{
//			gameObject.GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", Color.green);
//
//		}
//	}
//
//	void OnTriggerExit(Collider hit)
//	{
//		if(hit.gameObject.tag == "Untagged")
//		{
//			gameObject.GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", Color.black);
//
//		}
//	}
}