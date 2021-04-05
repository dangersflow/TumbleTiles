using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class TabSystem : MonoBehaviour
{
    public Transform TabContainer;
    public GameObject Tab;
    public GameObject AddTabButton;
    public GameObject sizeOfTabGroup;
    private int numOfTabs;
    private GameObject firstTab;
    private Transform InputCarat;
    private bool foundCarat = false;
    // Start is called before the first frame update
    void Start()
    {
        numOfTabs = TabContainer.transform.childCount - 1;
        firstTab = TabContainer.GetChild(0).gameObject;
        firstTab.transform.Find("Tab").transform.Find("DeleteButton").GetComponent<Toggle>().onValueChanged.AddListener((self) => DeleteTab(firstTab));
    }

    // Update is called once per frame
    void Update()
    {
        if(!foundCarat){
            InputCarat = firstTab.transform.Find("Tab").transform.Find("Label Input Caret").transform;
            InputCarat.transform.SetSiblingIndex(1);
            foundCarat = true;
        }
        
    }

    public void AddTab(){
        GameObject newTab = Instantiate(Tab);
        newTab.transform.localScale = new Vector3(1, 1, 1);
        newTab.transform.SetParent(TabContainer, false);
        newTab.transform.SetSiblingIndex(numOfTabs);
        newTab.transform.Find("Tab").transform.Find("DeleteButton").GetComponent<Toggle>().onValueChanged.AddListener((self) => DeleteTab(newTab));
        firstTab = newTab;
        foundCarat= false;
        numOfTabs++;
        if(numOfTabs == 4){
            AddTabButton.SetActive(false);
        }
    }

    public void DeleteTab(GameObject tab){
        Destroy(tab);
        numOfTabs--;
        if(numOfTabs < 4){
            AddTabButton.SetActive(true);
        }
    }
}
