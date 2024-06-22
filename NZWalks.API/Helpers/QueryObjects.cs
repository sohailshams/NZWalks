﻿namespace NZWalks.API.Helpers;

public class QueryObjects
{
    public string? searchString { get; set; } = null;
    public string? sortBy { get; set; } = null;
    public bool isAscending { get; set; } = true;
}
