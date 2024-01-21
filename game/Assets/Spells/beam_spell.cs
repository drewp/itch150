using UnityEngine;


public class beam_spell : MonoBehaviour
{
    [SerializeField]
    private inventory inventory;
    [SerializeField]
    private kindling kindling;
    public GameObject projectileObj; // has a sprite and particle system
    [SerializeField]
    private float spell_speed = 60f;
    [SerializeField]
    Material mat;
    

    private int counter = 0;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && kindling.kindle > 0 && inventory.Meat > 0 && inventory.Root > 0 && inventory.Flower > 0)
        {
            FireBeam();
        }

        // cheat
        if (Input.GetKeyDown("v"))
        {
            kindling.kindle = 99;
            inventory.Meat = 1;
            inventory.Root = 1;
            inventory.Flower = 1;
            FireBeam();
        }
    }

    private void FireBeam()
    {
        kindling.burn(0.05f + inventory.Meat / 8);
        Color customColor = new Color(inventory.Root / 2, inventory.Meat / 2, inventory.Flower, 1.0f);
        if (inventory.Meat != 0f)
        {
            spell_speed = inventory.Root * 150 / inventory.Meat / 0.8f;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        Vector3 scl = new Vector3(inventory.Meat / 1.5f, inventory.Meat / 1.5f, 0f);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        float particleStartSize = inventory.Root / 2.2f / 2f;
        CreateBeamInstance(angle, scl, customColor, particleStartSize);
    }

    private void CreateBeamInstance(float angle, Vector3 scl, Color customColor, float particleStartSize) {
        GameObject beam = Instantiate(projectileObj, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        beam.name = "projectile" + (counter++);
        beam.GetComponent<Rigidbody2D>().AddForce(beam.transform.right * spell_speed);
        beam.transform.localScale = scl;

        var sprite = projectileObj.GetComponent<SpriteRenderer>();
        var partis = projectileObj.GetComponent<ParticleSystem>();
        sprite.color = customColor;
        var main = partis.main;
        main.startColor = customColor;
        main.startSize = particleStartSize;

    }
}
