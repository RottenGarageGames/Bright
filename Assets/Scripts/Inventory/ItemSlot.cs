using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }
    [SerializeField] Image image;
    [SerializeField] Text amountText;

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            amountText.enabled = _item != null && _item.MaximumStacks > 1 && _amount > 1;
            if(amountText.enabled)
            {
                amountText.text = _amount.ToString();
            }
        }
    }

    private void OnValidate()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }

        if(amountText == null)
        {
            amountText = GetComponentInChildren<Text>();
        }
    }
}
