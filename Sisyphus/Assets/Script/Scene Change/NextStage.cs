using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public GameObject storiesPanel;
    private void Start()
    {
    }
    public void StartNextStage()
    {
        //初始化保存数据
        DataStorage.gearsInInventory = new GameObject[5];
        DataStorage.gearsInBaseStorage = new GameObject[10];
        //保存仓库数据,玩家将要装备的零件
        int i = 0;
        GameObject go;
        foreach (Transform child in GameObject.FindWithTag(TagName.baseStoragePanel).transform)
        {
            if (child.childCount > 0)
            {
                go = child.GetChild(0).gameObject;
                DataStorage.gearsInBaseStorage[i] = go;
                go.SetActive(false);
                //go.transform.SetParent(GameObject.FindWithTag(TagName.dontDestroyOnLoad).transform);
            }
            i++;
        }
        i = 0;
        foreach (Transform child in GameObject.FindWithTag(TagName.baseInventoryPanel).transform)
        {
            if (child.childCount > 0)
            {
                go = child.GetChild(0).gameObject;
                DataStorage.gearsInInventory[i] = go;
                go.SetActive(false);
                //go.GetComponent<Spawn>().item.transform.SetParent(GameObject.FindWithTag(TagName.dontDestroyOnLoad).transform);
                //go.transform.SetParent(GameObject.FindWithTag(TagName.dontDestroyOnLoad).transform);
            }
            i++;
        }
        GameObject.FindWithTag(TagName.dontDestroyOnLoad).GetComponent<DataStorage>().Save();
        DataStorage.stage += 1;
        StartCoroutine(LoadNextScene());
    }
    private IEnumerator LoadNextScene()
    {
        //切换到下一场景并用幕间图片覆盖地图，此时生成地图并为玩家装备零件
        storiesPanel.SetActive(true);
        GameObject.FindWithTag(TagName.basePanel).SetActive(false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneNum.SceneOfCurrentStage + 1);
        //图片淡出开始下一关卡
    }
}
