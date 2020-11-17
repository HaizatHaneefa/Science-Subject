using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PalReality.Heredity;

public class CustomizationManager : MonoBehaviour
{
    enum Features { WomanHair, WomanEye, WomanSkin, ManHair, ManEye, ManSkin }

    // characters
    [Header("Character Skins")]
    public GameObject womanBody;
    public GameObject manBody;
    public GameObject girlBody;
    public GameObject boyBody;

    // eye & skin color
    [Header("Eye Object")]
    public GameObject[] womanEyes;
    public GameObject[] manEyes;
    public GameObject[] girlEyes;
    public GameObject[] boyEyes;

    [Header("Child Spawn")]
    public GameObject girlChild;
    public GameObject boyChild;

    // hair types
    [Header("Woman's Hair")]
    public GameObject womanStraightHair;
    public GameObject womanWavyHair;
    public GameObject womanCurlyHair;
    GameObject[] womanHairStyles;

    [Header("Man's Hair")]
    public GameObject manStraightHair;
    public GameObject manWavyHair;
    public GameObject manCurlyHair;
    GameObject[] manHairStyles;

    [Header("Girl's Hair")]
    public GameObject girlStraightHair;
    public GameObject girlWavyHair;
    public GameObject girlCurlyHair;

    [Header("Boy's Hair")]
    public GameObject boyStraightHair;
    public GameObject boyWavyHair;
    public GameObject boyCurlyHair;

    GameObject womanHairCurrentOption, manHairCurrentOption;

    [Header("Eye Color")]
    public Material blueEye;
    public Material greenEye;
    public Material brownEye;
    Material[] eyeColors;

    [Header("Skin")]
    public Material paleSkin;
    public Material brownSkin;
    public Material yellowSkin;
    Material[] skinColors;

    [Header("Blush")]
    public Material blushPale;
    public Material blushBrown;
    public Material blushYellow;
    Material[] blushColors;

    Material[] colorWoman, colorMan, colorGirl, colorBoy;
    Material[] eyeColorWoman, eyeColorMan, eyeColorGirl, eyeColorBoy;
    Material womanEyeCurrentOption, manEyeCurrentOption;
    Material womanSkinCurrentOption, manSkinCurrentOption;
    Material womanBlushCurrentOption, manBlushCurrentOption;
    readonly int womanSkinColorIndex = 1;
    readonly int womanBlushColorIndex = 4;
    readonly int manSkinColorIndex = 3;
    readonly int manBlushColorIndex = 5;
    readonly int girlSkinColorIndex = 0;
    readonly int girlBlushColorIndex = 1;
    readonly int boySkinColorIndex = 1;
    readonly int boyBlushColorIndex = 5;
    readonly int eyeColorIndex = 2;

    // options
    int chosenHairOpt;
    int chosenEyeOpt;
    int chosenSkinOpt;
    int chosenChild;

    // change woman's hair icon
    [Header("Change Woman's Hair Button")]
    public Sprite[] optionHairIconW;
    public Sprite currentHairIconW;
    public Image mainHairIconW;

    // change woman's eye icon
    [Header("Change Woman's Eyes Button")]
    public Sprite[] optionEyeIconW;
    public Sprite currentEyeIconW;
    public Image mainEyeIconW;

    // change woman's skin icon
    [Header("Change Woman's Skin Button")]
    public Color currentSkinIconW;
    public Image mainSkinIconW;

    // change man's hair icon
    [Header("Change Man's Hair Button")]
    public Sprite[] optionHairIconM;
    public Sprite currentHairIconM;
    public Image mainHairIconM;

    // change man's eye icon
    [Header("Change Man's Eyes Button")]
    public Sprite[] optionEyeIconM;
    public Sprite currentEyeIconM;
    public Image mainEyeIconM;

    [Header("Change Man's Skin Button")]
    // change man's skin icon
    public Color currentSkinIconM;
    public Image mainSkinIconM;

    // pale skin color
    readonly float pR = 255;
    readonly float pG = 207;
    readonly float pB = 158;

    // brown skin color
    readonly float bR = 180;
    readonly float bG = 106;
    readonly float bB = 71;

    // yellow skin color
    readonly float yR = 245;
    readonly float yG = 218;
    readonly float yB = 119;

    // color
    Color pale, brown, yellow;
    Color[] skinIconColors;

    [Header("Sounds")]
    public AudioSource shineSound;
    public AudioSource buttonSound;
    public AudioSource sparkleSound;

    Vector3 startSize;

    int index = 0;
    
    [SerializeField] Button generateButton;
    [SerializeField] ChildDisplay childDisplay;
    TweenAnchorPos childDisplayTween;

    void Awake() {
        childDisplayTween = childDisplay.GetComponent<TweenAnchorPos>();
    }

