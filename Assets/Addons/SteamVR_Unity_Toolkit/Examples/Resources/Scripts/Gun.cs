using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class Gun : VRTK_InteractableObject
{
	
    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        FireBullet();
    }

    protected override void Start()
	{
		base.Start ();
	}

	void Update()
	{
		
	}

    private void FireBullet()
    {
			
	}
			
}