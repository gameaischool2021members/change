# CHANGE

## Team Members
- LJ Arendse (@LJArendse) 🇿🇦
- Christian Cecconi (@ChristianCecconi) :it:
- Anna Dollbo (@dollbo) 🇸🇪
- Björn P Mattsson (@Plankton555) :sweden:
- Vladyslav Ieliashevskyi (@vieliashevskyi) :ukraine:

## What is CHANGE?
**C**ollaborative **H**uman **A**I **N**PC **G**ame **E**nvironment - is a testbed for development of Human-AI collaboration inside sandboxed game environment.
Each of the presented environments enforces dependency on the AI-companion agent. In other words, the human needs the help of the AI agent to proceed. Furthermore, each problem solving collaborative game environment has:
* A shared global goal between the human and agent, and
* Enforces collaboration between the human and AI agent, thus ensuring collaboration over optional cooperation
 
In terms of solving effort, the human player is the leader and the AI agent is the companion assistant that tries to anticipate human intent, without any additional cues: vocal or action-based (e.g: mouse click), only based on environment observations.

The main goal is to teach a companion agent to _anticipate_ player desires, without direct communication and other cues, simply based on player actions.
* Players can progress to the next level only if the AI-agent can correctly predict player intent whilst minimising the number of actions taken.
  * The AI-agent plays an assistant (supportive/companion) role
  * The human player is the problem solving lead - leading the problem solving effort.
* Our gym environments aim to **enforce** collaboration, and eliminate options to win using _optional collaboration_
  * This is achieved by the level design and by placing movement constraints on the human player
  * Levels are built using 'intention based challenges' in mind
* World state observer confirms victory conditions based on actions performed by human player using standard game logic

### Why Companion Agents?
Cooperation between human agents and artificial intelligence is a topic of great scientific interest, especially due to its complexity, in particular for the need to advance the AI natural-language understanding (Dafoe et al., 2021).

It has been pointed out that a team composed of an AI and a human agent is more efficient than a team composed of only humans, even if humans seem to have better opinions on human partners, considering them more pleasant and creative compared to AI (Ashktorab et al., 2020; McNeese et al., 2021).

Based on what has emerged, we believe that cooperation between humans and AI is the future, to be able to establish cooperation that allows us to achieve otherwise impossible goals, combining the qualities of the human being and the growing power of artificial intelligence.

Furthermore from a video game persepective, Non-player characters (NPCs) in games play a unique part in enriching player experience.
Oftentimes NPCs play a supportive or companion role to the player.
Creating believable companion AI agents is an important research effort since the entire
collaborative experience can be adversely affected if the companion agent cannot meet player expectation.

Current there are 4 collaborative domains centered around Human-AI team collaboration:

"Win, get cake?", "**Intent** and **Act**", "Escort human", and "TeamAI Dungeon"
![change_world](/images/inagame_combined.png )

## Required Software
* Unity 2020.2.1f1 or newer
* Unity ml-agents 0.27.0 or newer
* Python 3.8.8 or newer

### Getting Started with the environment
Setting up **Python**, **Tensorflow**, **Unity** and **Unity ML-agents** does not diviate from general installation requirements. 
Also, we have listed requirements for Python environment, that can be found under following path -> **<repo_path>/CHANGE/requirements.txt**

Our agent for the "**Anticipate an Intent** and **Act**" environment can be found inside -> **IntentPredictingAgent.cs** file. This is a file to head to in order to alter agent action space, observation and reward.

_We recommend to run environment on Windows machine to avoid issues with OMP that may occur on MacOS operated machines_

## Results
We were able to successfuly train an agent that based on his observations predicted Intent displayed by a human avatar. 
System was trained on a **Human-Proxy** which displayed random intents for bot to step on a certain target platform.
**Actions space was limited to:**
* Move Right
* Move Left
* Stand Still

Agent results during the training process ->
![Training Process](/images/learning-process.png)

And our Tensorboard -> 

![Tensorboard](/images/tensorboard.png)

And our final result ->
[**Intention Predicting Agent (Youtube)**](https://youtu.be/Ow2F_gQqLTE)

### Recomended Unity ML links
* [Unity ML agents](https://github.com/Unity-Technologies/ml-agents)
 * [ML agents overview](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/ML-Agents-Overview.md)
* [Unity ML getting started](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Getting-Started.md)
* [How to create a new environment in Unity ML](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Learning-Environment-Create-New.md)
 * [Environment examples](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Learning-Environment-Examples.md)

## Other collaborative game domains which inspired this project
* [Minidungeons](http://antoniosliapis.com/projects/project_minidungeons.php)
  * [Gameplay Video](https://www.youtube.com/watch?v=8aRxeA2KA5A)
* [Portal 2 co-op mode](https://www.youtube.com/watch?v=A88YiZdXugA)
* [Dearth](http://gambit.mit.edu/loadgame/dearth.php)
  * [Gameplay Video](https://www.youtube.com/watch?v=fpMt3xs2Y9s)
* Geometry Friends Coop Track
  * This game domain is from the "Conference on Games" (see https://ieee-cog.org/2020/competitions_conference and https://ieeexplore.ieee.org/document/7317949)
  * [Gameplay Video](https://www.youtube.com/watch?v=DBWUFRMw754)

## Inspirational Research on Human-AI Communication/Collaboration 
* Ashktorab, Z., Liao, Q. V., Dugan, C., Johnson, J., Pan, Q., Zhang, W., Kumaravel, S., Campbell, M. (2020) Human-AI Collaboration in a Cooperative Game Setting: * Measuring Social Perception and Outcomes. In Proceedings of the ACM on Human-Computer Interaction, 4(CSCW2), pp. 1-20. https://doi.org/10.1145/3415167
* Bansal, G., Nushi, B., Kamar, E., Horvitz, E., Weld, D. S. (2021) Is the Most Accurate AI the Best Teammate? Optimizing AI for Teamwork. In ArXiv, abs/2004.13102v3.
* Dafoe, A., Bachrach, Y., Hadfield, G., Horvitz, E., Larson, L., Graepel, T. (2021) Cooperative AI: machines must learn to find common ground. In Nature, 593(7857), pp. 33-36. doi: 10.1038/d41586-021-01170-0.
* McNeese, N. J., Schelble, B. G., Canonico, L. B., Demir, M. (2021) Who/What is My Teammate? Team Composition Considerations in Human-AI Teaming. In ArXiv, abs/2105.11000v1.
* Schelble, B. G., Flathmann, C., McNeese, N., Canonico, L. B. (2021). Understanding Human-AI Cooperation Through Game-Theory and Reinforcement Learning Models. In Proceedings of the 54th Hawaii International Conference on System Sciences | 2021. DOI:10.24251/HICSS.2021.041
