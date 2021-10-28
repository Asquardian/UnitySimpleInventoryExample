using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private int hp = 100;
    public Text gui;
    private Inv Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = FindObjectOfType<Inv>();
        TextUpdate();
        Inventory.TextUpdate();
    }
    void TextUpdate()
    {
        gui.text = "Health: " + hp.ToString();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Heal") {
            Inventory.AddItem(0);
            TextUpdate();
            Inventory.TextUpdate();
            Destroy(collision.gameObject, 0f);
            return;
        }
        if (collision.gameObject.tag == "Unheal")
        {
            Inventory.AddItem(1);
            TextUpdate();
            Inventory.TextUpdate();
            Destroy(collision.gameObject, 0f);
            return;
        }
    }

    void use(int i)
    {
        switch (i)
        {
            case 0:
                hp += 10; //Heal
                break;
            case 1:
                hp -= 10; //Unheal
                break;
            default:
                break;
        }
        TextUpdate();
        Inventory.TextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        { 
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown("1"))
        {
            use(Inventory.use(0));
            Inventory.TextUpdate();
        }
        if (Input.GetKeyDown("2"))
        {
            use(Inventory.use(1));
            Inventory.TextUpdate();
        }
    }
}
