using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackC : MonoBehaviour
{

    public Transform PlatformTransform;
    public Transform PlayerTransform;
    public GameObject Platform;
    public GameObject Flame1;
    public GameObject Flame2;
    
    public bool isRising;

    // Start is called before the first frame update
    void Start()
    {
        Platform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            StartCoroutine(JetpackUp());
        }

        if (Input.GetKeyUp("f"))
        {
            StartCoroutine(StopJetpack());
        }
    }

    IEnumerator JetpackUp()
    {
        isRising = true;
        Flame1.SetActive(true);
        Flame2.SetActive(true);
        Platform.transform.SetParent(PlatformTransform);
        PlatformTransform.GetComponent<Animator>().Play("Jetpack");
        Platform.SetActive(true);
        yield return new WaitForSeconds(0f);
    }

    IEnumerator StopJetpack()
    {
        isRising = false;
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        PlatformTransform.GetComponent<Animator>().Play("New State");
        Platform.transform.SetParent(PlayerTransform);
        yield return new WaitForSeconds(0.1f);
        Platform.SetActive(false);
        PlatformTransform.DetachChildren();
        yield return new WaitForSeconds(0f);
    }
}
