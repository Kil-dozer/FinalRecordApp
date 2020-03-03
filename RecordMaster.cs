using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalRecordApp.Models
{
  public class RecordMaster
  {
    public void ViewBandHits()
    {
      var db = new DatabaseContext();
      var allBands = db.Bands.OrderBy(b => b.Name);
      Console.WriteLine("We have records of the following bands. Please select by integer.");
      foreach (var band in allBands)
      {
        Console.WriteLine($"{band.ID}, Band: {band.Name}");
      }
      Console.WriteLine("Which band's albums would you like to see?");
      var wantedArtest = int.Parse(Console.ReadLine());
      var tunesToList = db.Albums.FirstOrDefault(b => b.BandId == wantedArtest);
      // foreach (var a in wantedArtest)
      // {
      //   Console.WriteLine($"Album name: {a.Title}");
      // }
    }
    public void ViewByAlbum()
    {
      var db = new DatabaseContext();
      var allAlbums = db.Albums.OrderBy(a => a.ReleaseDate);
      foreach (var a in allAlbums)
      {
        Console.WriteLine($"Album: {a.Title}, released on {a.ReleaseDate}");
      }
    }
    public void SignABand()
    {
      var db = new DatabaseContext();
      // "adding a band"
      Console.WriteLine("What is the name of the band you want to sign?");
      var nBand = Console.ReadLine();
      Console.WriteLine($"What country is {nBand} from?");
      var whereFrom = Console.ReadLine();
      Console.WriteLine($"How many band members are in {nBand}? Please use an integer.");
      var birdNum = int.Parse(Console.ReadLine());
      // Need failsafe
      Console.WriteLine($"What is {nBand}'s website?");
      var interweb = Console.ReadLine();
      var onPaper = true;
      Console.WriteLine($"Who is the contact person for this band?");
      var point = Console.ReadLine();
      Console.WriteLine($"What is {point}'s number?");
      var digits = Console.ReadLine();

      var hipBand = new Band
      {
        Name = nBand,
        CountyOfOrigin = whereFrom,
        NumberOfBandMembers = birdNum,
        Website = interweb,
        IsSigned = onPaper,
        PersonOfContact = point,
        ContactNumber = digits,
      };
      Console.WriteLine($"We added {nBand} to our records.");
      db.Bands.Add(hipBand);
      db.SaveChanges();
    }
    public void ChangeThatAlbum()
    {
      var db = new DatabaseContext();
      Console.WriteLine("placeholder");
    }
    public void ResignSomeLuckyBoys()
    {
      var db = new DatabaseContext();
      var notContracted = db.Bands.Where(c => c.IsSigned == false);
      Console.WriteLine("Which band would you like to resign?");
      foreach (var b in notContracted)
      {
        Console.WriteLine($"{b.ID} {b.Name}");
      }
      var input = Console.ReadLine();
      var luckyBoys = db.Bands.First(n => n.Name == input);
      luckyBoys.IsSigned = true;
      db.SaveChanges();
    }
    public void SignMoreSongs()
    {
      var db = new DatabaseContext();
      var rockOn = true;
      while (rockOn)
      {
        var swears = true;
        Console.WriteLine("What is the name of this album?");
        var cD = Console.ReadLine();
        Console.WriteLine($"Does {cD} have explicit lyrics? (YES) or (NO)");
        var isSpicey = Console.ReadLine().ToLower();
        int catcher = 0;
        while (catcher == 0)
        {

          if (isSpicey == "yes")
          {
            Console.WriteLine($"{cD} has been labeled as explicit.");
            catcher++;
          }
          else if (isSpicey == "no")
          {
            Console.WriteLine($"{cD} has been labeled as non-explicit.");
            swears = false;
            catcher++;
          }
          else
          {
            Console.WriteLine("I'm sorry, that input is not valid. Please try again.");
          }
        }
        Console.WriteLine($"What band produced {cD}? Please use an int.");
        var bands = db.Bands.OrderBy(b => b.Name);
        foreach (var b in bands)
        {
          Console.WriteLine($"{b.Name} exists in our records ");
        }
        int popularBand = int.Parse(Console.ReadLine().ToLower());
        var whoSungIt = db.Bands.FirstOrDefault(b => b.ID == popularBand);
        // var whoSungIt = db.Bands.FirstOrDefault(b => b.Name == popularBand);
        // alb nav
        // var albNav = db.Albums.Where(al => al.ID == );


        // if (popularBand == null)
        // {
        //   Console.WriteLine($"I'm sorry, {whoSungIt} is not in the database. Please try again.");
        // }
        // var popularBandId = int.Parse(Console.ReadLine());
        // int navToband = db.Bands.First(b => b.ID == popularBand);


        //       Console.WriteLine("Which band's albums would you like to see?");
        // var wantedArtest = Console.ReadLine();
        // var tunesToList = db.Albums.Where(b => b.BandId == wantedArtest);




        // var alNavID = db.Albums.FirstOrDefault(band => band.Name);
        // var albNav = db.Albums.FirstOrDefault(band => band.Name == whoSungIt)

        // var tunesToList = db.Albums.Where(b => b.BandId == wantedArtest);
        Console.WriteLine($"What year was {cD} released? Please use an integer.");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine($"What month was {cD} released? Please use an integer.");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine($"What day was {cD} released? Please use an integer.");
        int day = int.Parse(Console.ReadLine());
        var whenRelease = new DateTime(year, month, day);

        var albumToAdd = new Album()
        {
          Title = cD,
          // fix needed
          IsExplicit = swears,
          ReleaseDate = whenRelease,
          BandId = popularBand,
          // BandId = navToband,





          // Band = whoSungIt,
        };
        Console.WriteLine("How many songs are on this album?");
        var howMany = int.Parse(Console.ReadLine());
        for (int i = 0; i < howMany; i++)
        {
          Console.WriteLine("What is the name of the song?");
          var chirps = Console.ReadLine();
          Console.WriteLine($"How long is {chirps}, in minutes? Please enter an integer.");
          var mins = Console.ReadLine();
          Console.WriteLine("What genre does this belong to?");
          var type = Console.ReadLine();
          bool hasWords = true;
          Console.WriteLine($"Does {chirps} have lyrics? (YES) or (NO)");
          var q = Console.ReadLine().ToLower();
          while (catcher == 1)
          {

            if (q == "yes")
            {
              Console.WriteLine($"{cD} has been labeled as having lyrics.");
              catcher++;
            }
            else if (q == "no")
            {
              Console.WriteLine($"{cD} is a song with no lyrics.");
              hasWords = false;
              catcher++;
            }
            else
            {
              Console.WriteLine("I'm sorry, that input is not valid. Please try again.");
            }
          }
          // var songNav = db.Albums.Where(al => al.ID == albumToAdd.AlbumId);
          // // find the album
          // var albNav = db.Albums.First(a => a.ID == albumID);






          var song = new Song()
          {
            Title = chirps,
            Lyric = hasWords,
            Length = mins,
            Genre = type,
            // Find the album

            // Album = songNav,

          };
          db.Songs.Add(song);
        }
        Console.WriteLine($"We've added {howMany} songs to {whoSungIt}");

        rockOn = false;
      }
    }
    public void CanEm()
    {
      var db = new DatabaseContext();
      Console.WriteLine("Which band would you like to remove from the roster?");
      var input = Console.ReadLine();
      var cannedBoys = db.Bands.First(n => n.Name == input);
      if (cannedBoys == null)
      {
        Console.WriteLine($"{cannedBoys} are not currently on the roster.");
      }
      else
      {
        cannedBoys.IsSigned = false;
        Console.WriteLine($"{cannedBoys} have been removed from the roster.");
      }
      db.SaveChanges();

    }
    public void NoHandcock()
    {
      var db = new DatabaseContext();
      var notContracted = db.Bands.Where(c => c.IsSigned == false);
      foreach (var b in notContracted)
      {
        Console.WriteLine($"{notContracted} is not under contract.");
      }
    }
    public void SoundOfMusic()
    {
      var db = new DatabaseContext();
      var signedBands = db.Bands.Where(band => band.IsSigned == true);
      foreach (var band in signedBands)
        Console.WriteLine($"{signedBands} is under contract.");
    }
    // Prevent user error
    // public static int LookForInt(string popularBand)
    // {
    //   var bandId = 0;
    //   var looking = true;
    //   while (looking)
    //   {
    //     var intBool = int.TryParse(popularBand, out bandId);
    //     if (intBool)
    //     {
    //       looking = false;
    //     }
    //     else
    //     {
    //       Console.WriteLine($"I'm sorry, there is no {popularBand} in the database. Please try again.");
    //       popularBand = Console.ReadLine();

    //     }
    //   }
    //   return bandId;

    // }



  }
}