using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SupportTeamHotline.Models
{
    public partial class SupportTicket
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            //
            if (String.IsNullOrEmpty(TicketCreator))
                yield return new RuleViolation("Support Team Member Name required", "Ticket Creator");

            if (String.IsNullOrEmpty(TicketType))
                yield return new RuleViolation("Support Ticket Type field is required", "Ticket Type");

            if (String.IsNullOrEmpty(TicketStatus))
                yield return new RuleViolation("Support Ticket Status is required", "Ticket Status");
            if (!PhoneValidator.IsValidNumber(CallerPhone1))
                yield return new RuleViolation("Phone Number entered is incorrect", "Caller Phone");


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

    public class PhoneValidator
    {
        static IDictionary<string, Regex> countryRegex = new Dictionary<string, Regex>()
        {
            { "USA", new Regex("^[2-9]\\d{2}-\\d{3}-\\d{4}$") }
        };

        public static bool IsValidNumber(string phoneNumber)
        {
            if (phoneNumber != null && countryRegex.ContainsKey(phoneNumber))
                return countryRegex[phoneNumber].IsMatch(phoneNumber);
            else
                return false;
        }

        public static IEnumerable<string> Countries
        {
            get
            {
                return countryRegex.Keys;
            }
        }
    }
}