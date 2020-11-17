using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LearninpalTransition : MonoBehaviour
{
    AsyncOperation async;

    public CanvasGroup Card01, Card02;
    public Image Card_First, Card_Second;
    public Sprite Card01_BM, Card01_BI, Card02_BM, Card02_BI;
    public RectTransform ProgressBar;

    public Image LoadingFiller;
    public CanvasGroup Background;
    RectTransform[] Symbols;
    bool isSwitchingCards=false;

    float ProgBarShow=50f, ProgBarHide=-100f;
    RectTransform CardRect01, CardRect02;
    bool isHomepageUnloaded = false;

    void Awake()
    {
        if(Lean.Localization.LeanLocalization.CurrentLanguage=="English") {
            Card_First.sprite=Card01_BI;
            Card_Second.sprite=Card02_BI;
        } else {
            Card_First.sprite=Card01_BM;
            Card_Second.sprite=Card02_BM;
        }

        Symbols=new RectTransform[Background.transform.childCount];
        for(int x=0; x<Background.transform.childCount; x++) {
            Symbols[x]=Background.transform.GetChild(x).GetComponent<RectTransform>();
        }
        ProgressBar.anchoredPosition= new Vector2(ProgressBar.anchoredPosition.x, ProgBarHide);

        CardRect01=Card01.GetComponent<RectTransform>();
        CardRect02=Card02.GetComponent<RectTransform>();
    }

    void Start()
    {
        DontDestroyOnLoad( this.gameObject );
        //Testing
        Background.DOFade(1.0f,0.5f);
        for(int x=0; x<Background.transform.childCount; x++) {
            float Movement=Random.Range(-1,2)*(5f);
            if(Random.Range(0,2)==0) {
                Symbols[x].DOAnchorPosX( Symbols[x].anchoredPosition.x+Movement,1f,false).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            } else {
                Symbols[x].DOAnchorPosY( Symbols[x].anchoredPosition.y+Movement,1f,false).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            }
        }
    }

    public void LoadLearninpalAR(string SceneLoading)
    {
        StartCoroutine(StartLoading(SceneLoading));
    }

    void SwitchCards()
    {
        if (isSwitchingCards) {
            Card01.DOFade(0.0f,1f);
            Card02.alpha=0f;
            Card02.gameObject.SetActive(true);
            Card02.DOFade(1.0f,.7f);
            isSwitchingCards=false;
        } else {
            Card02.DOFade(0.0f,1f);
            Card01.alpha=0f;
            Card01.gameObject.SetActive(true);
            Card01.DOFade(1.0f,.7f);
            isSwitchingCards=true;
        }
    }
    IEnumerator StartLoading(string SceneLoading)
    {
        Card01.transform.localScale=Vector3.zero;
        Card01.alpha=0f;
        Card01.gameObject.SetActive(true);
        Card01.DOFade(1.0f,.7f);
        Card01.transform.DOScale(Vector3.one,1.0f);
        isSwitchingCards=true;
        InvokeRepeating("SwitchCards",2.5f, 2.5f);

        ProgressBar.DOAnchorPosY(ProgBarShow,1f,false);
        async = SceneManager.LoadSceneAsync(SceneLoading);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            if (async.progress >= 0.9f) {
                LoadingFiller.DOFillAmount(1f, 1.5f);
                yield return new WaitForSeconds(1.5f);
                LoadingFiller.fillAmount = 1.0f;

                yield return new WaitForSeconds(1.0f);
                // async.allowSceneActivation = true;
                yield return new WaitForSeconds(1.5f);
                CancelInvoke();
                ProgressBar.DOAnchorPosY(ProgBarHide,1f,false);
                CardRect01.DOScale(Vector3.one*1.05f,0.5f);
                CardRect02.DOScale(Vector3.one*1.05f,0.5f);
                yield return new WaitForSeconds(2f);
                CardRect01.DOAnchorPosY(CardRect01.anchoredPosition.y+Screen.height,1f,false);
                CardRect02.DOAnchorPosY(CardRect02.anchoredPosition.y+Screen.height,1f,false);
                Background.DOFade(0.0f,0.5f).SetDelay(0.5f);
                async.allowSceneActivation = true;
                yield return new WaitForSeconds(1f);
                Destroy(this.gameObject);
            } else {
                LoadingFiller.fillAmount = async.progress;
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
