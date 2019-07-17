using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private PlayerMCU player;
    [SerializeField]private Text kmText;
    private float poinst = 0;
    private void Start() {
        kmText.text = "Points: " + poinst.ToString(); 
    }

    private void Update() {
        if(player.rightWheel.speed + player.leftWheel.speed != 0){
            poinst += 1;
            kmText.text = "Points: " + poinst.ToString(); 
        }
    }
}
