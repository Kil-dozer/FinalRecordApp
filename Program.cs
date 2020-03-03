using System;
using FinalRecordApp.Models;
using System.Linq;

namespace FinalRecordApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new DatabaseContext();
      var finder = new RecordMaster();
      var isRunning = true;
      Console.WriteLine("Welcome to the record store!");
      // Options
      while (isRunning == true)
      {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("(BAND) View all albums by one band.");
        Console.WriteLine("(ALBUMS) View all albums in store, by release date.");
        Console.WriteLine("(SIGN) Sign a band and add to store.");
        Console.WriteLine("(MODALBUM) Add songs to an album.");
        Console.WriteLine("(RESIGN) Resign a band.");
        Console.WriteLine("(ADDALBUM) Add an album and songs to the records.");
        Console.WriteLine("(REMOVE) Remove a band.");
        Console.WriteLine("(NOTSIGNED) View all bands that are not signed.");
        Console.WriteLine("(ROSTER) View all signed bands.");
        var input = Console.ReadLine().ToLower();
        // Method calls
        if (input == "band")
        {
          finder.ViewBandHits();
        }

        if (input == "albums")
        {
          finder.ViewByAlbum();
        }

        if (input == "sign")
        {
          finder.SignABand();
        }

        if (input == "modalbum")
        {
          finder.ChangeThatAlbum();
        }

        if (input == "resign")
        {
          finder.ResignSomeLuckyBoys();
        }

        if (input == "addalbum")
        {
          finder.SignMoreSongs();
        }

        if (input == "remove")
        {
          finder.CanEm();
        }

        if (input == "notsigned")
        {
          finder.NoHandcock();
        }
        if (input == "roster")
        {
          finder.SoundOfMusic();
        }
        if (input == "quit")
        {
          Console.WriteLine("Goodbye!");
          isRunning = false;
          Console.ReadLine();
        }

      }
    }
  }
}
