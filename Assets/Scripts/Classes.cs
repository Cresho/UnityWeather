using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class coord
{
    public double lon;
    public double lat;
}

[Serializable]
public class weather
{
    public int id;
    public string main;
    public string description;
    public string icon;
}


[Serializable]
public class main
{
    public double temp;
    public double feels_like;
    public double temp_min;
    public double temp_max;
    public int pressure;
    public int humidity;
    public int sea_level;
    public int grnd_level;
}

[Serializable]
public class wind
{
    public double speed;
    public int deg;
    public double gust;
}

[Serializable]
public class clouds
{
    public int all;
}

[Serializable]
public class sys
{
    public int type;
    public int id;
    public string country;
    public int sunrise;
    public int sunset;
}

[Serializable]
public class Result
{
    public coord coord;
    public List<weather> weather;
    public main main;
    public int visibility;
    public wind wind;
    public clouds clouds;
    public int dt;
    public sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}
