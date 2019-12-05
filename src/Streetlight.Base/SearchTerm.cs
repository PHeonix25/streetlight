using System;

namespace Streetlight.Base
{

    internal class SearchTerm
    {
        private static Random _r = new Random();

        private static string[] _Verbs = new[] {
            // from Richard Serra's "Verb List Compilation: Actions to Relate to Oneself" [1967-1968]
            "roll","crease","fold","store","bend","shorten","twist","dapple","crumple",
            "shave","tear","chip","split","cut","sever","drop","remove","simplify","differ",
            "disarrange","open","mix","splash","knot","spill","droop","flow","curve","lift",
            "inlay","impress","fire","flood","smear","rotate","swirl","support","hook","suspend",
            "spread","hang","collect","tension","gravity","entropy","nature","grouping",
            "layering","felting","grasp","tighten","bundle","heap","gather","scatter","arrange",
            "repair","discard","pair","distribute","surfeit","compliment","enclose","surround",
            "encircle","hole","cover","wrap","dig","tie","bind","weave","join","match","laminate",
            "bond","hinge","mark","expand","dilute","light","modulate","distill","waves",
            "electromagnetic","inertia","ionization","polarization","refraction","tides","reflection",
            "equilibrium","symmetry","friction","stretch","bounce","erase","spray","systematize",
            "refer","force","mapping","location","context","time","cabonization","continue"};

        // private static string[] _Nato = new[] {
        //     "alfa","bravo","charlie","delta","echo","foxtrot","golf","hotel","india","juliet",
        //     "kilo","lima","mike","november","oscar","papa","quebec","romeo","sierra","tango",
        //     "uniform","victor","whiskey","x-ray","yankee","zulu"};

        public static string GetNext(bool _) => $"{_Verbs[_r.Next(0, _Verbs.Length - 1)]}"; // {_Nato[_r.Next(0, _Nato.Length - 1)]}";
    }
}