using System;
using System.Collections.Generic;

namespace DemoASPNETCoreMVC.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
