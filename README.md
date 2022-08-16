# PokemonBDSPEditor

A WIP Editor for various parts of Pokémon Brilliant Diamond and Shining Pearl.

![Picture showing the application](https://i.imgur.com/g3xbTsf.png "The Script Editor")<br>

The most recent version can be downloaded from the releases page. Supported features are described further down.

## Features

### Script Editing

A full-blown editor for all scripts used by the game!
- Edit any script in a readable format and let the editor do the conversion work for you
- "Compile" the script to validate if there are any missing arguments or other issues
- Look through the 1000+ commands that can be used and get details on what they do and what arguments they need
- Add or delete scripts (Not yet implemented)

[Usage Example](https://youtu.be/CkC6rlwUOvw)

## Upcoming Features

### Text Editor

An editor for all the text strings in the game!
- Change the strings in any language you need to

### Trainer Editor

An editor for all the trainer battles!
- Edit the Pokémon used by trainers in all of Sinnoh

## Requirements

To start editing game files, you will first need to obtain them. You can use Ryujinx or yuzu to extract the game data, specifically the RomFS. You can also use any other tool that extracts the game files from your legally acquired ROM (hactool, etc.).

### Ryujinx
Simply right-click the ROM in your ROM list, then select Extract Data, then RomFS.<br>
![Picture showing where to extract on Ryujinx](https://i.imgur.com/KrqjTEa.png "Extracting on Ryujinx")<br>

### yuzu
Simply right-click the ROM in your ROM list, then select Dump RomFS, then Dump RomFS.<br>
![Picture showing where to extract on yuzu](https://i.imgur.com/whwEwKh.png "Extracting on yuzu")<br>
**Do note that yuzu does not create the "Data" folder between "romfs" and "StreamingAssets" and you will need to create it yourself before loading the files in the editor.**<br>

In all cases, the files will be found where your emulator dumped the files. **The editor expects the folder structure "\<directory\>/Data/StreamingAssets/...". Make sure to replicate it properly before loading it.** After the changes have been exported, only use the edited files and follow the many tutorials online for modding your Nintendo Switch games. Make sure that the folder structure is correct (Data/StreamingAssets/...).

Currently, as of version 1.0, the editor edits the following files:
- Script editor
  - "/Data/StreamingAssets/AssetAssistant/Dpr/ev_script"

## Bugs
If you find any bugs please let me know! You can use the issues tab of the repository.

## Dependencies
This project uses the [AssetsTools.NET](https://github.com/nesrak1/AssetsTools.NET/) library to easily manipulate Unity Asset Bundles.<br>
This project uses the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) library to read JSON files containing useful data for the program.<br>
This project uses the [Windows-API-Code-Pack](https://github.com/contre/Windows-API-Code-Pack-1.1) library for a better folder selection dialog.
