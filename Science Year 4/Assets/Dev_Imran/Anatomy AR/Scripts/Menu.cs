using UnityEngine;
using DG.Tweening;
//using MarchingBytes;

public class Menu : MonoBehaviour
{
    public GameObject genderButton;
    public GameObject panel;
    public GameObject panelMask;
    public GameObject subPanelG;
    public GameObject[] panelSub;
    public GameObject[] panelSubMask;

    public float openMove;
    public float openMoveSub;

    float iniPanelPos;
    float iniPnlSubPos;

    bool open = false;
    bool openSub = false;
    bool openHair = false;
    bool openEye = false;
    bool openSkin = false;
    
    public GameObject customObj;

    GameObject explosion;
    public GameObject womanButton;
    public GameObject explosionObj;
    Camera cam;

    public void Start()
    {
        cam = Camera.main;
        iniPanelPos = panel.transform.position.y;
        iniPnlSubPos = panelSub[0].transform.position.x;
    }

    public void Update()
    {
        subPanelG.transform.position = new Vector2(subPanelG.transform.position.x, panel.transform.position.y);
        if (openHair || openEye || openSkin)
        {
            openSub = true;
        }
        else
        {
            openSub = false;
        }
    }

    public void OpenMenu()
    {
        //Vector3 point = cam.ScreenToWorldPoint(new Vector3(womanButton.transform.position.x, womanButton.transform.position.y, 300f)); 

        //if (explosion == null)
        //{
        //    explosion = EasyObjectPool.instance.GetObjectFromPool("Explosion", point, Quaternion.identity);
        //}
        //EasyObjectPool.instance.ReturnObjectToPool(explosion);

        if (open == false)
        {
            panel.transform.DOMoveY(panelMask.transform.position.y, 1, false);
            open = true;
        }
        else if (open == true)
        {
            if (openSub == false)
            {
                CloseMenu();
                open = false;
            }
            else if (openSub == true)
            {
                for (int i = 0; i < panelSub.Length; i++)
                {
                    panelSub[i].transform.DOMoveX(iniPnlSubPos, 1, false);
                }
                Invoke("CloseMenu", 1.3f);
                open = false;
            }
        }
        //explosion = EasyObjectPool.instance.GetObjectFromPool("Explosion", point, Quaternion.identity);
    }

    void CloseMenu()
    {
        panel.transform.DOMoveY(iniPanelPos, 1, false);
    }

    public void HairMenu()
    {
        if (open == true)
        {
            if (openHair == false)
            {
                panelSub[0].transform.DOMoveX(panelSubMask[0].transform.position.x, 1, false);
                openHair = true;
            }
            else if (openHair == true)
            {
                panelSub[0].transform.DOMoveX(iniPnlSubPos, 1, false);
                openHair = false;
            }
        }
        else if (open == false)
        {
            return;
        }
    }

    public void EyeMenu()
    {
        if (open == true)
        {
            if (openEye == false)
            {
                panelSub[1].transform.DOMoveX(panelSubMask[1].transform.position.x, 1, false);
                openEye = true;
            }
            else if (openEye == true)
            {
                panelSub[1].transform.DOMoveX(iniPnlSubPos, 1, false);
                openEye = false;
            }
        }
        else if (open == false)
        {
            return;
        }
    }

    public void SkinMenu()
    {
        if (open == true)
        {
            if (openSkin == false)
            {
                panelSub[2].transform.DOMoveX(panelSubMask[2].transform.position.x, 1, false);
                openSkin = true;
            }
            else if (openSkin == true)
            {
                panelSub[2].transform.DOMoveX(iniPnlSubPos, 1, false);
                openSkin = false;
            }
        }
        else if (open == false)
        {
            return;
        }
    }
}
