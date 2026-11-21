EVENTHUB - EF CORE CONSOLE APPLICATION

This solution implements the EventHub case study using:
- .NET 8 Console Application
- Entity Framework Core 8
- SQL Server / LocalDB
- Data Annotations
- Fluent API
- Separate IEntityTypeConfiguration classes
- OnModelCreating
- Shadow properties for internal event timestamps

ENTITY / CONFIGURATION TECHNIQUE
1. Organizer          -> Data Annotations
2. OrganizerProfile   -> Separate configuration class
3. Event              -> Separate configuration class
4. Attendee           -> Data Annotations
5. Badge              -> Separate configuration class
6. Registration       -> Separate configuration class

No entity mixes configuration techniques.

IMPORTANT RELATIONSHIPS
- Organizer 1 : 1 OrganizerProfile
- Organizer 1 : Many Events
- Event 1 : Many Sessions (self-referencing)
- Attendee 1 : 1 Badge
- Attendee Many : Many Events through Registration

INTERNAL EVENT TIMESTAMPS
Event.CreatedAt and Event.LastModifiedAt are shadow properties.
They are stored in the database but are NOT fields in the Event class.

DATABASE
Name: EventHubDb
Provider: SQL Server LocalDB

RUN
1. Open EventHub.csproj in Visual Studio.
2. Restore NuGet packages.
3. Ensure SQL Server LocalDB is installed.
4. Run the project.
5. The console displays "Database created successfully!".

Note:
The prompt says each entity should use the technique assigned in the session.
Because the exact classroom assignment was not included in the prompt, this project deliberately distributes the six entities across the three techniques while keeping each entity's configuration approach separate.
