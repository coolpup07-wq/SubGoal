# SubGoal

# Linking streamerbot with OBS
you've probably already done this so ill make it brief. 
in the home page go to stream apps then obs studio, right click the host panel, add, Name it anything u want, Go to OBS, click tools tab on the top left, websocket server settings in the dropdown, tick enable websocket server, Show connect info, click copy beside server password, then click apply and ok. back to streamer.bot paste the password that you copied into password and  turn on auto connect on startup and reconnect on disconnect. right click the host you created on streamer.bot and hit connect, its status should say connected. 

# Global variables
This is at the top of your screen on streamer.bot, variable name subGoalPlaying (capitalisation is important), value: false, enable autotype.

<img width="752" height="233" alt="image" src="https://github.com/user-attachments/assets/0c0d8a46-c289-4d45-b25d-ce2c49a79042" />

# Actions
right click the actions panel > add > Name it something like subCounter > Ok
right click the triggers panel > add > twitch > subscriptions > subscription > Ok
right click the sub actions panel > add > twitch > sub counter > get twitch sub counter count

Now we must make three C# files, we'll go through them one by one. 

# sound file
right click the sub actions panel > add > core > C# > execute C# code. this will open a C# IDE. 
go on to my githup repository and open the sound.cs file. copy everything in there and paste it in the IDE thing you just opened on streamer.bot, replacing all the code thats there previously. You must change some of this code for it to work for you. Download the sound file that you want to play whenevr you recieve a subscriber, and in your file explorer, right click the file and copy path. paste this where my: "C:\Users\nzmah\OneDrive\Desktop\aura.mp3" is. note you must make sure not to delete the @ that comes before the file and keep quotations. 

<img width="483" height="142" alt="image" src="https://github.com/user-attachments/assets/a69a71f2-42ee-4de0-9368-e08a72e0e506" />


You must also check how long the audio file is, my audio file was 30 seconds so that is 30000ms, however long your audio is multiply it by 1000 and put that number here:

 <img width="692" height="65" alt="image" src="https://github.com/user-attachments/assets/48cbcd9d-5355-4bb9-8028-b4b2679421ca" />

That timer basically prevents another audio playing on top of the previous one incase someone drops more than one sub using the global variable we defined earlier.

click save and then compile, your compile log should output this:

<img width="552" height="231" alt="image" src="https://github.com/user-attachments/assets/4b4edfad-61c6-4d3e-8f72-eed41f40613b" />

you will save and compile each of these C# code blocks to ensure they compile. 

If you right click your source in triggers and click test triggers, you should hear your audio playing. 

# Overlay visibility

in my githup repo, open the overlay.html file and copy all the code there. Now in your file explorer create a text document, you do this by right clicking and empty space > new > text document. at this stage paste all the code into the document > file > save as> name it overlay.html, now its important to change the 'save as type' to all files, and not as a text document. save this file and it should now be openable as a browser: 

<img width="427" height="45" alt="image" src="https://github.com/user-attachments/assets/f4184379-3dc5-471c-81b8-fb3ea584c866" />

when you open this browser it should look something like this: 

<img width="953" height="808" alt="image" src="https://github.com/user-attachments/assets/004850f7-4ab5-4919-bdc1-24f8c11882fc" />

This is the overlay. either copy the url in the browser, or copy as path in ur directories, both gives the same thing. This will be needed in a sec.


in OBS take note of the scene you're always in, for mine it is 'Party'. Then right click sources > add source > browser > name the browser SubGoalUI (remember capitalisations important) > make sure source is not visible, ensuring the tick box is empty.

<img width="788" height="698" alt="image" src="https://github.com/user-attachments/assets/d45420fd-91e0-4516-8b52-10e821967d3c" />

hit Ok. 
Now paste in the webpage directory you copied earlier, this will act as an overlay that you can make visible or invisible.

<img width="907" height="777" alt="image" src="https://github.com/user-attachments/assets/b7199ce5-fb8a-4550-8d44-01279a7f4ad5" />

hit Ok, now if you make the source visible youll see confetti and the subgoal and everything. make sure u have it scale to window so that it doesnt look bummy: 

<img width="410" height="262" alt="image" src="https://github.com/user-attachments/assets/2d6361ea-385b-43ee-bf09-951c7aec7ce2" />


<img width="1153" height="836" alt="image" src="https://github.com/user-attachments/assets/7b2765fd-7e41-4033-87ec-32bda0a412ca" />


next we gotta make this controllable through streamer.bot
copying this from earlier in the readme: right click the sub actions panel > add > core > C# > execute C# code. this will open a C# IDE. Go to my github repo and open the overlayVisibility.cs, copy allat and paste it into the IDE that you opened in streamer.bot. 
reading the code you'll see we have adjustable paramaters for you: 

<img width="541" height="172" alt="image" src="https://github.com/user-attachments/assets/5563ec37-b813-4578-935a-277fef2dbeb7" />

"Party" is the scene that we created the overlay in, rename this to whatever scene you put the overlay in your obs. CPH.Wait(10000); controls how long the overlay lasts on the screen, right now its set to 10 seconds, adjust it if u want. again by clicking save and then clicking compile (if u click save and compile it closes the IDE) it should compile in log. hit ok and you can again test the trigger to see it work on your obs. at this point it should be fully functional except it doesnt track your subs. 

# check subs

again: right click the sub actions panel > add > core > C# > execute C# code. this will open a C# IDE. go to my repo and open checkSubs.cs paste it in to streamer.bot, save it then compile it and it should compile, hit ok and its all functional now. As i said though in dms I'm not 100% sure if this does track your subs but thats what the documentation says it does so lets hope.

<img width="1540" height="1017" alt="image" src="https://github.com/user-attachments/assets/7241b443-32a8-400b-bcb8-bb7205f12ef7" />

