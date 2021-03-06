# MasterProject# MasterProject: 
## What are the behaviourial changes of NPC's in a simulation environment set by the player?
In dit project is mijn doel om onderzoek te doen rond hoe de speler een effect kan hebben op een simulatie door de speler bepaalde variabelen te laten bepalen en hoe ik dit allemaal kan gebruiken voor een leuke demo game.

### Prototype 1: Movement towards object or other NPC
In mijn eerste prototype ging het vooral om er voor te zorgen dat de NPC een beslissing zou maken tussen het bewegen naar een andere NPC of eerst naar een object en dan pas naar een NPC.

Dit gebruik ik als een rudimentaire prototype waar ik later op kan verder werken door middel van *Weights*. 

Ik maak gebruik van de Unity Asset: *NavMeshComponents*. Dit is een meer advanced NavMeshComponent, waar ik de NavMesh in runtime mee kan aanpassen, speciale zones kan aanpassen
en deze ook tijdens runtime aanpassen indien nodig.

* *NavMeshComponents zijn componenten die van Unity zelf die je kan gebruiken via de Unity.AI namespace. Deze maakt van je level een plattegrond en zorgt ervoor dat objecten afgelijnd zijn en ook dynamisch afgelijnd kunnen worden tijdens beweging. Deze plattegrond wordt dan gebruikt door de KI die dan de A\* pathfinding methode gebruikt om zo het efficientste pad te zoeken naar zijn doel.*

* *Weights is een term gebruikt om aan te tonen hoe belangrijk een actie is voor een KI (Kunstmatige Intelligentie). In mijn geval gaat de KI weights gebruiken om te beslissen welk object het beste voordeel geeft*.

Om deze beslissing te laten maken heb ik moeten zoeken naar een bepaalde formule. Uiteindelijk kwam ik zo op de volgende formule dat de NPC zou gebruiken om naar de dichtsbijzijnde NPC te gaan:

**(NearestNPC_Health / (damage * multiplier * attackSpeed) + (distanceNearestNPC / 7)) - (NearestNPC_Health / (damage * multiplier * attackSpeed) + (distanceNearestObject + distanceNearestNPC / 7)) > 15**

De getallen 7 en 5 zijn magic numbers die ik op dit moment gebruik om de volgende redenen: 
- De NPC heeft een speed van 8 en heb uitgerekend dat door deze speed de NPC 7 units of distance behaald per seconde.
- Het getal 5 is gewoon een minimum verschil dat ik verwacht voordat de NPC voor het Object zou gaan.

Door deze formule kan ik de NPC al zelf bepalen wat een betere keuze is, door de vergelijking te maken van hoe lang het duurt om de andere NPC's te doden.
Hieronder zijn drie scenario's die een visueel beeld geven over wat er gebeurd.

**Scenario 1: Afstand van de NPC is kleiner dan het object en de multiplier is te laag om invloed te hebben.**
![Scenario 1](MP4s_IMGs/Scenario1.gif)

**Scenario 2: Afstand van de NPC is groter dan het object en de multiplier is goed genoeg om invloed te hebben.**
![Scenario 2](MP4s_IMGs/Scenario2.gif)

**Scenario 3: Afstand van de NPC is kleiner dan het object en de multiplier is goed genoeg om invloed te hebben.**
![Scenario 3](MP4s_IMGs/Scenario3.gif)

### Prototype 2: Interactable Object System

In deze prototype is het de bedoeling dat ik een systeem ontwerp die ik later kan laten werken met een UI systeem zodat de speler tijdens de runtime een Interactable Object kan aanmaken en deze dan door het spel gebruikt kan worden.

Hiervoor moest ik op voorhand beslissen welke gegevens belangrijk zijn om mee te geven aan het systeem en welke scripts ik nodig ga hebben. De structuur die ik dan heb gekozen is de volgende:

* Interactable Object Manager: Dit script gaat er voor zorgen dat alles ordelijk in een lijst terecht komt afhankelijk van het type van Interactable Object (hier komt meer later over). Deze lijsten worden opgevuld met Scriptable Objects.

  * Interactable Object ScriptableObject: Dit script is de basis van de Scriptable Object die ik in de Object Manager steek. Hier kan ik gegevens aan doorgeven die het Object zelf later gaat kunnen lezen.
  
    * Interactable Object Controller: Dit script beheert het Object zelf. Hierin zit de belangrijke functionele code die ervoor zorgt dat het Object veranderd afhankelijk van de gegevens.
    
       * Interactable Object: Dit is het 3D - model van het Object. Deze wordt volledig beinvloed door bovenstaande code en wordt gegenereerd via het ScriptableObject.

