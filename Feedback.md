## UVID U PROJEKT

## Uvod
* Dokumentacija vašeg programskog proizvoda je jedna od boljih dokumentacija ove akademske godine. Ima tu puno mjesta za pohvalu, pa vas molim da to uzmete u obzir. Svaka čast.
* Ispod navodim par mogućnosti za poboljšanje dokumentacije i aplikacije. Šteta što ste kontinuirat koji ste imali u radu prekinuli jer bi do sada vjerojatno većina aplikacije bila implementirana i riješena.

## Projektna dokumentacija
* Nije bilo obvezno raditi projektnu dokumentaciju za timove koji su u suradnji s industrijom. Međutim primijetim interesantan gantogram, pa ako mi možete javiti u kojem alatu je napravljen?


## Tehnička dokumentacija
* Struktura dokumentacije za pohvalu.
* Urednost i ujednačenost za pohvalu.
* SRS, SDS, ERA, KLASE - Detaljno i jasno definirani. Drago mi je što ste koristili predloške poglavlja.
* U navigaciji izmijenite naziv poglavlja (stranice) Tehnička dokumentacija U Korisnička dokumentacija. Pretpostavljam da vam je jasno da su poglavlja prikazana iznad ovoga poglavlja zapravo tehnička dokumentacija. 
* Nedostaje poglavlje o integraciji i točkama spajanja vaše aplikacije i ostalih timova. Također dodajte osvrt na dokumente koji se u tom procesu razmjenjuju ili kreiraju. 
* U dokumentaciju dodati poglavlje s uputama za podešavanje razvojne i produkcijske okoline te s podacima o testiranju programa (npr. korisnička imena i lozinke).

## Implementacija
* Verzioniranje - Vjerojatno najlošija karika vašeg projekta. Molim vas da više ne dodajete verzije u obliku "files via upload" već da uz pomoć odgovarajuće alata (npr. Source Tree) vršite proces pripreme i slanja novih verzija. Ako je potrebno prisjetite se vježbi koje smo imali na tu temu. Isto tako, molim vas da pokušate primijeniti feature-branch workflow koji je opisan ovdje: https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow.
* Repozitorij je zaprljan (verzioniraju se neke datoteke koje ne treba verzionirati), a osim toga nema dobro definiran .gitignore. Nakon prevođenja (compile) i pokretanja projekta u VS-u, bez ikakvih izmjena dokumenata, repozitorij bi trebao ostati čist.
* Programski kod - U redu. Ima još prostora za doradu i čišćenje.
* Implementirane funkcionalnosti - Zadovoljan sam s ukupnom razinom implementacije. Međutim navodim i nekoliko mogućih poboljšanja: pokušajte aplikaciju pretvoriti u MDI aplikaciju (Multiple Documents Interface). Forme bi se u tom slučaju otvarale u full screen modu te bi vam omogućile bolje iskorištenje prostora. Ovaj pristup će vam učiniti puno lakše spajanje rezultata vašeg i ostalih timova. Isto tako predlažem uklanjanje poruka korisniku pomoću MessageBox-a i zamjenu istih nekim modernijim načinom prikaza notifikacija korisniku (balloons, trey notifications, notification regions with hidable objects etc.). Posebno važno je odmah od početka zaboraviti na korištenje baze koja je u dokumentu (vidim da vam je takva baza uključena u rješenje). Priroda vašeg projekta zahtjeva spajanje više pokrenutih aplikacija na istu bazu podataka što se može postići samo pomoću smještanja baze na server. Za kraj primijetim da pomoć planirate prikazivati kao poziv PDF dokumenta. Puno jednostavniji pristup je izrada chm dokumenta te korištenje već postojeće Help klase u samom C#.

## Ostalo
* U dokumentaciji bi bilo dobro složiti da se klikom na sliku ista slika otvori u full screen prikazu.
* Pazite na minimalne zahtjeve za programske proizvode prije nego što pristupite obrani (npr. izdvajanje jednog dijela projekta u dll).

## Bodovi
P1: 15 bodova

---
