using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy :MonoBehaviour
{
    public Transform explosion;
    public Transform target;
    private float moveSpeed = 1f;

    private void Start()
    {
        setEmission(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if(Vector2.Distance(target.position,transform.position) < 20f)
        {
            Chase(target, moveSpeed);
        }
       
    }
    public void Chase(Transform target, float moveSpeed)
    {
        Vector3 difference = target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            StartCoroutine( Death());
        }
    }
    IEnumerator Death()
    {
        makeTransparent();
        setEmission(true);
        yield return new WaitForSeconds(2f);
        setEmission(false);
        Destroy(gameObject);
    }
    public void setEmission(bool emit)
    {
        var em = explosion.GetComponent<ParticleSystem>().emission;
        em.enabled = emit;
    }
    public void makeTransparent()
    {
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }
}
