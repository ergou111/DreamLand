using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public new void Update()
    {
        //调用父类的Update()方法
        base.Update();

        Filp();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

    void Filp()
    {
        if (transform.position.x < movePos.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

}
