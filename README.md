Dungeon Teller - The Third Reboot
=========
By demon1ak

Credit to  Aethereal


---------
___

SEE mobile app, should work from android 2.2 + : https://github.com/demon1ak/mqtt-android2.2-froyo-dungeonteller/releases/download/0.0.0.1/dungeonteller.tgz




Dungeon Teller is a simple tool that monitors your dungeon, scenario, raid, battlefield and arena queus in World of Warcraft (WoW).
___

**Current Status**

    - PvE (mostly) working as intended
    - PvP only briefly tested - if anyone wants to confirm this is working ok then that would be great (specifically Arenas & Rated BGS)
    - Only the default options have been tested - currently the status of notifications, emails etc. is unknown
    *** Updating has been disabled at the moment while I implement a solution; offsets are still read from offsets.xml ***

**Known Issues**

    - Scenario queue is broken - this will be implemented at a later stage
    - DBC reading is broken - a fudge has been implemented in the meantime (dumped dbcs; should be complete)
    - Queueing for multiple PvE instances is not handled as nicely as PvP, but this is due to the WoW client and cannot be helped :(
    - Code is ugly and needs reworking - but at least it's currently operational ^^
    
**TODO**

    - Implement Scenario Queues (High priority)
    - Clean up code; remove unused stuff etc. (Low priority)
    - Implement Updates system (Medium priority)

___

How To Use
----------

- Download latest revision from this repo (if you don't have git, click Download Zip to the right on the main page of this repo)
- Either:
    - Open the Precompiled Binaries directory and run Dungeon Teller.exe as admin
    - or, open the src directory and compile it yourself (recommended)

Current Supported Build
----

5.4.7.17956 (Live)

Credits
-----------

* [Jazerix] - The original author of Dungeon Teller; created the project in 2010
* [Siriuz] - Rebooted and continued to update Dungeon Teller for ages; released the source
* [Ownedcore Memory Editing Section] - one of the most amazing resources to learn memory editing; awesome people
* Anyone else I forgot - sorry!

___

**License**

Free, do whatever you want, as long as you give credit :)

[Jazerix]:http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/305710-dungeon-teller.html
[Siriuz]:http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/397465-dungeon-teller-lfr-lfd-queue-assistant.html
[Ownedcore Memory Editing Section]:http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/    
