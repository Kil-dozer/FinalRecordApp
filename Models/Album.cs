using System;
using System.Collections.Generic;

namespace FinalRecordApp.Models
{
  public class Album
  {
    public int ID { get; set; }
    public string Title { get; set; }
    public bool IsExplicit { get; set; }
    public DateTime ReleaseDate { get; set; }

    // Nav props
    public int BandId { get; set; }
    public Band Band { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();

  }
}
