using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace SupportTeamHotline.Models
{
    public partial class SupportTicket
    {
        public bool IsValid
        {
            get
            {
                return (GetRuleViolations().Count() == 0); 
            }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}