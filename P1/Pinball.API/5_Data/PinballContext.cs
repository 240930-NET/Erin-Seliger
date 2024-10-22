using Microsoft.EntityFrameworkCore;
using Pinball.API.Model;

namespace Pinball.API.Data;

public partial class PinballContext : DbContext {

    public PinballContext(){}

    public PinballContext(DbContextOptions<PinballContext> options) : base(options){} 

    public virtual DbSet<Player> Players {get; set; }
}