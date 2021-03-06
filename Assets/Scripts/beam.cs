﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    public GameObject beamObject;
    public GameObject pie;
    public bool canShoot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color collisionColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        Color pieColor = pie.gameObject.GetComponent<SpriteRenderer>().color;
        if (collision.tag == "Enemy" && ColorUtility.ToHtmlStringRGB(collisionColor).Equals(ColorUtility.ToHtmlStringRGB(pieColor)))
        {
            changeBeamOpacity(1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            changeBeamOpacity(0.3f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && collision.gameObject.GetComponent<SpriteRenderer>().color == pie.gameObject.GetComponent<SpriteRenderer>().color)
        {
            changeBeamOpacity(1f);
            GetComponent<Gun>().Shooting(collision.gameObject);
        }
    }
    void changeBeamOpacity(float value)
    {
        Color tmp = beamObject.GetComponent<SpriteRenderer>().color;
        tmp.a = value;
        beamObject.GetComponent<SpriteRenderer>().color = tmp;
    }
}
