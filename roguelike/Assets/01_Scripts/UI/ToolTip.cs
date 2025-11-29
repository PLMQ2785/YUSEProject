using UnityEngine;
using UnityEngine.EventSystems;
public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [TextArea]
    public string description; //설명

    //들어가면 열리고
    public void OnPointerEnter(PointerEventData eventData)
    {
        UpgradeManager.Instance.ShowToolTip(description);
    }

    //마우스가 나가면 닫히고
    public void OnPointerExit(PointerEventData eventData) 
    { 
        UpgradeManager.Instance.HideToolTip(); 
    }
}
