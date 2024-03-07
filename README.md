---
author: Lektion 8
---

# Teams lektion 8

Hej och välkommen!

## Agenda

1. Svar på frågor
2. Repetition
3. Genomgång av övningar
4. Grupparbete

---

# Fråga

Hur hårdkodar man roller (e.g. `admin`)?

# Svar

Exempel lösning:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ...

        var app = builder.Build();

        // ...

        Task.Run(async () =>
        {
            await CreateRole(app.Services);
        });

        app.Run();
    }

    static async Task CreateRole(IServiceProvider provider)
    {
        var scope = provider.CreateScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        IdentityRole? existing = await roleManager.FindByNameAsync("testRole");
        if (existing == null)
        {
            await roleManager.CreateAsync(new IdentityRole("testRole"));
        }
    }
}  
```

---

# Fråga

I en video så används `var id = User.FindFirstValue(ClaimTypes.NameIdentifier)` för att koppla todos till användare. Hur vet den raden att den kopplar till rätt användare?

# Svar

Varje token sparar id:t på användaren, och det är det som refereras till med `NameIdentifier`. Genom id:t så hämtas själva användaren.
