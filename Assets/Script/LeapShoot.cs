using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapShoot : MonoBehaviour
{
    #region Weapon Settings
    [Header("Weapon Settings")]
    public Transform m_muzzle;
    public GameObject m_shotPrefab;
    public GameObject reloadBar;
    private float counter;
    public AudioSource piupiu;
    public int bullet;
    public GameObject bulletCounter;
    public Text bulletCounterText;
    public string outOfBulletString = "|";
    public int reloadTime = 2;
    public float rateOfFire = 0.1f;
    public bool IsShooting = false;
    #endregion

    #region Button Settings
    [Header("Button Settings")]
//    public FingerButton Trigger;
    #endregion

    /*
    #region Hand Variables
    [Header("Hand Variables")]
    public Transform Forearm;
    public Vector3 LocalOffset;
    #endregion
    */


    [Header("Visibility Variables")]
    public bool Visible = true;

    void OnEnable()
    {
//        Trigger.ButtonActivated += Trigger_ButtonActivated;
        IsShooting = false;
        bulletCounterText = bulletCounter.GetComponent<Text>();
    }

    void OnDisable()
    {
//        Trigger.ButtonActivated -= Trigger_ButtonActivated;
        IsShooting = true;
    }

    void Start()
    {
        //transform.SetParent(Forearm);
        //transform.localPosition = LocalOffset;
        //bullet = 20;
        bulletCounterText = bulletCounter.GetComponent<Text>();
    }

//    void Trigger_ButtonActivated(FingerButton sender)
//    {
        /*
        if (bullet > 0)
        {

                GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
                GameObject.Destroy(go, 3f); //bullet is firing

                piupiu.GetComponent<AudioSource>().Play();

                bullet--;
                bulletCounterText.text = bullet.ToString();
            
            //Shoot();
        }
        else
        {
            bulletCounterText.text = "-";
            StartCoroutine(reloadBullet());
        }
        */
//    }

   public void Update()
    {
        bullet = int.Parse(bulletCounterText.text);
//        Shoot();
        Reloading();
    }

    public void Show()
    {
        Visible = true;
        SetButtonVisibility(Visible);
    }

    public void Hide()
    {
        Visible = false;
        SetButtonVisibility(Visible);
    }

    public void SetButtonVisibility(bool visible)
    {
//        Trigger.gameObject.SetActive(Visible);
    }

    
    public void Shoot()
    {
       
        if (bullet > 0 && !IsShooting)
        {
            IsShooting = true;
            //if(IsShooting == true)
            //{
                StartCoroutine(fireRate());

            //}
        }
        //else if (bullet <= 0 && IsShooting == false)
        //{
        //    IsShooting = false;
        //    bulletCounterText.text = "-";
        //    StartCoroutine(reloadBullet());
        //}
    }
    
    void Reloading()
    {
        if (bullet == 0)
        {
            reloadBar.SetActive(true);
            BarProgressing();

            if (reloadBar.GetComponent<Slider>().value == 1)
            {
                bullet = 20;
                bulletCounterText.text = bullet.ToString();

                if (bullet == 20)
                {
                    reloadBar.SetActive(false);
                    reloadBar.GetComponent<Slider>().value = 0;
                }
            }
        }

        else
        {
            reloadBar.SetActive(false);
            counter = 0;
        }

    }

    void BarProgressing()
    {
        if (Mathf.FloorToInt(counter) < reloadTime)
        {
            counter += 4 * Time.deltaTime;
            reloadBar.GetComponent<Slider>().value = counter / reloadTime;
        }
    }

    //private IEnumerator reloadBullet() //reloading bullet for 3 seconds
    //{

    //    for (int i = 0; i < reloadTime; i++) //looping for 3 seconds
    //    {
    //        IsShooting = false;
    //        yield return new WaitForSeconds(reloadTime);
    //        bulletCounterText.text += "-";
    //    }

    //    bullet = 20;
    //    bulletCounterText.text = bullet.ToString();
    //}

    private IEnumerator fireRate() 
    {
        if (IsShooting == true)
        {
            GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
            GameObject.Destroy(go, 3f); //bullet is firing

            piupiu.GetComponent<AudioSource>().Play();

            bullet--;
            bulletCounterText.text = bullet.ToString();
            yield return new WaitForSeconds(rateOfFire);
            IsShooting = false;
        }

            
    }
}
