# MasterProject# MasterProject: 
### What are the behaviourial changes of NPC's in a simulation environment set by the player?
In dit project is mijn doel om onderzoek te doen rond hoe de speler een effect kan hebben op een simulatie door de speler bepaalde variabelen te laten bepalen en hoe ik dit allemaal kan gebruiken voor een leuke demo game.

#### Prototype 1: Movement towards object or other NPC
In mijn eerste prototype ging het vooral om er voor te zorgen dat de NPC een beslissing zou maken tussen het bewegen naar een andere NPC of eerst naar een object en dan pas naar een NPC.

Dit gebruik ik als een rudimentaire prototype waar ik later op kan verder werken door middel van *Weights*. 

Ik maak gebruik van de Unity Asset: NavMeshComponents. Dit is een meer advanced NavMeshComponent, waar ik de NavMesh in runtime mee kan aanpassen, speciale zones kan aanpassen
en deze ook tijdens runtime aanpassen indien nodig.

* *Weights is een term gebruikt om aan te tonen hoe belangrijk een actie is voor een AI. In mijn geval gaat de AI weights gebruiken om te beslissen welk object het beste voordeel geeft*.

Om deze beslissing te laten maken heb ik moeten zoeken naar een bepaalde formule. Uiteindelijk kwam ik zo op de volgende formule dat de NPC zou gebruiken om naar de dichtsbijzijnde NPC te gaan:

**(NearestNPC_Health / (damage * multiplier * attackSpeed) + (distanceNearestNPC / 7)) - (NearestNPC_Health / (damage * multiplier * attackSpeed) + (distanceNearestObject + distanceNearestNPC / 7)) > 15**

De getallen 7 en 5 zijn magic numbers die ik op dit moment gebruik om de volgende redenen: 
- De NPC heeft een speed van 8 en heb uitgerekend dat door deze speed de NPC 7 units of distance behaald per seconde.
- Het getal 5 is gewoon een minimum verschil dat ik verwacht voordat de NPC voor het Object zou gaan.
#### Prototype 2: Interactable Object System