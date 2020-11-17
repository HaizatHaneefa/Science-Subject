using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManagerBasic : MonoBehaviour
{
    [SerializeField] HomeHeader header;
    [SerializeField] AnatomyMenu anatomyMenu;

    void Awake() {
        
    }

    IEnumerator Start() {

        anatomyMenu.Show();
        yield return new WaitForFixedUpdate();
        header.Hide();
        header.HideLevel(false);
        header.MenuNavigation(null);
    }
}
