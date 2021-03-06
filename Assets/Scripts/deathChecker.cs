﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathChecker : MonoBehaviour {

    public AudioSource deathSound;

    public GameObject landerShip;
    public bool dead;
    public bool disableShip;

    public GameObject deathOverlay;

    public EdgeCollider2D landersh;

    public Animator landerShipAnim;
	private timerDisplay time;

    private void Start()
    {
        deathOverlay = GameObject.Find("deathChecker");
    }

    // Update is called once per frame
    void Update() {
        if (disableShip == true)
        {
            landerShip.SetActive(false);
			 
        }
		if (time.timer <= 0) {
			dead = true;
		}

        if (dead == true)
        {
            StartCoroutine(animationPlayer());
        }
    }

    IEnumerator animationPlayer()
    {
        deathSound.Play();

        landerShipAnim.SetBool("Dead", true);

        landersh.enabled = false;

        yield return new WaitForSeconds(0.2f);

        disableShip = true;

        deathSound.Stop();
    }
}
