---
marp: true
theme: uncover
---

# Kurs Web API og CRUD

---
### Web API 

* HTTP grensesnitt mot en webserver
* REST: Retningslinjer for implementasjon av web API som behandler data

---
### REST
* Klient og server lever uavhengige liv
* Stateless. Server lagrer ikke klientens "state"
* GET requester kan caches.
* Lagvis system. Klienten må ikke ta hensyn til hvor data kommer fra
---
### REST
* APIet er uniformt. Kun en URI brukes per ressurs
    * Dette løser vi med CRUD

---
### CRUD
De fire operasjonene en tjeneste trenger for å behandle et sett med data.
Bruker HTTP verb for å unngå flere endepunkter

---
### CRUD
CREATE -> POST
READ -> GET
UPDATE -> PUT
DELETE -> DELETE
