using EventHub.Data;

using var context = new EventHubDbContext();

context.Database.EnsureCreated();

Console.WriteLine("================================");
Console.WriteLine("        EventHub Database        ");
Console.WriteLine("================================");
Console.WriteLine("Database created successfully!");
Console.WriteLine();
Console.WriteLine("Entities:");
Console.WriteLine("- Organizers");
Console.WriteLine("- OrganizerProfiles");
Console.WriteLine("- Events");
Console.WriteLine("- Attendees");
Console.WriteLine("- Badges");
Console.WriteLine("- Registrations");
Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
