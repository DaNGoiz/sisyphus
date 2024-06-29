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
        //��ʼ����������
        DataStorage.gearsInInventory = new GameObject[5];
        DataStorage.gearsInBaseStorage = new GameObject[10];
        //����ֿ�����,��ҽ�Ҫװ�������
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
        //�л�����һ��������Ļ��ͼƬ���ǵ�ͼ����ʱ���ɵ�ͼ��Ϊ���װ�����
        storiesPanel.SetActive(true);
        GameObject.FindWithTag(TagName.basePanel).SetActive(false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneNum.SceneOfCurrentStage + 1);
        //ͼƬ������ʼ��һ�ؿ�
    }
}
