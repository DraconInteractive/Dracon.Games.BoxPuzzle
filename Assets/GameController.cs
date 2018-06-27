using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public BoxTile[] allTiles;
    public GameObject tilePrefab, tileContainer;

    public enum PlacementType
    {
        Box,
        L,
        HorizFour,
        VertFour,
        HorizFive,
        VertFive,
        LCorner,
        RCorner,
        LTCorner,
        RTCorner,
        Point
    };

    public List<PlacementType> allPlacementTypes = new List<PlacementType>();

    public PlacementType currentPlacementType;
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        allTiles = new BoxTile[100];
        int x = 0;
        int y = 10;
        for (int i = 0; i < 100; i++)
        {
            allTiles[i] = Instantiate(tilePrefab, tileContainer.transform).GetComponent<BoxTile>();
            allTiles[i].pos = new Vector2(x, y);
            x++;
            if (x > 9)
            {
                x = 0;
                y--;
            }

            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetupPlacementEnum ()
    {
        allPlacementTypes.Add(PlacementType.Box);
        allPlacementTypes.Add(PlacementType.HorizFive);
        allPlacementTypes.Add(PlacementType.HorizFour);
        allPlacementTypes.Add(PlacementType.L);
        allPlacementTypes.Add(PlacementType.LCorner);
        allPlacementTypes.Add(PlacementType.RCorner);
        allPlacementTypes.Add(PlacementType.RTCorner);
        allPlacementTypes.Add(PlacementType.VertFive);
        allPlacementTypes.Add(PlacementType.VertFour);
        allPlacementTypes.Add(PlacementType.Point);
    }
    public void TileMEnter (BoxTile tile)
    {
        foreach (BoxTile t in allTiles)
        {
            t.tileImage.color = t.emptyColor;
        }

        List<BoxTile> selection = GetTileSelection(tile);
        bool validPlacement = true;
        foreach (BoxTile t in selection)
        {
            if (t == null)
            {
                validPlacement = false;
                break;
            }
        }
        foreach (BoxTile t in selection)
        {
            if (t == null)
            {
                continue;
            }
            
            if (validPlacement)
            {
                t.tileImage.color = Color.yellow;
            }
            else
            {
                t.tileImage.color = Color.red;
            }
        }
    }

    public List<BoxTile> GetTileSelection (BoxTile focus)
    {
        List<BoxTile> result = new List<BoxTile>();
        result.Add(focus);
        Vector2 focusPos = focus.pos;
        
        switch (currentPlacementType)
        {
            case PlacementType.Box:
                result.Add(GetTileFromCoord(focusPos + new Vector2(-1, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(-1, -1)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, -1)));
                break;
            case PlacementType.HorizFive:
                result.Add(GetTileFromCoord(focusPos + new Vector2(1, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(2, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(3, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(4, 0)));
                break;
            case PlacementType.HorizFour:
                result.Add(GetTileFromCoord(focusPos + new Vector2(1, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(2, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(3, 0)));
                break;
            case PlacementType.L:
                result.Add(GetTileFromCoord(focusPos + new Vector2(1, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(2, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 1)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 2)));
                break;
            case PlacementType.LCorner:
                result.Add(GetTileFromCoord(focusPos + new Vector2(1, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 1)));
                break;
            case PlacementType.LTCorner:
                result.Add(GetTileFromCoord(focusPos + new Vector2(1, 1)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 1)));
                break;
            case PlacementType.RCorner:
                result.Add(GetTileFromCoord(focusPos + new Vector2(-1, 0)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 1)));
                break;
            case PlacementType.RTCorner:
                result.Add(GetTileFromCoord(focusPos + new Vector2(-1, 1)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, -1)));
                break;
            case PlacementType.VertFive:
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 1)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 2)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 3)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 4)));
                break;
            case PlacementType.VertFour:
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 1)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 2)));
                result.Add(GetTileFromCoord(focusPos + new Vector2(0, 3)));
                break;
            case PlacementType.Point:
                //Leave blank
                break;
        }
        return result;
    }

    public BoxTile GetTileFromCoord (Vector2 c)
    {
        BoxTile result = null;
        foreach (BoxTile tile in allTiles)
        {
            if (tile.pos == c)
            {
                result = tile;
                break;
            }
        }

        return result;
    }
}
