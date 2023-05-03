using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    // A reference to the particle system that creates the blood splatter effect
    public ParticleSystem bloodSplatterParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Get the ParticleSystem component attached to the game object
        bloodSplatterParticleEffect = gameObject.GetComponent<ParticleSystem>();

        // Call the bloodSplatter method to create the particle effect
        bloodSplatter();
    }

    // Destroy the game object after 1 second
    private void DestroyIt()
    {
        Destroy(gameObject);
    }

    // Plays the blood splatter particle effect and destroys the game object after 1 second
    public void bloodSplatter()
    {
        // Play the particle system to create the blood splatter effect
        bloodSplatterParticleEffect.Play();

        // Wait 1 second and then destroy the game object
        Invoke("DestroyIt", 1f);
    }
}
