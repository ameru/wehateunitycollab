using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class ElderlyScenario : MonoBehaviour
{
    [Serializable]
    public struct Notification
    {
        public string name;
        public GameObject panel;
    }

    public GameObject notificationCanvas;

    public Notification[] notifications;

    private Dictionary<string, GameObject> _notifications = new Dictionary<string, GameObject>();

    private string userName;

    private GameObject popup;

    async void Start()
    {
        foreach (var notif in notifications)
        {
            _notifications[notif.name] = notif.panel;
        }

        await Convo1();
    }

    async Task Convo1()
    {
        await SpeechService.Say("Hi there!");
        await SpeechService.Say("I'm Tom");
        await SpeechService.Say("What's your name?");
        
        try
        {
            var result = await SpeechService.Interpret();
            userName = GetName(result);
        }
        catch
        {
            userName = "";
        }

        await SpeechService.Say("Nice to meet you " + userName);
        await SpeechService.Say("Thank you for taking caring care of me today, you're such a doll.");

        ShowPopup("Heart");
    }

    public async Task Convo2()
    {
        await SpeechService.Say("It feels like my heart's going on a rodeo, yeehaw.");
        
        ShowPopup("Meds");
    }

    public async Task Convo3()
    {
        await SpeechService.Say("Thanks, I feel much better now.");
        await SpeechService.Say("Please keep me company " + userName);

        ShowPopup("Talk", async () => await Convo4());
    }

    public async Task Convo4()
    {
        await SpeechService.Say("Tell me, how was your day?");

        await SpeechService.Hear();

        await SpeechService.Say("That was fascinating. Thank you for your time!");
    }

    private void ShowPopup(string name, Action nextAction = null)
    {
        var panel = _notifications[name];
        popup = Instantiate(panel, notificationCanvas.transform);

        if (nextAction != null)
        {
            var action = popup.GetComponent<PanelAction>();
            action.onClick.AddListener(() => nextAction());
        }
    }

    string GetName(InterpretResult result)
    {
        foreach (Entity entity in result.entities)
        {
            if (entity.type == "builtin.personName")
            {
                return entity.entity;
            }
        }
        return "";
    }
}
