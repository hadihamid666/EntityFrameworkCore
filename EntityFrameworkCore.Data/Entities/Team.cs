﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Data.Entities;

public partial class Team
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int LeagueId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    public virtual League League { get; set; } = null!;

    public virtual ICollection<Match> MatchAwayTeams { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchHomeTeams { get; set; } = new List<Match>();
}
