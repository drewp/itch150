using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spell : MonoBehaviour
{
    public GameObject BaseSpell;
    void Start()
    {

    }
    void Update()
    {
        // CastSpell(10, 100, 50, 1, 1000, new Color(256, 23, 43));
        //CastSpell(Random.Range(5, 30), Random.Range(50, 500), Random.Range(1, 10), Random.Range(1, 10), Random.Range(100, 1000), new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
        if (Input.GetMouseButtonUp(0))
        {
            CastSpell(10, 30, 1, 2, 300, Color.red, 0.5f, 2, 1, 0.4f);
        }
    }
    void CastSpell(float Speed, float Damage, float ProjAmnt, float Size, float Lasts, Color Color, float InnerRad, float OuterRad, float Intenstity, float FallOff)
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
                GameObject obj = Instantiate(BaseSpell, new Vector3(offset, transform.position.x, -6), Quaternion.Euler(new Vector3(0, 0, Angle)));
                obj.transform.localScale = new Vector3(Size, Size, 1);
                obj.GetComponent<Projectile>().Damage = Damage;
                obj.GetComponent<Projectile>().TellDespawn = Lasts;
                obj.GetComponent<Projectile>().Speed = Speed;
                obj.GetComponent<SpriteRenderer>().color = Color;
                obj.GetComponent<Light2D>().intensity = Intenstity;
                obj.GetComponent<Light2D>().pointLightInnerRadius = InnerRad;
                obj.GetComponent<Light2D>().pointLightOuterRadius = OuterRad;
                obj.GetComponent<Light2D>().falloffIntensity = FallOff;
                obj.GetComponent<Light2D>().color = Color;
                obj.GetComponentInChildren<Transform>().localScale = new Vector3(Size * 0.5f, Size * 0.5f, 1);
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
                GameObject obj = Instantiate(BaseSpell, new Vector3(transform.position.x, transform.position.y, -6), Quaternion.identity);
                obj.transform.localScale = new Vector3(Size, Size, 1);
                obj.GetComponent<Projectile>().Damage = Damage;
                obj.GetComponent<Projectile>().TellDespawn = Lasts;
                obj.GetComponent<SpriteRenderer>().color = Color;
                obj.GetComponent<Projectile>().CircularMove = MoveDir;
                obj.GetComponent<Light2D>().intensity = Intenstity;
                obj.GetComponent<Light2D>().pointLightInnerRadius = InnerRad;
                obj.GetComponent<Light2D>().pointLightOuterRadius = OuterRad;
                obj.GetComponent<Light2D>().falloffIntensity = FallOff;
                obj.GetComponent<Light2D>().color = Color;
                obj.GetComponentInChildren<Transform>().localScale = new Vector3(Size * 0.5f, Size * 0.5f, 1);
                BaseAngle += AngleStep;
            }
        }
    }

}
