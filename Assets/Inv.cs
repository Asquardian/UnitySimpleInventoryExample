using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inv : MonoBehaviour
{

    private ArrayList ID;
    public Text invText;

    public void AddItem(int idItem)
    {
        ID.Add(idItem);
    }
    public string ItemtoString(int idInv)
    {
        switch ((int)ID[idInv])
        {
            case 0:
                return "Heal";
            case 1:
                return "Unheal";
        }
        return "Empty";
    }
    public int use(int idInventory)
    {
        if (ID.Count > idInventory)
        {
            int idElement = (int)ID[idInventory];
            ID.RemoveAt(idInventory);
            return idElement;
        }
        return -1;
    }
    public int GetSizeOf()
    {
        return (int)ID.Count;
    }
    public void TextUpdate()
    {
        invText.text = "";
        if (GetSizeOf() > 0)
        {
            for (int i = 0; i < GetSizeOf(); i++)
                invText.text += ItemtoString(i) + ' ';
        }
        else
        {
            invText.text = "Empty";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ID = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
