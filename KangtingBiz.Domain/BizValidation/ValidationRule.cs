using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.BizValidation
{
    public class ValidationRule       
    {
        private string _ruleMessage; 
        public ValidationRule(string ruleMessage)
        {
            _ruleMessage = ruleMessage; 
        }
        public string RuleMessage
        {
            get { return _ruleMessage; }
        }

    }
}
