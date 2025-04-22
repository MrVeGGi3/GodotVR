using Godot;
using System;
using System.Collections.Generic;

public partial class RoletaCategoria : Control
{
    private static Marker2D surpriseMarker;
    private static Marker2D historyMarker;
    private static Marker2D scienceMarker;
    private static Marker2D sportsMarker;
    private static Marker2D entertainmentMarker;
    private static Marker2D languagesMarker;
    private static Marker2D geographyMarker;
    private static Marker2D artsMarker;


    public List <Marker2D> markers = new List<Marker2D>();
    

    public override void _Ready() 
    {
        base._Ready();
        surpriseMarker = GetNode<Marker2D>("RoulleteMarker/SurpriseCategory");
        historyMarker = GetNode<Marker2D>("RoulleteMarker/HistoryCategory");
        scienceMarker = GetNode<Marker2D>("RoulleteMarker/ScienceCategory");
        sportsMarker = GetNode<Marker2D>("RoulleteMarker/SportsCategory");
        entertainmentMarker = GetNode<Marker2D>("RoulleteMarker/EntertainmentCategory");
        languagesMarker = GetNode<Marker2D>("RoulleteMarker/LanguagesCategory");
        geographyMarker = GetNode<Marker2D>("RoulleteMarker/GeographyCategory");
        artsMarker = GetNode<Marker2D>("RoulleteMarker/ArtsCategory");
        
        markers.AddRange(new[] {surpriseMarker, historyMarker, scienceMarker, sportsMarker,
        entertainmentMarker, languagesMarker, geographyMarker, artsMarker});
        
    }

}
