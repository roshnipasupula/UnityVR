using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunter : MonoBehaviour
{
    // Start is called before the first frame update

    public CollectibleTreasure[] collectiblesInScene;
    public TreasureHunterInventory inventory;
    public TextMesh youWinText, scoreText;
    bool needTreas1 = true, needTreas2 = true, needTreas3 = true;
    bool  youWin = false, showScore = false;
    int treasCount = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            
            Debug.Log("You pressed '1' key\n");
            if(needTreas1) {
                inventory.collectibles[0] = collectiblesInScene[0];
                treasCount++;
                needTreas1 = false;
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("You pressed '2' key \n");
            if(needTreas2) {
                inventory.collectibles[1] = collectiblesInScene[1];
                treasCount++;
                needTreas2 = false;
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("You pressed '3' key\n");
            if(needTreas3) {
                treasCount++;
                inventory.collectibles[2] = collectiblesInScene[2];
                needTreas3 = false;
            }
        } 

        if(!needTreas1 && !needTreas2 && !needTreas3)
            youWin = true;

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Debug.Log("You pressed '4' key\n");
            showScore = !showScore;
           }

        if(youWin)
            youWinText.text = "you won...that's cool i guess";

        if(showScore) {
            scoreText.text = "Roshni Pasupula made this \n";
            if(!needTreas1)
                scoreText.text += "you got treasure 1 +"+inventory.collectibles[0].value+ "pts \n";
            if(!needTreas2)
                scoreText.text += "you got treasure 2! +"+inventory.collectibles[1].value+"pts \n";
            if(!needTreas3)
                scoreText.text += "you got treasure 3! +"+inventory.collectibles[2].value+"pts \n";
            scoreText.text += "you got "+ treasCount + " out of 3 treasures \n";
            scoreText.text += "You got " + countScore() + " out of 6 points \n";
            
        } else if (!showScore) {
            scoreText.text = "";
        }
        
    }

    int countScore()
    {
        int score = 0;

        for(int i = 0; i < 3; i++) 
        if(inventory.collectibles[i] != null)
            score += inventory.collectibles[i].value;
        
        return score;
    }
}
