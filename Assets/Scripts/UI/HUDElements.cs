using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HUDElements : MonoBehaviour
{
    public PlayerController player;
    public TMP_Text locationDate, level, objective, messageText;
    public MsgSystem ldNode, ldNode2, levelNode, levelNode2, objNode;
    public List<MsgSystem> messages;
    

    void Update()
    {
        if (player.isWarping)
        {
            locationDate.text = ldNode2.message;
            level.text = levelNode2.message;
        }
        else
        {
            locationDate.text = ldNode.message;
            level.text = levelNode.message;
        }
        
        objective.text = objNode.message;
        
        UpdateMessages();
    }

    void UpdateMessages()
    {
        messageText.text = string.Join("\n", messages.ConvertAll(m => m.message));

        if (messages.Count > 0)
        {
            for(int i = messages.Count - 1; i >= 0; i--)
            {
                StartCoroutine(RemoveMessage(messages[i], 5f));
            }
        }

        foreach (var message in messages)
        {
            switch (message.type)
            {
                case MsgType.Default:
                    messageText.color = Color.white;
                    break;
                case MsgType.Error:
                    messageText.color = Color.red;
                    break;
                case MsgType.Warning:
                    messageText.color = Color.yellow;
                    break;
                case MsgType.Info:
                    messageText.color = Color.blue;
                    break;
                case MsgType.Success:
                    messageText.color = Color.green;
                    break;
            }
        
        }
    }
    
    IEnumerator RemoveMessage(MsgSystem message, float delay)
    {
        yield return new WaitForSeconds(delay);
        message.Remove(messages);
    }
}
