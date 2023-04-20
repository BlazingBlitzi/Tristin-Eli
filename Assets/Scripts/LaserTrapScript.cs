using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrapScript : MonoBehaviour
{
    public float warningTime = 5f;
    public float laserTime = 2f;
    public float repeatTime = 5f;
    public GameObject warningCircle;
    public GameObject badCircle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Laser());
    }

    private IEnumerator Laser()
    {
        yield return new WaitForSeconds(repeatTime);

        warningCircle.SetActive(true);

        yield return new WaitForSeconds(warningTime);

        warningCircle.SetActive(false);
        badCircle.SetActive(true);

        yield return new WaitForSeconds(laserTime);

        badCircle.SetActive(false);
        StartCoroutine(Laser());
    }
    
}
