using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject BaseSpell;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            // CastSpell(10, 100, 50, 1, 1000, new Color(256, 23, 43));
            //CastSpell(Random.Range(5, 30), Random.Range(50, 500), Random.Range(1, 10), Random.Range(1, 10), Random.Range(100, 1000), new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
            CastSpell(10, 30, 1, 2, 300, Color.red);
        }
    }
    void CastSpell(float Speed, float Damage, float ProjAmnt, float Size, float Lasts, Color Color)
    {
        Vector3 Mp = Input.mousePosition;
        Mp.z = 10f;
        Vector3 Op = Camera.main.WorldToScreenPoint(transform.position);
        Mp.x = Mp.x - Op.x;
        Mp.y = Mp.y - Op.y;
        float Angle = Mathf.Atan2(Mp.y, Mp.x) * Mathf.Rad2Deg;
        float add = 0;
        float offset = 0;
        if (ProjAmnt != 0)
        {
            add = Size * 1.5f;
            offset = transform.position.x - (add * (ProjAmnt / 2));
        } else
        {
            add = 0;
            offset = transform.position.x;
        }
        if (ProjAmnt <= 3)
        {
            for (int i = 0; i < ProjAmnt; i++)
            {
                GameObject obj = Instantiate(BaseSpell, new Vector3(offset, transform.position.x, -1), Quaternion.Euler(new Vector3(0, 0, Angle)));
                obj.transform.localScale = new Vector3(Size, Size, 1);
                obj.GetComponent<Projectile>().Damage = Damage;
                obj.GetComponent<Projectile>().TellDespawn = Lasts;
                obj.GetComponent<Projectile>().Speed = Speed;
                obj.GetComponent<SpriteRenderer>().color = Color;
                offset += add;
            }
        } else
        {
            float AngleStep = 360 / ProjAmnt;
            float BaseAngle = 0f;
            for(int i = 0; i < ProjAmnt; i++)
            {
                float ProjDirx = transform.position.x + Mathf.Sin((BaseAngle * Mathf.PI) / 180) * 5f;
                float ProjDiry = transform.position.y + Mathf.Cos((BaseAngle * Mathf.PI) / 180) * 5f;
                Vector2 ProjVec = new Vector2(ProjDirx, ProjDiry);
                Vector2 MoveDir = (ProjVec - (Vector2)transform.position).normalized * Speed;
                GameObject obj = Instantiate(BaseSpell, transform.position, Quaternion.identity);
                obj.transform.localScale = new Vector3(Size, Size, 1);
                obj.GetComponent<Projectile>().Damage = Damage;
                obj.GetComponent<Projectile>().TellDespawn = Lasts;
                obj.GetComponent<SpriteRenderer>().color = Color;
                obj.GetComponent<Projectile>().CircularMove = MoveDir;
                BaseAngle += AngleStep;
            }
        }
    }

}
