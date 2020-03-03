using System;
using System.Collections.Generic;

namespace FinalRecordApp.Models
{
  public class Song
  {
    public int ID { get; set; }
    public string Title { get; set; }
    public bool Lyric { get; set; }
    public string Length { get; set; }
    public string Genre { get; set; }
    // nav to alb
    public int AlbumId { get; set; }
    public Album Album { get; set; }
  }
}