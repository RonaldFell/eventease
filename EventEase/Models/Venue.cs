using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Models;

// Represents venue table in EventEase Db 
public partial class Venue
{
    [Key]
    public int VenueId { get; set; } 

    [StringLength(100)]
    [Unicode(false)]
    public string VenueName { get; set; } = null!; 

    [StringLength(255)]
    [Unicode(false)]
    public string Location { get; set; } = null!; 

    public int Capacity { get; set; } 

    [Column(TypeName = "text")]
    public string ImageUrl { get; set; } = null!; 

    [InverseProperty("Venue")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>(); 
}
