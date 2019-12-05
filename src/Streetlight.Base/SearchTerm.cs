using System;

namespace Streetlight.Base
{

    internal class SearchTerm
    {
        private static Random _r = new Random();

        private static string[] _Verbs = new[] {
            // from Richard Serra's "Verb List Compilation: Actions to Relate to Oneself" [1967-1968], then alphabetised
            "arrange","bend","bind","bond","bounce","bundle","chip","collect","compliment","context","continue","cover",
            "crease","crumple","curve","cut","dapple","differ","dig","dilute","disarrange","discard","distill","distribute",
            "droop","drop","electromagnetic","encircle","enclose","entropy","equilibrium","erase","expand","felting","fire",
            "flood","flow","fold","force","friction","gather","grasp","gravity","grouping","hang","heap","hinge","hole",
            "hook","impress","inertia","inlay","ionization","join","knot","laminate","layering","lift","light","location",
            "mapping","mark","match","mix","modulate","nature","open","pair","polarization","refer","reflection","refraction",
            "remove","repair","roll","rotate","scatter","sever","shave","shorten","simplify","smear","spill","splash","split",
            "spray","spread","store","stretch","support","surfeit","surround","suspend","swirl","symmetry","systematize",
            "tear","tension","tides","tie","tighten","time","twist","waves","weave","wrap"};

        private static string[] _Nato = new[] {
            "alfa","bravo","charlie","delta","echo","foxtrot","golf","hotel","india","juliet",
            "kilo","lima","mike","november","oscar","papa","quebec","romeo","sierra","tango",
            "uniform","victor","whiskey","x-ray","yankee","zulu"};

        public static string GetNext(bool _) => $"{_Verbs[_r.Next(0, _Verbs.Length - 1)]}"; // {_Nato[_r.Next(0, _Nato.Length - 1)]}";
    }
}