# CabinLosingPressure

You are an emergency response AI, being trained to handle simulated emergencies during space travel. Manage a group of randomly generated astronauts through a crisis of depressurization as your hull is breached by asteroids.

Summary:

You're an emergency protocol AI being trained to manage a spaceship during a major crisis in transit and get your astronauts home alive safely and quickly. Your ship is being hit by asteroids, the hull is getting cracked and cabin pressure is falling as you lose air.

Different rooms when manned by an astronaut will provide you with different benefits (man the engines and you'll go faster, have someone on the bridge and you'll get an earlier warning of where the asteroids will hit, etc), but you only have so many astronauts so you can't have them all manned at once.

Your astronauts will have randomly generated traits and skills (you're being trained to handle a variety of potential scenarios after all) and could potentially lose faith in you and just stop working.

Each round, when you lose, you're put back into the same scenario as before, but your time limit is increased. Your score ends up determined by what your max time limit was.

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
  * Rooms that take damage will leak air and eventually become inoperable
* Astronauts possess randomly generated traits that affect what jobs they are most effective in.
  * Job: Will give the astronaut a skill at a particular task, such as repair, piloting, or enhancing the engine
  * Randomly generated trait, flaw, and/or conditions that affect their skills in other areas, such as movement speed or non-job tasks.
  * Trust: If it falls low enough, the astronaut will collapse and be unable to act for a time.
  * Astronauts in a room when it gets hit will take damage and potentially die.

Known issues 8/21:
  * Only one Astronaut and one door.
