# FunRace3DPrototype

Prototype réalisé sous Unity 2018.3.12f

Compatible avec Android

Même si cela n'est pas d'usage, j'ai conservé le Build du jeu au format .apk pour que le jeu puisse être testé directement sur téléphone.

J'ai passé un total de 4h30 sur le développement de ce prototype.

# Testez en ligne

La version sur ce git hub correspond à mes 4.5 premières heures de développement, mais je n'étais pas totalement satisfait de moi-même et le sujet m'a plu donc j'ai continué, vous pouvez suivre le résultat actuel sur cette page : https://splifingald.itch.io/skyrace

# Temps consacré et commentaires

Voici une répartition approximative du temps que j'ai passé sur les différents aspects du jeu, chacun comprennant une partie dédiée au test des fonctionnalités.

Analyse du jeu Fun Race 3D : 15 minutes

J'ai simplement téléchargé le jeu et joué en essayant de noter les aspects les plus importants du jeu, j'ai décidé de laisser de côté l'aspect multi-joueur qui selon moi nécessite bien plus de temps.

Déplacements du personnage et de la camera : 1 heure

Le personnage se déplace de point en point, la camera suit le joueur. J'utilise ces points comme "check points".
Une autre méthode aurait pu être d'utiliser un NavMesh (ce qui permettrait de gagner du temps au niveau du paramétrage) et un agent de navigation sur le joueur, celui-ci aurait pu se déplacer automatiquement d'un point à un autre du niveau (avec I.A.). Cependant il ne serait pas nécessairement resté au centre du chemin pendant ses déplacements et l'utilisation d'algorithmes de path-finding est un peu plus coûteux.

Déplacement des obstacles : 30 minutes

Les obstacles peuvent se déplacer suivant une liste de positions et peuvent tourner sur eux mêmes ou changer de scale progressivement. (Bien que cette dernière fonctionnalité n'était pas présente dans les premiers niveaux de Fun Race 3D).
Ici, de nombreuses améliorations restent à faire, on peut imaginer des obstacles en rotations qui n'effectuent pas forcement de révolutions complètes et qui, de la même manière que pour les positions, suivent une liste de rotations.
J'ai souhaité pouvoir intervenir sur les trois composantes principales de la transform mais les possibilités restent limités avec mes scripts.
Lorsque le joueur touche un obstacle, il retourne au "checkpoint" précédent.

Animation : 35 minutes

J'ai récupéré un asset sur l'asset store Unity pour le personnage, j'ai réalisé un nouvel Animator avec les animations données car l'Animator donné est plus complexe. J'ai effectué les appels correspondant dans le script du joueur et modifié la position de la caméra à l'arrivée.

Management des scènes : 15 minutes

Sur cette version il y a trois scenes disponibles, le menu général, le premier niveau et le deuxième niveau qui bouclent entre eux. Le management des scenes correspond au passage d'une scene à l'autre et à la sauvegarde du dernier niveau commencé dans les préférences joueur.

Level design : 30 minutes

Comprend la création du sol et des obstacles ainsi que le paramétrage de ces divers objets sur deux niveaux.

Barre de progrès : 30 minutes

J'ai utilisé les sliders pour afficher le progrès du joueur sur la barre supérieure.

Menu principal : 15 minutes

Affichage de deux boutons permettant de commencer le jeu ou de quitter. Si le jeu a déjà été commencé, le joueur reprendra au début du dernier niveau commencé.
Ajout d'un bouton permettant de revenir au menu sur les scènes de jeu.

Builds, tests sur téléphone et résolution de bugs : 40 minutes

Les builds sont assez longs et ça n'est pas vraiment une réalisation en soit, mais c'était nécessaire pour tester l'application correctement. C'est pour cette raison que cette partie est aussi longue.

# Problèmes rencontrés

Je pense avoir perdu un peu de temps sur le déplacement du personnage lorsque j'ai fait quelques essais avec les NavMesh.
Je pense que la partie déplacement du joueur et déplacement de la caméra n'est pas tout à fait identique à ce que l'on peut voir dans le jeu de base, mon joueur effectue des angles droits quand il tourne et dans le jeu de base la caméra peut changer complétement de position entre les différentes phases d'un niveau. Ayant déjà passé beaucoup de temps sur cette partie, j'ai préféré conserver des systèmes plus simples et faire le reste.

# Pour aller plus loin

- Améliorer la gestion des mouvements et de la camera.
- Ajouter des patterns sur le sol, pour aider le joueur à repérer les éléments dans l'environnement 3D. L'appréhension de la profondeur pouvant être difficile.
- Ajouter des traits sur la barre de progrès permettant de voir les check points. (Bien que ça ne soit pas dans le jeu de base)
- Améliorer la classe "Obstacle" pour avoir plus de possibilités, notamment au niveau des rotations ou encore pour ne pas être obligé d'avoir une vitesse constante.
- Ajouter d'autres objets obstacles de différentes formes.
- Améliorer l'environnement du jeu (Skybox, matériaux, plateformes, obstacles, animations, sons).

# Pour aller encore plus loin
- Générer des niveaux procéduralement (je suis très fan de génération procédurale, donc à choisir, je ferai cela en premier)
- Ajouter le multi-joueur
- Ajouter la possibilité de jouer contre des I.A. ou contre des versions précédentes du parcours du joueur
- Ajouter d'autres types de déplacements (sauter, glisser, s'accroupir...)


# Conclusion
Je pense avoir répondu aux problématiques principales qui étaient posées dans un temps très restreint. Je n'ai pas trouvé l'exercice trop difficile mais cela m'a tout de même demandé un peu de réflexion. 
Je vais surement continuer de créer quelques niveaux de mon côté et poster le jeu sur ma page itch.io.
Pendant toute la durée de l'exercice, j'ai essayé de réaliser des systèmes réutilisables pour facilier la création de niveaux.
