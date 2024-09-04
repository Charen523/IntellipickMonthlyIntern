using UnityEngine;
using UnityEngine.UI;

public class MonsterInfoPopup : MonoBehaviour
{
    [SerializeField] private Text infoTxt;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetInfoTxt(MonsterData data)
    {
        string text = "";
        text += "이름: " + data.Name + "\n";
        text += "등급: " + data.Grade + "\n";
        text += "속도: " + data.Speed + "\n";
        text += "체력: " + data.Health;

        infoTxt.text = text;
    }
}
