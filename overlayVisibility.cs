using System;

public class CPHInline
{
    public bool Execute()
    {
        CPH.ObsSetSourceVisibility("Party", "SubGoalUI", true);
        
        // Keep overlay visible for x seconds
        CPH.Wait(10000);
        
        CPH.ObsSetSourceVisibility("Party", "SubGoalUI", false);

        return true;
    }
}
