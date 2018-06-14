using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemDisplay : MonoBehaviour {

    public Sprite trash1;
    public Sprite trash2;
    public Sprite trash3;
    public Sprite trash4;
    public Sprite trash5;
    public Sprite trash6;
    public Sprite trash7;
    public Sprite trash8;
    public Sprite trash9;
    public Sprite trash10;
    public Sprite trash11;
    public Sprite trash12;
    public Sprite trash13;
	public Sprite trash14;
    public Sprite trash15;
    public Sprite trash16;
    public Sprite trash17;
    public Sprite trash18;
    public Sprite trash19;
    public Sprite trash20;
    public Sprite trash21;
    public Sprite trash22;
    public Sprite trash23;
    public Sprite trash24;
    public Sprite trash25;
    public Sprite trash26;
    public Sprite trash27;
    public Sprite trash28;
    public Sprite trash29;
    public Sprite trash30;
    public Sprite trash31;
    public Sprite trash32;
    public Sprite trash33;
    public Sprite trash34;
    public Sprite trash35;
    public Sprite trash36;

    Image image;

	// Use this for initialization
	void Start()
	{
		image = GetComponent<Image>();
		switch (tips.tipsSlot1) {
            case 1:
                image.sprite = trash1;
                break;
            case 2:
                image.sprite = trash2;
                break;
            case 3:
                image.sprite = trash3;
                break;
            case 4:
                image.sprite = trash4;
                break;
            case 5:
                image.sprite = trash5;
                break;
            case 6:
                image.sprite = trash6;
                break;
            case 7:
                image.sprite = trash7;
                break;
            case 8:
                image.sprite = trash8;
                break;
            case 9:
                image.sprite = trash9;
                break;
            case 10:
                image.sprite = trash10;
                break;
            case 11:
                image.sprite = trash11;
                break;
            case 12:
                image.sprite = trash12;
                break;
            case 13:
                image.sprite = trash13;
                break;
			case 14:
				image.sprite = trash14;
				break;
            case 15:
                image.sprite = trash15;
                break;
            case 16:
                image.sprite = trash16;
                break;
            case 17:
                image.sprite = trash17;
                break;
            case 18:
                image.sprite = trash18;
                break;
            case 19:
                image.sprite = trash19;
                break;
            case 20:
                image.sprite = trash20;
                break;
            case 21:
                image.sprite = trash21;
                break;
            case 22:
                image.sprite = trash22;
                break;
            case 23:
                image.sprite = trash23;
                break;
            case 24:
                image.sprite = trash24;
                break;
            case 25:
                image.sprite = trash25;
                break;
            case 26:
                image.sprite = trash26;
                break;
            case 27:
                image.sprite = trash27;
                break;
            case 28:
                image.sprite = trash28;
                break;
            case 29:
                image.sprite = trash29;
                break;
            case 30:
                image.sprite = trash30;
                break;
            case 31:
                image.sprite = trash31;
                break;
            case 32:
                image.sprite = trash32;
                break;
            case 33:
                image.sprite = trash33;
                break;
            case 34:
                image.sprite = trash34;
                break;
            case 35:
                image.sprite = trash35;
                break;
            case 36:
                image.sprite = trash36;
                break;
        }
	}

	// Update is called once per frame
	void Update()
	{
	}
}
