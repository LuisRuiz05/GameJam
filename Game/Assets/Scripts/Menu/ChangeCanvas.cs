using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCanvas : MonoBehaviour
{
    public GameObject toHide;
    public GameObject toShow;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
		toHide.SetActive(false);
        toShow.SetActive(true);
	}
}
