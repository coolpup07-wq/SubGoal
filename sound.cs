using System;

public class CPHInline
{
    public bool Execute()
    {
        // read the flag (string) – persisted so it survives restarts
        string playing = CPH.GetGlobalVar<string>("subGoalPlaying", true);

        if (playing != "true")            // not already playing?
        {
            CPH.SetGlobalVar("subGoalPlaying", "true", true); // mark busy

            // play the clip 
            var handle = CPH.PlaySound(
                @"C:\Users\nzmah\OneDrive\Desktop\aura.mp3",
                1.0f, false, "subGoalSound", true
            );

            CPH.Wait(30000);              // MAKE THIS THE DURATION OF YOUR AUDIO (in ms)

            CPH.SetGlobalVar("subGoalPlaying", "false", true); // clear flag
        }
        else
        {
            CPH.LogInfo("Sub sound skipped; already playing");
        }

        return true;
    }
}
