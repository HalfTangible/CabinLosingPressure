# CabinLosingPressure

You are an emergency response AI, being trained to handle simulated emergencies during space travel. Manage a group of randomly generated astronauts through a crisis of depressurization as your hull is breached by asteroids.

Planned features:
* Each round has a time limit to rescue the astronauts
  * If the player fails, the mission restarts, but with a longer time limit.
  * The maximum time limit of the final round is your score. 
* Asteroids will randomly hit the ship, causing air to leak from the vessel.
  * Room will signal a warning when the ship is about to be hit.
* Rooms with various functionality
  * Rooms have air that moves between them based on which airlocks are open or shut.
    * (take a cue from FTL and add a red filter on rooms as they lose air?)
  * Rooms will provide benefits to your astronauts (IF an astronaut is in them) until they take enough damage
    * Bridge: Grants chance to dodge incoming asteroids.
    * Medbay: Allows astronauts to heal.
    * Maintenance: Contains tools that will allow Astronauts to repair the ship (at all, or more quickly?)
  * Rooms that take damage will leak air and  
* Astronauts possess randomly generated traits that affect what jobs they are most effective in.
  * Job: Will give the astronaut a skill at a particular task, such as repair, piloting, or enhancing the engine
  * Randomly generated trait, flaw, and/or conditions that affect their skills in other areas, such as movement speed or non-job tasks.
  * Trust: If it falls low enough, the astronaut will collapse and be unable to act for a time.
  * Astronauts in a room when it gets hit will take damage and potentially die.
 
Current blockers:
  * Implement 2D navmesh
    * Select and move astronauts on the mesh.
  * Select doors and open/close them.
