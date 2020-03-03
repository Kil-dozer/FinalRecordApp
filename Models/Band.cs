using System;
using System.Collections.Generic;

namespace FinalRecordApp.Models
{
  public class Band
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string CountyOfOrigin { get; set; }
    public int NumberOfBandMembers { get; set; }
    public string Website { get; set; }
    public bool IsSigned { get; set; }
    public string PersonOfContact { get; set; }
    public string ContactNumber { get; set; }


    // Nav prop
    public List<Album> Albums { get; set; } = new List<Album>();

    // Try for key
    // public int BandID { get; set; }

  }
}