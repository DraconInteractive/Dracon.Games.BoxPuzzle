using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoxTile : MonoBehaviour, IPointerEnterHandler {
    GameController controller;

    private bool filled;

    public Color emptyColor, filledColor;

    [HideInInspector]
    public Image tileImage;

    public Vector2 pos;

    public bool Filled
    {
        get
        {
            return filled;
        }

        set
        {
            filled = value;
            if (value)
            {
                tileImage.color = filledColor;
            }
            else
            {
                tileImage.color = emptyColor;
            }
        }
    }

    // Use this for initialization
    void Start () {
        controller = GameController.instance;

        tileImage = GetComponent<Image>();
        Filled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        controller.TileMEnter(this);
    }
}
