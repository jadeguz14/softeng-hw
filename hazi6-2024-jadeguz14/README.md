[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/vF2nYsfs)

Mit biztosít a Strategy a DI mintával kombinálva a labor példa keretében, mik az együttes alkalmazásuk előnyei?
    Ahelyett hogy több konstruktorba lenne beégetve a különböző algoritmusok és progressek kombinációja, egy konstruktorba adjuk át paraméterben hogy milyen algoritmust milyen progressel szeretnénk futtatni. Ez biztosítja a rugalmasságot és a könnyű cserélhetőséget, és nem kell új konstruktort létrehoznunk az Anonymizer osztályban mindig amikor újonnan implementált algoritmust akarunk futtatni.

Mit jelent az, hogy a Strategy minta alkalmazásával az Open/Closed elv megvalósul a megoldásban? (az Open/Closed elvről az előadás és laboranyagban is olvashatsz).
    Azt jelenti, hogyha új algoritmust vagy progresst kell létrehoznunk, az Anonymizer osztályhoz egyáltalán nem kell hozzányúlnunk, elég létrehozni egy új osztályt, ami megvalósítja az IProgress vagy IAnonymizerAlgorithm interfacet, majd átadni egy ilyen objektumot az Anonymizer konstruktorában, és működik is.