    private void Start()
    {
        womanHairStyles = new GameObject[3];
        womanHairStyles[0] = womanStraightHair;
        womanHairStyles[1] = womanWavyHair;
        womanHairStyles[2] = womanCurlyHair;

        manHairStyles = new GameObject[3];
        manHairStyles[0] = manStraightHair;
        manHairStyles[1] = manWavyHair;
        manHairStyles[2] = manCurlyHair;

        eyeColors = new Material[3];
        eyeColors[0] = blueEye;
        eyeColors[1] = greenEye;
        eyeColors[2] = brownEye;

        skinColors = new Material[3];
        skinColors[0] = paleSkin;
        skinColors[1] = brownSkin;
        skinColors[2] = yellowSkin;

        blushColors = new Material[3];
        blushColors[0] = blushPale;
        blushColors[1] = blushBrown;
        blushColors[2] = blushYellow;

        pale = new Color(pR / 255, pG / 255, pB / 255);
        brown = new Color(bR / 255, bG / 255, bB / 255);
        yellow = new Color(yR / 255, yG / 255, yB / 255);

        skinIconColors = new Color[3];
        skinIconColors[0] = pale;
        skinIconColors[1] = brown;
        skinIconColors[2] = yellow;

        startSize = new Vector3(0, 0, 0);

        eyeColorWoman = womanEyes[1].transform.GetComponent<SkinnedMeshRenderer>().materials;
        eyeColorMan = manEyes[1].transform.GetComponent<SkinnedMeshRenderer>().materials;
        eyeColorGirl = girlEyes[1].transform.GetComponent<SkinnedMeshRenderer>().materials;
        eyeColorBoy = boyEyes[1].transform.GetComponent<SkinnedMeshRenderer>().materials;

        colorWoman = womanBody.transform.GetComponent<SkinnedMeshRenderer>().materials;
        colorMan = manBody.transform.GetComponent<SkinnedMeshRenderer>().materials;
        colorGirl = girlBody.transform.GetComponent<SkinnedMeshRenderer>().materials;
        colorBoy = boyBody.transform.GetComponent<SkinnedMeshRenderer>().materials;

        womanHairCurrentOption = womanStraightHair;
        manHairCurrentOption = manStraightHair;
        womanSkinCurrentOption = colorWoman[womanSkinColorIndex];
        manSkinCurrentOption = colorMan[manSkinColorIndex];
        womanBlushCurrentOption = colorWoman[womanBlushColorIndex];
        manBlushCurrentOption = colorMan[manBlushColorIndex];
        womanEyeCurrentOption = eyeColorWoman[eyeColorIndex];
        manEyeCurrentOption = eyeColorMan[eyeColorIndex];

        currentHairIconW = mainHairIconW.GetComponent<Image>().sprite;
        currentEyeIconW = mainEyeIconW.GetComponent<Image>().sprite;
        currentSkinIconW = mainSkinIconW.GetComponent<Image>().color;

        currentHairIconM = mainHairIconM.GetComponent<Image>().sprite;
        currentEyeIconM = mainEyeIconM.GetComponent<Image>().sprite;
        currentSkinIconM = mainSkinIconM.GetComponent<Image>().color;
    }

    void ChangeAppearance(Features features, int id)
    {
        switch (features)
        {
            case Features.WomanHair:
                womanStraightHair.SetActive(false);
                womanWavyHair.SetActive(false);
                womanCurlyHair.SetActive(false);
                womanHairStyles[id].SetActive(true);
                womanHairCurrentOption = womanHairStyles[id];
                currentHairIconW = optionHairIconW[id];
                mainHairIconW.GetComponent<Image>().sprite = currentHairIconW;
                break;

            case Features.WomanEye:
                eyeColorWoman[eyeColorIndex] = eyeColors[id];
                for (int i = 0; i < womanEyes.Length; i++)
                {
                    womanEyes[i].transform.GetComponent<SkinnedMeshRenderer>().materials = eyeColorWoman;
                }
                womanEyeCurrentOption = eyeColorWoman[eyeColorIndex];

                currentEyeIconW = optionEyeIconW[id];
                mainEyeIconW.GetComponent<Image>().sprite = currentEyeIconW;

                break;

            case Features.WomanSkin:
                colorWoman[womanSkinColorIndex] = skinColors[id];
                womanBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorWoman;
                womanSkinCurrentOption = colorWoman[womanSkinColorIndex];

                colorWoman[womanBlushColorIndex] = blushColors[id];
                womanBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorWoman;
                womanBlushCurrentOption = colorWoman[womanBlushColorIndex];

                currentSkinIconW = skinIconColors[id];
                mainSkinIconW.GetComponent<Image>().color = currentSkinIconW;

                //Debug.Log("skin color is " + womanBody.transform.GetComponent<SkinnedMeshRenderer>().materials[womanSkinColorIndex] + " target eye color is " + colorWoman[womanSkinColorIndex]);
                break;

            case Features.ManHair:
                manStraightHair.SetActive(false);
                manWavyHair.SetActive(false);
                manCurlyHair.SetActive(false);
                manHairStyles[id].SetActive(true);
                manHairCurrentOption = manHairStyles[id];
                currentHairIconM = optionHairIconM[id];
                mainHairIconM.GetComponent<Image>().sprite = currentHairIconM;
                break;

            case Features.ManEye:
                eyeColorMan[eyeColorIndex] = eyeColors[id];
                for (int i = 0; i < manEyes.Length; i++)
                {
                    manEyes[i].transform.GetComponent<SkinnedMeshRenderer>().materials = eyeColorMan;
                }
                manEyeCurrentOption = eyeColorMan[eyeColorIndex];

                currentEyeIconM = optionEyeIconM[id];
                mainEyeIconM.GetComponent<Image>().sprite = currentEyeIconM;
                break;

            case Features.ManSkin:
                colorMan[manSkinColorIndex] = skinColors[id];
                manBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorMan;
                manSkinCurrentOption = colorMan[manSkinColorIndex];

                colorMan[manBlushColorIndex] = blushColors[id];
                manBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorMan;
                manBlushCurrentOption = colorMan[manBlushColorIndex];

                currentSkinIconM = skinIconColors[id];
                mainSkinIconM.GetComponent<Image>().color = currentSkinIconM;
                break;
        }
    }

