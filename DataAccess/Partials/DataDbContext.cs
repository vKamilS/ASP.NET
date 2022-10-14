﻿using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IDataDbContext
    {
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<User> Users { get; set; }
    }
    
    public partial class DataDbContext : IDataDbContext
    {
    
    }
}
