using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundModulation : MonoBehaviour
{
    [Header("Objects requirement")]
    [SerializeField] public GameObject soundSphere;
    [SerializeField] public Animator anim;
    [SerializeField] SphereCollider sphere;
    [Space]
    [Header("Raycast requirement")]
    [Tooltip("Necesario para que la esfera este siempre a nivel del suelo")]
    [SerializeField] Transform player;
    [SerializeField] float compensation;
    public bool noSoundHere;
    RaycastHit hit;
    Ray ray;
    [Space]
    [Header("Bool States")]
    [Tooltip("Booleanos que determinan el nivel de ruido y se resetean siempre a cero")]
    [SerializeField] public bool low, medium, high, cero;
    void Awake()
    {
        sphere.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (noSoundHere) { soundSphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); }
        else
        {
            SpeedMovements();
            BoolSpeeds();
            if (Physics.Raycast(player.position, Vector3.down, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.blue);
                soundSphere.transform.position = new Vector3(transform.position.x, hit.transform.position.y + compensation, transform.position.z);
            }
        }


    }
    public void IsSneak(bool sneaking)
    {
        if (sneaking) noSoundHere = sneaking;

    }
    void SpeedMovements()
    {
        if (anim.GetFloat("Vertical") > 2f) high = true;
        if (anim.GetFloat("Vertical") > 1.1f && anim.GetFloat("Vertical") < 2) medium = true;
        if (anim.GetFloat("Vertical") > 0 && anim.GetFloat("Vertical") < 1.1f) low = true;
        if (anim.GetFloat("Vertical") == 0) cero = true;
    }
    void BoolSpeeds()
    {
        if (cero) soundSphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        if (low) StartCoroutine("LowSound");
        if (medium) StartCoroutine("MediumSound");
        if (high) StartCoroutine("HighSound");

    }
    IEnumerator LowSound()
    {
        cero = false;
        soundSphere.transform.localScale = new Vector3(0.5f, 0.01f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        cero = true;
        low = false;
    }
    IEnumerator MediumSound()
    {
        cero = false;
        soundSphere.transform.localScale = new Vector3(2, 0.01f, 2);
        yield return new WaitForSeconds(0.2f);
        cero = true;
        medium = false;
    }
    IEnumerator HighSound()
    {
        cero = false;
        soundSphere.transform.localScale = new Vector3(4, 0.01f, 4);
        yield return new WaitForSeconds(0.2f);
        cero = true;
        high = false;
    }
}
