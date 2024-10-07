using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;

    private void Awake() 
    {
        if(Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            DestroyImmediate(this.gameObject);
        }
    }

    private Dictionary<string, List<Component>> mainList = new Dictionary<string, List<Component>>();

    /* 
    _lName stands for the name of the list of components
    _c stands for the name of the component to be added to the list
    */
    public void AddListener(Component _c, string _lName) 
    {
        if(!mainList.ContainsKey(_lName)) 
        {
            mainList.Add(_lName, new List<Component>());
        }

        mainList[_lName].Add(_c);

        Debug.Log("Added " + _c.name + " to " + _lName);    
    }

    /*
    _cID stands for instance ID, as we are using the instance ID 
    matching and verifying and removing the component from 
    the list
    _lName stands for the name of the list of components
    */
    public void RemoveListener(int _cID, string _lName)
    {
        if(mainList.ContainsKey(_lName)) 
        {
            foreach(Component _c in mainList[_lName])
            {   
                if(_c.GetInstanceID() == _cID) 
                {
                    mainList[_lName].Remove(_c);
                }
            }
        }

        //Redundancy checking
        List<Component> tempList = new List<Component>();

        foreach (Component _c in mainList[_lName])
        {
            if(_c != null) 
            {
                tempList.Add(_c);
            }
        }

        mainList[_lName] = tempList;
    }

    /*
    _funcName stands for the name of the function to be called on the listeners
    _lName stands for the name of the list of components
    _sendToChildren says if we are going to use SendMessage() function or BroadcastMessage() function, as the latter sends the message to all the children gameobjects as well.
    */
    public void SendNotification(string _funcName, string _lName, bool _sendToChildren = false) 
    {
        if(mainList.ContainsKey(_lName)) 
        {
            foreach (Component _c in mainList[_lName])
            {
                if(!_sendToChildren) 
                {
                    _c.SendMessage(_funcName, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Sent " + _funcName + " to " + _c.name);
                }
                else 
                {
                    _c.BroadcastMessage(_funcName, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else
        {
            Debug.LogError("List with the specified name " + _lName + " does not exist");
        }
    }

    /**/
    public void ClearList(string _lName) 
    {
        mainList[_lName].Clear();

        //Redundancy Check

        Dictionary<string, List<Component>> temp = new Dictionary<string, List<Component>>();

        foreach (KeyValuePair<string, List<Component>> item in mainList)
        {
            if(item.Value.Count > 0) 
            {
                temp.Add(item.Key, item.Value);
            }
        }

        mainList = temp;
    }
}
