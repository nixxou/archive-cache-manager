This is a special version of the plugin Archive Cache Manager from fraganator.
You can find the original page here : 
https://github.com/fraganator/archive-cache-manager
https://forums.launchbox-app.com/files/file/234-archive-cache-manager/

The main purpose of this version is to show metadata on the rom selection window. I like to keep quite a bunch of hacked version of a game alongside the original rom, within the 7z file, and for me, just having filename to choose is not enought.

So, i put on the right side of the screen a webview that show contents stored in a json file.

If your rom folder is « C:/rom/N64 » and you have a 7z archive named « MarioKart.7z », the metadata json file « MarioKart.json » must be stored either in « <YouLaunchBoxDirectory>/Metadata/N64 » or in « C:/rom/metadata/N64 » (ParentDirectory + Metadata + Name_of_the_rom_folder)
Alongside the json, you muse provide a « template.html » file.

Technical note :
The plugin will read the template.html, search a key that match the filename within the json file and remplace the string [[JSONDATA]] with the json data. You have to do a bunch of javascript within the template file to format it as you wish. You will find an exemple in the exemple folder.
For BigBox, it will use template.BB.html if availiable (if not, it will still use template.html)
If json is a pain for you, you can also make a folder Metadata/N64/MarioKart/Nameoftherom.html and it will use this html file instead.
On top of that quite a few features where added.
HiRes texture : This functionality is tailored for N64 games in mind with texture with htc or hts extension.
You have to setup the texture folder that will define where the texture file will be extracted.

For retroarch muppen with gliden64 plugin, it's in 
LaunchBox\Emulators\RetroArch\system\Mupen64plus\cache
Don't forget in the Core option :
Set Use High-Res textures to True
Set Continuous texrect coords to Auto
And if it's a HTS file :
Set Use High-Res Full Alpha Channel to True
Set Use enhanced Hi-Res Storage to True

You will also find some feature on right click on the listing, like filter or extract rom.


