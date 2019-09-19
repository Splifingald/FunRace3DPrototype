# FunRace3DPrototype

Prototype réalisé sous Unity 2018.3.12f

Compatible avec Android

Même si cela n'est pas d'usage, j'ai conservé le Build du jeu au format .apk pour que tu puisses le tester directement sur téléphone.

Ceci est une première ébauche, je continuerai surement le développement en début de semaine prochaine, à moins que cela ne soit suffisant.

# Temps consacré et commentaires

J'ai mis 2h30 pour réaliser ce jeu
Voici une répartition approximative du temps que j'ai passé sur les différents aspects du jeu, chacun comprennant une partie dédiée au test des fonctionnalités.

Analyse du jeu Fun Race 3D : 10 minutes

J'ai simplement téléchargé le jeu et joué en essayant de noter les aspects les plus importants du jeu, j'ai décidé de laisser de côté l'aspect multi-joueur.

Déplacements du personnage et de la camera : 45 minutes

Le personnage se déplace de point en point, la camera suit le joueur.
Une autre méthode aurait pu être d'utiliser un NavMesh (ce qui permettrait de gagner du temps au niveau du paramétrage) et un agent de navigation sur le joueur, celui-ci aurait pu se déplacer automatiquement d'un point à un autre du niveau (avec I.A.). Cependant il ne serait pas nécessairement resté au centre du chemin pendant ses déplacements et l'utilisation d'algorithmes de path-finding est plus coûteuse que d'écrire les positions en dur.

Déplacement des obstacles : 20 minutes

Les obstacles peuvent se déplacer suivant une liste de positions et peuvent tourner sur eux mêmes.
Ici, de nombreuses améliorations restent à faire, on peut imaginer des obstacles en rotations qui n'effectuent pas forcement de révolutions complètes et qui, de la même manière que pour les positions, suivent une liste de rotations.

Détection des collisions : 15 minutes

Lorsque le joueur touche un obstacle, il retourne au "checkpoint" précédent (pas nécessairement à la ligne de départ).

Animation : 35 minutes

J'ai récupéré un asset sur l'asset store Unity pour le personnage, j'ai réalisé un nouvel Animator avec les animations données car l'Animator donné est plus complexe. J'ai effectué les appels correspondant dans le script du joueur et modifié la position de la caméra à l'arrivée.

Management des scènes : 5 minutes

Sur cette version il n'y a qu'une scène disponible, et le niveau recommence en boucle après l'animation d'arrivée.

Level design : 20 minutes

Comprend la création du sol et des obstacles ainsi que le paramétrage de ces divers objets.

# Problèmes rencontrés

Pour l'instant aucun point ne m'a réellement posé de difficultés, mais je pense avoir perdu un peu de temps sur le déplacement du personnage lorsque j'ai fait quelques essais avec les NavMesh.
Le fonctionnement de la camera est très basique et il aurait peut-être été plus simple de la mettre directement en enfant du joueur. De plus, j'utilise "transform.LookAt()" sur la camera pour que celle ci regarde le joueur, cela a pour effet de le placer au centre de l'écran, cependant, étant donné que le joueur ne peut pas aller en arrière il lui est inutile de voir aussi loin derrière lui.

# Pour aller plus loin

- Ajouter des patterns sur le sol, pour aider le joueur à repérer les éléments dans l'environnement 3D. L'appréhension de la profondeur pouvant être difficile.
- Un niveau permettant de réellement se rendre compte des possibilités offertes par ma classe "Obstacle" avec des obstacles ayant des mouvements plus élaborés.
- Améliorer la classe "Obstacle" notamment au niveau des rotations et peut être, ajouter d'autres types de mouvements.
- Comme dans le jeu de base, réaliser une barre de progression en haut de l'écran, cela renforce le sentiment d'avancement du joueur et l'aide à continuer malgré les potentiels échecs.
- Ajouter d'autres objets obstacles de différentes formes.
- Améliorer l'environnement du jeu (Skybox, matériaux, plateformes, obstacles, animations, sons).
- Et bien d'autres choses auxquelles je n'ai pas encore eu le temps de penser.

# Conclusion
Je pense avoir répondu aux problématiques principales qui étaient posées dans un temps très restreint. Je n'ai pas trouvé l'exercice trop difficile mais cela m'a tout de même demandé un peu de réflexion. 
Ceci est une première ébauche, je continuerai surement le développement en début de semaine prochaine, à moins que cela ne soit suffisant.
