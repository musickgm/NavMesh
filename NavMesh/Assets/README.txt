Geoff Musick
CPSC 6820
3/11/20
Assignment 5: Tutorial on Character Animation or AI
Inspired by Unity Tutorial - Runtime NavMesh Generation

6 POINTS:
1) [1; 4:45] The last time I tried to use a NavMesh was about 4-5 years ago, possible before 5.6. If 5.6 was out 
at the time, it might have been so new tha the tutorial I did (which was way above my head at the time)
did not incorporate advanced NavMesh features like walking on walls/ceilings. This feature is news to me.
2) [2; 7:30] The baking options are really robust. Not only can you select between all/volume/children, you can 
also select specific layers. The volume option is interesting since you can expand or shrink the area you want
to bake. 
3) [2; 9:20] You can use advanced features in the nav mesh surface to have different surfaces (like a slow
mud area or something like that). 
4) [3; 4:30] Setting width on the nav mesh link to something really big (like 200) can help you visualize
valid links (white is valid). 
5) [4; 1:00] I learned that there is a UnityEngine.AI namespace. I bet there are all kinds of useful things
in that namespace!
6) [5; 3:30] You can bake navmeshes at runtime. This can be pretty applicable for destructable environments
and things of that nature. 
Bonus1) [5; 4:00] You can lock the inspector and shift click on items to auto-fill an array/list. This is huge
if you have a big list and do not want to populate it one object at a time. 
Bonus2) [6; 3:50] There isn't currently support for 2D unity assets. Though 3D objects can be used in a 2D scene
to make this work. 

THE CHANGE:
Portals between opposite  walls?
Multiple agent (current agent is the one closest to target?)
Collectables? Use coins from maze - make agents collect them?
Add UI with instructions, controls, etc. 


ISSUES & SOLUTIONS:



SOURCES:
Tutorial assets acquired from: http://bit.ly/navmeshunity
Unity tutorial (RuntimeNavMesh Generation) - https://learn.unity.com/tutorial/5c515372edbc2a002069505f
