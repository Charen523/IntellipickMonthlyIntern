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
        text += "�̸�: " + data.Name + "\n";
        text += "���: " + data.Grade + "\n";
        text += "�ӵ�: " + data.Speed + "\n";
        text += "ü��: " + data.Health;

        infoTxt.text = text;
    }
}
