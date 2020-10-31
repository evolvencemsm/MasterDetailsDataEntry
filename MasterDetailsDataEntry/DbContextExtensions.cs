﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace MasterDetailsDataEntry
{
    public static class DbContextExtensions
    {
        public static IQueryable FindSet(this DbContext db, Type entityType)
        {
            MethodInfo method = typeof(DbContext).GetMethod("Set");
            MethodInfo generic = method.MakeGenericMethod(entityType);
            IQueryable queryable = ((IQueryable)generic.Invoke(db, null)).Cast(entityType);
            return queryable;
        }
    }
}