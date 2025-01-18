![The Qwest logo](https://i.ibb.co/YN2sLRT/the-qwest.png)

[![forthebadge](http://forthebadge.com/images/badges/built-with-love.svg)](http://forthebadge.com)  [![forthebadge](http://forthebadge.com/images/badges/powered-by-electricity.svg)](http://forthebadge.com)

Ce projet est une implémentation d'un jeu de rôle (JDR) développé en C#, contenant des classes, des ressources et un exécutable principal. Voici une vue d'ensemble pour vous guider dans l'installation, l'exécution et la personnalisation du jeu.

Liste base : 

    Un héro :
    - Point de vie (+-20PV)
    - Une attaque
    - Stat de défense (Réduction de dégat)

    Une map : 
    - Différents environnement (Forêt, prairie) (purement graphique)
    - Une zone de boss (ou deux)
    - Un endroit de spawn (respawn)

    Au moins 3 ennemis (par zone) et 1 boss:
    - Point de vie
    - Une attaque
    - Stat de défense

    Fontaine de vie :
    - Rend entre 5 et 15 PV
    - Visible sur la map
    - Placé aléatoirement sur la map
    
    Coffres
    - Bonus d'attaque (Différents types d'arme (Hache, épée, bois, bronze, or))
    - Bonus de défense (Type d'armure (Fer, tissu, cuir ..))


## <ins>Pour commencer</ins>

### <ins>Pré-requis</ins>

Avant de commencer, assurez-vous d'avoir installé les outils suivants :

.NET 8.0 SDK ou version ultérieure : Requis pour compiler et exécuter le projet.

Téléchargez-le depuis : https://dotnet.microsoft.com/

Un éditeur de code : Par exemple, Visual Studio ou Visual Studio Code.

### <ins>Installation</ins>

Clonez ce dépôt ou téléchargez-le sous forme d'archive ZIP :

git clone <https://github.com/ArnaudClarat/JDR.git>
cd JDR

Restaurez les dépendances avec le gestionnaire .NET si nécessaire :

dotnet restore

## <ins>Démarrage</ins>

Pour lancer le jeu, exécutez simplement la commande suivante :

dotnet run

Cela démarrera le programme principal défini dans Program.cs.

## <ins>Fabriqué avec</ins>

* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Framework front-end basé sur C#  
* [Blazor Web Assembly](http://materializecss.com) - Framework CSS (front-end)
* [Visual Studio Code](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Exécution d'applications web côté client avec .NET  

## <ins>Auteurs</ins>

* **Anthony Chang** _alias_ [@changzhiho](https://github.com/changzhiho)
* **Arnaud Clarat** _alias_ [@ArnaudClarat](https://github.com/ArnaudClarat)
* **Kévin Goossens** _alias_ [@KGOx](https://github.com/KGOx)
* **Enzo Scarpa** _alias_ [@enzoscarpa-fnk](https://github.com/enzoscarpa-fnk)

## <ins>Etapes de création du projet</ins>

**<ins>Bases du jeu :</ins>**

* Création d’un plateau de jeu (map) avec une grille simple de 10x10
* Création d’un héros qui peut se déplacer sur la map (avec sprite d’animation)
* Création d’une fontaine de vie pour soigner le héros


**<ins>Module de combat :</ins>**

* v1.0:
    * Ajout d’une classe Character:
    * Ajout des propriétés de base (niveau, expérience, PV…)
    * Ajout de méthodes de base (attaque, prise de dégât, soin, mort…)
* Ajout des classes Hero_Mage et Hero_Warrior (héritent de Character)
* Ajout d’une interface pour les combats

* v2.0:
    * Ajout d’un composant Console pour afficher les informations de combat directement dans l’UI 

* v3.0:
    * Ajout d’un système de progression de niveau
    * Ajout d’un système de calcul des statistiques du héros
    * Ajout de monstres + méthode de calcul du niveau du monstre en fonction du niveau du héros
    * Abandon prévu du mode PvP (test) pour un mode PvE (final)

* v4.0:
    * Introduction de la map avec le système de combat
    * Introduction des méthodes de déplacement du héros
    * Introduction des méthodes d’interactions avec les entités
    * Introduction des méthodes pour gérer la fin de partie
    * Modification de l’héritage en insérant une classe Hero entre Character et les différentes classes de héros
    * Ajout de sorts spécialisés pour le Mage

* v5.0:
    * Ajout de la gestion du module de combat (trigger), affiche/retire le module en fonction de l’état de combat du héros
    * Ajout de propriétés principales (Endurance, Force, Esprit…) et secondaires (Hâte, Chance de critique…)
    * Redéfinition de méthodes spécialisées pour le héros prenant en compte les nouvelles propriétés
    * Introduction d’une classe Item prévoyant l’ajout de stats au héros grâce au bonus d’objets

* v6.0:
    * Ajout d’une méthode de fuite
    * Redéfinition des calculs de statistiques pour le levelling
    * Intégration de concepts tels que la régénération d’énergie (en combat/hors combat), la hâte (détermination du premier attaquant), l’esquive, l’ajout de stats bonus par l’équipement


**<ins>Map :</ins>**

* Ajout d’une classe et d’un composant Map pour simplifier la gestion du fichier Home
* Déplacement des propriétés et méthodes de la map dans sa classe
* Déplacement de la gestion de l’affichage et des interactions de la map dans son composant
* Intégration du composant de la map dans le fichier Home
* Ajout de gestionnaires d’évènement pour le dialogue entre les composants


**<ins>Trésors & Objets :</ins>**

* Ajout d’une classe Trésor pour gérer le comportement des trésors sur la map
* Ajout des classes Armure et Arme pour pouvoir équiper le héros grâce aux trésors trouvés
* Ajout de propriétés et de méthodes pour les armes et armures afin de déterminer leur rareté et leur performance grâce à des calculs de probabilité


**<ins>Fichier Home :</ins>**

* Ajout d’un module de création de personnage en début de partie (nom, classe)
* Ajout d’un module d’affichage des stats du héros
* Ajout d’un module d’affichage de l’inventaire du héros


**<ins>Fonctionnement du jeu :</ins>**

* Passage d’un système de tour par tour au lieu d’un système en temps réel pour les combats


**<ins>La suite? :</ins>**

* Balance du jeu
* Tootltips sur les objets
* Habillage graphique évolué
* Habillage audio
* Ajout d’un système de portes/téléporteurs pour passer d’une map à une autre (avec d’autres monstres, boss, trésors, quêtes…)
* Intégration de NPCs permettant des interactions diverses (commerçant, donneur de quêtes) avec des dialogues dédiés
* Ajout d’une trame basique avec une quêtes principale et quelques quêtes secondaires
* Transformer les modules de combat, de stats héros, et d’inventaire en composant
* Ajout de niveaux de difficultés basés sur un facteur pour certaines propriétés des monstres et du héros
* Ajout d’animations de combat
* Génération de maps procédurales plus complexes de manière pseudo-aléatoire (normal maps, height maps, Perlin noise…)


<ins>last edited by FNK on 2025/01/18</ins>