Zoals eerder aangehaald zijn er verschillende Interactable Object Types. Deze zijn: Powerup en Upgrade. Beide kunnen een ander effect hebben op de NPC. Voor dit prototype kan de - Powerup dienen als: Health of Speed boost. 
- Upgrade dienen als: Armor of Weapon upgrade.

De Interactable Objects kunnen ook op drie verschillende grootes zitten:
- Small (Groen)
- Normal (Rood)
- Big (Blauw)

Dit dient om aan te tonen welke NPC's kunnen interacten met welk Interactable Object. Dit is aan te tonen door de kleur van het model.

**Interactable Object Manager**

![Interactable Object Manager](MP4s_IMGs/IOM.png)

**Interactable Object ScriptableObject**

![Interactable Object ScriptableObject](MP4s_IMGs/IOSO.gif)

**Interactable Object Controller**

In de afbeelding hieronder kan je zien dat het geselecteerd object zich onder de InteractableObjectManager plaatst. Dit object neemt als model referentie de prefab: InteractableObjectReference die ook te zien valt in de hierarchy. In de Scene kan je zien welk object geselecteerd is en welke kleur het heeft. Tenslotte in de Inspector kun je zien dat de Interactable Object Controller de gegevens van de ScriptableObject heeft overgenomen. De groote van dit object is Big dus is de material kleur ook blauw.
![Interactable Object Controller](MP4s_IMGs/IOC.png)

Dit systeem kan ik nu ook gebruiken om de NPC's.

### Prototype 3: NPC Object System

Mijn NPC Object werkt soort gelijk aan mijn Interactable Object Systeem. Er is een NPC Object Manager die een lijst bijhoudt van alle mogelijke NPCs. Deze NPCs worden gegenereerd door een Scriptable Object asset en daarna worden deze gegevens door gegeven aan de NPC Object Controller.

In deze prototype gaat het niet over de beweging van de NPCs dus heb ik deze ook niet expliciet getest. De volgende stap na deze prototype is het samenzetten van de vorige drie systemen om een volledige demo op te zetten. Daarna kan ik deze demo testen via een playtesting sessie. 

**NPC Object Manager**

![NPC Object Manager](MP4s_IMGs/NOM.png)

**NPC Object ScriptableObject**

![NPC Object ScriptableObject](MP4s_IMGs/NOSO.png)

**NPC Object Controller**

![NPC Object Controller](MP4s_IMGs/NOC.png)

Aan deze screenshots kan je merken dat het NPC Object Systeem gelijk is aan het Interactable Object Systeem.

### Uitleg: Waarom Scriptable Objects & Demo 01?

Ik gebruik Scriptable Objects voor mijn NPC en Interactable Objecten omdat ik deze via runtime kan laten genereren door de speler via een UI systeem. Dit moet natuurlijk getest worden tijdens Demo 01. Om dit te kunnen doen ga ik een UI systeem moeten maken met verschillende knoppen en input velden, waar de speler gegevens kan ingeven om zo een aantal NPC's en Interactable Objecten te laten genereren in de spel wereld.

Demo 01 zal dan ook bestaan uit de voorgaande prototypes die dan ook met elkaar gaan werken. Concreet gezegd gaat de playtester deze NPCs en Interactables kunnen aanmaken tijdens runtime en nadien op een speel knop kunnen drukken. Als op deze speel knop wordt gedrukt zullen alle NPCs en Interactables in de genereren en gaan de NPCs naar de Interactables bewegen of naar andere NPCs en deze doen verdwijnen. Dit gaat zo door tot er 1 NPC overblijft. Deze demo is niet gebaseerd op de gameplay elementen, maar eerder op de technische elementen en als deze op een interessante of intuitieve manier samenwerken. 

***Als er iets zou mislopen vang ik de errors op via een Try-Catch systeem en laat ik de scene herstarten zodat de speler gewoon verder kan testen.***

**Demo 01 Flowchart**

![Demo 01 Flowchart](MP4s_IMGs/DEMO01.png)
