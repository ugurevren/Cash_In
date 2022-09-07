using TMPro;
using UnityEngine;

public class ATM : MonoBehaviour
{
    public TextMeshProUGUI text;
    public playerStats _stats;
    void Update()
    {
        text.text = "Current debt:\n" + _stats.dept;
    }
}
