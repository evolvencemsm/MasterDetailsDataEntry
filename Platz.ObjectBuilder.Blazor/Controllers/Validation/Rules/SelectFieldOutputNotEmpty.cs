﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platz.ObjectBuilder.Blazor.Controllers.Validation.Rules
{
    public class SelectFieldOutputNotEmpty : IObjectBuilderRule
    {
        public RuleValidationResult Validate(IQueryModel qm)
        {
            if (!qm.SelectionProperties.Where(prop => prop.IsOutput).Any())
            {
                return new RuleValidationResult("Select clause should contain at list one output property");
            }

            return null;
        }
    }
}
