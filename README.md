Progetto: CORSI DI FORMAZIONE
Realizzato da:
- Eleonora Carbini; matricola 118300
- Antonio Avola; matricola 118596

**************************************************************************************************************************************

Istruzioni per il dump del database:
Il file è presente all'interno della repository git, avente nominazione "dump".
Una volta avviato SQL Server Management Studio e stabilita la connessione con il proprio server:
- Nella sezione "Database" creare un database avente nome "CorsiFormazione"
- Nella sezione "Sicurezza" --> "Account di accesso" creare un utente con le seguenti caratteristiche:
	- nome account accesso: "eleonoraCarb"
	- Autenticazione SQL Server
		- password: paradigmi2024
	- database predefinito: selezionare il database "CorsiFormazione"
	- nella sezione di "Mapping utente":
		- selezionare "CorsiFormazione"
		- tra i ruoli selezionare db_owner e public
Una volta aggiunti Database e Utente, aprire il file dump tramite la sequenza:
File -> Apri -> File -> selezionare file "dump.sql"

Infine eseguire il file del dump.

**************************************************************************************************************************************

Istruzioni codice:

INFORMAZIONI PRELIMINARI:
	Prima di eseguire il codice, nel progetto CorsiFormazione.Web modificare il file "appsettings.json" :
	"ConnectionString" -> "MyDbContext" nella parte di stringa relativa al "Data Source" inserire il nome del Server su cui si è eseguito
	il ripristino del dump.

All'inizio il progetto si presenta con un database privo di record. 
Per poter utilizzare le API per i Corsi e le Presenze, è necessaria la creazione di un utente e poi la successiva autenticazione
utilizzando email e password per ottenere il token, da usare per l'autenticazione Bearer.
Da notare che quando viene creato un corso, questo non presenta lezioni.
Dopo la creazione del corso, le lezioni possono essere aggiunte in qualsiasi momento. 
