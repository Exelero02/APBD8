using APBD8.Models;
using Microsoft.EntityFrameworkCore;


public class MyDbContext : DbContext
{
    public MyDbContext(DbSet<Client> clients, DbSet<Country?> countries, DbSet<Trip> trips, DbSet<ClientTrip> clientTrips, DbSet<CountryTrip> countryTrips) : base()
    {
        Clients = clients;
        Countries = countries;
        Trips = trips;
        ClientTrips = clientTrips;
        CountryTrips = countryTrips;
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Country?> Countries { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<ClientTrip> ClientTrips { get; set; }
    public DbSet<CountryTrip> CountryTrips { get; set; }
        
}