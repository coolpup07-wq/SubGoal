using System;

public class CPHInline
{
    public bool Execute()
    {
        // This fires automatically on every new subscription
        // Send newSub event to the HTML
        string jsonData = "{\"type\": \"newSub\", \"amount\": 1}";
        CPH.WebsocketBroadcastString(jsonData);

        return true;
    }
}
