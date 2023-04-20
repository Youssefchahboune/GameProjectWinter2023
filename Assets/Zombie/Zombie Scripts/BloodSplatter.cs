using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{

    public ParticleSystem bloodSplatterParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        bloodSplatterParticleEffect = gameObject.GetComponent<ParticleSystem>();
        bloodSplatter();
    }

    private void DestroyIt()
    {
        Destroy(gameObject);
    }

    public void bloodSplatter()
    {
        bloodSplatterParticleEffect.Play();
        Invoke("DestroyIt",1f);
    }
}
