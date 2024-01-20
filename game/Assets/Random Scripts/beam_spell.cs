using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

class makebeam
{
    public float root, meat, flower = 0;
    
    
    public void make(float x, float y, float z)
    {
        meat = x;
        root = y;
        flower = z;



        //root = Random.Range(0f, 2.0f);
        //flower = Random.Range(0f, 2.0f);
        //meat = Random.Range(0f, 2.0f);

       
    }
}
public class beam_spell : MonoBehaviour
{
    [SerializeField]
    private inventory inventory;
    [SerializeField]
    private kindling kindling;
    public GameObject projectileObj;
    private Rigidbody projectileRb;
    [SerializeField]
    private float spell_speed = 60f;
    [SerializeField]
    Material mat;
    [SerializeField]
    SpriteRenderer sr;
    [SerializeField]
    ParticleSystem Particles;

    makebeam spell = new makebeam();

    // Start is called before the first frame update
    void Start()
    {
        
        projectileRb = projectileObj.GetComponent<Rigidbody>();
        
    }
    

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && kindling.kindle > 0 && inventory.Root > 0 && inventory.Meat > 0 && inventory.Flower > 0)
        {
            



            kindling.burn(0.05f + inventory.Meat / 8);

            Color customColor = new Color(inventory.Root/2, inventory.Meat/2, inventory.Flower, 1.0f);
            //mat.SetColor("_Color", customColor);
            sr.color = customColor;
            var main = Particles.main;
            main.startSize = inventory.Root/2.2f;
            projectileObj.transform.localScale = new Vector3(inventory.Meat/1.5f, inventory.Meat/1.5f, 0f);
            if (inventory.Meat != 0f)
            {
                spell_speed = inventory.Flower * 150 / inventory.Meat / 0.8f;
            }
            


            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Rigidbody beam;
            beam = Instantiate(projectileRb, transform.position, Quaternion.Euler(new Vector3(0, 0, angle))) as Rigidbody;



            beam.AddForce(beam.transform.right * spell_speed);
        }
    }
}
