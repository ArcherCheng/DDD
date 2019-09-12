using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.BizValidation
{
    public class Validation        
    {
        private List<ValidationRule> _validationRule = 
            new List<ValidationRule>(); 

        public IEnumerable<ValidationRule> GetRules()
        {
            return _validationRule; 
        }
        public void AddRule(ValidationRule rule)
        {
            _validationRule.Add(rule);
        }
    }
}