    // eyes
    public void WomanBlueEyes()
    {
        index = 0;
        ChangeAppearance(Features.WomanEye, index);
        buttonSound.Play();
    }

    public void WomanGreenEyes()
    {
        index = 1;
        ChangeAppearance(Features.WomanEye, index);
        buttonSound.Play();
    }

    public void WomanBrownEyes()
    {
        index = 2;
        ChangeAppearance(Features.WomanEye, index);
        buttonSound.Play();
    }

    public void ManBlueEyes()
    {
        index = 0;
        ChangeAppearance(Features.ManEye, index);
        buttonSound.Play();
    }

    public void ManGreenEyes()
    {
        index = 1;
        ChangeAppearance(Features.ManEye, index);
        buttonSound.Play();
    }

    public void ManBrownEyes()
    {
        index = 2;
        ChangeAppearance(Features.ManEye, index);
        buttonSound.Play();
    }

    // skin
    public void WomanPaleSkin()
    {
        index = 0;
        ChangeAppearance(Features.WomanSkin, index);
        buttonSound.Play();
    }

    public void WomanBrownSkin()
    {
        index = 1;
        ChangeAppearance(Features.WomanSkin, index);
        buttonSound.Play();
    }

    public void WomanYellowSkin()
    {
        index = 2;
        ChangeAppearance(Features.WomanSkin, index);
        buttonSound.Play();
    }

    public void ManPaleSkin()
    {
        index = 0;
        ChangeAppearance(Features.ManSkin, index);
        buttonSound.Play();
    }

    public void ManBrownSkin()
    {
        index = 1;
        ChangeAppearance(Features.ManSkin, index);
        buttonSound.Play();
    }

    public void ManYellowSkin()
    {
        index = 2;
        ChangeAppearance(Features.ManSkin, index);
        buttonSound.Play();
    }

    // hair
    public void WomanStraight()
    {
        index = 0;
        ChangeAppearance(Features.WomanHair, index);
        buttonSound.Play();
    }

    public void WomanWavy()
    {
        index = 1;
        ChangeAppearance(Features.WomanHair, index);
        buttonSound.Play();
    }

    public void WomanCurly()
    {
        index = 2;
        ChangeAppearance(Features.WomanHair, index);
        buttonSound.Play();
    }

    public void ManStraight()
    {
        index = 0;
        ChangeAppearance(Features.ManHair, index);
        buttonSound.Play();
    }

    public void ManWavy()
    {
        index = 1;
        ChangeAppearance(Features.ManHair, index);
        buttonSound.Play();
    }

    public void ManCurly()
    {
        index = 2;
        ChangeAppearance(Features.ManHair, index);
        buttonSound.Play();
    }

    // generate
    public void Generate()
    {
        buttonSound.Play();
        sparkleSound.Play();
        girlChild.SetActive(false);
        boyChild.SetActive(false);
        StartCoroutine("SpawnChild");
    }

