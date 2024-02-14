using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUIController : MonoBehaviour
{
    //Level Controller
    private LevelController lvlController;

    //Controls the visual feedback for power and the power bar
    [SerializeField] PowerBarUI powerbar;
    [SerializeField] RawImage face;
    [SerializeField] RawImage HUD;
    //Gameplay Vars
    private int startingPower = 10;
    private int currentPower = 10;

    //DebugVars
    public bool debug = true;
    public int debugVar1 = 0;

    private enum state
    {
        low,
        medium,
        high,
    }

    state _current = state.high;
    private string keyword = "high";

    //Getting Each Version of the UI
    private Sprite[] _BaseSprites;
    private Sprite[] _FaceSprites;
    private Sprite[] _BarUpSprites;
    private Sprite[] _BarDownSprites;

    private void Awake()
    {
        lvlController = GameObject.FindGameObjectWithTag("LVLcontroller").GetComponent<LevelController>();
        _BaseSprites = Resources.LoadAll<Sprite>("UI/PowerUI/HUDsprites");
        _FaceSprites = Resources.LoadAll<Sprite>("UI/PowerUI/FaceSprites");
        _BarUpSprites = Resources.LoadAll<Sprite>("UI/PowerUI/PowerUp");
        _BarDownSprites = Resources.LoadAll<Sprite>("UI/PowerUI/PowerDown");
    }

    public void InitPower(int power)
    {
        startingPower = power;
        currentPower = power;
    }
    public void UpdatePower(int power)
    {
        currentPower = power;
    }
    // Update is called once per frame
    void Update()
    {
        //debug 
        if (debug)
        {
            Debug.Log(_current);
            debugUIstate(debugVar1);
        }

        powerbar.SetPower(currentPower);
        Debug.Log((float)currentPower / (float)startingPower);
        if ((float)currentPower / (float)startingPower > 0.66)
        {
            _current = state.high;
        }
        else if((float)currentPower / (float)startingPower > 0.33)
        {
            _current = state.medium;
        }
        else if ((float)currentPower / (float)startingPower <= 0)
        {
            lvlController.SetGameState(LevelController.gameState.Lose);
        }
        else 
        {
            _current = state.low;
        }

        //
        switch (_current)
        {
            case state.low:
                if (keyword != "low")
                {
                    keyword = "low";
                    UpdateSprites();
                }
                break;
            case state.medium:
                if (keyword != "mid")
                {
                    keyword = "mid";
                    UpdateSprites();
                }
                break; 
            case state.high:
                if (keyword != "high")
                {
                    keyword = "high";
                    UpdateSprites();
                }
                break;
            default:
                _current = state.high;
            break;
        }
    }
    public void UpdateSprites()
    {
        HUD.texture = UpdateSprite(_BaseSprites);
        face.texture = UpdateSprite(_FaceSprites);
        powerbar.updateBars(UpdateSprite(_BarUpSprites), UpdateSprite(_BarDownSprites));
    }


    public Texture2D UpdateSprite(Sprite[] list)
    {
        Sprite temp = null;
        //Get the one for each that contains the keyword
        foreach (Sprite sprite in list)
        {
            if (sprite.name.Contains(keyword))
            {
                temp = sprite;
            }
        }
        return temp.texture;
    }

    public void debugUIstate(int i)
    {
        _current = (state)i;
    }

    public int GetStartingPower()
    {
        return startingPower;
    }

    public int GetCurrentPower()
    {
        return currentPower;
    }
}
