# ReservationSystem


## How to run
In the project main folder:

    dotnet ef migrations add InitialCreate --project ReservationSystem.RoomManagement.Data.SQLite --startup-project ReservationSystem

    dotnet ef database update --project ReservationSystem.RoomManagement.Data.SQLite --startup-project ReservationSystem

## Patterns

Clean and segregated concerns.
REPR Pattern on APIs
Minimal APIs
Easy to change data source
Easy to change email service
**All projects except ReservationSystem are made to be used as NuGet packages so that they are easily replaceable by teams**


## TODOs

I have very little frontend experience so I had no time to do that task.
I lack unit tests on all the projects

## Pains

Spent a lot of time with an exotic error on SQLite migrations. (its fixed now)
