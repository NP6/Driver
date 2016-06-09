# JAVA Driver

Ceci est le driver permettant d'utiliser l'API de NP6

/!\ Le projet est encore en développement /!\

N'hésitez pas à signaler tout problème ou poser une question sur GitHub

## Documentation
- [Documentation et exemples du driver basique diponible ici](./src/main/java/route/LISEZMOI.md)
- [Documentation et exemples de l'implemantation du driver ici](./src/main/java/implementation/LISEZMOI.md)

## Tests

Pour lancer les tests il suffit de lancer les commandes suivantes:

```
$> sudo npm install -g apimocker
$> apimocker -c ./mocks/config.json
```

Une fois le server de test lancé, il suffit de lancer les test avec JUnit ou depuis votre IDE.