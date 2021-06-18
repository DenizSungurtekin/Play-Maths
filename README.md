# Play-Maths


L’objectif de ce projet est de créer une application permettant à de jeunes utilisateurs de s’exercer aux calculs
mentaux de manière ludique. L’idée est de concevoir un jeu relaxant s’adaptant à certains signaux biologiques
du joueur afin de trouver une évolution de la difficulté optimale pour permettre un meilleur apprentissage. Le
système demandera donc à l’utilisateur de résoudre une série d’équations devenant de plus en plus complexe
selon les signaux perçus.

<br/><br/>
![git](https://user-images.githubusercontent.com/43375040/122575949-80fe2600-d051-11eb-9414-b9a30cdd8f8a.png)
<br/><br/>

L’émotion qui nous intéresse est le stress, nous avons donc jugé pertinent de mesurer le rythme cardiaque
de l’utilisateur et son activité électrodermale qui capte la variation électrique de la conductivité de la peau en
réponse à la sécrétion de sueur.

Par conséquent, nous avons donc décidé d'utiliser le matériel d’acquisition suivant:
- Bitalino
- The bitalino revolution ecg sensor
- The bitalino electrodermal activity sensor

Le jeu a été devellopé avec Unity et l'acquisition et le traitement des données a été fait en python (/Code/Assets/Scripts).
Vous trouverez une description complète du système et le résultat des expériences effectuées dans le fichier pdf "Report".

Pour jouer au jeu, il vous faudra:
- Vous munir du Bitalino et les deux capteurs cités.
- Cloner le repository.
- Lancer le signalManager.py.
- Lancer l'exécutable sous /Build/PlayMaths.exe.

Une démonstration complète du fonctionnement de l'application est disponible sous: /Demo.mp4

Après au moins quatre parties, il est possible de plot les données des quatre dernières parties du joueur en lançant le script python sous /Build/dataPlot.py.
Il est également possible de consulter nos propres données en lancant le script /dataPlot.py directement. 