    IEnumerator SpawnChild()
    {
        childDisplayTween.Hide();
        generateButton.interactable = false;
        yield return new WaitForSeconds(1f);

        GameObject[] childOption = { girlChild, boyChild };
        chosenChild = Random.Range(0, childOption.Length);
        GameObject inheritGender = childOption[chosenChild];

        if (inheritGender == girlChild)
        {
            // choose gender
            girlChild.SetActive(true);
            boyChild.SetActive(false);

            // choose hair
            GameObject[] hairOption = { womanHairCurrentOption, manHairCurrentOption };
            chosenHairOpt = Random.Range(0, hairOption.Length);
            GameObject inheritHair = hairOption[chosenHairOpt];
            if (inheritHair.CompareTag("Straight"))
            {
                girlStraightHair.SetActive(true);
                girlWavyHair.SetActive(false);
                girlCurlyHair.SetActive(false);
            }
            else if (inheritHair.CompareTag("Wavy"))
            {
                girlStraightHair.SetActive(false);
                girlWavyHair.SetActive(true);
                girlCurlyHair.SetActive(false);
            }
            else if (inheritHair.CompareTag("Curly"))
            {
                girlStraightHair.SetActive(false);
                girlWavyHair.SetActive(false);
                girlCurlyHair.SetActive(true);
            }
            childDisplay.hair.Set(chosenHairOpt == 0 ? Gender.female : Gender.male);

            // choose skin
            Material[] skinOption = { womanSkinCurrentOption, manSkinCurrentOption };
            chosenSkinOpt = Random.Range(0, skinOption.Length);
            Material inheritSkin = skinOption[chosenSkinOpt];
            colorGirl[girlSkinColorIndex] = inheritSkin;
            girlBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorGirl;
            childDisplay.skin.Set(chosenSkinOpt == 0 ? Gender.female : Gender.male);

            // choose eye
            Material[] eyeOption = { womanEyeCurrentOption, manEyeCurrentOption };
            chosenEyeOpt = Random.Range(0, eyeOption.Length);
            Material inheritEye = eyeOption[chosenEyeOpt];
            eyeColorGirl[eyeColorIndex] = inheritEye;
            for (int i = 0; i < girlEyes.Length; i++)
            {
                girlEyes[i].transform.GetComponent<SkinnedMeshRenderer>().materials = eyeColorGirl;
            }
            childDisplay.eye.Set(chosenEyeOpt == 0 ? Gender.female : Gender.male);

            // choose blush
            Material[] blushOption = { womanBlushCurrentOption, manBlushCurrentOption };
            Material inheritBlush = blushOption[chosenSkinOpt];
            colorGirl[girlBlushColorIndex] = inheritBlush;
            girlBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorGirl;

        }
        else if (inheritGender == boyChild)
        {
            // choose gender
            boyChild.SetActive(true);
            girlChild.SetActive(false);

            // choose hair
            GameObject[] hairOption = { womanHairCurrentOption, manHairCurrentOption };
            chosenHairOpt = Random.Range(0, hairOption.Length);
            GameObject inheritHair = hairOption[chosenHairOpt];
            if (inheritHair.CompareTag("Straight"))
            {
                boyStraightHair.SetActive(true);
                boyWavyHair.SetActive(false);
                boyCurlyHair.SetActive(false);
            }
            else if (inheritHair.CompareTag("Wavy"))
            {
                boyStraightHair.SetActive(false);
                boyWavyHair.SetActive(true);
                boyCurlyHair.SetActive(false);
            }
            else if (inheritHair.CompareTag("Curly"))
            {
                boyStraightHair.SetActive(false);
                boyWavyHair.SetActive(false);
                boyCurlyHair.SetActive(true);
            }
            childDisplay.hair.Set(chosenHairOpt == 0 ? Gender.female : Gender.male);

            // choose skin
            Material[] skinOption = { womanSkinCurrentOption, manSkinCurrentOption };
            chosenSkinOpt = Random.Range(0, skinOption.Length);
            Material inheritSkin = skinOption[chosenSkinOpt];
            colorBoy[boySkinColorIndex] = inheritSkin;
            boyBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorBoy;
            childDisplay.skin.Set(chosenSkinOpt == 0 ? Gender.female : Gender.male);

            // choose eye
            Material[] eyeOption = { womanEyeCurrentOption, manEyeCurrentOption };
            chosenEyeOpt = Random.Range(0, eyeOption.Length);
            Material inheritEye = eyeOption[chosenEyeOpt];
            eyeColorBoy[eyeColorIndex] = inheritEye;
            for (int i = 0; i < boyEyes.Length; i++)
            {
                boyEyes[i].transform.GetComponent<SkinnedMeshRenderer>().materials = eyeColorBoy;
            }
            childDisplay.eye.Set(chosenEyeOpt == 0 ? Gender.female : Gender.male);

            // choose blush
            Material[] blushOption = { womanBlushCurrentOption, manBlushCurrentOption };
            Material inheritBlush = blushOption[chosenSkinOpt];
            colorBoy[boyBlushColorIndex] = inheritBlush;
            boyBody.transform.GetComponent<SkinnedMeshRenderer>().materials = colorBoy;
        }

        shineSound.Play();
        childDisplayTween.Show();
        generateButton.interactable = true;
    }
}
