using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy :MonoBehaviour
{
    public Transform target;
    private float moveSpeed = 1f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        Chase(target, moveSpeed);
    }
    public enum Color
    {
        RED,
        BLUE
    }
    public string getColorCode(Color color)
    {
        string colorCode;
        switch (color)
        {
            case Color.BLUE:
                colorCode = "FF0000" ;
                return colorCode;
            case Color.RED:
                colorCode = "2626FF";
                return colorCode;
        }
        return "FFFFFF";
    }
    public void Chase(Transform target, float moveSpeed)
    {
        Vector3 difference = target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
